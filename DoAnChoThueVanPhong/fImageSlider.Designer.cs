namespace DoAnChoThueVanPhong
{
    partial class fImageSlider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fImageSlider));
            this.panel1 = new System.Windows.Forms.Panel();
            this.isHinhNen = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isHinhNen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.isHinhNen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1789, 740);
            this.panel1.TabIndex = 0;
            // 
            // isHinhNen
            // 
            this.isHinhNen.AutoSlide = DevExpress.XtraEditors.Controls.AutoSlide.Forward;
            this.isHinhNen.AutoSlideInterval = 3000;
            this.isHinhNen.CurrentImageIndex = 0;
            this.isHinhNen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images1"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images2"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images3"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images4"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images5"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images6"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images7"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images8"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images9"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images10"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images11"))));
            this.isHinhNen.Images.Add(((System.Drawing.Image)(resources.GetObject("isHinhNen.Images12"))));
            this.isHinhNen.Location = new System.Drawing.Point(0, 0);
            this.isHinhNen.Name = "isHinhNen";
            this.isHinhNen.Size = new System.Drawing.Size(1789, 740);
            this.isHinhNen.TabIndex = 0;
            this.isHinhNen.Text = "imageSlider1";
            // 
            // fImageSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1789, 740);
            this.Controls.Add(this.panel1);
            this.Name = "fImageSlider";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.isHinhNen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.Controls.ImageSlider isHinhNen;
    }
}