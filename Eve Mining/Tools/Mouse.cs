using Eve_Mining.Windows;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace Eve_Mining.Tools
{
    internal class Mouse
    {
        #region Variables

        private int m_iX = 0;
        private int m_iY = 0;
        private int m_iDelay = 100;
        private bool m_bBackReturn = false;
        private bool m_bHiddenMode = false;
        private bool m_bHidden = false;
        private readonly IntPtr m_hWnd;

        #endregion
        #region Constructor

        internal Mouse()
        {
            m_hWnd = Process.GetCurrentProcess().MainWindowHandle;
        }

        #endregion
        #region Set/Get

        internal int Delay
        {
            get
            {
                return m_iDelay;
            }
            set
            {
                if (value < 0)
                    return;

                m_iDelay = value;
            }
        }

        internal bool HiddenMode
        {
            get
            {
                return m_bHiddenMode;
            }
            set
            {
                m_bHiddenMode = value;
            }
        }

        internal Point Position
        {
            get
            {
                Api.GetCursorPos(out Point p);

                if (p == null || p.IsEmpty)
                    return new Point(m_iX, m_iY);

                if (m_iX != p.X)
                    m_iX = p.X;

                if (m_iY != p.Y)
                    m_iY = p.Y;

                return p;
            }
        }

        internal bool BackReturn
        {
            get
            {
                return BackReturn;
            }
            set
            {
                m_bBackReturn = value;
            }
        }

        #endregion

        #region Functions

        internal void Move(Point _p)
        {
            if (_p == null)
                return;

            Move(_p.X, _p.Y);
        }

        internal void Move(int _iDeltaX, int _iDeltaY)
        {
            m_iX += _iDeltaX;
            m_iY += _iDeltaY;

            SendInput(GetInputs(_iDeltaX, _iDeltaY, Api.MouseEventF.Move));
        }

        internal void MoveTo(Point _p)
        {
            if (_p == null)
                return;

            MoveTo(_p.X, _p.Y);
        }

        internal void MoveTo(int _iX, int _iY)
        {
            m_iX = _iX;
            m_iY = _iY;

            SendInput(GetInputs(_iX, _iY, Api.MouseEventF.Absolute | Api.MouseEventF.Move));
        }

        internal void LeftClickTo(Point _p)
        {
            if (_p == null)
                return;

            LeftClickTo(_p.X, _p.Y);
        }

        internal void LeftClickTo(int _iX, int _iY)
        {
            MoveTo(_iX, _iY);
            LeftClick();
        }

        internal void LeftClick()
        {
            SendInput(GetInputs(Api.MouseEventF.LeftDown, Api.MouseEventF.LeftUp));
        }

        internal void LeftDoubleClickTo(Point _p)
        {
            if (_p == null)
                return;

            LeftDoubleClickTo(_p.X, _p.Y);
        }

        internal void LeftDoubleClickTo(int _iX, int _iY)
        {
            MoveTo(_iX, _iY);
            LeftDoubleClick();
        }

        internal void LeftDoubleClick()
        {
            LeftClick();
            LeftClick();
        }

        internal void LeftDown()
        {
            SendInput(GetInputs(Api.MouseEventF.LeftDown));
        }

        internal void LeftUp()
        {
            SendInput(GetInputs(Api.MouseEventF.LeftUp));
        }

        internal void LeftDrag(Point _start, Point _end)
        {
            LeftDrag(_start.X, _start.Y, _end.X, _end.Y);
        }

        internal void LeftDrag(int _iStartX, int _iStartY, int _iEndX, int _iEndY)
        {
            MoveTo(_iStartX, _iStartY);
            LeftDown();

            Thread.Sleep(100);

            MoveTo(_iEndX, _iEndY);
            LeftUp();
        }

        internal void RightClickTo(Point _p)
        {
            if (_p == null)
                return;

            RightClickTo(_p.X, _p.Y);
        }

        internal void RightClickTo(int _iX, int _iY)
        {
            MoveTo(_iX, _iY);
            RightClick();
        }

        internal void RightClick()
        {
            SendInput(GetInputs(Api.MouseEventF.RightDown, Api.MouseEventF.RightUp));
        }

        internal void RightDoubleClickTo(Point _p)
        {
            if (_p == null)
                return;

            RightDoubleClickTo(_p.X, _p.Y);
        }

        internal void RightDoubleClickTo(int _iX, int _iY)
        {
            MoveTo(_iX, _iY);
            RightDoubleClick();
        }

        internal void RightDoubleClick()
        {
            RightClick();
            RightClick();
        }

        internal void RightDown()
        {
            SendInput(GetInputs(Api.MouseEventF.RightDown));
        }

        internal void RightUp()
        {
            SendInput(GetInputs(Api.MouseEventF.RightUp));
        }

        internal void RightDrag(Point _start, Point _end)
        {
            RightDrag(_start.X, _start.Y, _end.X, _end.Y);
        }

        internal void RightDrag(int _iStartX, int _iStartY, int _iEndX, int _iEndY)
        {
            MoveTo(_iStartX, _iStartY);
            LeftDown();

            Thread.Sleep(100);

            MoveTo(_iEndX, _iEndY);
            LeftUp();
        }

        internal Color GetPixel()
        {
            return GetPixel(IntPtr.Zero);
        }

        internal Color GetPixel(int _iX, int _iY)
        {
            return GetPixel(IntPtr.Zero, _iX, _iY);
        }

        internal Color GetPixel(IntPtr _hWnd)
        {
            return GetPixel(_hWnd, m_iX, m_iY);
        }

        internal Color GetPixel(IntPtr _hWnd, int _iX, int _iY)
        {
            uint pixel = GetPixelUint(_hWnd, _iX, _iY);

            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                (int)(pixel & 0x0000FF00) >> 8,
                (int)(pixel & 0x00FF0000) >> 16);

            return color;
        }

        internal uint GetPixelUint()
        {
            return GetPixelUint(IntPtr.Zero);
        }

        internal uint GetPixelUint(int _iX, int _iY)
        {
            return GetPixelUint(IntPtr.Zero, _iX, _iY);
        }

        internal uint GetPixelUint(IntPtr _hWnd)
        {
            IntPtr hdc = Api.GetDC(_hWnd);
            uint pixel = Api.GetPixel(hdc, m_iX, m_iY);

            Api.ReleaseDC(_hWnd, hdc);

            return pixel;
        }

        internal uint GetPixelUint(IntPtr _hWnd, int _iX, int _iY)
        {
            Point p = Position;

            MoveTo(_iX, _iY);

            IntPtr hdc = Api.GetDC(_hWnd);
            uint pixel = Api.GetPixel(hdc, _iX, _iY);

            Api.ReleaseDC(_hWnd, hdc);

            if (m_bBackReturn)
                MoveTo(p.X, p.Y);

            return pixel;
        }

        private Api.Input[] GetInputs(params Api.MouseEventF[] _events)
        {
            return GetInputs(0, 0, _events);
        }

        private Api.Input[] GetInputs(int _iX, int _iY, params Api.MouseEventF[] _events)
        {
            Api.Input[] inputs = new Api.Input[_events.Length];

            for (int i = 0; i < _events.Length; i++)
            {
                inputs[i] = new Api.Input
                {
                    type = (int)Api.InputType.Mouse,
                    u = new Api.InputUnion
                    {
                        mi = new Api.MouseInput
                        {
                            dx = CalculateAbsoluteCoordinateX(_iX),
                            dy = CalculateAbsoluteCoordinateY(_iY),
                            dwFlags = (uint)(_events[i]),
                            dwExtraInfo = Api.GetMessageExtraInfo(),

                        }
                    }
                };
            }

            return inputs;
        }

        private uint SendInput(Api.Input[] _inputs)
        {
            Hide();

            uint r = Api.SendInput((uint)_inputs.Length, _inputs, Marshal.SizeOf(typeof(Api.Input)));

            Thread.Sleep(m_iDelay);

            UnHide();

            return r;
        }

        private void Hide()
        {
            if (!m_bHiddenMode)
                return;

            if (m_bHidden)
                return;

            Api.ShowWindow(m_hWnd, Api.SW_HIDE);

            m_bHidden = true;
        }

        private void UnHide()
        {
            if (!m_bHiddenMode)
                return;

            if (!m_bHidden)
                return;

            Api.ShowWindow(m_hWnd, Api.SW_SHOW);

            m_bHidden = false;
        }

        private int CalculateAbsoluteCoordinateX(int _iX)
        {
            return (_iX * 65536) / Api.GetSystemMetrics(Api.SystemMetric.SM_CXSCREEN);
        }

        private int CalculateAbsoluteCoordinateY(int _iY)
        {
            return (_iY * 65536) / Api.GetSystemMetrics(Api.SystemMetric.SM_CYSCREEN);
        }

        #endregion
    }
}
