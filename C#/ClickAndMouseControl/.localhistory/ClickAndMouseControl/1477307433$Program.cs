using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClickAndMouseControl
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public enum KeyEventFlags
        {
            KeyDown = 0x0001, //KEYEVENTF_EXTENDEDKEY
            KeyUp = 0x0002,//KEYEVENTF_KEYUP
        }

        //Come up with a smart way to port these to enum http://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
        public enum VirtualKeyCodes
        {
            A = 0x41,
            B = 0x42,
            C = 0x43
        }

        static void Main(string[] args)
        {
            int x = int.Parse(args[0]);
            int y = int.Parse(args[1]);
            HandleMouseMove(x, y);
        }

        public static void HandleMouseMove(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(Cursor.Position.X + x, Cursor.Position.Y + y);
            mouse_event((int)(MouseEventFlags.MOVE), 0, 0, 0, 0);
        }

        public static void HandleMouseDown(MouseEventFlags button)
        {
            mouse_event((int)(button), 0, 0, 0, 0);
        }

        public static void HandleMouseUp(MouseEventFlags button)
        {
            mouse_event((int)(button), 0, 0, 0, 0);
        }

        public static void HandleKeyDown(VirtualKeyCodes code)
        {
            keybd_event((byte)code, 0, (int)KeyEventFlags.KeyDown, 0);

        }

        public static void HandleKeyUp(VirtualKeyCodes code)
        {
            keybd_event((byte)code, 0, (int)KeyEventFlags.KeyDown, 0);
        }
    }
}
