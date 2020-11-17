namespace DoAnChoThueVanPhong
{
    partial class fHuongDanSD
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
            this.wbHDSD = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbHDSD
            // 
            this.wbHDSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHDSD.Location = new System.Drawing.Point(0, 0);
            this.wbHDSD.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHDSD.Name = "wbHDSD";
            this.wbHDSD.Size = new System.Drawing.Size(1775, 738);
            this.wbHDSD.TabIndex = 0;
            this.wbHDSD.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbHDSD_DocumentCompleted);
            // 
            // fHuongDanSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1775, 738);
            this.Controls.Add(this.wbHDSD);
            this.Name = "fHuongDanSD";
            this.Text = "Hướng dẫn sử dụng";
            this.Load += new System.EventHandler(this.fHuongDanSD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbHDSD;
    }
}