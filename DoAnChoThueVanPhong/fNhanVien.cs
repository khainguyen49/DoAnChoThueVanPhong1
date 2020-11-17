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
    public partial class fNhanVien : DevExpress.XtraEditors.XtraForm
    {
        bool Flag;
        VanPhongDBContext db = new VanPhongDBContext();
        public fNhanVien()
        {
            InitializeComponent();
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            cboTimKiem.SelectedIndex = 0;
            HienThiDSNhanVien();
            HienThiChucVu();
            setNull();
            setButton(true);
            setKhoa(true);            
        }

        void setNull()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtLuong.Text = "";
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
            txtMaNV.ReadOnly = !a;
            txtTenNV.ReadOnly = a;
            dtpNgaySinh.Enabled = !a;
            cboChucVu.Enabled = !a;
            txtLuong.ReadOnly = a;
            txtDiaChi.ReadOnly = a;
            rdbNam.Enabled = !a;
            rdbNu.Enabled = !a;
            txtSDT.ReadOnly = a;
            txtEmail.ReadOnly = a;
        }

        void setKhoa(bool a) 
        {
            txtMaNV.ReadOnly = !a;
            txtTenNV.ReadOnly = a;
            dtpNgaySinh.Enabled = !a;
            cboChucVu.Enabled = !a;
            txtLuong.ReadOnly = a;
            txtDiaChi.ReadOnly = a;
            rdbNam.Enabled = !a;
            rdbNu.Enabled = !a;
            txtSDT.ReadOnly = a;
            txtEmail.ReadOnly = a;
        }

        public void HienThiDSNhanVien()
        {
            var listNhanVien = db.tbl_NhanVien.Join(db.tbl_ChucVu,
                s => s.MaChucVu,
                k => k.MaChucVu, (s, k) => new
                {
                    MaNhanVien = s.MaNhanVien,
                    HoTen = s.HoTen,
                    NgaySinh = s.NgaySinh,
                    Luong = s.Luong,
                    DiaChi = s.DiaChi,
                    GioiTinh = s.GioiTinh,
                    SDT = s.SDT,
                    Email = s.Email,
                    TenChucVu = k.TenChucVu,
                }).ToList();
            dgvNhanVien.DataSource = listNhanVien;
        }

        public void HienThiChucVu()
        {
            var listChucVu = db.tbl_ChucVu.ToList();
            cboChucVu.DataSource = listChucVu;
            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "MaChucVu";
        }

        public string TangMaNV()
        {
            string sql = @"select * from tbl_NhanVien";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source=LAPTOP-OH9ESAI8\\SQLEXPRESS;initial catalog=QuanLyChoThueVanPhong;integrated security=True";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "NV01";
            }
            else
            {
                int k;
                ma = "NV";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                {
                    ma = ma + "0";
                }
                else if (k < 100)
                {
                    ma = ma + "";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtTenNV.Text = row.Cells[1].Value.ToString();
                dtpNgaySinh.Text = row.Cells[2].Value.ToString();
                txtLuong.Text = row.Cells[3].Value.ToString();
                cboChucVu.SelectedIndex = cboChucVu.FindString(row.Cells[8].Value.ToString());
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value.ToString() == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                txtSDT.Text = row.Cells[6].Value.ToString();
                txtEmail.Text = row.Cells[7].Value.ToString();
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Flag = true;
            setButton(false);
            setKhoa(false);
            setNull();
            txtMaNV.Text = TangMaNV();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
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
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text;
                string tennv = txtTenNV.Text;
                DateTime ngaysinh = DateTime.Parse(dtpNgaySinh.Value.ToString("dd/MM/yyyy"));
                float luong = float.Parse(txtLuong.Text);
                string diachi = txtDiaChi.Text;
                string gioitinh;
                if (rdbNam.Checked == true)
                    gioitinh = "Nam";
                else
                    gioitinh = "Nữ";
                string sdt = txtSDT.Text;
                string email = txtEmail.Text;
                string chucvu = cboChucVu.SelectedValue.ToString();
                if (Flag == true)
                {
                    if (db.tbl_NhanVien.SqlQuery("select * from tbl_NhanVien").Where(m => m.MaNhanVien.Contains(txtMaNV.Text)).Count() > 0)
                    {
                        XtraMessageBox.Show("Mã nhân viên nhập sai hoặc bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtTenNV.Text == "" || txtLuong.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtEmail.Text == "")
                        {
                            XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                        }
                        else
                        {
                            tbl_NhanVien nv = new tbl_NhanVien();
                            nv.MaNhanVien = manv;
                            nv.HoTen = tennv;
                            nv.NgaySinh = ngaysinh;
                            nv.Luong = luong;
                            nv.DiaChi = diachi;
                            nv.GioiTinh = gioitinh;
                            nv.SDT = sdt;
                            nv.Email = email;
                            nv.MaChucVu = chucvu;
                            db.tbl_NhanVien.Add(nv);
                            db.SaveChanges();
                            HienThiDSNhanVien();
                            XtraMessageBox.Show("Thêm nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setNull();
                            setButton(true);
                            setKhoa(true);
                        }
                    }
                }
                else
                {
                    tbl_NhanVien nv = db.tbl_NhanVien.Where(m => m.MaNhanVien == manv).FirstOrDefault();
                    nv.HoTen = tennv;
                    nv.NgaySinh = ngaysinh;
                    nv.Luong = luong;
                    nv.DiaChi = diachi;
                    nv.GioiTinh = gioitinh;
                    nv.SDT = sdt;
                    nv.Email = email;
                    nv.MaChucVu = chucvu;
                    if (nv == null)
                    {
                        XtraMessageBox.Show("Nhân viên không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        db.Entry(nv).State = EntityState.Modified;
                        db.SaveChanges();
                        HienThiDSNhanVien();
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
            setNull();
            setButton(true);
            setKhoa(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa không ? ", "Thông Báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string manv = txtMaNV.Text;
                    tbl_NhanVien nv = db.tbl_NhanVien.Find(manv);
                    db.tbl_NhanVien.Remove(nv);
                    db.SaveChanges();
                    HienThiDSNhanVien();
                    setNull();
                }
            }
            else
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa");
        }

        public void TimTheoMa()
        {
            string manv = schTimKiem.Text;
            var list = db.tbl_NhanVien.Join(db.tbl_ChucVu,
                s => s.MaChucVu,
                k => k.MaChucVu, (s, k) => new
                {
                    MaNhanVien = s.MaNhanVien,
                    HoTen = s.HoTen,
                    NgaySinh = s.NgaySinh,
                    Luong = s.Luong,
                    DiaChi = s.DiaChi,
                    GioiTinh = s.GioiTinh,
                    SDT = s.SDT,
                    Email = s.Email,
                    TenChucVu = k.TenChucVu,
                }).Where(m => m.MaNhanVien.Contains(manv)).ToList();
            dgvNhanVien.DataSource = list;
        }

        public void TimTheoTen()
        {
            string tennv = schTimKiem.Text;
            var list = db.tbl_NhanVien.Join(db.tbl_ChucVu,
                s => s.MaChucVu,
                k => k.MaChucVu, (s, k) => new
                {
                    MaNhanVien = s.MaNhanVien,
                    HoTen = s.HoTen,
                    NgaySinh = s.NgaySinh,
                    Luong = s.Luong,
                    DiaChi = s.DiaChi,
                    GioiTinh = s.GioiTinh,
                    SDT = s.SDT,
                    Email = s.Email,
                    TenChucVu = k.TenChucVu,
                }).Where(m => m.HoTen.Contains(tennv)).ToList();
            dgvNhanVien.DataSource = list;
        }

        public void TimTheoChucVu()
        {
            string tencv = schTimKiem.Text;
            var list = db.tbl_NhanVien.Join(db.tbl_ChucVu,
                s => s.MaChucVu,
                k => k.MaChucVu, (s, k) => new
                {
                    MaNhanVien = s.MaNhanVien,
                    HoTen = s.HoTen,
                    NgaySinh = s.NgaySinh,
                    Luong = s.Luong,
                    DiaChi = s.DiaChi,
                    GioiTinh = s.GioiTinh,
                    SDT = s.SDT,
                    Email = s.Email,
                    TenChucVu = k.TenChucVu,
                }).Where(m => m.TenChucVu.Contains(tencv)).ToList();
            dgvNhanVien.DataSource = list;
        }            

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void schTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(cboTimKiem.SelectedIndex == 0)
            {
                TimTheoMa();
            }
            else if (cboTimKiem.SelectedIndex == 1)
            {
                TimTheoTen();
            }
            else
            {
                TimTheoChucVu();
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
            else
            {
                TimTheoChucVu();
            }
        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {
            float num = 0;
            if(float.TryParse(txtLuong.Text, out num))
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                float value = float.Parse(txtLuong.Text, System.Globalization.NumberStyles.AllowThousands);
                txtLuong.Text = String.Format(culture, "{0:N0}", value);
                txtLuong.Select(txtLuong.Text.Length, 0);
            }    
        }
    }
}