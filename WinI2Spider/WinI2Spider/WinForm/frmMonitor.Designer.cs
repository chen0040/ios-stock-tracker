namespace WinI2Spider.WinForm
{
    partial class frmMonitor
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
            this.btnMonitor = new System.Windows.Forms.Button();
            this.dtpUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.gbTimerDateTime = new System.Windows.Forms.GroupBox();
            this.dtpUpdateTime = new System.Windows.Forms.DateTimePicker();
            this.gbCrawlStats = new System.Windows.Forms.GroupBox();
            this.txtCrawledNewsCount = new System.Windows.Forms.TextBox();
            this.lblCrawledNewsCount = new System.Windows.Forms.Label();
            this.txtCrawledStockQuoteCount = new System.Windows.Forms.TextBox();
            this.lblCrawledStockQuoteCount = new System.Windows.Forms.Label();
            this.btnStopMonitor = new System.Windows.Forms.Button();
            this.tmrMonitor = new System.Windows.Forms.Timer(this.components);
            this.gbMonitor = new System.Windows.Forms.GroupBox();
            this.txtMonitorInterval = new System.Windows.Forms.TextBox();
            this.lblMonitorInterval = new System.Windows.Forms.Label();
            this.lblCrawledWarrantQuoteCount = new System.Windows.Forms.Label();
            this.txtCrawledWarrantQuoteCount = new System.Windows.Forms.TextBox();
            this.txtHttpStats = new System.Windows.Forms.TextBox();
            this.txtUpdateDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPacketSize = new System.Windows.Forms.TextBox();
            this.gbTimerDateTime.SuspendLayout();
            this.gbCrawlStats.SuspendLayout();
            this.gbMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonitor.Location = new System.Drawing.Point(306, 15);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnMonitor.TabIndex = 0;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.UseVisualStyleBackColor = false;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // dtpUpdateDate
            // 
            this.dtpUpdateDate.Location = new System.Drawing.Point(12, 19);
            this.dtpUpdateDate.Name = "dtpUpdateDate";
            this.dtpUpdateDate.Size = new System.Drawing.Size(185, 20);
            this.dtpUpdateDate.TabIndex = 1;
            // 
            // gbTimerDateTime
            // 
            this.gbTimerDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTimerDateTime.Controls.Add(this.dtpUpdateTime);
            this.gbTimerDateTime.Controls.Add(this.dtpUpdateDate);
            this.gbTimerDateTime.Location = new System.Drawing.Point(12, 114);
            this.gbTimerDateTime.Name = "gbTimerDateTime";
            this.gbTimerDateTime.Size = new System.Drawing.Size(485, 55);
            this.gbTimerDateTime.TabIndex = 2;
            this.gbTimerDateTime.TabStop = false;
            this.gbTimerDateTime.Text = "Last Updated DateTime";
            // 
            // dtpUpdateTime
            // 
            this.dtpUpdateTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpUpdateTime.Location = new System.Drawing.Point(203, 19);
            this.dtpUpdateTime.Name = "dtpUpdateTime";
            this.dtpUpdateTime.Size = new System.Drawing.Size(128, 20);
            this.dtpUpdateTime.TabIndex = 1;
            // 
            // gbCrawlStats
            // 
            this.gbCrawlStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCrawlStats.Controls.Add(this.txtCrawledNewsCount);
            this.gbCrawlStats.Controls.Add(this.lblCrawledNewsCount);
            this.gbCrawlStats.Controls.Add(this.txtCrawledWarrantQuoteCount);
            this.gbCrawlStats.Controls.Add(this.lblCrawledWarrantQuoteCount);
            this.gbCrawlStats.Controls.Add(this.txtCrawledStockQuoteCount);
            this.gbCrawlStats.Controls.Add(this.lblCrawledStockQuoteCount);
            this.gbCrawlStats.Location = new System.Drawing.Point(12, 175);
            this.gbCrawlStats.Name = "gbCrawlStats";
            this.gbCrawlStats.Size = new System.Drawing.Size(485, 104);
            this.gbCrawlStats.TabIndex = 3;
            this.gbCrawlStats.TabStop = false;
            this.gbCrawlStats.Text = "Crawl Statistics";
            // 
            // txtCrawledNewsCount
            // 
            this.txtCrawledNewsCount.Location = new System.Drawing.Point(221, 69);
            this.txtCrawledNewsCount.Name = "txtCrawledNewsCount";
            this.txtCrawledNewsCount.Size = new System.Drawing.Size(100, 20);
            this.txtCrawledNewsCount.TabIndex = 1;
            // 
            // lblCrawledNewsCount
            // 
            this.lblCrawledNewsCount.AutoSize = true;
            this.lblCrawledNewsCount.Location = new System.Drawing.Point(6, 72);
            this.lblCrawledNewsCount.Name = "lblCrawledNewsCount";
            this.lblCrawledNewsCount.Size = new System.Drawing.Size(190, 13);
            this.lblCrawledNewsCount.TabIndex = 0;
            this.lblCrawledNewsCount.Text = "Number of News Articles Last Crawled:";
            // 
            // txtCrawledStockQuoteCount
            // 
            this.txtCrawledStockQuoteCount.Location = new System.Drawing.Point(221, 19);
            this.txtCrawledStockQuoteCount.Name = "txtCrawledStockQuoteCount";
            this.txtCrawledStockQuoteCount.Size = new System.Drawing.Size(99, 20);
            this.txtCrawledStockQuoteCount.TabIndex = 1;
            // 
            // lblCrawledStockQuoteCount
            // 
            this.lblCrawledStockQuoteCount.AutoSize = true;
            this.lblCrawledStockQuoteCount.Location = new System.Drawing.Point(6, 22);
            this.lblCrawledStockQuoteCount.Name = "lblCrawledStockQuoteCount";
            this.lblCrawledStockQuoteCount.Size = new System.Drawing.Size(191, 13);
            this.lblCrawledStockQuoteCount.TabIndex = 0;
            this.lblCrawledStockQuoteCount.Text = "Number of Stock Quotes Last Crawled:";
            // 
            // btnStopMonitor
            // 
            this.btnStopMonitor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStopMonitor.Enabled = false;
            this.btnStopMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopMonitor.Location = new System.Drawing.Point(390, 15);
            this.btnStopMonitor.Name = "btnStopMonitor";
            this.btnStopMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnStopMonitor.TabIndex = 0;
            this.btnStopMonitor.Text = "Stop";
            this.btnStopMonitor.UseVisualStyleBackColor = false;
            this.btnStopMonitor.Click += new System.EventHandler(this.btnStopMonitor_Click);
            // 
            // tmrMonitor
            // 
            this.tmrMonitor.Interval = 1000;
            this.tmrMonitor.Tick += new System.EventHandler(this.tmrMonitor_Tick);
            // 
            // gbMonitor
            // 
            this.gbMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMonitor.Controls.Add(this.txtPacketSize);
            this.gbMonitor.Controls.Add(this.label1);
            this.gbMonitor.Controls.Add(this.txtUpdateDuration);
            this.gbMonitor.Controls.Add(this.lblDuration);
            this.gbMonitor.Controls.Add(this.btnMonitor);
            this.gbMonitor.Controls.Add(this.btnStopMonitor);
            this.gbMonitor.Controls.Add(this.txtMonitorInterval);
            this.gbMonitor.Controls.Add(this.lblMonitorInterval);
            this.gbMonitor.Location = new System.Drawing.Point(12, 12);
            this.gbMonitor.Name = "gbMonitor";
            this.gbMonitor.Size = new System.Drawing.Size(485, 96);
            this.gbMonitor.TabIndex = 4;
            this.gbMonitor.TabStop = false;
            this.gbMonitor.Text = "Monitor";
            // 
            // txtMonitorInterval
            // 
            this.txtMonitorInterval.Location = new System.Drawing.Point(159, 17);
            this.txtMonitorInterval.Name = "txtMonitorInterval";
            this.txtMonitorInterval.Size = new System.Drawing.Size(100, 20);
            this.txtMonitorInterval.TabIndex = 1;
            this.txtMonitorInterval.Text = "10000";
            // 
            // lblMonitorInterval
            // 
            this.lblMonitorInterval.AutoSize = true;
            this.lblMonitorInterval.Location = new System.Drawing.Point(6, 20);
            this.lblMonitorInterval.Name = "lblMonitorInterval";
            this.lblMonitorInterval.Size = new System.Drawing.Size(148, 13);
            this.lblMonitorInterval.TabIndex = 0;
            this.lblMonitorInterval.Text = "Monitor Interval (milliseconds):";
            // 
            // lblCrawledWarrantQuoteCount
            // 
            this.lblCrawledWarrantQuoteCount.AutoSize = true;
            this.lblCrawledWarrantQuoteCount.Location = new System.Drawing.Point(6, 46);
            this.lblCrawledWarrantQuoteCount.Name = "lblCrawledWarrantQuoteCount";
            this.lblCrawledWarrantQuoteCount.Size = new System.Drawing.Size(201, 13);
            this.lblCrawledWarrantQuoteCount.TabIndex = 0;
            this.lblCrawledWarrantQuoteCount.Text = "Number of Warrant Quotes Last Crawled:";
            // 
            // txtCrawledWarrantQuoteCount
            // 
            this.txtCrawledWarrantQuoteCount.Location = new System.Drawing.Point(221, 43);
            this.txtCrawledWarrantQuoteCount.Name = "txtCrawledWarrantQuoteCount";
            this.txtCrawledWarrantQuoteCount.Size = new System.Drawing.Size(99, 20);
            this.txtCrawledWarrantQuoteCount.TabIndex = 1;
            // 
            // txtHttpStats
            // 
            this.txtHttpStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHttpStats.Location = new System.Drawing.Point(12, 285);
            this.txtHttpStats.Multiline = true;
            this.txtHttpStats.Name = "txtHttpStats";
            this.txtHttpStats.Size = new System.Drawing.Size(485, 64);
            this.txtHttpStats.TabIndex = 5;
            // 
            // txtUpdateDuration
            // 
            this.txtUpdateDuration.Location = new System.Drawing.Point(159, 40);
            this.txtUpdateDuration.Name = "txtUpdateDuration";
            this.txtUpdateDuration.Size = new System.Drawing.Size(100, 20);
            this.txtUpdateDuration.TabIndex = 3;
            this.txtUpdateDuration.Text = "0";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(9, 43);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(116, 13);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Http Post Duration (ms)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Http Post Packet Size:";
            // 
            // txtPacketSize
            // 
            this.txtPacketSize.Location = new System.Drawing.Point(159, 66);
            this.txtPacketSize.Name = "txtPacketSize";
            this.txtPacketSize.Size = new System.Drawing.Size(100, 20);
            this.txtPacketSize.TabIndex = 3;
            this.txtPacketSize.Text = "100";
            // 
            // frmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 361);
            this.Controls.Add(this.txtHttpStats);
            this.Controls.Add(this.gbMonitor);
            this.Controls.Add(this.gbCrawlStats);
            this.Controls.Add(this.gbTimerDateTime);
            this.Name = "frmMonitor";
            this.Text = "Monitor";
            this.gbTimerDateTime.ResumeLayout(false);
            this.gbCrawlStats.ResumeLayout(false);
            this.gbCrawlStats.PerformLayout();
            this.gbMonitor.ResumeLayout(false);
            this.gbMonitor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.DateTimePicker dtpUpdateDate;
        private System.Windows.Forms.GroupBox gbTimerDateTime;
        private System.Windows.Forms.DateTimePicker dtpUpdateTime;
        private System.Windows.Forms.GroupBox gbCrawlStats;
        private System.Windows.Forms.TextBox txtCrawledNewsCount;
        private System.Windows.Forms.Label lblCrawledNewsCount;
        private System.Windows.Forms.TextBox txtCrawledStockQuoteCount;
        private System.Windows.Forms.Label lblCrawledStockQuoteCount;
        private System.Windows.Forms.Button btnStopMonitor;
        private System.Windows.Forms.Timer tmrMonitor;
        private System.Windows.Forms.GroupBox gbMonitor;
        private System.Windows.Forms.TextBox txtMonitorInterval;
        private System.Windows.Forms.Label lblMonitorInterval;
        private System.Windows.Forms.TextBox txtCrawledWarrantQuoteCount;
        private System.Windows.Forms.Label lblCrawledWarrantQuoteCount;
        private System.Windows.Forms.TextBox txtHttpStats;
        private System.Windows.Forms.TextBox txtUpdateDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtPacketSize;
        private System.Windows.Forms.Label label1;
    }
}
