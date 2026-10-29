using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Automation;

namespace WinAccentHold
{
    public static class CaretHelper
    {
        private const uint GUI_CARETBLINKING = 0x00000001;
        private const uint GUI_INMOVESIZE = 0x00000002;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct GUITHREADINFO
        {
            public int cbSize;
            public uint flags;
            public IntPtr hwndActive;
            public IntPtr hwndFocus;
            public IntPtr hwndCapture;
            public IntPtr hwndMenuOwner;
            public IntPtr hwndMoveSize;
            public IntPtr hwndCaret;
            public RECT rcCaret;
        }

        [DllImport("user32.dll")]
        private static extern bool GetGUIThreadInfo(
            uint idThread, ref GUITHREADINFO lpgui);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(
            IntPtr hWnd, IntPtr lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(
            IntPtr hWnd, ref POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X, Y;
        }

        public static bool TryGetCaretPosition(out System.Drawing.Point position)
        {
            position = System.Drawing.Point.Empty;

            IntPtr foreground = GetForegroundWindow();
            if (foreground == IntPtr.Zero)
                return false;

            uint threadId = GetWindowThreadProcessId(foreground, IntPtr.Zero);

            GUITHREADINFO info = new GUITHREADINFO();
            info.cbSize = Marshal.SizeOf(typeof(GUITHREADINFO));

            if (!GetGUIThreadInfo(threadId, ref info) || info.hwndCaret == IntPtr.Zero)
                return TryGetAutomationCaret(out position);

            POINT point = new POINT
            {
                X = info.rcCaret.Left,
                Y = info.rcCaret.Top
            };

            if (!ClientToScreen(info.hwndCaret, ref point))
                return false;

            position = new System.Drawing.Point(point.X, point.Y);
            return true;
        }

        private static bool TryGetAutomationCaret(out System.Drawing.Point position)
        {
            position = System.Drawing.Point.Empty;
            try
            {
                AutomationElement focused = AutomationElement.FocusedElement;
                object value;
                if (focused == null || !focused.TryGetCurrentPattern(TextPattern.Pattern, out value)) return false;
                var selections = ((TextPattern)value).GetSelection();
                if (selections == null || selections.Length == 0) return false;
                var range = selections[0];
                var rectangles = range.GetBoundingRectangles();
                if (rectangles == null || rectangles.Length == 0) return false;
                position = new System.Drawing.Point((int)rectangles[0].Left, (int)rectangles[0].Top);
                return true;
            }
            catch (ElementNotAvailableException) { return false; }
            catch (InvalidOperationException) { return false; }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
    }
}
