using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Eve_Mining.Windows
{
    internal class Api
    {
        #region Constants

        internal const int SW_HIDE = 0;
        internal const int SW_SHOWNORMAL = 1;
        internal const int SW_NORMAL = 1;
        internal const int SW_SHOWMINIMIZED = 2;
        internal const int SW_SHOWMAXIMIZED = 3;
        internal const int SW_MAXIMIZE = 3;
        internal const int SW_SHOWNOACTIVATE = 4;
        internal const int SW_SHOW = 5;
        internal const int SW_MINIMIZE = 6;
        internal const int SW_SHOWMINNOACTIVE = 7;
        internal const int SW_SHOWNA = 8;
        internal const int SW_RESTORE = 9;
        internal const int SW_SHOWDEFAULT = 10;
        internal const int SW_FORCEMINIMIZE = 11;

        internal const int MOD_ALT = 0x0001;
        internal const int MOD_CONTROL = 0x0002;
        internal const int MOD_NOREPEAT = 0x4000;
        internal const int MOD_SHIFT = 0x0004;
        internal const int MOD_WIN = 0x0008;

        #endregion
        #region Enums

        [Flags]
        internal enum SystemMetric : int
        {
            SM_CXSCREEN = 0,
            SM_CYSCREEN = 1,
        }

        [Flags]
        internal enum InputType : int
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        [Flags]
        internal enum KeyEventF : int
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }

        [Flags]
        internal enum MouseEventF : uint
        {
            Absolute = 0x8000,
            HWheel = 0x01000,
            Move = 0x0001,
            MoveNoCoalesce = 0x2000,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            VirtualDesk = 0x4000,
            Wheel = 0x0800,
            XDown = 0x0080,
            XUp = 0x0100
        }

        [Flags]
        internal enum TernaryRasterOperations : uint
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
            CAPTUREBLT = 0x40000000 //only if WinVer >= 5.0.0 (see wingdi.h)
        }

        [Flags]
        public enum DwmWindowAttribute : uint
        {
            DWMWA_NCRENDERING_ENABLED = 1,
            DWMWA_NCRENDERING_POLICY,
            DWMWA_TRANSITIONS_FORCEDISABLED,
            DWMWA_ALLOW_NCPAINT,
            DWMWA_CAPTION_BUTTON_BOUNDS,
            DWMWA_NONCLIENT_RTL_LAYOUT,
            DWMWA_FORCE_ICONIC_REPRESENTATION,
            DWMWA_FLIP3D_POLICY,
            DWMWA_EXTENDED_FRAME_BOUNDS,
            DWMWA_HAS_ICONIC_BITMAP,
            DWMWA_DISALLOW_PEEK,
            DWMWA_EXCLUDED_FROM_PEEK,
            DWMWA_CLOAK,
            DWMWA_CLOAKED,
            DWMWA_FREEZE_REPRESENTATION,
            DWMWA_LAST
        }

        [Flags]
        internal enum KeyCode : ushort
        {
            #region Media

            MEDIA_NEXT_TRACK = 0xb0,
            MEDIA_PLAY_PAUSE = 0xb3,
            MEDIA_PREV_TRACK = 0xb1,
            MEDIA_STOP = 0xb2,

            #endregion
            #region math

            ADD = 0x6b,
            MULTIPLY = 0x6a,
            DIVIDE = 0x6f,
            SUBTRACT = 0x6d,

            #endregion
            #region Browser

            BROWSER_BACK = 0xa6,
            BROWSER_FAVORITES = 0xab,
            BROWSER_FORWARD = 0xa7,
            BROWSER_HOME = 0xac,
            BROWSER_REFRESH = 0xa8,
            BROWSER_SEARCH = 170,
            BROWSER_STOP = 0xa9,

            #endregion
            #region Numpad numbers

            NUMPAD0 = 0x60,
            NUMPAD1 = 0x61,
            NUMPAD2 = 0x62,
            NUMPAD3 = 0x63,
            NUMPAD4 = 100,
            NUMPAD5 = 0x65,
            NUMPAD6 = 0x66,
            NUMPAD7 = 0x67,
            NUMPAD8 = 0x68,
            NUMPAD9 = 0x69,

            #endregion
            #region Fkeys

            F1 = 0x70,
            F10 = 0x79,
            F11 = 0x7a,
            F12 = 0x7b,
            F13 = 0x7c,
            F14 = 0x7d,
            F15 = 0x7e,
            F16 = 0x7f,
            F17 = 0x80,
            F18 = 0x81,
            F19 = 130,
            F2 = 0x71,
            F20 = 0x83,
            F21 = 0x84,
            F22 = 0x85,
            F23 = 0x86,
            F24 = 0x87,
            F3 = 0x72,
            F4 = 0x73,
            F5 = 0x74,
            F6 = 0x75,
            F7 = 0x76,
            F8 = 0x77,
            F9 = 120,

            #endregion
            #region Other

            OEM_1 = 0xba,
            OEM_102 = 0xe2,
            OEM_2 = 0xbf,
            OEM_3 = 0xc0,
            OEM_4 = 0xdb,
            OEM_5 = 220,
            OEM_6 = 0xdd,
            OEM_7 = 0xde,
            OEM_8 = 0xdf,
            OEM_CLEAR = 0xfe,
            OEM_COMMA = 0xbc,
            OEM_MINUS = 0xbd,
            OEM_PERIOD = 190,
            OEM_PLUS = 0xbb,

            #endregion
            #region KEYS

            KEY_0 = 0x30,
            KEY_1 = 0x31,
            KEY_2 = 50,
            KEY_3 = 0x33,
            KEY_4 = 0x34,
            KEY_5 = 0x35,
            KEY_6 = 0x36,
            KEY_7 = 0x37,
            KEY_8 = 0x38,
            KEY_9 = 0x39,
            KEY_A = 0x41,
            KEY_B = 0x42,
            KEY_C = 0x43,
            KEY_D = 0x44,
            KEY_E = 0x45,
            KEY_F = 70,
            KEY_G = 0x47,
            KEY_H = 0x48,
            KEY_I = 0x49,
            KEY_J = 0x4a,
            KEY_K = 0x4b,
            KEY_L = 0x4c,
            KEY_M = 0x4d,
            KEY_N = 0x4e,
            KEY_O = 0x4f,
            KEY_P = 80,
            KEY_Q = 0x51,
            KEY_R = 0x52,
            KEY_S = 0x53,
            KEY_T = 0x54,
            KEY_U = 0x55,
            KEY_V = 0x56,
            KEY_W = 0x57,
            KEY_X = 0x58,
            KEY_Y = 0x59,
            KEY_Z = 90,

            #endregion
            #region volume

            VOLUME_DOWN = 0xae,
            VOLUME_MUTE = 0xad,
            VOLUME_UP = 0xaf,

            #endregion

            SNAPSHOT = 0x2c,
            RightClick = 0x5d,
            BACKSPACE = 8,
            CANCEL = 3,
            CAPS_LOCK = 20,
            CONTROL = 0x11,
            ALT = 18,
            DECIMAL = 110,
            DELETE = 0x2e,
            DOWN = 40,
            END = 0x23,
            ESC = 0x1b,
            HOME = 0x24,
            INSERT = 0x2d,
            LAUNCH_APP1 = 0xb6,
            LAUNCH_APP2 = 0xb7,
            LAUNCH_MAIL = 180,
            LAUNCH_MEDIA_SELECT = 0xb5,
            LCONTROL = 0xa2,
            LEFT = 0x25,
            LSHIFT = 160,
            LWIN = 0x5b,
            PAGEDOWN = 0x22,
            NUMLOCK = 0x90,
            PAGE_UP = 0x21,
            RCONTROL = 0xa3,
            ENTER = 13,
            RIGHT = 0x27,
            RSHIFT = 0xa1,
            RWIN = 0x5c,
            SHIFT = 0x10,
            SPACE_BAR = 0x20,
            TAB = 9,
            UP = 0x26
        }

        #endregion
        #region Structures

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }

        internal struct Input
        {
            public int type;
            public InputUnion u;
        }

        #endregion
        #region Delegates

        internal delegate bool EnumWindowsProc(IntPtr _hWnd, IntPtr _lParam);

        #endregion
        #region Dll Imports

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr FindWindow(string _lpClassName, string _lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool ShowWindow(IntPtr _hWnd, int _nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool SetForegroundWindow(IntPtr _hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetWindowRect(IntPtr _hWnd, out Rect _lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetClientRect(IntPtr _hWnd, out Rect _lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr _hWnd, int _X, int _Y, int _nWidth, int _nHeight, bool _bRepaint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr _hWnd, StringBuilder _lpString, int _nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetClassName(IntPtr _hWnd, StringBuilder _lpClassName, int _nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowTextLength(IntPtr _hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool EnumWindows(EnumWindowsProc _lpEnumFunc, IntPtr _lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool RegisterHotKey(IntPtr _hWnd, int _id, int _fsModifiers, int _vk);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UnregisterHotKey(IntPtr _hWnd, int _id);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetDC(IntPtr _hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern Int32 ReleaseDC(IntPtr _hWnd, IntPtr _hdc);

        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern uint GetPixel(IntPtr _hdc, int _nX, int _nY);

        [DllImport("gdi32.dll", SetLastError = true)]
        static extern uint SetPixel(IntPtr _hdc, int _X, int _Y, uint _crColor);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int SendMessage(IntPtr _hWnd, int _wMsg, IntPtr _wParam, IntPtr _lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetCursorPos(out Point _lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint SendInput(uint _nInputs, Input[] _pInputs, int _cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int GetSystemMetrics(SystemMetric _smIndex);

        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool BitBlt([In] IntPtr _hdc, int _nXDest, int _nYDest, int _nWidth, int _nHeight, [In] IntPtr _hdcSrc, int _nXSrc, int _nYSrc, TernaryRasterOperations _dwRop);

        [DllImport("dwmapi.dll", SetLastError = true)]
        internal static extern int DwmGetWindowAttribute(IntPtr _hWnd, int _dwAttribute, out Rect _pvAttribute, int _cbAttribute);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr WindowFromPoint(Point _lpPoint);

        #endregion
        internal static Rectangle GetWindowRect(IntPtr _hWnd)
        {
            Rect rect = new Rect();

            if (Environment.OSVersion.Version.Major >= 6)
            {
                int size = Marshal.SizeOf(typeof(Rect));
                DwmGetWindowAttribute(_hWnd, (int)DwmWindowAttribute.DWMWA_EXTENDED_FRAME_BOUNDS, out rect, size);
                rect.Left++;
                rect.Right--;
            }
            else
            {
                GetWindowRect(_hWnd, out rect);
            }

            return rect.ToRectangle();
        }


        #region Tools : EnumWindows

        internal static string GetWindowText(IntPtr _hWnd)
        {
            int size = GetWindowTextLength(_hWnd);
            if (size > 0)
            {
                var sb = new StringBuilder(size + 1);
                GetWindowText(_hWnd, sb, sb.Capacity);

                return sb.ToString();
            }

            return String.Empty;
        }

        internal static IEnumerable<IntPtr> FindWindows(EnumWindowsProc _filter)
        {
            IntPtr found = IntPtr.Zero;
            List<IntPtr> windows = new List<IntPtr>();

            EnumWindows(delegate (IntPtr _hWnd, IntPtr _param)
            {
                if (_filter(_hWnd, _param))
                    windows.Add(_hWnd);

                return true;
            }, IntPtr.Zero);

            return windows;
        }

        internal static IEnumerable<IntPtr> FindWindowsWithText(string _sPartialTitle)
        {
            return FindWindows(delegate (IntPtr _hWnd, IntPtr _param)
            {
                return GetWindowText(_hWnd).Contains(_sPartialTitle);
            });
        }

        #endregion

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    }
}
