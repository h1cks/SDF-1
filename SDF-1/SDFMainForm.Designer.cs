namespace SDF_1
{
    partial class SDFMainForm
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
            this.pc_mainWindow = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_loadBitmap = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_execute = new System.Windows.Forms.Button();
            this.prg_processing = new System.Windows.Forms.ProgressBar();
            this.pb_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pc_mainWindow)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pc_mainWindow
            // 
            this.pc_mainWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pc_mainWindow.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pc_mainWindow.Location = new System.Drawing.Point(142, 30);
            this.pc_mainWindow.Name = "pc_mainWindow";
            this.pc_mainWindow.Size = new System.Drawing.Size(649, 422);
            this.pc_mainWindow.TabIndex = 0;
            this.pc_mainWindow.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_loadBitmap});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mi_loadBitmap
            // 
            this.mi_loadBitmap.Name = "mi_loadBitmap";
            this.mi_loadBitmap.Size = new System.Drawing.Size(141, 22);
            this.mi_loadBitmap.Text = "Load Bitmap";
            this.mi_loadBitmap.Click += new System.EventHandler(this.Mi_loadBitmap_Click);
            // 
            // pb_execute
            // 
            this.pb_execute.Location = new System.Drawing.Point(12, 429);
            this.pb_execute.Name = "pb_execute";
            this.pb_execute.Size = new System.Drawing.Size(124, 23);
            this.pb_execute.TabIndex = 2;
            this.pb_execute.Text = "Execute";
            this.pb_execute.UseVisualStyleBackColor = true;
            this.pb_execute.Click += new System.EventHandler(this.pb_execute_Click);
            // 
            // prg_processing
            // 
            this.prg_processing.Location = new System.Drawing.Point(12, 249);
            this.prg_processing.Name = "prg_processing";
            this.prg_processing.Size = new System.Drawing.Size(124, 23);
            this.prg_processing.TabIndex = 3;
            // 
            // pb_save
            // 
            this.pb_save.Location = new System.Drawing.Point(48, 310);
            this.pb_save.Name = "pb_save";
            this.pb_save.Size = new System.Drawing.Size(75, 23);
            this.pb_save.TabIndex = 4;
            this.pb_save.Text = "button1";
            this.pb_save.UseVisualStyleBackColor = true;
            this.pb_save.Click += new System.EventHandler(this.pb_save_Click);
            // 
            // SDFMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 464);
            this.Controls.Add(this.pb_save);
            this.Controls.Add(this.prg_processing);
            this.Controls.Add(this.pb_execute);
            this.Controls.Add(this.pc_mainWindow);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SDFMainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pc_mainWindow)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pc_mainWindow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mi_loadBitmap;
        private System.Windows.Forms.Button pb_execute;
        private System.Windows.Forms.ProgressBar prg_processing;
        private System.Windows.Forms.Button pb_save;
    }
}

