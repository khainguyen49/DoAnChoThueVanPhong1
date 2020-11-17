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
using DevExpress.XtraReports.UI;

namespace DoAnChoThueVanPhong
{
    public partial class fQuanLyHoaDon : DevExpress.XtraEditors.XtraForm
    {
        bool Flag;
        VanPhongDBContext db = new VanPhongDBContext();
        public fQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void fQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            cboTimKiem.SelectedIndex = 0;
            HienThiDSHoaDon();
            HienThiNhanVien();
            setNull();
            setButton(true);
            setKhoa(true);
        }

        void setNull()
        {
            txtMaHDon.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtMaHopDong.Text = "";
            txtGiaPhong.Text = "";
            txtThanhTien.Text = "";
            txtNoiDung.Text = "";
        }

        void setButton(bool a)
        {
            btnXoa.Enabled = a;
            btnSua.Enabled = a;
            btnThoat.Enabled = a;
            btnLuu.Enabled = !a;
            btnKLuu.Enabled = !a;
        }

        void setKhoaSua(bool a)
        {
            txtMaHDon.ReadOnly = !a;
            cboTenNV.Enabled = !a;
            txtMaKH.ReadOnly = a;
            txtTenKH.ReadOnly = a;
            txtMaHopDong.ReadOnly = a;
            dtpNgayLap.Enabled = !a;
            dtpNgayTra.Enabled = !a;
            txtGiaPhong.ReadOnly = a;
            txtNoiDung.ReadOnly = a;
            txtThanhTien.ReadOnly = a;
        }

        void setKhoa(bool a)
        {
            txtMaHDon.ReadOnly = a;
            cboTenNV.Enabled = !a;
            txtMaKH.ReadOnly = a;
            txtTenKH.ReadOnly = a;
            txtMaHopDong.ReadOnly = a;
            dtpNgayLap.Enabled = !a;
            dtpNgayTra.Enabled = !a;
            txtGiaPhong.ReadOnly = a;
            txtNoiDung.ReadOnly = a;
            txtThanhTien.ReadOnly = a;
        }

        public void HienThiDSHoaDon()
        {
            var listHoaDon = db.tbl_HoaDon.Join(db.tbl_NhanVien,
                s => s.MaNhanVien,
                k => k.MaNhanVien, (s, k) => new
                {
                    MaHoaDon = s.MaHoaDon,
                    HoTen = k.HoTen,
                    MaKhachHang = s.MaKhachHang,
                    HoTenKhach = s.HoTenKhach,
                    MaHopDong = s.MaHopDong,
                    NgayLap = s.NgayLap,
                    NgayTra = s.NgayTra,
                    GiaPhong = s.GiaPhong,
                    NoiDung = s.NoiDung,
                    ThanhTien = s.ThanhTien,
                }).ToList();
            dgvHoaDon.DataSource = listHoaDon;
        }

