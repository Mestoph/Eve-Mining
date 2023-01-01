namespace Eve_Mining
{
    using System.Windows.Forms;

    partial class FrmGui
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblAvrTime = new System.Windows.Forms.Label();
            this.LblStation = new System.Windows.Forms.Label();
            this.LblCycle = new System.Windows.Forms.Label();
            this.LblBelt = new System.Windows.Forms.Label();
            this.LblTotalTime = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.LblStatusV = new System.Windows.Forms.Label();
            this.LblTotalTimeV = new System.Windows.Forms.Label();
            this.LblCycleV = new System.Windows.Forms.Label();
            this.LblAvrTimeV = new System.Windows.Forms.Label();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblLasers = new System.Windows.Forms.Label();
            this.Chk1 = new System.Windows.Forms.CheckBox();
            this.Chk3 = new System.Windows.Forms.CheckBox();
            this.LblBeltV = new System.Windows.Forms.Label();
            this.LblStationV = new System.Windows.Forms.Label();
            this.NumB = new System.Windows.Forms.NumericUpDown();
            this.LblMaxB = new System.Windows.Forms.Label();
            this.LblMaxS = new System.Windows.Forms.Label();
            this.NumS = new System.Windows.Forms.NumericUpDown();
            this.ChkPortal = new System.Windows.Forms.CheckBox();
            this.ChkDrone = new System.Windows.Forms.CheckBox();
            this.ChkFleet = new System.Windows.Forms.CheckBox();
            this.LblFleet = new System.Windows.Forms.Label();
            this.LblFleetI = new System.Windows.Forms.Label();
            this.Chk4 = new System.Windows.Forms.CheckBox();
            this.Chk8 = new System.Windows.Forms.CheckBox();
            this.Chk7 = new System.Windows.Forms.CheckBox();
            this.Chk6 = new System.Windows.Forms.CheckBox();
            this.Chk5 = new System.Windows.Forms.CheckBox();
            this.Chk2 = new System.Windows.Forms.CheckBox();
            this.lblMisc = new System.Windows.Forms.Label();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumS)).BeginInit();
            this.SuspendLayout();
            // 
            // LblAvrTime
            // 
            this.LblAvrTime.AutoSize = true;
            this.LblAvrTime.Location = new System.Drawing.Point(2, 174);
            this.LblAvrTime.Name = "LblAvrTime";
            this.LblAvrTime.Size = new System.Drawing.Size(82, 13);
            this.LblAvrTime.TabIndex = 2;
            this.LblAvrTime.Text = "Avg. cycle time:";
            // 
            // LblStation
            // 
            this.LblStation.AutoSize = true;
            this.LblStation.Location = new System.Drawing.Point(2, 21);
            this.LblStation.Name = "LblStation";
            this.LblStation.Size = new System.Drawing.Size(66, 13);
            this.LblStation.TabIndex = 4;
            this.LblStation.Text = "Use  station:";
            // 
            // LblCycle
            // 
            this.LblCycle.AutoSize = true;
            this.LblCycle.Location = new System.Drawing.Point(2, 161);
            this.LblCycle.Name = "LblCycle";
            this.LblCycle.Size = new System.Drawing.Size(36, 13);
            this.LblCycle.TabIndex = 5;
            this.LblCycle.Text = "Cycle:";
            // 
            // LblBelt
            // 
            this.LblBelt.AutoSize = true;
            this.LblBelt.Location = new System.Drawing.Point(2, 2);
            this.LblBelt.Name = "LblBelt";
            this.LblBelt.Size = new System.Drawing.Size(49, 13);
            this.LblBelt.TabIndex = 6;
            this.LblBelt.Text = "Use belt:";
            // 
            // LblTotalTime
            // 
            this.LblTotalTime.AutoSize = true;
            this.LblTotalTime.Location = new System.Drawing.Point(2, 148);
            this.LblTotalTime.Name = "LblTotalTime";
            this.LblTotalTime.Size = new System.Drawing.Size(56, 13);
            this.LblTotalTime.TabIndex = 7;
            this.LblTotalTime.Text = "Total time:";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(2, 135);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(40, 13);
            this.LblStatus.TabIndex = 8;
            this.LblStatus.Text = "Status:";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(-1, 190);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(94, 20);
            this.BtnStart.TabIndex = 9;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.LblStart_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Location = new System.Drawing.Point(92, 190);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(94, 20);
            this.BtnPause.TabIndex = 11;
            this.BtnPause.Text = "Pause";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // LblStatusV
            // 
            this.LblStatusV.ForeColor = System.Drawing.Color.Green;
            this.LblStatusV.Location = new System.Drawing.Point(76, 135);
            this.LblStatusV.Name = "LblStatusV";
            this.LblStatusV.Size = new System.Drawing.Size(108, 13);
            this.LblStatusV.TabIndex = 20;
            this.LblStatusV.Text = "Status";
            this.LblStatusV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTotalTimeV
            // 
            this.LblTotalTimeV.ForeColor = System.Drawing.Color.Green;
            this.LblTotalTimeV.Location = new System.Drawing.Point(76, 148);
            this.LblTotalTimeV.Name = "LblTotalTimeV";
            this.LblTotalTimeV.Size = new System.Drawing.Size(108, 13);
            this.LblTotalTimeV.TabIndex = 21;
            this.LblTotalTimeV.Text = "Status";
            this.LblTotalTimeV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblCycleV
            // 
            this.LblCycleV.ForeColor = System.Drawing.Color.Green;
            this.LblCycleV.Location = new System.Drawing.Point(76, 161);
            this.LblCycleV.Name = "LblCycleV";
            this.LblCycleV.Size = new System.Drawing.Size(108, 13);
            this.LblCycleV.TabIndex = 22;
            this.LblCycleV.Text = "Status";
            this.LblCycleV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblAvrTimeV
            // 
            this.LblAvrTimeV.ForeColor = System.Drawing.Color.Green;
            this.LblAvrTimeV.Location = new System.Drawing.Point(76, 174);
            this.LblAvrTimeV.Name = "LblAvrTimeV";
            this.LblAvrTimeV.Size = new System.Drawing.Size(108, 13);
            this.LblAvrTimeV.TabIndex = 23;
            this.LblAvrTimeV.Text = "Status";
            this.LblAvrTimeV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.StatusStrip.Location = new System.Drawing.Point(0, 209);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(185, 22);
            this.StatusStrip.TabIndex = 24;
            this.StatusStrip.Text = "Status";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 17);
            // 
            // LblLasers
            // 
            this.LblLasers.AutoSize = true;
            this.LblLasers.Location = new System.Drawing.Point(2, 43);
            this.LblLasers.Name = "LblLasers";
            this.LblLasers.Size = new System.Drawing.Size(76, 13);
            this.LblLasers.TabIndex = 27;
            this.LblLasers.Text = "Lasers to use :";
            // 
            // Chk1
            // 
            this.Chk1.Appearance = System.Windows.Forms.Appearance.Button;
            this.Chk1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk1.Location = new System.Drawing.Point(79, 39);
            this.Chk1.Name = "Chk1";
            this.Chk1.Size = new System.Drawing.Size(28, 20);
            this.Chk1.TabIndex = 28;
            this.Chk1.Text = "F1";
            this.Chk1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk1.UseVisualStyleBackColor = true;
            // 
            // Chk3
            // 
            this.Chk3.Appearance = System.Windows.Forms.Appearance.Button;
            this.Chk3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk3.Location = new System.Drawing.Point(131, 39);
            this.Chk3.Name = "Chk3";
            this.Chk3.Size = new System.Drawing.Size(28, 20);
            this.Chk3.TabIndex = 34;
            this.Chk3.Text = "F3";
            this.Chk3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk3.UseVisualStyleBackColor = true;
            // 
            // LblBeltV
            // 
            this.LblBeltV.AutoSize = true;
            this.LblBeltV.Location = new System.Drawing.Point(66, 2);
            this.LblBeltV.Name = "LblBeltV";
            this.LblBeltV.Size = new System.Drawing.Size(47, 13);
            this.LblBeltV.TabIndex = 36;
            this.LblBeltV.Text = "Belt n° 1";
            // 
            // LblStationV
            // 
            this.LblStationV.AutoSize = true;
            this.LblStationV.Location = new System.Drawing.Point(66, 21);
            this.LblStationV.Name = "LblStationV";
            this.LblStationV.Size = new System.Drawing.Size(62, 13);
            this.LblStationV.TabIndex = 37;
            this.LblStationV.Text = "Station n° 1";
            // 
            // NumB
            // 
            this.NumB.Location = new System.Drawing.Point(156, 0);
            this.NumB.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NumB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumB.Name = "NumB";
            this.NumB.Size = new System.Drawing.Size(28, 20);
            this.NumB.TabIndex = 38;
            this.NumB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumB.ValueChanged += new System.EventHandler(this.NumB_ValueChanged);
            // 
            // LblMaxB
            // 
            this.LblMaxB.AutoSize = true;
            this.LblMaxB.Location = new System.Drawing.Point(128, 2);
            this.LblMaxB.Name = "LblMaxB";
            this.LblMaxB.Size = new System.Drawing.Size(30, 13);
            this.LblMaxB.TabIndex = 39;
            this.LblMaxB.Text = "Max:";
            // 
            // LblMaxS
            // 
            this.LblMaxS.AutoSize = true;
            this.LblMaxS.Location = new System.Drawing.Point(128, 21);
            this.LblMaxS.Name = "LblMaxS";
            this.LblMaxS.Size = new System.Drawing.Size(30, 13);
            this.LblMaxS.TabIndex = 40;
            this.LblMaxS.Text = "Max:";
            // 
            // NumS
            // 
            this.NumS.Location = new System.Drawing.Point(156, 19);
            this.NumS.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NumS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumS.Name = "NumS";
            this.NumS.Size = new System.Drawing.Size(28, 20);
            this.NumS.TabIndex = 41;
            this.NumS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumS.ValueChanged += new System.EventHandler(this.NumS_ValueChanged);
            // 
            // ChkPortal
            // 
            this.ChkPortal.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkPortal.Location = new System.Drawing.Point(79, 76);
            this.ChkPortal.Name = "ChkPortal";
            this.ChkPortal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkPortal.Size = new System.Drawing.Size(106, 20);
            this.ChkPortal.TabIndex = 43;
            this.ChkPortal.Text = "Use portals";
            this.ChkPortal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkPortal.UseVisualStyleBackColor = true;
            // 
            // ChkDrone
            // 
            this.ChkDrone.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkDrone.Location = new System.Drawing.Point(79, 94);
            this.ChkDrone.Name = "ChkDrone";
            this.ChkDrone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkDrone.Size = new System.Drawing.Size(106, 20);
            this.ChkDrone.TabIndex = 45;
            this.ChkDrone.Text = "Use drones";
            this.ChkDrone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkDrone.UseVisualStyleBackColor = true;
            // 
            // ChkFleet
            // 
            this.ChkFleet.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkFleet.Location = new System.Drawing.Point(79, 112);
            this.ChkFleet.Name = "ChkFleet";
            this.ChkFleet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkFleet.Size = new System.Drawing.Size(106, 20);
            this.ChkFleet.TabIndex = 47;
            this.ChkFleet.Text = "Use fleet";
            this.ChkFleet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkFleet.UseVisualStyleBackColor = true;
            // 
            // LblFleet
            // 
            this.LblFleet.AutoSize = true;
            this.LblFleet.Location = new System.Drawing.Point(6, 107);
            this.LblFleet.Name = "LblFleet";
            this.LblFleet.Size = new System.Drawing.Size(0, 13);
            this.LblFleet.TabIndex = 46;
            // 
            // LblFleetI
            // 
            this.LblFleetI.AutoSize = true;
            this.LblFleetI.ForeColor = System.Drawing.Color.DarkRed;
            this.LblFleetI.Location = new System.Drawing.Point(2, 116);
            this.LblFleetI.Name = "LblFleetI";
            this.LblFleetI.Size = new System.Drawing.Size(76, 13);
            this.LblFleetI.TabIndex = 48;
            this.LblFleetI.Text = "Disable warps!";
            // 
            // Chk4
            // 
            this.Chk4.Appearance = System.Windows.Forms.Appearance.Button;
            this.Chk4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk4.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.Chk4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Chk4.Location = new System.Drawing.Point(157, 39);
            this.Chk4.Name = "Chk4";
            this.Chk4.Size = new System.Drawing.Size(28, 20);
            this.Chk4.TabIndex = 49;
            this.Chk4.Text = "F4";
            this.Chk4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk4.UseVisualStyleBackColor = true;
            // 
            // Chk8
            // 
            this.Chk8.Appearance = System.Windows.Forms.Appearance.Button;
            this.Chk8.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk8.Location = new System.Drawing.Point(157, 57);
            this.Chk8.Name = "Chk8";
            this.Chk8.Size = new System.Drawing.Size(28, 20);
            this.Chk8.TabIndex = 51;
            this.Chk8.Text = "F8";
            this.Chk8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk8.UseVisualStyleBackColor = true;
            // 
            // Chk7
            // 
            this.Chk7.Appearance = System.Windows.Forms.Appearance.Button;
            this.Chk7.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk7.Location = new System.Drawing.Point(131, 57);
            this.Chk7.Name = "Chk7";
            this.Chk7.Size = new System.Drawing.Size(28, 20);
            this.Chk7.TabIndex = 52;
            this.Chk7.Text = "F7";
            this.Chk7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk7.UseVisualStyleBackColor = true;
            // 
            // Chk6
            // 
            this.Chk6.Appearance = System.Windows.Forms.Appearance.Button;
            this.Chk6.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk6.Location = new System.Drawing.Point(105, 57);
            this.Chk6.Name = "Chk6";
            this.Chk6.Size = new System.Drawing.Size(28, 20);
            this.Chk6.TabIndex = 53;
            this.Chk6.Text = "F6";
            this.Chk6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk6.UseVisualStyleBackColor = true;
            // 
            // Chk5
            // 
            this.Chk5.Appearance = System.Windows.Forms.Appearance.Button;
            this.Chk5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk5.Location = new System.Drawing.Point(79, 57);
            this.Chk5.Name = "Chk5";
            this.Chk5.Size = new System.Drawing.Size(28, 20);
            this.Chk5.TabIndex = 54;
            this.Chk5.Text = "F5";
            this.Chk5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk5.UseVisualStyleBackColor = true;
            // 
            // Chk2
            // 
            this.Chk2.Appearance = System.Windows.Forms.Appearance.Button;
            this.Chk2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk2.Location = new System.Drawing.Point(105, 39);
            this.Chk2.Name = "Chk2";
            this.Chk2.Size = new System.Drawing.Size(28, 20);
            this.Chk2.TabIndex = 55;
            this.Chk2.Text = "F2";
            this.Chk2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chk2.UseVisualStyleBackColor = true;
            // 
            // lblMisc
            // 
            this.lblMisc.AutoSize = true;
            this.lblMisc.Location = new System.Drawing.Point(2, 80);
            this.lblMisc.Name = "lblMisc";
            this.lblMisc.Size = new System.Drawing.Size(77, 13);
            this.lblMisc.TabIndex = 56;
            this.lblMisc.Text = "Miscellaneous:";
            // 
            // FrmGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 231);
            this.Controls.Add(this.LblAvrTime);
            this.Controls.Add(this.lblMisc);
            this.Controls.Add(this.NumB);
            this.Controls.Add(this.Chk2);
            this.Controls.Add(this.Chk5);
            this.Controls.Add(this.Chk6);
            this.Controls.Add(this.Chk7);
            this.Controls.Add(this.Chk8);
            this.Controls.Add(this.Chk4);
            this.Controls.Add(this.LblFleetI);
            this.Controls.Add(this.ChkFleet);
            this.Controls.Add(this.LblFleet);
            this.Controls.Add(this.ChkDrone);
            this.Controls.Add(this.ChkPortal);
            this.Controls.Add(this.NumS);
            this.Controls.Add(this.LblMaxS);
            this.Controls.Add(this.LblMaxB);
            this.Controls.Add(this.LblStationV);
            this.Controls.Add(this.LblBeltV);
            this.Controls.Add(this.Chk3);
            this.Controls.Add(this.Chk1);
            this.Controls.Add(this.LblLasers);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.LblAvrTimeV);
            this.Controls.Add(this.LblCycleV);
            this.Controls.Add(this.LblTotalTimeV);
            this.Controls.Add(this.LblStatusV);
            this.Controls.Add(this.BtnPause);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.LblTotalTime);
            this.Controls.Add(this.LblBelt);
            this.Controls.Add(this.LblCycle);
            this.Controls.Add(this.LblStation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eve Online - Mining Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGui_FormClosing);
            this.Load += new System.EventHandler(this.FrmGui_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label LblAvrTime;
        private Label LblStation;
        private Label LblCycle;
        private Label LblBelt;
        private Label LblTotalTime;
        private Label LblStatus;
        private Button BtnStart;
        private Button BtnPause;
        private Label LblStatusV;
        private Label LblTotalTimeV;
        private Label LblCycleV;
        private Label LblAvrTimeV;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel Status;
        private Label LblLasers;
        private CheckBox Chk1;
        private CheckBox Chk3;
        private Label LblBeltV;
        private Label LblStationV;
        private NumericUpDown NumB;
        private Label LblMaxB;
        private Label LblMaxS;
        private NumericUpDown NumS;
        private CheckBox ChkPortal;
        private CheckBox ChkDrone;
        private CheckBox ChkFleet;
        private Label LblFleet;
        private Label LblFleetI;
        private CheckBox Chk4;
        private CheckBox Chk8;
        private CheckBox Chk7;
        private CheckBox Chk6;
        private CheckBox Chk5;
        private CheckBox Chk2;
        private Label lblMisc;
    }
}

