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
            this.Chk2 = new System.Windows.Forms.CheckBox();
            this.LblBeltV = new System.Windows.Forms.Label();
            this.LblStationV = new System.Windows.Forms.Label();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblAvrTime
            // 
            this.LblAvrTime.AutoSize = true;
            this.LblAvrTime.Location = new System.Drawing.Point(2, 121);
            this.LblAvrTime.Name = "LblAvrTime";
            this.LblAvrTime.Size = new System.Drawing.Size(100, 13);
            this.LblAvrTime.TabIndex = 2;
            this.LblAvrTime.Text = "Average cycle time:";
            // 
            // LblStation
            // 
            this.LblStation.AutoSize = true;
            this.LblStation.Location = new System.Drawing.Point(2, 22);
            this.LblStation.Name = "LblStation";
            this.LblStation.Size = new System.Drawing.Size(66, 13);
            this.LblStation.TabIndex = 4;
            this.LblStation.Text = "Use  station:";
            // 
            // LblCycle
            // 
            this.LblCycle.AutoSize = true;
            this.LblCycle.Location = new System.Drawing.Point(2, 101);
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
            this.LblTotalTime.Location = new System.Drawing.Point(2, 81);
            this.LblTotalTime.Name = "LblTotalTime";
            this.LblTotalTime.Size = new System.Drawing.Size(56, 13);
            this.LblTotalTime.TabIndex = 7;
            this.LblTotalTime.Text = "Total time:";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(2, 61);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(40, 13);
            this.LblStatus.TabIndex = 8;
            this.LblStatus.Text = "Status:";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(3, 137);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(104, 20);
            this.BtnStart.TabIndex = 9;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.LblStart_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Location = new System.Drawing.Point(107, 137);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(104, 20);
            this.BtnPause.TabIndex = 11;
            this.BtnPause.Text = "Pause";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // LblStatusV
            // 
            this.LblStatusV.AutoSize = true;
            this.LblStatusV.Location = new System.Drawing.Point(102, 61);
            this.LblStatusV.Name = "LblStatusV";
            this.LblStatusV.Size = new System.Drawing.Size(40, 13);
            this.LblStatusV.TabIndex = 20;
            this.LblStatusV.Text = "Status:";
            // 
            // LblTotalTimeV
            // 
            this.LblTotalTimeV.AutoSize = true;
            this.LblTotalTimeV.Location = new System.Drawing.Point(102, 81);
            this.LblTotalTimeV.Name = "LblTotalTimeV";
            this.LblTotalTimeV.Size = new System.Drawing.Size(40, 13);
            this.LblTotalTimeV.TabIndex = 21;
            this.LblTotalTimeV.Text = "Status:";
            // 
            // LblCycleV
            // 
            this.LblCycleV.AutoSize = true;
            this.LblCycleV.Location = new System.Drawing.Point(102, 101);
            this.LblCycleV.Name = "LblCycleV";
            this.LblCycleV.Size = new System.Drawing.Size(40, 13);
            this.LblCycleV.TabIndex = 22;
            this.LblCycleV.Text = "Status:";
            // 
            // LblAvrTimeV
            // 
            this.LblAvrTimeV.AutoSize = true;
            this.LblAvrTimeV.Location = new System.Drawing.Point(102, 121);
            this.LblAvrTimeV.Name = "LblAvrTimeV";
            this.LblAvrTimeV.Size = new System.Drawing.Size(40, 13);
            this.LblAvrTimeV.TabIndex = 23;
            this.LblAvrTimeV.Text = "Status:";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.StatusStrip.Location = new System.Drawing.Point(0, 160);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(215, 22);
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
            this.LblLasers.Location = new System.Drawing.Point(2, 41);
            this.LblLasers.Name = "LblLasers";
            this.LblLasers.Size = new System.Drawing.Size(76, 13);
            this.LblLasers.TabIndex = 27;
            this.LblLasers.Text = "Lasers to use :";
            // 
            // Chk1
            // 
            this.Chk1.AutoSize = true;
            this.Chk1.Location = new System.Drawing.Point(105, 40);
            this.Chk1.Name = "Chk1";
            this.Chk1.Size = new System.Drawing.Size(38, 17);
            this.Chk1.TabIndex = 28;
            this.Chk1.Text = "F1";
            this.Chk1.UseVisualStyleBackColor = true;
            // 
            // Chk3
            // 
            this.Chk3.AutoSize = true;
            this.Chk3.Location = new System.Drawing.Point(179, 40);
            this.Chk3.Name = "Chk3";
            this.Chk3.Size = new System.Drawing.Size(38, 17);
            this.Chk3.TabIndex = 34;
            this.Chk3.Text = "F3";
            this.Chk3.UseVisualStyleBackColor = true;
            // 
            // Chk2
            // 
            this.Chk2.AutoSize = true;
            this.Chk2.Location = new System.Drawing.Point(141, 40);
            this.Chk2.Name = "Chk2";
            this.Chk2.Size = new System.Drawing.Size(38, 17);
            this.Chk2.TabIndex = 35;
            this.Chk2.Text = "F2";
            this.Chk2.UseVisualStyleBackColor = true;
            // 
            // LblBeltV
            // 
            this.LblBeltV.AutoSize = true;
            this.LblBeltV.Location = new System.Drawing.Point(102, 2);
            this.LblBeltV.Name = "LblBeltV";
            this.LblBeltV.Size = new System.Drawing.Size(47, 13);
            this.LblBeltV.TabIndex = 36;
            this.LblBeltV.Text = "Belt n° 1";
            // 
            // LblStationV
            // 
            this.LblStationV.AutoSize = true;
            this.LblStationV.Location = new System.Drawing.Point(102, 22);
            this.LblStationV.Name = "LblStationV";
            this.LblStationV.Size = new System.Drawing.Size(62, 13);
            this.LblStationV.TabIndex = 37;
            this.LblStationV.Text = "Station n° 1";
            // 
            // FrmGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 182);
            this.Controls.Add(this.LblStationV);
            this.Controls.Add(this.LblBeltV);
            this.Controls.Add(this.Chk2);
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
            this.Controls.Add(this.LblAvrTime);
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
        private CheckBox Chk2;
        private Label LblBeltV;
        private Label LblStationV;
    }
}