        public void HienThiNhanVien()
        {
            var listNhanVien = db.tbl_NhanVien.ToList();
            cboTenNV.DataSource = listNhanVien;
            cboTenNV.DisplayMember = "HoTen";
            cboTenNV.ValueMember = "MaNhanVien";
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHDon.Text = row.Cells[0].Value.ToString();
                cboTenNV.SelectedIndex = cboTenNV.FindString(row.Cells[1].Value.ToString());
                txtMaKH.Text = row.Cells[2].Value.ToString();
                txtTenKH.Text = row.Cells[3].Value.ToString();
                txtMaHopDong.Text = row.Cells[4].Value.ToString();
                dtpNgayLap.Text = row.Cells[5].Value.ToString();
                dtpNgayTra.Text = row.Cells[6].Value.ToString();
                txtGiaPhong.Text = row.Cells[7].Value.ToString();
                txtNoiDung.Text = row.Cells[8].Value.ToString();
                txtThanhTien.Text = row.Cells[9].Value.ToString();
            }
            catch { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
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

        void GetPay()
        {
            int ThoiGianThue = 0;
            float tinhtien = 0;
            float giaphong = float.Parse(txtGiaPhong.Text);
            if (dtpNgayLap.Value.Year != dtpNgayTra.Value.Year)
            {
                ThoiGianThue = (dtpNgayTra.Value.Year - dtpNgayLap.Value.Year) * 12 + (dtpNgayTra.Value.Month - dtpNgayLap.Value.Month);
            }
            else
                ThoiGianThue = (dtpNgayTra.Value.Month - dtpNgayLap.Value.Month);
            tinhtien = giaphong * int.Parse(ThoiGianThue.ToString());
            txtThanhTien.Text = String.Format("{0:#,###}", tinhtien);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string mahd = txtMaHDon.Text;
                string nhanvien = cboTenNV.SelectedValue.ToString();
                string makh = txtMaKH.Text;
                string tenkh = txtTenKH.Text;
                string mahdong = txtMaHopDong.Text;
                DateTime ngaylap = DateTime.Parse(dtpNgayLap.Value.ToString("dd/MM/yyyy"));
                DateTime ngaytra = DateTime.Parse(dtpNgayTra.Value.ToString("dd/MM/yyyy"));
                float thanhtien = float.Parse(txtThanhTien.Text);
                float giaphong = float.Parse(txtGiaPhong.Text);
                string noidung = txtNoiDung.Text;
                if (Flag == true)
                {
                    if (db.tbl_HoaDon.SqlQuery("select * from tbl_HoaDon").Where(m => m.MaHoaDon.Contains(txtMaHDon.Text)).Count() > 0)
                    {
                        XtraMessageBox.Show("Mã hóa đơn nhập sai hoặc bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtNoiDung.Text == "")
                        {
                            XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                        }
                        else
                        {
                            tbl_HoaDon hd = new tbl_HoaDon();
                            hd.MaHoaDon = mahd;
                            hd.MaNhanVien = nhanvien;
                            hd.MaKhachHang = makh;
                            hd.HoTenKhach = tenkh;
                            hd.MaHopDong = mahdong;
                            hd.NgayLap = ngaylap;
                            hd.NgayTra = ngaytra;
                            hd.GiaPhong = giaphong;
                            hd.NoiDung = noidung;
                            hd.ThanhTien = thanhtien;
                            db.tbl_HoaDon.Add(hd);
                            db.SaveChanges();
                            HienThiDSHoaDon();
                            XtraMessageBox.Show("Thêm hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setNull();
                            setButton(true);
                            setKhoa(true);
                        }
                    }
                }
                else
                {
                    tbl_HoaDon hd = db.tbl_HoaDon.Where(m => m.MaHoaDon == mahd).FirstOrDefault();
                    hd.MaNhanVien = nhanvien;
                    hd.MaKhachHang = makh;
                    hd.HoTenKhach = tenkh;
                    hd.MaHopDong = mahdong;
                    hd.NgayLap = ngaylap;
                    hd.NgayTra = ngaytra;
                    hd.GiaPhong = giaphong;
                    hd.NoiDung = noidung;
                    hd.ThanhTien = thanhtien;
                    if (hd == null)
                    {
                        XtraMessageBox.Show("Hóa đơn không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        db.Entry(hd).State = EntityState.Modified;
                        db.SaveChanges();
                        HienThiDSHoaDon();
                        XtraMessageBox.Show("Cập nhật thành công!", "Thông Báo");
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
            setNull();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa không ? ", "Thông Báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string mahd = txtMaHDon.Text;
                    tbl_HoaDon hd = db.tbl_HoaDon.Find(mahd);
                    db.tbl_HoaDon.Remove(hd);
                    db.SaveChanges();
                    HienThiDSHoaDon();
                    setNull();
                }
            }
            else
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa");
        }

        public void TimTheoMa()
        {
            string mahdon = schTimKiem.Text;
            var listHoaDon = db.tbl_HoaDon.Join(db.tbl_NhanVien,
                s => s.MaNhanVien,
                k => k.MaNhanVien, (s, k) => new
                {
                    MaHoaDon = s.MaHoaDon,
                    HoTen = k.HoTen,
                    MaKhachHang = s.MaKhachHang,
                    HoTenKhach = s.HoTenKhach,
                    MaHopDong = s.MaHopDong,
                    NgayLap = s.NgayLap,
                    NgayTra = s.NgayTra,
                    GiaPhong = s.GiaPhong,
                    ThanhTien = s.ThanhTien,
                    NoiDung = s.NoiDung,
                }).Where(m => m.MaHoaDon.Contains(mahdon)).ToList();
            dgvHoaDon.DataSource = listHoaDon;
        }

        public void TimTheoTen()
        {
            string tennv = schTimKiem.Text;
            var listHoaDon = db.tbl_HoaDon.Join(db.tbl_NhanVien,
                s => s.MaNhanVien,
                k => k.MaNhanVien, (s, k) => new
                {
                    MaHoaDon = s.MaHoaDon,
                    HoTen = k.HoTen,
                    MaKhachHang = s.MaKhachHang,
                    HoTenKhach = s.HoTenKhach,
                    MaHopDong = s.MaHopDong,
                    NgayLap = s.NgayLap,
                    NgayTra = s.NgayTra,
                    GiaPhong = s.GiaPhong,
                    ThanhTien = s.ThanhTien,
                    NoiDung = s.NoiDung,
                }).Where(m => m.HoTen.Contains(tennv)).ToList();
            dgvHoaDon.DataSource = listHoaDon;
        }

        private void schTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboTimKiem.SelectedIndex == 0)
            {
                TimTheoMa();
            }
            else
            {
                TimTheoTen();
            }
        }

        private void schTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            if (cboTimKiem.SelectedIndex == 0)
            {
                TimTheoMa();
            }
            else
            {
                TimTheoTen();
            }
        }

        private void txtGiaPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaPhong_TextChanged(object sender, EventArgs e)
        {
            float num = 0;
            if (float.TryParse(txtGiaPhong.Text, out num))
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                float value = float.Parse(txtGiaPhong.Text, System.Globalization.NumberStyles.AllowThousands);
                txtGiaPhong.Text = String.Format(culture, "{0:N0}", value);
                txtGiaPhong.Select(txtGiaPhong.Text.Length, 0);
            }
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            float num = 0;
            if (float.TryParse(txtThanhTien.Text, out num))
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                float value = float.Parse(txtThanhTien.Text, System.Globalization.NumberStyles.AllowThousands);
                txtThanhTien.Text = String.Format(culture, "{0:N0}", value);
                txtThanhTien.Select(txtThanhTien.Text.Length, 0);
            }
        }

        private void txtThanhTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThanhTien_Click(object sender, EventArgs e)
        {
            GetPay();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            rptHoaDon rpt = new rptHoaDon();
            rpt.ShowPreviewDialog();
        }
    }
}

        