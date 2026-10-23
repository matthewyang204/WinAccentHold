using System;
using System.Runtime.InteropServices;

namespace WinAccentHold
{
    internal static class DPIHelper
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(int value);

        [DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(IntPtr value);

        private static readonly IntPtr PerMonitorAwareV2 = new IntPtr(-4);

        public static void EnableDPIAwareness()
        {
            try
            {
                if (Environment.OSVersion.Version.Major >= 10)
                    SetProcessDpiAwarenessContext(PerMonitorAwareV2);
                else if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 3)
                    SetProcessDpiAwareness(2);
                else if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 0)
                    SetProcessDPIAware();
                else
                    return;
            }
            catch (EntryPointNotFoundException)
            {
                try { SetProcessDPIAware(); } catch { }
            }
            catch { }
        }

    }
}
