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
    public partial class fVanPhong : DevExpress.XtraEditors.XtraForm
    {
        public static string mavp;
        bool Flag;
        VanPhongDBContext db = new VanPhongDBContext();
        public fVanPhong()
        {
            InitializeComponent();
        }

        private void fVanPhong_Load(object sender, EventArgs e)
        {             
            cboTimKiem.SelectedIndex = 0;
            HienThiDSVanPhong();
            setNull();
            setButton(true);
            setKhoa(true);           
        }

        void setNull()
        {
            txtMaVP.Text = "";
            txtTenVP.Text = "";
            txtGia.Text = "";
            txtDVT.Text = "";
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
            txtMaVP.ReadOnly = !a;
            txtTenVP.ReadOnly = a;
            cboTinhTrang.Enabled = !a;
            cboTang.Enabled = !a;
            txtGia.ReadOnly = a;
            txtDVT.ReadOnly = a;
        }

        void setKhoa(bool a)
        {
            txtMaVP.ReadOnly = !a;
            txtTenVP.ReadOnly = a;
            cboTinhTrang.Enabled = !a;
            cboTang.Enabled = !a;
            txtGia.ReadOnly = a;
            txtDVT.ReadOnly = a;
        }

        public void HienThiDSVanPhong()
        {
            var listVanPhong = db.tbl_VanPhong.Select(c => new { c.MaVanPhong, c.TenVanPhong, c.TinhTrang, c.Tang, c.Gia, c.DVT }).ToList();
            dgvVanPhong.DataSource = listVanPhong;
        }

        public string TangMaVP()
        {
            string sql = @"select * from tbl_VanPhong";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source=LAPTOP-OH9ESAI8\\SQLEXPRESS;initial catalog=QuanLyChoThueVanPhong;integrated security=True";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "VP01";
            }
            else
            {
                int k;
                ma = "VP";
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
            cboTang.SelectedIndex = 0;
            cboTinhTrang.SelectedIndex = 0;
            Flag = true;
            setButton(false);
            setKhoa(false);
            setNull();
            txtMaVP.Text = TangMaVP();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvVanPhong.SelectedRows.Count > 0)
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
                string mavp = txtMaVP.Text;
                string tenvp = txtTenVP.Text;
                string tinhtrang = cboTinhTrang.SelectedItem.ToString();
                int tang = int.Parse(cboTang.SelectedItem.ToString());
                float gia = float.Parse(txtGia.Text);
                string dvt = txtDVT.Text;
                if (Flag == true)
                {
                    if (db.tbl_VanPhong.SqlQuery("select * from tbl_VanPhong").Where(m => m.MaVanPhong.Contains(txtMaVP.Text)).Count() > 0)
                    {
                        XtraMessageBox.Show("Mã văn phòng nhập sai hoặc bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtTenVP.Text == "" || txtGia.Text == "" || txtDVT.Text == "")
                        {
                            XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                        }
                        else
                        {
                            tbl_VanPhong vp = new tbl_VanPhong();
                            vp.MaVanPhong = mavp;
                            vp.TenVanPhong = tenvp;
                            vp.TinhTrang = tinhtrang;
                            vp.Tang = tang;
                            vp.Gia = gia;
                            vp.DVT = dvt;
                            db.tbl_VanPhong.Add(vp);
                            db.SaveChanges();
                            HienThiDSVanPhong();
                            XtraMessageBox.Show("Thêm văn phòng thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setNull();
                            setButton(true);
                            setKhoa(true);
                        }
                    }
                }
                else
                {
                    tbl_VanPhong vp = db.tbl_VanPhong.Where(m => m.MaVanPhong == mavp).FirstOrDefault();
                    vp.TenVanPhong = tenvp;
                    vp.TinhTrang = tinhtrang;
                    vp.Tang = tang;
                    vp.Gia = gia;
                    vp.DVT = dvt;
                    if (vp == null)
                    {
                        XtraMessageBox.Show("Văn phòng không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        db.Entry(vp).State = EntityState.Modified;
                        db.SaveChanges();
                        HienThiDSVanPhong();
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
            if (dgvVanPhong.SelectedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa không ? ", "Thông Báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string mavp = txtMaVP.Text;
                    tbl_VanPhong vp = db.tbl_VanPhong.Find(mavp);
                    db.tbl_VanPhong.Remove(vp);
                    db.SaveChanges();
                    HienThiDSVanPhong();
                    setNull();
                }
            }
            else
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa");
        }

        public void TimTheoMa()
        {
            string mavp = schTimKiem.Text;
            var list = db.tbl_VanPhong.Select(c => new { c.MaVanPhong, c.TenVanPhong, c.TinhTrang, c.Tang, c.Gia, c.DVT }).Where(m => m.MaVanPhong.Contains(mavp)).ToList();
            dgvVanPhong.DataSource = list;
        }

        public void TimTheoTen()
        {
            string tenvp = schTimKiem.Text;
            var list = db.tbl_VanPhong.Select(c => new { c.MaVanPhong, c.TenVanPhong, c.TinhTrang, c.Tang, c.Gia, c.DVT }).Where(m => m.TenVanPhong.Contains(tenvp)).ToList();
            dgvVanPhong.DataSource = list;
        }

        private void dgvVanPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvVanPhong.Rows[e.RowIndex];
                txtMaVP.Text = row.Cells[0].Value.ToString();
                txtTenVP.Text = row.Cells[1].Value.ToString();
                cboTinhTrang.Text = row.Cells[2].Value.ToString();
                cboTang.Text = row.Cells[3].Value.ToString();
                txtGia.Text = row.Cells[4].Value.ToString();
                txtDVT.Text = row.Cells[5].Value.ToString();
            }
            catch { }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
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
            else 
            {
                TimTheoTen();
            }            
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            float num = 0;
            if(float.TryParse(txtGia.Text, out num))
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                float value = float.Parse(txtGia.Text, System.Globalization.NumberStyles.AllowThousands);
                txtGia.Text = String.Format(culture, "{0:N0}", value);
                txtGia.Select(txtGia.Text.Length, 0);
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
    }
}