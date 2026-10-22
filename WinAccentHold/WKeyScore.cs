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

                // Suppress the auto-repeat generated while the trigger is held.
                if (pressed && (key.flags & Injected) == 0 && pending != null && pending.Vk == key.vk)
                    return (IntPtr)1;

                if (pressed && (key.flags & Injected) == 0 && pending == null && IsTrigger(key.vk))
                {
                    string letter = ((char)key.vk).ToString().ToLowerInvariant();
                    owner.BeginInvoke((MethodInvoker)delegate { Begin(letter, key.vk); });
                    return (IntPtr)1;
                }
                if (released && (key.flags & Injected) == 0 && pending != null && pending.Vk == key.vk)
                {
                    owner.BeginInvoke((MethodInvoker)Finish);
                    return (IntPtr)1; // Suppress this key event
                }
            }

            return CallNextHookEx(hook, code, message, data);
        }

        static bool IsTrigger(uint vk) { return vk >= 'A' && vk <= 'Z' && db.mainDB.ContainsKey(((char)vk).ToString().ToLowerInvariant()); }
        static void Begin(string letter, uint vk) { pending = new Pending(letter, vk); pending.Timer = new Timer { Interval = delay }; pending.Timer.Tick += delegate { pending.Timer.Stop(); pending.Held = true; if (TriggerKeyChanged != null) TriggerKeyChanged(pending.Letter, true); }; pending.Timer.Start(); }
        static void Finish() { if (pending == null) return; Pending done = pending; pending = null; done.Timer.Dispose(); if (!done.Held) SendKey(done.Vk); if (TriggerKeyChanged != null) TriggerKeyChanged(done.Letter, false); }
        static void SendKey(uint vk) { keybd_event((byte)vk, 0, 0, UIntPtr.Zero); keybd_event((byte)vk, 0, 2, UIntPtr.Zero); }
        sealed class Pending { public string Letter; public uint Vk; public bool Held; public Timer Timer; public Pending(string l, uint v) { Letter = l; Vk = v; } }
        delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)] struct Kbd { public uint vk, scan, flags, time; public IntPtr extra; }
        [DllImport("user32.dll")] static extern IntPtr SetWindowsHookEx(int id, HookProc callback, IntPtr module, uint threadId);
        [DllImport("user32.dll")] static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll")] static extern IntPtr CallNextHookEx(IntPtr hook, int code, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)] static extern IntPtr GetModuleHandle(string moduleName);
        [DllImport("user32.dll")] static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, UIntPtr extraInfo);
    }
}
