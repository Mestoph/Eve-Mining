using Eve_Mining.Enums;
using Eve_Mining.Extentions;
using Eve_Mining.Tools;
using Eve_Mining.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Eve_Mining
{
    public partial class FrmGui : Form
    {
        #region Constants

        private const string START = "Start";
        private const string STOP = "Stop";
        private const string PAUSE = "Pause";
        private const string RESUME = "Resume";
        private const string INITIALIZING = "Initializing";
        private const string WAITING_GAME = "Waiting for the game Eve Online";
        private const string WAITING_START = "Waiting to start";
        private const string WAITING_RESUME = "Waiting to resume";
        private const string RUNNING = "Running";
        private const string ALT_F2 = "(ALT+F2)";
        private const string ALT_F3 = "(ALT+F3)";
        private const string SPACE = " ";
        private const string BELT_NUMBER = "Belt n° {0}";
        private const string STATION_NUMBER = "Station n° {0}";
        private const string TIME = @"hh\:mm\:ss";
        private const string NOT_AVAILABLE = "Not available";

        private const int START_HOTKEY_ID = 1;
        private const int PAUSE_HOTKEY_ID = 2;
        private const int MAX_DOT = 3;
        private const int MAX_TRIES = 3;
        private const int MAX_SELECTIONS = 10;

        #endregion
        #region Variables

        private Thread m_MiningThread = null;
        private readonly ManualResetEvent m_MiningResetEvent = new ManualResetEvent(true);

        private System.Windows.Forms.Timer m_GuiUpdateTimer = null;

        private readonly Stopwatch m_totalTime = new Stopwatch();

        private MiningState m_MiningState;
        private BotState m_BotState;

        private int m_iNumberOfDot = 0;
        private int m_iBelt = 1;
        private int m_iStation = 1;
        private readonly int m_iPortal = 1;
        private int m_iBeltCnt = 1;
        private int m_iStationCnt = 1;
        private int m_iCycles = 0;
        private int m_iSelection = 0;
        private int m_iTries = 0;

        #endregion
        #region Constructor & Destructor

        public FrmGui()
        {
            InitializeComponent();

            Api.RegisterHotKey(Handle, START_HOTKEY_ID, Api.MOD_ALT, (int)Keys.F2);
            Api.RegisterHotKey(Handle, PAUSE_HOTKEY_ID, Api.MOD_ALT, (int)Keys.F3);

            m_MiningState = MiningState.Idle;
            m_BotState = BotState.None;

            m_GuiUpdateTimer = new System.Windows.Forms.Timer();
            m_GuiUpdateTimer.Tick += TimerTick;
            m_GuiUpdateTimer.Interval = 250;
            m_GuiUpdateTimer.Start();

            GuiUpdate();

            StatusStrip.Text = INITIALIZING;

            KeyPreview = true;
        }

        ~FrmGui()
        {
            if (m_GuiUpdateTimer != null)
            {
                if (m_GuiUpdateTimer.Enabled)
                    m_GuiUpdateTimer.Stop();

                m_GuiUpdateTimer = null;
            }

            if (m_MiningThread != null)
            {
                if (m_MiningThread.IsAlive)
                    m_MiningThread.Abort();

                m_MiningThread = null;
            }

            Environment.Exit(Environment.ExitCode);
        }

        #endregion
        #region Overrides

        protected override void WndProc(ref Message _m)
        {
            if (_m.Msg == 0x0312)
            {
                switch (_m.WParam.ToInt32())
                {
                    case START_HOTKEY_ID:
                        BtnStart.PerformClick();

                        break;

                    case PAUSE_HOTKEY_ID:
                        BtnPause.PerformClick();

                        break;
                }
            }

            base.WndProc(ref _m);
        }

        #endregion
        #region Events

        private void TimerTick(object sender, EventArgs e)
        {
            GuiUpdate();
        }

        private void LblStart_Click(object sender, EventArgs e)
        {
            if (m_BotState == BotState.Waiting || m_BotState == BotState.Stopped)
                MiningStart();
            else
                MiningStop(BotState.Stopped);
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (m_BotState == BotState.Started)
                MiningPause();
            else
                MiningResume();
        }

        #endregion
        #region Functions

        private void GuiUpdate()
        {
            if (!IsEve())
                MiningStop(BotState.None);

            else if (m_BotState == BotState.None)
                m_BotState = BotState.Waiting;

            switch (m_BotState)
            {
                case BotState.None:
                    BtnStart.Enabled = false;
                    BtnStart.Text = string.Concat(START, SPACE, ALT_F2);

                    BtnPause.Enabled = false;
                    BtnPause.Text = string.Concat(PAUSE, SPACE, ALT_F3);

                    StatusStrip.Text = WAITING_GAME;

                    break;

                case BotState.Waiting:
                case BotState.Stopped:
                    BtnStart.Enabled = true;
                    BtnStart.Text = string.Concat(START, SPACE, ALT_F2); ;

                    BtnPause.Enabled = false;
                    BtnPause.Text = string.Concat(PAUSE, SPACE, ALT_F3);

                    StatusStrip.Text = WAITING_START;

                    break;

                case BotState.Started:
                    BtnStart.Enabled = true;
                    BtnStart.Text = string.Concat(STOP, SPACE, ALT_F2);

                    BtnPause.Enabled = true;
                    BtnPause.Text = string.Concat(PAUSE, SPACE, ALT_F3);

                    StatusStrip.Text = RUNNING;

                    break;

                case BotState.Suspended:
                    BtnStart.Enabled = true;
                    BtnStart.Text = string.Concat(STOP, SPACE, ALT_F2);

                    BtnPause.Enabled = true;
                    BtnPause.Text = string.Concat(RESUME, SPACE, ALT_F3);

                    StatusStrip.Text = WAITING_RESUME;

                    break;
            }

            AnimateStatus();

            LblBeltV.Text = string.Format(BELT_NUMBER, m_iBelt);
            LblStationV.Text = string.Format(STATION_NUMBER, m_iStation);
            LblStatusV.Text = m_MiningState.ToString().Replace('_', ' ');

            TimeSpan t = m_totalTime.Elapsed;
            LblTotalTimeV.Text = t.ToString(TIME);

            LblCycleV.Text = m_iCycles.ToString();

            if (m_iCycles <= 0)
                LblAvrTimeV.Text = NOT_AVAILABLE;
            else
            {
                t = new TimeSpan(t.Ticks / m_iCycles);
                LblAvrTimeV.Text = t.ToString(TIME);
            }
        }

        private bool IsEve()
        {
            if (GetEvehWnd() != IntPtr.Zero)
                return true;

            return false;
        }

        private IntPtr GetEvehWnd()
        {
            IntPtr hWnd = IntPtr.Zero;
            IEnumerable<IntPtr> windows = Api.FindWindowsWithText("EVE");
            foreach (IntPtr w in windows)
            {
                StringBuilder sb = new StringBuilder(256);
                Api.GetClassName(w, sb, 256);

                if (sb.ToString().ToLowerInvariant().Equals("trinitywindow"))
                {
                    hWnd = w;

                    break;
                }
            }

            return hWnd;
        }

        #endregion


        private bool MiningIsAlive()
        {
            if (m_BotState == BotState.Waiting || m_BotState == BotState.Stopped || m_BotState == BotState.None)
                return false;

            return true;
        }

        private void Mining()
        {
            Mouse m = new Mouse
            {
                Delay = 250,
                //BackReturn = true
            };

            while (true)
            {
                if (!MiningIsAlive())
                    return;

                IntPtr hWnd = GetEvehWnd();

                if (hWnd == IntPtr.Zero)
                    return;

                if (!Api.ShowWindow(hWnd, Api.SW_SHOWMAXIMIZED))
                    return;

                if (!Api.SetForegroundWindow(hWnd))
                    return;

                if (!Api.GetClientRect(hWnd, out Api.Rect rC))
                    return;

                Rectangle rW = Api.GetWindowRect(hWnd);
                if (rW.IsEmpty)
                    return;

                rW.Y = rW.Bottom - rC.Bottom - 1;
                int iCx = rC.Right / 2;
                int iCy = rC.Bottom / 2;


                m.LeftClickTo(rW.X + iCx - 98, rW.Y + rC.Bottom - 85);

                switch (m_MiningState)
                {
                    case MiningState.Idle:

                        m_MiningState = MiningState.Undocking;

                        break;

                    case MiningState.Undocking:

                        m.RightClickTo(rW.X + iCx, rW.Y + iCy);
                        m.LeftClickTo((rW.X + iCx) + 50, (rW.Y + iCy) + 15);

                        while (!m.GetPixel(rW.X + 62, rW.Y + 85).Equals(Color.FromArgb(255, 255, 255)))
                        {
                            Thread.Sleep(1000);

                            if (!MiningIsAlive())
                                return;
                        }

                        m_MiningState = MiningState.Warping_to_belt;

                        break;

                    case MiningState.Warping_to_belt:

                        OpenMainMenu(ref m, rW);
                        WarpToBelt(ref m, rW);

                        while (m.GetPixel(rW.X + iCx - 37, rW.Y + rC.Bottom - 62).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00FFFF")) ||
                            m.GetPixel(rW.X + iCx - 37, rW.Y + rC.Bottom - 62).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00BFFF")))
                        {
                            Thread.Sleep(1000);

                            if (!MiningIsAlive())
                                return;
                        }

                        m_MiningState = MiningState.Selecting_target;

                        break;

                    case MiningState.Warping_to_portal:

                        OpenMainMenu(ref m, rW);
                        WarpToPortal(ref m, rW);

                        break;

                    case MiningState.Selecting_target:
                        bool exit = false;

                        m.LeftClickTo(rW.X + rW.Width - 395, rW.Y + 237);
                        m.LeftClickTo(rW.X + rW.Width - 395, rW.Y + 292 + (24 * m_iSelection));

                        while (!m.GetPixel(rW.X + rW.Width - 546, rW.Y + 163).Equals(Color.FromArgb(255, 255, 255))
                            || (m.GetPixel(rW.X + rW.Width - 555, rW.Y + 295 + (24 * m_iSelection)).Equals(Color.FromArgb(255, 255, 255)) &&
                                m.GetPixel(rW.X + rW.Width - 555, rW.Y + 299 + (24 * m_iSelection)).Equals(Color.FromArgb(255, 255, 255))))
                        {
                            Thread.Sleep(250);

                            if (!MiningIsAlive())
                                return;

                            if (m_iTries < MAX_TRIES)
                            {
                                bool portal = false;

                                if (m_iSelection++ > MAX_SELECTIONS)
                                {
                                    m_iSelection = 0;

                                    m_iBelt++;

                                    if (m_iBelt > m_iBeltCnt)
                                    {
                                        m_iTries++;

                                        m_iBelt = 1;
                                    }

                                    m_iStation++;
                                    if (m_iStation > m_iStationCnt)
                                    {
                                        m_iStation = 1;

                                        if (ChkPortal.Checked)
                                            portal = true;
                                    }

                                    if (portal)
                                        m_MiningState = MiningState.Warping_to_portal;
                                    else
                                        m_MiningState = MiningState.Warping_to_station;
                                }

                                exit = true;

                                break;
                            }

                            m.LeftClickTo(rW.X + rW.Width - 395, rW.Y + 294 + (22 * m_iSelection));
                        }

                        if (!exit)
                            m_MiningState = MiningState.Approaching;

                        break;

                    case MiningState.Approaching:

                        m.LeftClickTo(rW.X + rW.Width - 546, rW.Y + 163);

                        while (m.GetPixel(rW.X + iCx - 37, rW.Y + rC.Bottom - 62).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00FFFF")) ||
                            m.GetPixel(rW.X + iCx - 37, rW.Y + rC.Bottom - 62).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00BFFF")))
                        {
                            Thread.Sleep(1000);

                            if (!MiningIsAlive())
                                return;

                            if (m.GetPixel(rW.X + rW.Width - 413, rW.Y + 154).Equals(Color.FromArgb(255, 255, 255)))
                                break;
                        }

                        m_MiningState = MiningState.Locking_target;

                        break;

                    case MiningState.Locking_target:

                        while (!m.GetPixel(rW.X + rW.Width - 413, rW.Y + 154).Equals(Color.FromArgb(255, 255, 255)))
                        {
                            Thread.Sleep(1000);

                            if (!MiningIsAlive())
                                return;
                        }

                        m.LeftClickTo(rW.X + rW.Width - 413, rW.Y + 154);

                        m_MiningState = MiningState.Fiering_lasers;

                        break;

                    case MiningState.Fiering_lasers:

                        if (Chk1.Checked)
                            m.LeftClickTo(rW.X + iCx + 107, rW.Y + rC.Bottom - 145);

                        if (Chk2.Checked)
                            m.LeftClickTo(rW.X + iCx + 160, rW.Y + rC.Bottom - 145);

                        if (Chk3.Checked)
                            m.LeftClickTo(rW.X + iCx + 210, rW.Y + rC.Bottom - 145);

                        Thread.Sleep(3000);

                        m_MiningState = MiningState.Mining;

                        break;

                    case MiningState.Mining:

                        // Open inventory
                        m.RightClickTo(rW.X + iCx, rW.Y + iCy);
                        m.LeftClickTo((rW.X + iCx) + 50, (rW.Y + iCy) + 15);
                        m.RightClickTo(rW.X + iCx, rW.Y + iCy);
                        m.LeftClickTo((rW.X + iCx) + 50, (rW.Y + iCy) + 295);

                        bool end = false;

                        bool f = m.GetPixel(rW.X + 335, rW.Y + 321).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00FFFF")) ||
                            m.GetPixel(rW.X + 335, rW.Y + 321).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00BFFF"));
                        bool s = m.GetPixel(rW.X + 540, rW.Y + 321).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00FFFF")) ||
                            m.GetPixel(rW.X + 540, rW.Y + 321).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00BFFF"));

                        while (!f || f != s)
                        {
                            if (!m.GetPixel(rW.X + rW.Width - 413, rW.Y + 154).Equals(Color.FromArgb(255, 255, 255)))
                            {
                                end = true;

                                break;
                            }

                            Thread.Sleep(1000);

                            if (!MiningIsAlive())
                                return;
                        }

                        if (end)
                        {
                            m_MiningState = MiningState.Selecting_target;

                            break;
                        }

                        m_MiningState = MiningState.Warping_to_station;

                        break;

                    case MiningState.Warping_to_station:

                        m_MiningState = MiningState.Docking;

                        break;

                    case MiningState.Docking:

                        OpenMainMenu(ref m, rW);
                        WarpToStation(ref m, rW);

                        m_iStation = 1;

                        while (m.GetPixel(rW.X + iCx - 37, rW.Y + rC.Bottom - 62).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00FFFF")) ||
                            m.GetPixel(rW.X + iCx - 37, rW.Y + rC.Bottom - 62).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00BFFF")))
                        {
                            Thread.Sleep(1000);

                            if (!MiningIsAlive())
                                return;
                        }

                        m.LeftClickTo(rW.X + rW.Width - 554, rW.Y + 233);
                        m.LeftClickTo(rW.X + rW.Width - 424, rW.Y + 292);
                        m.LeftClickTo(rW.X + rW.Width - 482, rW.Y + 163);

                        while (!m.GetPixel(rW.X + rW.Width - 43, rW.Y + 30).Equals(Color.FromArgb(255, 255, 255)))
                        {
                            Thread.Sleep(1000);

                            if (!MiningIsAlive())
                                return;
                        }

                        m_MiningState = MiningState.Unloading;

                        break;

                    case MiningState.Unloading:

                        m.LeftClickTo(rW.X + rW.Width - 36, rW.Y + 390);
                        m.RightClickTo(rW.X + iCx, rW.Y + iCy);
                        m.LeftClickTo(rW.X + iCx + 50, (rW.Y + iCy) + 200);

                        m.RightClickTo(rW.X + 331, rW.Y + 376);
                        m.LeftClickTo(rW.X + 376, rW.Y + 396);

                        m.LeftDrag(rW.X + 289, rW.Y + 381, rW.Width - 214, 505);

                        m_MiningState = MiningState.Cleaning_interface;

                        break;
                    case MiningState.Cleaning_interface:
                        m.LeftClickTo(rW.X + 662, rW.Y + 225);
                        m.LeftClickTo(rW.X + rW.Width - 120, rW.Y + 217);

                        Thread.Sleep(10000);

                        m.LeftClickTo(rW.X + 25, rW.Y + 25);
                        m.LeftClickTo(rW.X + 80, rW.Y + 588);
                        m.LeftClickTo(rW.X + iCx + 102, rW.Y + iCy - 256);
                        Thread.Sleep(1000);
                        m.LeftClickTo(rW.X + iCx + 15, rW.Y + iCy + 307);
                        Thread.Sleep(1000);


                        m_iCycles++;

                        m_MiningState = MiningState.Undocking;

                        break;
                }

                Thread.Sleep(250);

                m_MiningResetEvent.WaitOne();
            }
        }

        private void OpenMainMenu(ref Mouse _m, Rectangle _rW)
        {
            if (!_m.GetPixel(_rW.X + 62, _rW.Y + 86).Equals(Color.FromArgb(255, 255, 255)))
                return;

            _m.LeftClickTo(_rW.X + 90, _rW.Y + 86);
        }

        private void WarpToBelt(ref Mouse _m, Rectangle _rW)
        {
            _m.LeftClickTo(_rW.X + 260, _rW.Y + 137);
            _m.LeftClickTo(_rW.X + 500, _rW.Y + 127 + (21 * m_iBelt));

            Thread.Sleep(5000);
        }

        private void WarpToStation(ref Mouse _m, Rectangle _rW)
        {
            _m.LeftClickTo(_rW.X + 260, _rW.Y + 197);
            _m.LeftClickTo(_rW.X + 450, _rW.Y + 187 + (21 * m_iStation));

            Thread.Sleep(5000);
        }
        private void WarpToPortal(ref Mouse _m, Rectangle _rW)
        {
            _m.LeftClickTo(_rW.X + 260, _rW.Y + 180);
            _m.MoveTo(_rW.X + 400, _rW.Y + 170 + (21 * m_iPortal));
            _m.LeftClickTo(_rW.X + 500, _rW.Y + 250 + (21 * m_iPortal) + 63);

            Thread.Sleep(5000);
        }

        private void MiningStart()
        {
            Screen screen = Screen.FromHandle(GetEvehWnd());

            Left = screen.WorkingArea.Right - Width;
            Top = screen.WorkingArea.Bottom - Height;
            TopMost = true;
            Opacity = Opacity = .4;

            m_BotState = BotState.Started;
            m_MiningState = MiningState.Cleaning_interface;

            m_MiningThread = new Thread(Mining)
            {
                IsBackground = true
            };
            m_MiningThread.Start();

            if (!m_totalTime.IsRunning)
                m_totalTime.Start();
        }

        private void MiningStop(BotState _botState)
        {
            TopMost = false;
            Opacity = 1;

            m_BotState = _botState;
            m_MiningState = MiningState.Idle;
            m_iCycles = 0;
            m_iTries = 0;
            m_iSelection = 0;
            m_iStation = 1;
            m_iBelt = 1;

            m_MiningResetEvent.Set();

            m_MiningThread?.Join();

            if (m_totalTime.IsRunning)
                m_totalTime.Reset();
        }

        private void MiningPause()
        {
            m_BotState = BotState.Suspended;

            m_MiningResetEvent.Reset();

            if (!m_totalTime.IsRunning)
                m_totalTime.Stop();
        }

        private void MiningResume()
        {
            m_BotState = BotState.Started;

            m_MiningResetEvent.Set();

            if (!m_totalTime.IsRunning)
                m_totalTime.Start();
        }

        private void AnimateStatus()
        {
            Status.Text = string.Concat(StatusStrip.Text, new string('.', m_iNumberOfDot));

            m_iNumberOfDot = (m_iNumberOfDot + 1) % (MAX_DOT + 1);
        }

        private void FrmGui_Load(object sender, EventArgs e)
        {
            Chk1.Checked = Config.ReadBoolean("F1");
            Chk2.Checked = Config.ReadBoolean("F2");
            Chk3.Checked = Config.ReadBoolean("F3");

            NumB.Value = Config.ReadDecimal("MaxBeltWarp", 1);
            NumS.Value = Config.ReadDecimal("MaxStationWarp", 1);

            ChkPortal.Checked = Config.ReadBoolean("UsePortal");
        }

        private void FrmGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.AddOrUpdate("F1", Chk1.Checked);
            Config.AddOrUpdate("F2", Chk2.Checked);
            Config.AddOrUpdate("F3", Chk3.Checked);

            Config.AddOrUpdate("MaxBeltWarp", NumB.Value);
            Config.AddOrUpdate("MaxStationWarp", NumS.Value);

            Config.AddOrUpdate("UsePortal", ChkPortal.Checked);
        }

        private void NumB_ValueChanged(object sender, EventArgs e)
        {
            m_iBeltCnt = Convert.ToInt32(NumB.Value);
        }

        private void NumS_ValueChanged(object sender, EventArgs e)
        {
            m_iStationCnt = Convert.ToInt32(NumB.Value);

        }
    }
}