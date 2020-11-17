using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DoAnChoThueVanPhong.Models;
using System.Data.Entity;
using DevExpress.Office.Crypto;
using DevExpress.Utils.Extensions;
using System.Data.SqlClient;

namespace DoAnChoThueVanPhong
{
    public partial class fHopDong : DevExpress.XtraEditors.XtraForm
    {
        bool Flag;
        VanPhongDBContext db = new VanPhongDBContext();
        public static string hd;
        public static string mahd;
        public static DateTime ngaylap;
        public static DateTime ngaytra;
        public static string timvp;
        public static string timtien;
        public static string tennv;
        public fHopDong()
        {
            InitializeComponent();
        }

        private void fHopDong_Load(object sender, EventArgs e)
        {
            cboTimKiem.SelectedIndex = 0;
            HienThiDSHopDong();
            HienThiNhanVien();
            setNull();
            setButton(true);
            setKhoa(true);
            txtMaKH.Text = fKhachHang.ma;
            txtMaVP.Text = fLapHopDong.mavp;
        }

        void setNull()
        {
            txtTienCoc.Text = "";
            txtMaKH.Text = "";
            txtMaHD.Text = "";
            txtMaVP.Text = "";
        }

        void setButton(bool a)
        {
            btnThem.Enabled = a;
            btnXoa.Enabled = a;
            btnSua.Enabled = a;
            btnThoat.Enabled = a;
            btnLuu.Enabled = !a;
            btnKLuu.Enabled = !a;
        }

        void setKhoaSua(bool a)
        {
            txtMaHD.ReadOnly = !a;
            cboNhanVien.Enabled = !a;
            txtMaKH.ReadOnly = a;
            txtMaVP.ReadOnly = a;
            dtpNgayLap.Enabled = !a;
            dtpThoiGian.Enabled = !a;
            txtTienCoc.ReadOnly = a;
        }

        void setKhoa(bool a)
        {
            txtMaHD.ReadOnly = !a;
            cboNhanVien.Enabled = !a;
            txtMaKH.ReadOnly = !a;
            txtMaVP.ReadOnly = !a;
            dtpNgayLap.Enabled = !a;
            dtpThoiGian.Enabled = !a;
            txtTienCoc.ReadOnly = a;
        }

        public void HienThiDSHopDong()
        {
            var listHopDong = db.tbl_HopDong.Join(db.tbl_NhanVien,
                s => s.MaNhanVien,
                k => k.MaNhanVien, (s, k) => new
                {
                    MaHopDong = s.MaHopDong,
                    HoTen = k.HoTen,
                    MaKhachHang = s.MaKhachHang,
                    MaVanPhong = s.MaVanPhong,
                    NgayLap = s.NgayLap,
                    ThoiGianThue = s.ThoiGianThue,
                    TienCoc = s.TienCoc,
                }).ToList();
            dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHopDong.DataSource = listHopDong;
        }

        public void HienThiNhanVien()
        {
            var listNhanVien = db.tbl_NhanVien.ToList();
            cboNhanVien.DataSource = listNhanVien;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNhanVien";
        }       

        public string TangMaHDong()
        {
            string sql = @"select * from tbl_HopDong";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source=LAPTOP-OH9ESAI8\\SQLEXPRESS;initial catalog=QuanLyChoThueVanPhong;integrated security=True";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "HOD001";
            }
            else
            {
                int k;
                ma = "HOD";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(3, 3));
                k = k + 1;
                if (k < 10)
                {
                    ma = ma + "00";
                }
                else if (k < 100)
                {
                    ma = ma + "0";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvHopDong.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells[1].Value.ToString();
                cboNhanVien.SelectedIndex = cboNhanVien.FindString(row.Cells[2].Value.ToString());
                txtMaKH.Text = row.Cells[3].Value.ToString();
                txtMaVP.Text = row.Cells[4].Value.ToString();
                dtpNgayLap.Text = row.Cells[5].Value.ToString();
                dtpThoiGian.Text = row.Cells[6].Value.ToString();
                txtTienCoc.Text = row.Cells[7].Value.ToString();
            }
            catch { }
        }

