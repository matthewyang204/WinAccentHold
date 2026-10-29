using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace WinAccentHold
{
    internal static class WKeyScore
    {
        const int Hook = 13, Down = 0x100, Up = 0x101, SysDown = 0x104, SysUp = 0x105, Injected = 0x10, AltDown = 0x20;
        static IntPtr hook;
        static HookProc proc;
        static Control owner;
        static AccentDB db;
        static Pending pending;
        static bool altDown;
        public static event Action<string, bool> TriggerKeyChanged;
        const int delay = 600;

        public static void Start(Control uiOwner)
        {
            if (hook != IntPtr.Zero) return;
            owner = uiOwner; db = new AccentDB(); proc = Callback;
            using (Process p = Process.GetCurrentProcess()) using (ProcessModule m = p.MainModule) hook = SetWindowsHookEx(Hook, proc, GetModuleHandle(m.ModuleName), 0);

            if (hook == IntPtr.Zero)
            {
                int error = Marshal.GetLastWin32Error();
                proc = null;
                owner = null;
                db = null;

                DebugHelper.LogWin32Error("SetWindowsHookEx", error);
            }
        }

        public static void Stop()
        {
            CancelPending();
            
            if (pending != null) { pending.Timer.Dispose(); pending = null; }
            if (hook != IntPtr.Zero)
            {
                if (UnhookWindowsHookEx(hook))
                {
                    hook = IntPtr.Zero;
                    proc = null;
                }
                else
                {
                    DebugHelper.LogWin32Error("UnhookWindowsHookEx", Marshal.GetLastWin32Error());
                    return;
                }
            }
            owner = null;
            altDown = false;
        }

        static IntPtr Callback(int code, IntPtr message, IntPtr data)
        {
            if (code >= 0 && owner != null)
            {
                int msg = message.ToInt32();
                Kbd key = (Kbd)Marshal.PtrToStructure(data, typeof(Kbd));

                bool pressed = msg == Down || msg == SysDown;
                bool released = msg == Up || msg == SysUp;
                if (key.vk == 0x12 || key.vk == 0xA4 || key.vk == 0xA5)
                {
                    if (pressed) altDown = true;
                    if (released) altDown = false;
                }
                bool alt = altDown;

                if ((pressed || released) && (key.flags & Injected) == 0 && pending != null && pending.Vk != key.vk)
                    CancelPending();

                // Suppress the auto-repeat generated while the trigger is held.
                if (pressed && (key.flags & Injected) == 0 && pending != null && pending.Vk == key.vk)
                    return (IntPtr)1;

                if (pressed && (key.flags & Injected) == 0 && pending == null && IsTrigger(key.vk, alt))
                {
                    string letter = GetTriggerLabel(key.vk);
                    if (key.vk >= 'A' && key.vk <= 'Z')
                    {
                        bool shifted = (GetAsyncKeyState(0x10) & 0x8000) != 0;
                        bool capsLocked = (GetAsyncKeyState(0x14) & 1) != 0;
                        letter = (shifted ^ capsLocked) ? letter.ToUpperInvariant() : letter.ToLowerInvariant();
                    }
                    string altKey = letter.Length == 1 && letter[0] >= 'a' && letter[0] <= 'z'
                        ? letter.ToUpperInvariant()
                        : letter;
                    if (alt && db.altDB.ContainsKey(altKey)) letter = "ALT:" + altKey;
                    pending = new Pending(letter, key.vk);
                    owner.BeginInvoke((MethodInvoker)BeginTimer);
                    return CallNextHookEx(hook, code, message, data);
                }
                if (released && (key.flags & Injected) == 0 && pending != null && pending.Vk == key.vk)
                {
                    Pending done = pending;
                    pending = null;
                    if (done.Timer != null) done.Timer.Dispose();
                    return CallNextHookEx(hook, code, message, data);
                }
            }

            return CallNextHookEx(hook, code, message, data);
        }

        static bool IsTrigger(uint vk, bool alt)
        {
            string label = GetTriggerLabel(vk);
            if (label == null) return false;
            if (db.mainDB.ContainsKey(label.ToLowerInvariant())) return true;
            return alt && db.altDB.ContainsKey(label);
        }
        static string GetTriggerLabel(uint vk)
        {
            if (vk >= 'A' && vk <= 'Z') return ((char)vk).ToString();
            if (vk >= '0' && vk <= '9') return ((char)vk).ToString();
            if (vk == 0xBD) return "-";
            if (vk == 0xBB) return "=";
            if (vk == 0xC0) return "GRAVE";
            if (vk == 0xDB) return "[";
            if (vk == 0xDD) return "]";
            if (vk == 0xDC) return "\\";
            if (vk == 0xBA) return ";";
            if (vk == 0xDE) return "'";
            if (vk == 0xBC) return ",";
            if (vk == 0xBE) return ".";
            if (vk == 0xBF) return "/";
            if (vk == 0x20) return "SPACE";
            return null;
        }
        static void CancelPending() { if (pending == null) return; if (pending.Timer != null) { pending.Timer.Stop(); pending.Timer.Dispose(); } pending = null; }
        static void BeginTimer()
        {
            Pending current = pending;
            if (current == null) return;
            current.Timer = new Timer { Interval = delay };
            current.Timer.Tick += delegate
            {
                if (pending != current) { current.Timer.Stop(); current.Timer.Dispose(); return; }
                current.Timer.Stop(); current.Held = true;
                if (TriggerKeyChanged != null) TriggerKeyChanged(current.Letter, true);
            };
            current.Timer.Start();
        }
        sealed class Pending { public string Letter; public uint Vk; public bool Held; public Timer Timer; public Pending(string l, uint v) { Letter = l; Vk = v; } }
        delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)] struct Kbd { public uint vk, scan, flags, time; public IntPtr extra; }
        [DllImport("user32.dll", SetLastError=true)] static extern IntPtr SetWindowsHookEx(int id, HookProc callback, IntPtr module, uint threadId);
        [DllImport("user32.dll", SetLastError=true)] static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll")] static extern IntPtr CallNextHookEx(IntPtr hook, int code, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)] static extern IntPtr GetModuleHandle(string moduleName);
        [DllImport("user32.dll")] static extern short GetKeyState(int key);
        [DllImport("user32.dll")] static extern short GetAsyncKeyState(int key);
    }
}
