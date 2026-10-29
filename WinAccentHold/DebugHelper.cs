using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace WinAccentHold
{
    public static class DebugHelper
    {
        public static void LogWin32Error(String piece, int error)
        {
            String errorText = new Win32Exception(error).Message;
            Debug.WriteLine(piece + " failed!");
            Debug.WriteLine("Error code: " + error);
            Debug.WriteLine("Description: " + errorText);
            Console.WriteLine("SetWindowsHookEx failed!");
            Console.WriteLine("Error code: " + error);
            Console.WriteLine("Description: " + errorText);
        }
    }
}
