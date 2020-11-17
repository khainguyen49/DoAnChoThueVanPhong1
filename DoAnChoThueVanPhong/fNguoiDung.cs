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

namespace DoAnChoThueVanPhong
{
    public partial class fNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        bool Flag;
        VanPhongDBContext db = new VanPhongDBContext();
        public fNguoiDung()
        {
            InitializeComponent();
        }

        private void fNguoiDung_Load(object sender, EventArgs e)
        {
            HienThiDSTaiKhoan();
            setNull();
            setButton(true);
            setKhoa(true);
        }

        void setNull()
        {
            txtTenDN.Text = "";
            txtTenNV.Text = "";
            txtMK.Text = "";
        }

        void setButton(bool a)
        {
            btnThem.Enabled = a;
            btnXoa.Enabled = a;
            btnSua.Enabled = a;
            btnLuu.Enabled = !a;
            btnHuy.Enabled = !a;
        }

        void setKhoaSua(bool a)
        {
            txtTenDN.ReadOnly = !a;
            txtTenNV.ReadOnly = a;
            rdbAdmin.Enabled = !a;
            rdbNhanVien.Enabled = !a;
            txtMK.ReadOnly = a;
        }

        void setKhoa(bool a)
        {
            txtTenDN.ReadOnly = a;
            txtTenNV.ReadOnly = a;
            rdbAdmin.Enabled = !a;
            rdbNhanVien.Enabled = !a;
            txtMK.ReadOnly = a;
        }

        public void HienThiDSTaiKhoan()
        {
            var listTaiKhoan = db.tbl_TaiKhoan.Select(c => new { c.TenDangNhap, c.TenNhanVien, c.MatKhau, c.Quyen }).ToList();
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaiKhoan.DataSource = listTaiKhoan;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvTaiKhoan.Rows[e.RowIndex];
                txtTenDN.Text = row.Cells[0].Value.ToString();
                txtTenNV.Text = row.Cells[1].Value.ToString();
                txtMK.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString() == "Admin")
                    rdbAdmin.Checked = true;
                else
                    rdbNhanVien.Checked = true;
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Flag = true;
            setButton(false);
            setKhoa(false);
            setNull();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                Flag = false;
                setButton(false);
                setKhoaSua(false);
            }
            else
                XtraMessageBox.Show("Bạn phải chọn mẫu tin để cập nhật!", "Thông Báo");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string tendn = txtTenDN.Text;
                string tennv = txtTenNV.Text;
                string quyen;
                if (rdbAdmin.Checked == true)
                    quyen = "Admin";
                else
                    quyen = "Nhân Viên";
                string matkhau = txtMK.Text;
                if (Flag == true)
                {
                    if (db.tbl_TaiKhoan.SqlQuery("select * from tbl_TaiKhoan").Where(m => m.TenDangNhap.Contains(txtTenDN.Text)).Count() > 0)
                    {
                        XtraMessageBox.Show("Tên đăng nhập sai hoặc bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtTenDN.Text == "" || txtTenNV.Text == "" || txtMK.Text == "")
                        {
                            XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                        }
                        else
                        {
                            tbl_TaiKhoan tk = new tbl_TaiKhoan();
                            tk.TenDangNhap = tendn;
                            tk.TenNhanVien = tennv;
                            tk.Quyen = quyen;
                            tk.MatKhau = matkhau;
                            db.tbl_TaiKhoan.Add(tk);
                            db.SaveChanges();
                            HienThiDSTaiKhoan();
                            XtraMessageBox.Show("Tạo tài khoản thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setNull();
                            setButton(true);
                            setKhoa(true);
                        }
                    }
                }
                else
                {
                    tbl_TaiKhoan tk = db.tbl_TaiKhoan.Where(m => m.TenDangNhap == tendn).FirstOrDefault();
                    tk.TenNhanVien = tennv;
                    tk.Quyen = quyen;
                    tk.MatKhau = matkhau;
                    if (tk == null)
                    {
                        XtraMessageBox.Show("Tài khoản không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        db.Entry(tk).State = EntityState.Modified;
                        db.SaveChanges();
                        HienThiDSTaiKhoan();
                        XtraMessageBox.Show("Cập nhật thành công", "Thông Báo");
                        setNull();
                        setButton(true);
                        setKhoa(true);
                    }
                }
            }
            catch { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setNull();
            setButton(true);
            setKhoa(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa không ? ", "Thông Báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string tendn = txtTenDN.Text;
                    tbl_TaiKhoan tk = db.tbl_TaiKhoan.Find(tendn);
                    db.tbl_TaiKhoan.Remove(tk);
                    db.SaveChanges();
                    HienThiDSTaiKhoan();
                    setNull();
                }
            }
            else
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa");
        }
    }
}