        private void txtTienCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Flag = true;
            setButton(false);
            setKhoa(false);
            txtMaHD.Text = TangMaHDong();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.SelectedRows.Count > 0)
            {
                Flag = false;
                setButton(false);
                setKhoaSua(false);
            }
            else
                XtraMessageBox.Show("Bạn phải chọn mẫu tin để cập nhật!", "Thông Báo");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string mahd = txtMaHD.Text;
                string nhanvien = cboNhanVien.SelectedValue.ToString();
                string makh = txtMaKH.Text;
                string mavp = txtMaVP.Text;
                DateTime ngaylap = DateTime.Parse(dtpNgayLap.Value.ToString("dd/MM/yyyy"));
                DateTime thoigianthue = DateTime.Parse(dtpThoiGian.Value.ToString("dd/MM/yyyy"));
                float tiencoc = float.Parse(txtTienCoc.Text);
                if (Flag == true)
                {
                    if (db.tbl_HopDong.SqlQuery("select * from tbl_HopDong").Where(m => m.MaHopDong.Contains(txtMaHD.Text)).Count() > 0)
                    {
                        XtraMessageBox.Show("Mã hợp đồng nhập sai hoặc bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtTienCoc.Text == "")
                        {
                            XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                        }
                        else
                        {
                            tbl_HopDong hd = new tbl_HopDong();
                            hd.MaHopDong = mahd;
                            hd.MaNhanVien = nhanvien;
                            hd.MaKhachHang = makh;
                            hd.MaVanPhong = mavp;
                            hd.NgayLap = ngaylap;
                            hd.ThoiGianThue = thoigianthue;
                            hd.TienCoc = tiencoc;
                            db.tbl_HopDong.Add(hd);
                            db.SaveChanges();
                            HienThiDSHopDong();
                            XtraMessageBox.Show("Lập hợp đồng thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setNull();
                            setButton(true);
                            setKhoa(true);
                        }
                    }
                }
                else
                {
                    tbl_HopDong hd = db.tbl_HopDong.Where(m => m.MaHopDong == mahd).FirstOrDefault();
                    hd.MaNhanVien = nhanvien;
                    hd.MaKhachHang = makh;
                    hd.MaVanPhong = mavp;
                    hd.NgayLap = ngaylap;
                    hd.ThoiGianThue = thoigianthue;
                    hd.TienCoc = tiencoc;
                    if (hd == null)
                    {
                        XtraMessageBox.Show("Hợp đồng không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        db.Entry(hd).State = EntityState.Modified;
                        db.SaveChanges();
                        HienThiDSHopDong();
                        XtraMessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setNull();
                        setButton(true);
                        setKhoa(true);
                    }
                }
            }
            catch { }
        }

        private void btnKLuu_Click(object sender, EventArgs e)
        {
            setButton(true);
            setKhoa(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHopDong.SelectedRows.Count > 0)
            {
                DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    string mahd = txtMaHD.Text;
                    tbl_HopDong hd = db.tbl_HopDong.Find(mahd);
                    db.tbl_HopDong.Remove(hd);
                    db.SaveChanges();
                    HienThiDSHopDong();
                    setNull();
                }
            }
            else
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa");
        }

        private void txtTienCoc_TextChanged(object sender, EventArgs e)
        {
            float num = 0;
            if (float.TryParse(txtTienCoc.Text, out num))
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                float value = float.Parse(txtTienCoc.Text, System.Globalization.NumberStyles.AllowThousands);
                txtTienCoc.Text = String.Format(culture, "{0:N0}", value);
                txtTienCoc.Select(txtTienCoc.Text.Length, 0);
            }
        }

        public void TimTheoMa()
        {
            string mahd = schTimKiem.Text;
            var listHopDong = db.tbl_HopDong.Join(db.tbl_NhanVien,
                s => s.MaNhanVien,
                k => k.MaNhanVien, (s, k) => new
                {
                    MaHopDong = s.MaHopDong,
                    HoTen = k.HoTen,
                    MaKhachHang = s.MaKhachHang,
                    MaVanPhong = s.MaVanPhong,
                    NgayLap = s.NgayLap,
                    ThoiGianThue = s.ThoiGianThue,
                    TienCoc = s.TienCoc,
                }).Where(m => m.MaHopDong.Contains(mahd)).ToList();
            dgvHopDong.DataSource = listHopDong;
        }

        public void TimTheoTen()
        {
            string ten = schTimKiem.Text;
            var listHopDong = db.tbl_HopDong.Join(db.tbl_NhanVien,
                s => s.MaNhanVien,
                k => k.MaNhanVien, (s, k) => new
                {
                    MaHopDong = s.MaHopDong,
                    HoTen = k.HoTen,
                    MaKhachHang = s.MaKhachHang,
                    MaVanPhong = s.MaVanPhong,
                    NgayLap = s.NgayLap,
                    ThoiGianThue = s.ThoiGianThue,
                    TienCoc = s.TienCoc,
                }).Where(m => m.HoTen.Contains(ten)).ToList();
            dgvHopDong.DataSource = listHopDong;
        }

        public void TimTheoMaKH()
        {
            string makh = schTimKiem.Text;
            var listHopDong = db.tbl_HopDong.Join(db.tbl_NhanVien,
                s => s.MaNhanVien,
                k => k.MaNhanVien, (s, k) => new
                {
                    MaHopDong = s.MaHopDong,
                    HoTen = k.HoTen,
                    MaKhachHang = s.MaKhachHang,
                    MaVanPhong = s.MaVanPhong,
                    NgayLap = s.NgayLap,
                    ThoiGianThue = s.ThoiGianThue,
                    TienCoc = s.TienCoc,
                }).Where(m => m.MaKhachHang.Contains(makh)).ToList();
            dgvHopDong.DataSource = listHopDong;
        }

        public void TimTheoVP()
        {
            string mavp = schTimKiem.Text;
            var listHopDong = db.tbl_HopDong.Join(db.tbl_NhanVien,
                s => s.MaNhanVien,
                k => k.MaNhanVien, (s, k) => new
                {
                    MaHopDong = s.MaHopDong,
                    HoTen = k.HoTen,
                    MaKhachHang = s.MaKhachHang,
                    MaVanPhong = s.MaVanPhong,
                    NgayLap = s.NgayLap,
                    ThoiGianThue = s.ThoiGianThue,
                    TienCoc = s.TienCoc,
                }).Where(m => m.MaVanPhong.Contains(mavp)).ToList();
            dgvHopDong.DataSource = listHopDong;
        }

        private void schTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboTimKiem.SelectedIndex == 0)
            {
                TimTheoMa();
            }
            else if (cboTimKiem.SelectedIndex == 1)
            {
                TimTheoTen();
            }
            else if (cboTimKiem.SelectedIndex == 2)
            {
                TimTheoMaKH();
            }
            else
            {
                TimTheoVP();
            }
        }

        private void schTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            if (cboTimKiem.SelectedIndex == 0)
            {
                TimTheoMa();
            }
            else if (cboTimKiem.SelectedIndex == 1)
            {
                TimTheoTen();
            }
            else if (cboTimKiem.SelectedIndex == 2)
            {
                TimTheoMaKH();
            }
            else
            {
                TimTheoVP();
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            mahd = TimMaHD().ToString();
            tennv = TimTenNV().ToString();
            ngaylap = DateTime.Parse(TimNgayLap().ToString());
            ngaytra = DateTime.Parse(TimNgayTra().ToString());
            fHoaDon frm = new fHoaDon();
            frm.ShowDialog();
        }

        public string TimMaHD()
        {
            string x = "";
            for (int i = 0; i < dgvHopDong.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvHopDong.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvHopDong.Rows[i].Cells[1].Value);
                }
            }
            return x;
        }

        public string TimNgayLap()
        {
            string x = "";
            for (int i = 0; i < dgvHopDong.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvHopDong.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvHopDong.Rows[i].Cells[5].Value);
                }
            }
            return x;
        }

        public string TimNgayTra()
        {
            string x = "";
            for (int i = 0; i < dgvHopDong.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvHopDong.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvHopDong.Rows[i].Cells[6].Value);
                }
            }
            return x;
        }

        public string TimMAVP()
        {
            string x = "";
            for (int i = 0; i < dgvHopDong.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvHopDong.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvHopDong.Rows[i].Cells[4].Value);
                }
            }
            return x;
        }

        public string TimTienCoc()
        {
            string x = "";
            for (int i = 0; i < dgvHopDong.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvHopDong.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvHopDong.Rows[i].Cells[7].Value);
                }
            }
            return x;
        }

        public string TimTenNV()
        {
            string x = "";
            for (int i = 0; i < dgvHopDong.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvHopDong.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvHopDong.Rows[i].Cells[2].Value);
                }
            }
            return x;
        }

        private void btnChiTietHĐ_Click(object sender, EventArgs e)
        {
            timvp = TimMAVP().ToString();
            mahd = TimMaHD().ToString();
            timtien = TimTienCoc().ToString();
            ngaylap = DateTime.Parse(TimNgayLap().ToString());
            fChiTietHopDong frm = new fChiTietHopDong();
            frm.ShowDialog();
        }
    }
}