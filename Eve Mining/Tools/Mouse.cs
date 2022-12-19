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
            this.m_hWnd = Process.GetCurrentProcess().MainWindowHandle;
        }

        #endregion
        #region Set/Get

        internal int Delay
        {
            get
            {
                return this.m_iDelay;
            }
            set
            {
                if (value < 0)
                    return;

                this.m_iDelay = value;
            }
        }

        internal bool HiddenMode
        {
            get
            {
                return this.m_bHiddenMode;
            }
            set
            {
                this.m_bHiddenMode = value;
            }
        }

        internal Point Position
        {
            get
            {
                Api.GetCursorPos(out Point p);

                if (p == null || p.IsEmpty)
                    return new Point(this.m_iX, this.m_iY);

                if (this.m_iX != p.X)
                    this.m_iX = p.X;

                if (this.m_iY != p.Y)
                    this.m_iY = p.Y;

                return p;
            }
        }

        internal bool BackReturn
        {
            get
            {
                return this.BackReturn;
            }
            set
            {
                this.m_bBackReturn = value;
            }
        }

        #endregion

        #region Functions

        internal void Move(Point _p)
        {
            if (_p == null)
                return;

            this.Move(_p.X, _p.Y);
        }

        internal void Move(int _iDeltaX, int _iDeltaY)
        {
            this.m_iX += _iDeltaX;
            this.m_iY += _iDeltaY;

            this.SendInput(this.GetInputs(_iDeltaX, _iDeltaY, Api.MouseEventF.Move));
        }

        internal void MoveTo(Point _p)
        {
            if (_p == null)
                return;

            this.MoveTo(_p.X, _p.Y);
        }

        internal void MoveTo(int _iX, int _iY)
        {
            this.m_iX = _iX;
            this.m_iY = _iY;

            this.SendInput(this.GetInputs(_iX, _iY, Api.MouseEventF.Absolute | Api.MouseEventF.Move));
        }

        internal void LeftClickTo(Point _p)
        {
            if (_p == null)
                return;

            this.LeftClickTo(_p.X, _p.Y);
        }

        internal void LeftClickTo(int _iX, int _iY)
        {
            this.MoveTo(_iX, _iY);
            this.LeftClick();
        }

        internal void LeftClick()
        {
            this.SendInput(this.GetInputs(Api.MouseEventF.LeftDown, Api.MouseEventF.LeftUp));
        }

        internal void LeftDoubleClickTo(Point _p)
        {
            if (_p == null)
                return;

            this.LeftDoubleClickTo(_p.X, _p.Y);
        }

        internal void LeftDoubleClickTo(int _iX, int _iY)
        {
            this.MoveTo(_iX, _iY);
            this.LeftDoubleClick();
        }

        internal void LeftDoubleClick()
        {
            this.LeftClick();
            this.LeftClick();
        }

        internal void LeftDown()
        {
            this.SendInput(this.GetInputs(Api.MouseEventF.LeftDown));
        }

        internal void LeftUp()
        {
            this.SendInput(this.GetInputs(Api.MouseEventF.LeftUp));
        }

        internal void LeftDrag(Point _start, Point _end)
        {
            this.LeftDrag(_start.X, _start.Y, _end.X, _end.Y);
        }

        internal void LeftDrag(int _iStartX, int _iStartY, int _iEndX, int _iEndY)
        {
            this.MoveTo(_iStartX, _iStartY);
            this.LeftDown();

            Thread.Sleep(100);

            this.MoveTo(_iEndX, _iEndY);
            this.LeftUp();
        }

        internal void RightClickTo(Point _p)
        {
            if (_p == null)
                return;

            this.RightClickTo(_p.X, _p.Y);
        }

        internal void RightClickTo(int _iX, int _iY)
        {
            this.MoveTo(_iX, _iY);
            this.RightClick();
        }

        internal void RightClick()
        {
            this.SendInput(this.GetInputs(Api.MouseEventF.RightDown, Api.MouseEventF.RightUp));
        }

        internal void RightDoubleClickTo(Point _p)
        {
            if (_p == null)
                return;

            this.RightDoubleClickTo(_p.X, _p.Y);
        }

        internal void RightDoubleClickTo(int _iX, int _iY)
        {
            this.MoveTo(_iX, _iY);
            this.RightDoubleClick();
        }

        internal void RightDoubleClick()
        {
            this.RightClick();
            this.RightClick();
        }

        internal void RightDown()
        {
            this.SendInput(this.GetInputs(Api.MouseEventF.RightDown));
        }

        internal void RightUp()
        {
            this.SendInput(this.GetInputs(Api.MouseEventF.RightUp));
        }

        internal void RightDrag(Point _start, Point _end)
        {
            this.RightDrag(_start.X, _start.Y, _end.X, _end.Y);
        }

        internal void RightDrag(int _iStartX, int _iStartY, int _iEndX, int _iEndY)
        {
            this.MoveTo(_iStartX, _iStartY);
            this.LeftDown();

            Thread.Sleep(100);

            this.MoveTo(_iEndX, _iEndY);
            this.LeftUp();
        }

        internal Color GetPixel()
        {
            return this.GetPixel(IntPtr.Zero);
        }

        internal Color GetPixel(int _iX, int _iY)
        {
            return this.GetPixel(IntPtr.Zero, _iX, _iY);
        }

        internal Color GetPixel(IntPtr _hWnd)
        {
            return this.GetPixel(_hWnd, this.m_iX, this.m_iY);
        }

        internal Color GetPixel(IntPtr _hWnd, int _iX, int _iY)
        {
            uint pixel = this.GetPixelUint(_hWnd, _iX, _iY);

            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                (int)(pixel & 0x0000FF00) >> 8,
                (int)(pixel & 0x00FF0000) >> 16);

            return color;
        }

        internal uint GetPixelUint()
        {
            return this.GetPixelUint(IntPtr.Zero);
        }

        internal uint GetPixelUint(int _iX, int _iY)
        {
            return this.GetPixelUint(IntPtr.Zero, _iX, _iY);
        }

        internal uint GetPixelUint(IntPtr _hWnd)
        {
            IntPtr hdc = Api.GetDC(_hWnd);
            uint pixel = Api.GetPixel(hdc, this.m_iX, this.m_iY);

            Api.ReleaseDC(_hWnd, hdc);

            return pixel;
        }

        internal uint GetPixelUint(IntPtr _hWnd, int _iX, int _iY)
        {
            Point p = this.Position;

            this.MoveTo(_iX, _iY);

            IntPtr hdc = Api.GetDC(_hWnd);
            uint pixel = Api.GetPixel(hdc, _iX, _iY);

            Api.ReleaseDC(_hWnd, hdc);

            if (this.m_bBackReturn)
                this.MoveTo(p.X, p.Y);

            return pixel;
        }

        private Api.Input[] GetInputs(params Api.MouseEventF[] _events)
        {
            return this.GetInputs(0, 0, _events);
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
                            dx = this.CalculateAbsoluteCoordinateX(_iX),
                            dy = this.CalculateAbsoluteCoordinateY(_iY),
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
            this.Hide();

            uint r = Api.SendInput((uint)_inputs.Length, _inputs, Marshal.SizeOf(typeof(Api.Input)));

            Thread.Sleep(this.m_iDelay);

            this.UnHide();

            return r;
        }

        private void Hide()
        {
            if (!this.m_bHiddenMode)
                return;

            if (this.m_bHidden)
                return;

            Api.ShowWindow(this.m_hWnd, Api.SW_HIDE);

            this.m_bHidden = true;
        }

        private void UnHide()
        {
            if (!this.m_bHiddenMode)
                return;

            if (!this.m_bHidden)
                return;

            Api.ShowWindow(this.m_hWnd, Api.SW_SHOW);

            this.m_bHidden = false;
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
