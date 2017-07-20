namespace WinI2Spider.WinForm
{
    partial class frmI2Spider
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
            this.menuMasterStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMasterStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMonitor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMasterStrip.SuspendLayout();
            this.toolMasterStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMasterStrip
            // 
            this.menuMasterStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuMasterStrip.Location = new System.Drawing.Point(0, 0);
            this.menuMasterStrip.Name = "menuMasterStrip";
            this.menuMasterStrip.Size = new System.Drawing.Size(510, 24);
            this.menuMasterStrip.TabIndex = 1;
            this.menuMasterStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolMasterStrip
            // 
            this.toolMasterStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMonitor,
            this.toolStripSeparator1});
            this.toolMasterStrip.Location = new System.Drawing.Point(0, 24);
            this.toolMasterStrip.Name = "toolMasterStrip";
            this.toolMasterStrip.Size = new System.Drawing.Size(510, 55);
            this.toolMasterStrip.TabIndex = 2;
            this.toolMasterStrip.Text = "toolStrip1";
            // 
            // toolStripButtonMonitor
            // 
            this.toolStripButtonMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMonitor.Image = global::WinI2Spider.Properties.Resources.webspider;
            this.toolStripButtonMonitor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMonitor.Name = "toolStripButtonMonitor";
            this.toolStripButtonMonitor.Size = new System.Drawing.Size(52, 52);
            this.toolStripButtonMonitor.Text = "toolStripButton1";
            this.toolStripButtonMonitor.Click += new System.EventHandler(this.toolStripButtonMonitor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // frmI2Spider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 287);
            this.Controls.Add(this.toolMasterStrip);
            this.Controls.Add(this.menuMasterStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMasterStrip;
            this.Name = "frmI2Spider";
            this.Text = "I2 Web Spider";
            this.menuMasterStrip.ResumeLayout(false);
            this.menuMasterStrip.PerformLayout();
            this.toolMasterStrip.ResumeLayout(false);
            this.toolMasterStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMasterStrip;
        private System.Windows.Forms.ToolStrip toolMasterStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonMonitor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

