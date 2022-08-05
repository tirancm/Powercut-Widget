namespace PowercutGadget
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.settingBtn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_timeslot1 = new System.Windows.Forms.Label();
            this.lbl_timeslot2 = new System.Windows.Forms.Label();
            this.lbl_timeslot3 = new System.Windows.Forms.Label();
            this.lastSynced = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.blockUiPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingBtn)).BeginInit();
            this.blockUiPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::PowercutGadget.Properties.Resources.sync;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(188, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::PowercutGadget.Properties.Resources.top_bar;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(240, 41);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.BackgroundImage = global::PowercutGadget.Properties.Resources.top_back_color;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Image = global::PowercutGadget.Properties.Resources.close_btn;
            this.closeBtn.Location = new System.Drawing.Point(212, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(16, 16);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseLeave += new System.EventHandler(this.closeBtn_MouseLeave);
            this.closeBtn.MouseHover += new System.EventHandler(this.closeBtn_MouseHover);
            // 
            // settingBtn
            // 
            this.settingBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingBtn.BackgroundImage = global::PowercutGadget.Properties.Resources.top_back_color;
            this.settingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingBtn.Image = global::PowercutGadget.Properties.Resources.setting_btn1;
            this.settingBtn.Location = new System.Drawing.Point(12, 12);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(16, 16);
            this.settingBtn.TabIndex = 2;
            this.settingBtn.TabStop = false;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            this.settingBtn.MouseLeave += new System.EventHandler(this.settingBtn_MouseLeave);
            this.settingBtn.MouseHover += new System.EventHandler(this.settingBtn_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::PowercutGadget.Properties.Resources.top_bar;
            this.label1.Location = new System.Drawing.Point(49, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Powercut Schedule";
            // 
            // lbl_timeslot1
            // 
            this.lbl_timeslot1.AutoSize = true;
            this.lbl_timeslot1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timeslot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeslot1.ForeColor = System.Drawing.Color.White;
            this.lbl_timeslot1.Location = new System.Drawing.Point(12, 52);
            this.lbl_timeslot1.Name = "lbl_timeslot1";
            this.lbl_timeslot1.Size = new System.Drawing.Size(67, 16);
            this.lbl_timeslot1.TabIndex = 4;
            this.lbl_timeslot1.Text = "1. syncing";
            // 
            // lbl_timeslot2
            // 
            this.lbl_timeslot2.AutoSize = true;
            this.lbl_timeslot2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timeslot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeslot2.ForeColor = System.Drawing.Color.White;
            this.lbl_timeslot2.Location = new System.Drawing.Point(12, 87);
            this.lbl_timeslot2.Name = "lbl_timeslot2";
            this.lbl_timeslot2.Size = new System.Drawing.Size(67, 16);
            this.lbl_timeslot2.TabIndex = 4;
            this.lbl_timeslot2.Text = "2. syncing";
            // 
            // lbl_timeslot3
            // 
            this.lbl_timeslot3.AutoSize = true;
            this.lbl_timeslot3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_timeslot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeslot3.ForeColor = System.Drawing.Color.White;
            this.lbl_timeslot3.Location = new System.Drawing.Point(12, 122);
            this.lbl_timeslot3.Name = "lbl_timeslot3";
            this.lbl_timeslot3.Size = new System.Drawing.Size(67, 16);
            this.lbl_timeslot3.TabIndex = 4;
            this.lbl_timeslot3.Text = "3. syncing";
            // 
            // lastSynced
            // 
            this.lastSynced.AutoSize = true;
            this.lastSynced.BackColor = System.Drawing.Color.Transparent;
            this.lastSynced.Location = new System.Drawing.Point(21, 158);
            this.lastSynced.Name = "lastSynced";
            this.lastSynced.Size = new System.Drawing.Size(43, 13);
            this.lastSynced.TabIndex = 5;
            this.lastSynced.Text = "syncing";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // blockUiPanel
            // 
            this.blockUiPanel.BackColor = System.Drawing.Color.Transparent;
            this.blockUiPanel.Controls.Add(this.label3);
            this.blockUiPanel.Controls.Add(this.label2);
            this.blockUiPanel.Location = new System.Drawing.Point(0, 47);
            this.blockUiPanel.Name = "blockUiPanel";
            this.blockUiPanel.Size = new System.Drawing.Size(240, 100);
            this.blockUiPanel.TabIndex = 6;
            this.blockUiPanel.Visible = false;
            this.blockUiPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.blockUiPanel_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 45);
            this.label3.TabIndex = 1;
            this.label3.Text = "Click the Sync button to retry.. \r\nMake sure your Computer is connected \r\nto the " +
    "internet.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Failed to connect server";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "Powecut Shedule";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openToolStripMenuItem.Text = "Open Gadget";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.quitToolStripMenuItem.Text = "Quit Gadget";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon2.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
            this.notifyIcon2.Text = "Powecut Shedule";
            this.notifyIcon2.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImage = global::PowercutGadget.Properties.Resources.background_2;
            this.ClientSize = new System.Drawing.Size(240, 180);
            this.Controls.Add(this.blockUiPanel);
            this.Controls.Add(this.lastSynced);
            this.Controls.Add(this.lbl_timeslot3);
            this.Controls.Add(this.lbl_timeslot2);
            this.Controls.Add(this.lbl_timeslot1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.settingBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingBtn)).EndInit();
            this.blockUiPanel.ResumeLayout(false);
            this.blockUiPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.PictureBox settingBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_timeslot1;
        private System.Windows.Forms.Label lbl_timeslot2;
        private System.Windows.Forms.Label lbl_timeslot3;
        private System.Windows.Forms.Label lastSynced;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel blockUiPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
    }
}

