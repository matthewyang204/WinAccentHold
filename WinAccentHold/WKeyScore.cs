using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinAccentHold
{
    internal static class WKeyScore
    {
        const int Hook = 13, Down = 0x100, Up = 0x101, SysDown = 0x104, SysUp = 0x105, Injected = 0x10;
        static IntPtr hook; static HookProc proc; static Control owner; static AccentDB db;
        public static event Action<string, bool> TriggerKeyChanged;

        public static void Start(Control uiOwner)
        {
            if (hook != IntPtr.Zero) return;
            owner = uiOwner; db = new AccentDB(); proc = Callback;
            using (Process p = Process.GetCurrentProcess()) using (ProcessModule m = p.MainModule) hook = SetWindowsHookEx(Hook, proc, GetModuleHandle(m.ModuleName), 0);
        }

        public static void Stop()
        {
            if (hook != IntPtr.Zero) UnhookWindowsHookEx(hook);
            hook = IntPtr.Zero; proc = null; owner = null;
        }

        static IntPtr Callback(int code, IntPtr message, IntPtr data)
        {
            if (code >= 0 && owner != null)
            {
                int msg = message.ToInt32(); Kbd key = (Kbd)Marshal.PtrToStructure(data, typeof(Kbd));
                bool pressed = msg == Down || msg == SysDown, released = msg == Up || msg == SysUp;
                if ((pressed || released) && (key.flags & Injected) == 0 && IsTrigger(key.vk))
                {
                    string letter = ((char)key.vk).ToString().ToLowerInvariant();
                    owner.BeginInvoke((MethodInvoker)delegate { if (TriggerKeyChanged != null) TriggerKeyChanged(letter, pressed); });
                }
            }
            return CallNextHookEx(hook, code, message, data);
        }

        static bool IsTrigger(uint vk) { return vk >= 'A' && vk <= 'Z' && db.mainDB.ContainsKey(((char)vk).ToString().ToLowerInvariant()); }
        delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)] struct Kbd { public uint vk, scan, flags, time; public IntPtr extra; }
        [DllImport("user32.dll")] static extern IntPtr SetWindowsHookEx(int id, HookProc callback, IntPtr module, uint threadId);
        [DllImport("user32.dll")] static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll")] static extern IntPtr CallNextHookEx(IntPtr hook, int code, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)] static extern IntPtr GetModuleHandle(string moduleName);
    }
}
