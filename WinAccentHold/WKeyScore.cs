using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinAccentHold
{
    internal static class WKeyScore
    {
        const int Hook = 13, Down = 0x100, Up = 0x101, SysDown = 0x104, SysUp = 0x105, Injected = 0x10;
        static IntPtr hook; static HookProc proc; static Control owner; static AccentDB db; static Pending pending;
        public static event Action<string, bool> TriggerKeyChanged;
        const int delay = 600;

        public static void Start(Control uiOwner)
        {
            if (hook != IntPtr.Zero) return;
            owner = uiOwner; db = new AccentDB(); proc = Callback;
            using (Process p = Process.GetCurrentProcess()) using (ProcessModule m = p.MainModule) hook = SetWindowsHookEx(Hook, proc, GetModuleHandle(m.ModuleName), 0);
        }

        public static void Stop()
        {
            if (pending != null) { pending.Timer.Dispose(); pending = null; }
            if (hook != IntPtr.Zero) UnhookWindowsHookEx(hook);
            hook = IntPtr.Zero; proc = null; owner = null;
        }

        static IntPtr Callback(int code, IntPtr message, IntPtr data)
        {
            if (code >= 0 && owner != null)
            {
                int msg = message.ToInt32();
                Kbd key = (Kbd)Marshal.PtrToStructure(data, typeof(Kbd));

                bool pressed = msg == Down || msg == SysDown;
                bool released = msg == Up || msg == SysUp;

                if ((pressed || released) && (key.flags & Injected) == 0 && pending != null && pending.Vk != key.vk)
                    CancelPending();

                // Suppress the auto-repeat generated while the trigger is held.
                if (pressed && (key.flags & Injected) == 0 && pending != null && pending.Vk == key.vk)
                    return (IntPtr)1;

                if (pressed && (key.flags & Injected) == 0 && pending == null && IsTrigger(key.vk))
                {
                    string letter = GetTriggerLabel(key.vk);
                    if (key.vk >= 'A' && key.vk <= 'Z')
                    {
                        bool shifted = (GetKeyState(0x10) & 0x8000) != 0;
                        bool capsLocked = (GetKeyState(0x14) & 1) != 0;
                        letter = (shifted ^ capsLocked) ? letter.ToUpperInvariant() : letter.ToLowerInvariant();
                    }
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

        static bool IsTrigger(uint vk) { string label = GetTriggerLabel(vk); return label != null && db.mainDB.ContainsKey(label.ToLowerInvariant()); }
        static string GetTriggerLabel(uint vk)
        {
            if (vk >= 'A' && vk <= 'Z') return ((char)vk).ToString();
            if (vk >= '0' && vk <= '9') return ((char)vk).ToString();
            if (vk == 0xBD) return "-";
            if (vk == 0xBB) return "=";
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
        [DllImport("user32.dll")] static extern IntPtr SetWindowsHookEx(int id, HookProc callback, IntPtr module, uint threadId);
        [DllImport("user32.dll")] static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll")] static extern IntPtr CallNextHookEx(IntPtr hook, int code, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)] static extern IntPtr GetModuleHandle(string moduleName);
        [DllImport("user32.dll")] static extern short GetKeyState(int key);
    }
}
