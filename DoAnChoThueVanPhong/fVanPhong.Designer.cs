namespace DoAnChoThueVanPhong
{
    partial class fVanPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fVanPhong));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblDSVPhong = new System.Windows.Forms.Label();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.cboTang = new System.Windows.Forms.ComboBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbThongTinVP = new System.Windows.Forms.GroupBox();
            this.dgvVanPhong = new System.Windows.Forms.DataGridView();
            this.MaVanPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVanPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cboTimKiem = new System.Windows.Forms.ComboBox();
            this.schTimKiem = new DevExpress.XtraEditors.SearchControl();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnKLuu = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.txtTenVP = new System.Windows.Forms.TextBox();
            this.txtMaVP = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblTang = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.lblTenVP = new System.Windows.Forms.Label();
            this.lblMaVP = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grbThongTinVP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVanPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schTimKiem.Properties)).BeginInit();
            this.grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDSVPhong
            // 
            this.lblDSVPhong.AutoSize = true;
            this.lblDSVPhong.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSVPhong.Location = new System.Drawing.Point(744, 29);
            this.lblDSVPhong.Name = "lblDSVPhong";
            this.lblDSVPhong.Size = new System.Drawing.Size(360, 38);
            this.lblDSVPhong.TabIndex = 1;
            this.lblDSVPhong.Text = "DANH SÁCH VĂN PHÒNG";
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Items.AddRange(new object[] {
            "Trống",
            "Đang Thuê"});
            this.cboTinhTrang.Location = new System.Drawing.Point(260, 236);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(248, 39);
            this.cboTinhTrang.TabIndex = 3;
            // 
            // cboTang
            // 
            this.cboTang.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTang.FormattingEnabled = true;
            this.cboTang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cboTang.Location = new System.Drawing.Point(260, 330);
            this.cboTang.Name = "cboTang";
            this.cboTang.Size = new System.Drawing.Size(248, 39);
            this.cboTang.TabIndex = 4;
            // 
            // txtGia
            // 
            this.txtGia.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGia.Location = new System.Drawing.Point(260, 426);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(248, 38);
            this.txtGia.TabIndex = 5;
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            this.txtGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGia_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbThongTinVP);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.grpChucNang);
            this.panel1.Controls.Add(this.grbThongTin);
            this.panel1.Controls.Add(this.lblDSVPhong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1789, 740);
            this.panel1.TabIndex = 1;
            // 
            // grbThongTinVP
            // 
            this.grbThongTinVP.Controls.Add(this.dgvVanPhong);
            this.grbThongTinVP.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTinVP.Location = new System.Drawing.Point(30, 82);
            this.grbThongTinVP.Name = "grbThongTinVP";
            this.grbThongTinVP.Size = new System.Drawing.Size(1013, 442);
            this.grbThongTinVP.TabIndex = 8;
            this.grbThongTinVP.TabStop = false;
            this.grbThongTinVP.Text = "Thông Tin Văn Phòng";
            // 
            // dgvVanPhong
            // 
            this.dgvVanPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvVanPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVanPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVanPhong,
            this.TenVanPhong,
            this.TinhTrang,
            this.Tang,
            this.Gia,
            this.DVT});
            this.dgvVanPhong.Location = new System.Drawing.Point(6, 29);
            this.dgvVanPhong.Name = "dgvVanPhong";
            this.dgvVanPhong.RowHeadersWidth = 51;
            this.dgvVanPhong.RowTemplate.Height = 24;
            this.dgvVanPhong.Size = new System.Drawing.Size(1001, 407);
            this.dgvVanPhong.TabIndex = 9;
            this.dgvVanPhong.TabStop = false;
            this.dgvVanPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVanPhong_CellClick);
            // 
            // MaVanPhong
            // 
            this.MaVanPhong.DataPropertyName = "MaVanPhong";
            this.MaVanPhong.HeaderText = "Mã Văn Phòng";
            this.MaVanPhong.MinimumWidth = 6;
            this.MaVanPhong.Name = "MaVanPhong";
            this.MaVanPhong.Width = 145;
            // 
            // TenVanPhong
            // 
            this.TenVanPhong.DataPropertyName = "TenVanPhong";
            this.TenVanPhong.HeaderText = "Tên Văn Phòng";
            this.TenVanPhong.MinimumWidth = 6;
            this.TenVanPhong.Name = "TenVanPhong";
            this.TenVanPhong.Width = 150;
            // 
            // TinhTrang
            // 
            this.TinhTrang.DataPropertyName = "TinhTrang";
            this.TinhTrang.HeaderText = "Tình Trạng";
            this.TinhTrang.MinimumWidth = 6;
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Width = 130;
            // 
            // Tang
            // 
            this.Tang.DataPropertyName = "Tang";
            this.Tang.HeaderText = "Tầng";
            this.Tang.MinimumWidth = 6;
            this.Tang.Name = "Tang";
            this.Tang.Width = 130;
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "Gia";
            this.Gia.HeaderText = "Giá Phòng";
            this.Gia.MinimumWidth = 6;
            this.Gia.Name = "Gia";
            this.Gia.Width = 130;
            // 
            // DVT
            // 
            this.DVT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DVT.DataPropertyName = "DVT";
            this.DVT.HeaderText = "Đơn Vị";
            this.DVT.MinimumWidth = 6;
            this.DVT.Name = "DVT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(662, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // grpChucNang
            // 
            this.grpChucNang.Controls.Add(this.pictureBox2);
            this.grpChucNang.Controls.Add(this.cboTimKiem);
            this.grpChucNang.Controls.Add(this.schTimKiem);
            this.grpChucNang.Controls.Add(this.btnTimKiem);
            this.grpChucNang.Controls.Add(this.btnThoat);
            this.grpChucNang.Controls.Add(this.btnKLuu);
            this.grpChucNang.Controls.Add(this.btnLuu);
            this.grpChucNang.Controls.Add(this.btnSua);
            this.grpChucNang.Controls.Add(this.btnXoa);
            this.grpChucNang.Controls.Add(this.btnThem);
            this.grpChucNang.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChucNang.Location = new System.Drawing.Point(30, 530);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new System.Drawing.Size(1013, 198);
            this.grpChucNang.TabIndex = 4;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Chức Năng";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(787, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(111, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // cboTimKiem
            // 
            this.cboTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTimKiem.FormattingEnabled = true;
            this.cboTimKiem.Items.AddRange(new object[] {
            "Tìm Theo Mã",
            "Tìm Theo Tên"});
            this.cboTimKiem.Location = new System.Drawing.Point(699, 28);
            this.cboTimKiem.Name = "cboTimKiem";
            this.cboTimKiem.Size = new System.Drawing.Size(294, 36);
            this.cboTimKiem.TabIndex = 20;
            // 
            // schTimKiem
            // 
            this.schTimKiem.Location = new System.Drawing.Point(699, 70);
            this.schTimKiem.Name = "schTimKiem";
            this.schTimKiem.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schTimKiem.Properties.Appearance.Options.UseFont = true;
            this.schTimKiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.schTimKiem.Size = new System.Drawing.Size(294, 34);
            this.schTimKiem.TabIndex = 19;
            this.schTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.schTimKiem_KeyDown);
            this.schTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.schTimKiem_KeyUp);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(787, 112);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(111, 66);
            this.btnTimKiem.TabIndex = 17;
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.LightCyan;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(518, 112);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(146, 66);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnKLuu
            // 
            this.btnKLuu.BackColor = System.Drawing.Color.LightCyan;
            this.btnKLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnKLuu.Image")));
            this.btnKLuu.Location = new System.Drawing.Point(284, 112);
            this.btnKLuu.Name = "btnKLuu";
            this.btnKLuu.Size = new System.Drawing.Size(146, 66);
            this.btnKLuu.TabIndex = 4;
            this.btnKLuu.Text = "Hủy";
            this.btnKLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKLuu.UseVisualStyleBackColor = false;
            this.btnKLuu.Click += new System.EventHandler(this.btnKLuu_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.LightCyan;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(56, 112);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(146, 66);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.LightCyan;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(518, 29);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(146, 66);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.LightCyan;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(284, 29);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(146, 66);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.LightCyan;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(56, 29);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(146, 66);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.pictureBox3);
            this.grbThongTin.Controls.Add(this.txtDVT);
            this.grbThongTin.Controls.Add(this.cboTinhTrang);
            this.grbThongTin.Controls.Add(this.cboTang);
            this.grbThongTin.Controls.Add(this.txtGia);
            this.grbThongTin.Controls.Add(this.txtTenVP);
            this.grbThongTin.Controls.Add(this.txtMaVP);
            this.grbThongTin.Controls.Add(this.lblDVT);
            this.grbThongTin.Controls.Add(this.lblGia);
            this.grbThongTin.Controls.Add(this.lblTang);
            this.grbThongTin.Controls.Add(this.lblTinhTrang);
            this.grbThongTin.Controls.Add(this.lblTenVP);
            this.grbThongTin.Controls.Add(this.lblMaVP);
            this.grbThongTin.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTin.Location = new System.Drawing.Point(1077, 82);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(680, 646);
            this.grbThongTin.TabIndex = 3;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông Tin Chi Tiết";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(529, 521);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(145, 119);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // txtDVT
            // 
            this.txtDVT.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDVT.Location = new System.Drawing.Point(260, 521);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(248, 38);
            this.txtDVT.TabIndex = 6;
            // 
            // txtTenVP
            // 
            this.txtTenVP.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenVP.Location = new System.Drawing.Point(260, 147);
            this.txtTenVP.Name = "txtTenVP";
            this.txtTenVP.Size = new System.Drawing.Size(369, 38);
            this.txtTenVP.TabIndex = 2;
            // 
            // txtMaVP
            // 
            this.txtMaVP.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVP.Location = new System.Drawing.Point(260, 62);
            this.txtMaVP.Name = "txtMaVP";
            this.txtMaVP.Size = new System.Drawing.Size(369, 38);
            this.txtMaVP.TabIndex = 1;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDVT.Location = new System.Drawing.Point(60, 526);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(77, 28);
            this.lblDVT.TabIndex = 5;
            this.lblDVT.Text = "Đơn Vị";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.Location = new System.Drawing.Point(60, 431);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(109, 28);
            this.lblGia.TabIndex = 4;
            this.lblGia.Text = "Giá Phòng";
            // 
            // lblTang
            // 
            this.lblTang.AutoSize = true;
            this.lblTang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTang.Location = new System.Drawing.Point(60, 335);
            this.lblTang.Name = "lblTang";
            this.lblTang.Size = new System.Drawing.Size(59, 28);
            this.lblTang.TabIndex = 3;
            this.lblTang.Text = "Tầng";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhTrang.Location = new System.Drawing.Point(60, 241);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(113, 28);
            this.lblTinhTrang.TabIndex = 2;
            this.lblTinhTrang.Text = "Tình Trạng";
            // 
            // lblTenVP
            // 
            this.lblTenVP.AutoSize = true;
            this.lblTenVP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenVP.Location = new System.Drawing.Point(60, 152);
            this.lblTenVP.Name = "lblTenVP";
            this.lblTenVP.Size = new System.Drawing.Size(152, 28);
            this.lblTenVP.TabIndex = 2;
            this.lblTenVP.Text = "Tên Văn Phòng";
            // 
            // lblMaVP
            // 
            this.lblMaVP.AutoSize = true;
            this.lblMaVP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaVP.Location = new System.Drawing.Point(60, 67);
            this.lblMaVP.Name = "lblMaVP";
            this.lblMaVP.Size = new System.Drawing.Size(149, 28);
            this.lblMaVP.TabIndex = 1;
            this.lblMaVP.Text = "Mã Văn Phòng";
            // 
            // fVanPhong
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1789, 740);
            this.Controls.Add(this.panel1);
            this.Name = "fVanPhong";
            this.Text = "Quản Lý Văn Phòng";
            this.Load += new System.EventHandler(this.fVanPhong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbThongTinVP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVanPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpChucNang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schTimKiem.Properties)).EndInit();
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblDSVPhong;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.ComboBox cboTang;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnKLuu;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TextBox txtTenVP;
        private System.Windows.Forms.TextBox txtMaVP;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblTang;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.Label lblTenVP;
        private System.Windows.Forms.Label lblMaVP;
        private System.Windows.Forms.GroupBox grbThongTinVP;
        private System.Windows.Forms.DataGridView dgvVanPhong;
        private DevExpress.XtraEditors.SearchControl schTimKiem;
        private System.Windows.Forms.ComboBox cboTimKiem;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVanPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVanPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVT;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}