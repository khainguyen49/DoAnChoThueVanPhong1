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
    public partial class fKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public static string ma;
        public static string ten;
        bool Flag;
        VanPhongDBContext db = new VanPhongDBContext();
        public fKhachHang()
        {
            InitializeComponent();
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            cboTimKiem.SelectedIndex = 0;
            HienThiDSKhachHang();
            setNull();
            setButton(true);
            setKhoa(true);          
        }

        void setNull()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtCMND.Text = "";
            txtSDT.Text = "";
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
            txtMaKH.ReadOnly = !a;
            txtTenKH.ReadOnly = a;
            rdbNam.Enabled = !a;
            rdbNu.Enabled = !a;
            txtDiaChi.ReadOnly = a;
            txtCMND.ReadOnly = a;
            txtSDT.ReadOnly = a;
        }

        void setKhoa(bool a)
        {
            txtMaKH.ReadOnly = !a;
            txtTenKH.ReadOnly = a;
            rdbNam.Enabled = !a;
            rdbNu.Enabled = !a;
            txtDiaChi.ReadOnly = a;
            txtCMND.ReadOnly = a;
            txtSDT.ReadOnly = a;
        }

        public void HienThiDSKhachHang()
        {
            var listKhachHang = db.tbl_KhachHang.Select(c => new { c.MaKhachHang, c.HoTenKhach, c.GioiTinh, c.DiaChi, c.CMND, c.SDT }).ToList();
            dgvKH.DataSource = listKhachHang;
        }        

        public string timMaKH()
        {
            string x = "";
            for(int i = 0; i < dgvKH.RowCount; i++)
            {
                if(Convert.ToBoolean(dgvKH.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvKH.Rows[i].Cells[1].Value);
                }
            }
            return x;
        }

        public string timTen()
        {
            string x = "";
            for (int i = 0; i < dgvKH.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvKH.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvKH.Rows[i].Cells[2].Value);
                }
            }
            return x;
        }

        public string TangMaKH()
        {
            string sql = @"select * from tbl_KhachHang";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source=LAPTOP-OH9ESAI8\\SQLEXPRESS;initial catalog=QuanLyChoThueVanPhong;integrated security=True";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "KH01";
            }
            else
            {
                int k;
                ma = "KH";
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            Flag = true;
            setButton(false);
            setKhoa(false);
            setNull();
            txtMaKH.Text = TangMaKH();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKH.SelectedRows.Count > 0)
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
            ma = timMaKH().ToString();
            ten = timTen().ToString();
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string makh = txtMaKH.Text;
                string tenkh = txtTenKH.Text;
                string gioitinh;
                if (rdbNam.Checked == true)
                    gioitinh = "Nam";
                else
                    gioitinh = "Nữ";
                string diachi = txtDiaChi.Text;
                string cmnd = txtCMND.Text;
                string sdt = txtSDT.Text;
                if(Flag == true)
                {
                    if (db.tbl_KhachHang.SqlQuery("select * from tbl_KhachHang").Where(m => m.MaKhachHang.Contains(txtMaKH.Text)).Count() > 0)
                    {
                        XtraMessageBox.Show("Mã khách hàng nhập sai hoặc bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtCMND.Text == "" || txtSDT.Text == "")
                        {
                            XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                        }
                        else
                        {
                            tbl_KhachHang kh = new tbl_KhachHang();
                            kh.MaKhachHang = makh;
                            kh.HoTenKhach = tenkh;
                            kh.GioiTinh = gioitinh;
                            kh.DiaChi = diachi;
                            kh.CMND = cmnd;
                            kh.SDT = sdt;
                            db.tbl_KhachHang.Add(kh);
                            db.SaveChanges();
                            HienThiDSKhachHang();
                            XtraMessageBox.Show("Thêm khách hàng thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setNull();
                            setButton(true);
                            setKhoa(true);
                        }
                    }
                }
                else
                {
                    tbl_KhachHang kh = db.tbl_KhachHang.Where(m => m.MaKhachHang == makh).FirstOrDefault();
                    kh.HoTenKhach = tenkh;
                    kh.GioiTinh = gioitinh;
                    kh.DiaChi = diachi;
                    kh.CMND = cmnd;
                    kh.SDT = sdt;
                    if(kh==null)
                    {
                        XtraMessageBox.Show("Khách hàng không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        db.Entry(kh).State = EntityState.Modified;
                        db.SaveChanges();
                        HienThiDSKhachHang();
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
            setNull();
            setButton(true);
            setKhoa(true);
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvKH.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[1].Value.ToString();
                txtTenKH.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString() == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtCMND.Text = row.Cells[5].Value.ToString();
                txtSDT.Text = row.Cells[6].Value.ToString();
            }
            catch { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKH.SelectedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa không ? ", "Thông Báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string makh = txtMaKH.Text;
                    tbl_KhachHang kh = db.tbl_KhachHang.Find(makh);
                    db.tbl_KhachHang.Remove(kh);
                    db.SaveChanges();
                    HienThiDSKhachHang();
                    setNull();
                }
            }
            else
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa");
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void TimTheoMa()
        {
            string makh = schTimKiem.Text;
            var listKhachHang = db.tbl_KhachHang.Select(c => new { c.MaKhachHang, c.HoTenKhach, c.GioiTinh, c.DiaChi, c.CMND, c.SDT }).Where(m => m.MaKhachHang.Contains(makh)).ToList();
            dgvKH.DataSource = listKhachHang;
        }

        public void TimTheoTen()
        {
            string tenkh = schTimKiem.Text;
            var listKhachHang = db.tbl_KhachHang.Select(c => new { c.MaKhachHang, c.HoTenKhach, c.GioiTinh, c.DiaChi, c.CMND, c.SDT }).Where(m => m.HoTenKhach.Contains(tenkh)).ToList();
            dgvKH.DataSource = listKhachHang;
        }

        public void TimTheoCMND()
        {
            string cmnd = schTimKiem.Text;
            var listKhachHang = db.tbl_KhachHang.Select(c => new { c.MaKhachHang, c.HoTenKhach, c.GioiTinh, c.DiaChi, c.CMND, c.SDT }).Where(m => m.CMND.Contains(cmnd)).ToList();
            dgvKH.DataSource = listKhachHang;
        }

        private void schTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(cboTimKiem.SelectedIndex == 0)
            {
                TimTheoMa();
            }
            else if(cboTimKiem.SelectedIndex == 1)
            {
                TimTheoTen();
            }
            else
            {
                TimTheoCMND();
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
                TimTheoCMND();
            }
        }
    }
}