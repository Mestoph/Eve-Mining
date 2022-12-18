using Eve_Mining.Enums;
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
        private int m_iCycles = 0;
        private int m_iSelection = 0;
        private int m_iTries = 0;

        #endregion
        #region Constructor & Destructor

        public FrmGui()
        {
            InitializeComponent();

            Api.RegisterHotKey(this.Handle, START_HOTKEY_ID, Api.MOD_ALT, (int)Keys.F2);
            Api.RegisterHotKey(this.Handle, PAUSE_HOTKEY_ID, Api.MOD_ALT, (int)Keys.F3);

            this.m_MiningState = MiningState.Idle;
            this.m_BotState = BotState.None;

            this.m_GuiUpdateTimer = new System.Windows.Forms.Timer();
            this.m_GuiUpdateTimer.Tick += this.TimerTick;
            this.m_GuiUpdateTimer.Interval = 250;
            this.m_GuiUpdateTimer.Start();

            this.GuiUpdate();

            this.StatusStrip.Text = INITIALIZING;

            this.KeyPreview = true;
        }

        ~FrmGui()
        {
            if (this.m_GuiUpdateTimer != null)
            {
                if (this.m_GuiUpdateTimer.Enabled)
                    this.m_GuiUpdateTimer.Stop();

                this.m_GuiUpdateTimer = null;
            }

            if (this.m_MiningThread != null)
            {
                if (this.m_MiningThread.IsAlive)
                    this.m_MiningThread.Abort();

                this.m_MiningThread = null;
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
                        this.BtnStart.PerformClick();

                        break;

                    case PAUSE_HOTKEY_ID:
                        this.BtnPause.PerformClick();

                        break;
                }
            }

            base.WndProc(ref _m);
        }

        #endregion
        #region Events

        private void TimerTick(object sender, EventArgs e)
        {
            this.GuiUpdate();
        }

        private void LblStart_Click(object sender, EventArgs e)
        {
            if (this.m_BotState == BotState.Waiting || this.m_BotState == BotState.Stopped)
                this.MiningStart();
            else
                this.MiningStop(BotState.Stopped);
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (this.m_BotState == BotState.Started)
                this.MiningPause();
            else
                this.MiningResume();
        }

        #endregion
        #region Functions

        private void GuiUpdate()
        {
            if (!this.IsEve())
                this.MiningStop(BotState.None);

            else if (this.m_BotState == BotState.None)
                this.m_BotState = BotState.Waiting;

            switch (this.m_BotState)
            {
                case BotState.None:
                    this.BtnStart.Enabled = false;
                    this.BtnStart.Text = string.Concat(START, SPACE, ALT_F2);

                    this.BtnPause.Enabled = false;
                    this.BtnPause.Text = string.Concat(PAUSE, SPACE, ALT_F3);

                    this.StatusStrip.Text = WAITING_GAME;

                    break;

                case BotState.Waiting:
                case BotState.Stopped:
                    this.BtnStart.Enabled = true;
                    this.BtnStart.Text = string.Concat(START, SPACE, ALT_F2); ;

                    this.BtnPause.Enabled = false;
                    this.BtnPause.Text = string.Concat(PAUSE, SPACE, ALT_F3);

                    this.StatusStrip.Text = WAITING_START;

                    break;

                case BotState.Started:
                    this.BtnStart.Enabled = true;
                    this.BtnStart.Text = string.Concat(STOP, SPACE, ALT_F2);

                    this.BtnPause.Enabled = true;
                    this.BtnPause.Text = string.Concat(PAUSE, SPACE, ALT_F3);

                    this.StatusStrip.Text = RUNNING;

                    break;

                case BotState.Suspended:
                    this.BtnStart.Enabled = true;
                    this.BtnStart.Text = string.Concat(STOP, SPACE, ALT_F2);

                    this.BtnPause.Enabled = true;
                    this.BtnPause.Text = string.Concat(RESUME, SPACE, ALT_F3);

                    this.StatusStrip.Text = WAITING_RESUME;

                    break;
            }

            this.AnimateStatus();

            this.LblBeltV.Text = string.Format(BELT_NUMBER, this.m_iBelt);
            this.LblStationV.Text = string.Format(STATION_NUMBER, this.m_iStation);
            this.LblStatusV.Text = this.m_MiningState.ToString().Replace('_', ' ');

            TimeSpan t = this.m_totalTime.Elapsed;
            this.LblTotalTimeV.Text = t.ToString(TIME);

            this.LblCycleV.Text = this.m_iCycles.ToString();

            if (this.m_iCycles <= 0)
                this.LblAvrTimeV.Text = NOT_AVAILABLE;
            else
            {
                t = new TimeSpan(t.Ticks / this.m_iCycles);
                this.LblAvrTimeV.Text = t.ToString(TIME);
            }
        }

        private bool IsEve()
        {
            if (this.GetEvehWnd() != IntPtr.Zero)
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
            if (this.m_BotState == BotState.Waiting || this.m_BotState == BotState.Stopped || this.m_BotState == BotState.None)
                return false;

            return true;
        }

        private void Mining()
        {
            Mouse m = new Mouse
            {
                Delay = 250,
                BackReturn = true
            };

            while (true)
            {
                if (!this.MiningIsAlive())
                    return;

                IntPtr hWnd = GetEvehWnd();

                if (hWnd == IntPtr.Zero)
                    return;

                if (!Api.ShowWindow(hWnd, Api.SW_SHOWMAXIMIZED))
                    return;

                if (!Api.SetForegroundWindow(hWnd))
                    return;

                if (!Api.GetWindowRect(hWnd, out Rectangle rW))
                    return;

                m.LeftClickTo(862, 949);

                switch (this.m_MiningState)
                {
                    case MiningState.Idle:

                        this.m_MiningState = MiningState.Undocking;

                        break;

                    case MiningState.Undocking:

                        m.LeftClickTo(rW.Width / 2, rW.Height / 2);

                        while (!m.GetPixel(62, 109).Equals(Color.FromArgb(255, 255, 255)))
                        {
                            Thread.Sleep(1000);

                            if (!this.MiningIsAlive())
                                return;
                        }

                        this.m_MiningState = MiningState.Warping_to_belt;

                        break;

                    case MiningState.Warping_to_belt:

                        this.OpenMainMenu(ref m);
                        this.WarpToBelt(ref m);

                        while (m.GetPixel(923, 970).GetHue() > 10)
                        {
                            Thread.Sleep(1000);

                            if (!this.MiningIsAlive())
                                return;
                        }

                        this.m_MiningState = MiningState.Selecting_target;

                        break;

                    case MiningState.Selecting_target:
                        bool exit = false;

                        m.LeftClickTo(1525, 260);
                        m.LeftClickTo(1525, 317 + (24 * this.m_iSelection));

                        while (!m.GetPixel(1374, 186).Equals(Color.FromArgb(255, 255, 255))
                            || (m.GetPixel(1365, 317 + (24 * this.m_iSelection)).Equals(Color.FromArgb(255, 255, 255)) &&
                                m.GetPixel(1365, 321 + (24 * this.m_iSelection)).Equals(Color.FromArgb(255, 255, 255))))
                        {
                            Thread.Sleep(250);

                            if (!this.MiningIsAlive())
                                return;

                            if (this.m_iTries < 10)
                            {

                                if (this.m_iSelection++ > 10)
                                {
                                    this.m_iSelection = 0;

                                    this.m_iBelt++;

                                    if (this.m_iBelt > 8)
                                    {
                                        this.m_iTries++;

                                        this.m_iBelt = 1;
                                    }

                                    this.m_MiningState = MiningState.Warping_to_belt;
                                }

                                exit = true;

                                break;
                            }

                            m.LeftClickTo(1525, 317 + (22 * this.m_iSelection));
                        }

                        if (!exit)
                            this.m_MiningState = MiningState.Approaching;

                        break;

                    case MiningState.Approaching:

                        m.LeftClickTo(1374, 186);

                        while (m.GetPixel(923, 970).GetHue() > 10)
                        {
                            Thread.Sleep(1000);

                            if (!this.MiningIsAlive())
                                return;

                            if (m.GetPixel(1507, 177).Equals(Color.FromArgb(255, 255, 255)))
                                break;
                        }

                        this.m_MiningState = MiningState.Locking_target;

                        break;

                    case MiningState.Locking_target:

                        while (!m.GetPixel(1507, 177).Equals(Color.FromArgb(255, 255, 255)))
                        {
                            Thread.Sleep(1000);

                            if (!this.MiningIsAlive())
                                return;
                        }

                        m.LeftClickTo(1507, 177);

                        this.m_MiningState = MiningState.Fiering_lasers;

                        break;

                    case MiningState.Fiering_lasers:

                        if (this.Chk1.Checked)
                            m.LeftClickTo(1067, 887);

                        if (this.Chk2.Checked)
                            m.LeftClickTo(1120, 887);

                        if (this.Chk3.Checked)
                            m.LeftClickTo(1170, 887);

                        Thread.Sleep(3000);

                        this.m_MiningState = MiningState.Mining;

                        break;

                    case MiningState.Mining:

                        // Open inventory
                        m.RightClickTo(rW.Width / 2, rW.Height / 2);
                        m.LeftClickTo((rW.Width / 2) + 50, (rW.Height / 2) + 15);
                        m.RightClickTo(rW.Width / 2, rW.Height / 2);
                        m.LeftClickTo((rW.Width / 2) + 50, (rW.Height / 2) + 295);

                        bool end = false;

                        bool f = m.GetPixel(334, 344).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00FFFF"));
                        bool s = m.GetPixel(540, 344).BasedColorFromHue24().Equals(ColorTranslator.FromHtml("#00FFFF"));

                        while (!f || f != s)
                        {
                            if (!m.GetPixel(1507, 177).Equals(Color.FromArgb(255, 255, 255)))
                            {
                                end = true;

                                break;
                            }

                            Thread.Sleep(1000);

                            if (!this.MiningIsAlive())
                                return;
                        }

                        if (end)
                        {
                            this.m_MiningState = MiningState.Selecting_target;

                            break;
                        }

                        this.m_MiningState = MiningState.Warping_to_station;

                        break;

                    case MiningState.Warping_to_station:

                        // Close inventory
                        m.LeftClickTo(25, 340);

                        this.m_MiningState = MiningState.Docking;

                        break;

                    case MiningState.Docking:

                        this.OpenMainMenu(ref m);
                        this.WarpToStation(ref m);

                        if (this.m_iStation++ > 2)
                            this.m_iStation = 1;

                        while (m.GetPixel(923, 970).GetHue() > 10)
                        {
                            Thread.Sleep(1000);

                            if (!this.MiningIsAlive())
                                return;
                        }

                        m.LeftClickTo(1366, 256);
                        m.LeftClickTo(1496, 315);
                        m.LeftClickTo(1438, 186);

                        while (!m.GetPixel(1877, 53).Equals(Color.FromArgb(255, 255, 255)))
                        {
                            Thread.Sleep(1000);

                            if (!this.MiningIsAlive())
                                return;
                        }

                        this.m_MiningState = MiningState.Unloading;

                        break;

                    case MiningState.Unloading:

                        m.LeftClickTo(1884, 413);
                        m.RightClickTo(rW.Width / 2, rW.Height / 2);
                        m.LeftClickTo((rW.Width / 2) + 50, (rW.Height / 2) + 200);

                        m.RightClickTo(331, 399);
                        m.LeftClickTo(376, 419);

                        m.LeftDrag(289, 404, 1706, 528);

                        this.m_MiningState = MiningState.Cleaning_interface;

                        break;
                    case MiningState.Cleaning_interface:

                        m.LeftClickTo(665, 323);
                        m.LeftClickTo(1800, 240);

                        Thread.Sleep(10000);

                        this.m_iCycles++;

                        this.m_MiningState = MiningState.Undocking;

                        break;
                }

                Thread.Sleep(250);

                this.m_MiningResetEvent.WaitOne();
            }
        }

        private void OpenMainMenu(ref Mouse _m)
        {
            if (!_m.GetPixel(62, 109).Equals(Color.FromArgb(255, 255, 255)))
                return;

            _m.LeftClickTo(90, 108);
        }

        private void WarpToBelt(ref Mouse _m)
        {
            _m.LeftClickTo(260, 160);
            _m.LeftClickTo(500, 152 + (16 * this.m_iBelt));

            Thread.Sleep(5000);
        }

        private void WarpToStation(ref Mouse _m)
        {
            _m.LeftClickTo(260, 220);
            _m.LeftClickTo(450, 220);

            Thread.Sleep(5000);
        }

        private void MiningStart()
        {
            Screen screen = Screen.FromHandle(GetEvehWnd());

            this.Left = screen.WorkingArea.Right - this.Width;
            this.Top = screen.WorkingArea.Bottom - this.Height;
            this.TopMost = true;
            this.Opacity = this.Opacity = .4;

            this.m_BotState = BotState.Started;
            this.m_MiningState = MiningState.Cleaning_interface;

            this.m_MiningThread = new Thread(this.Mining)
            {
                IsBackground = true
            };
            this.m_MiningThread.Start();

            if (!this.m_totalTime.IsRunning)
                this.m_totalTime.Start();
        }

        private void MiningStop(BotState _botState)
        {
            this.TopMost = false;
            this.Opacity = 1;

            this.m_BotState = _botState;
            this.m_MiningState = MiningState.Idle;
            this.m_iCycles = 0;
            this.m_iTries = 0;
            this.m_iSelection = 0;
            this.m_iStation = 1;
            this.m_iBelt = 1;

            this.m_MiningResetEvent.Set();

            this.m_MiningThread?.Join();

            if (this.m_totalTime.IsRunning)
                this.m_totalTime.Reset();
        }

        private void MiningPause()
        {
            this.m_BotState = BotState.Suspended;

            this.m_MiningResetEvent.Reset();

            if (!this.m_totalTime.IsRunning)
                this.m_totalTime.Stop();
        }

        private void MiningResume()
        {
            this.m_BotState = BotState.Started;

            this.m_MiningResetEvent.Set();

            if (!this.m_totalTime.IsRunning)
                this.m_totalTime.Start();
        }

        private void AnimateStatus()
        {
            this.Status.Text = string.Concat(this.StatusStrip.Text, new string('.', this.m_iNumberOfDot));

            this.m_iNumberOfDot = (this.m_iNumberOfDot + 1) % (MAX_DOT + 1);
        }

        private void FrmGui_Load(object sender, EventArgs e)
        {
            Config c = new Config();

            this.Chk1.Checked = c.ReadBoolean("F1");
            this.Chk2.Checked = c.ReadBoolean("F2");
            this.Chk3.Checked = c.ReadBoolean("F3");
        }

        private void FrmGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config c = new Config();

            c.AddOrUpdate("F1", this.Chk1.Checked);
            c.AddOrUpdate("F2", this.Chk2.Checked);
            c.AddOrUpdate("F3", this.Chk3.Checked);
        }
    }
}