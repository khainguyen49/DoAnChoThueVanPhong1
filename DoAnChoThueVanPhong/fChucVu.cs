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
    public partial class fChucVu : DevExpress.XtraEditors.XtraForm
    {
        VanPhongDBContext db = new VanPhongDBContext();
        public fChucVu()
        {
            InitializeComponent();
        }

        private void fChucVu_Load(object sender, EventArgs e)
        {
            HienThiDSChucVu();
        }

        public void HienThiDSChucVu()
        {
            var listchucvu = db.tbl_ChucVu.Select(c => new { c.MaChucVu, c.TenChucVu }).ToList();
            dgvChucVu.DataSource = listchucvu;
        }

        void setNull()
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string macv = txtMaCV.Text;
                string tencv = txtTenCV.Text;
                if (db.tbl_ChucVu.SqlQuery("select * from tbl_ChucVu").Where(m => m.MaChucVu.Contains(txtMaCV.Text)).Count() > 0)
                {
                    XtraMessageBox.Show("Mã chức vụ nhập sai hoặc bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtMaCV.Text == "" || txtTenCV.Text == "")
                    {
                        XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    }
                    else
                    {
                        tbl_ChucVu cv = new tbl_ChucVu();
                        cv.MaChucVu = macv;
                        cv.TenChucVu = tencv;
                        db.tbl_ChucVu.Add(cv);
                        db.SaveChanges();
                        HienThiDSChucVu();
                        XtraMessageBox.Show("Đã thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setNull();
                    }
                }
            }
            catch { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgvChucVu.SelectedRows.Count > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa không ? ", "Thông Báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string macv = txtMaCV.Text;
                    tbl_ChucVu cv = db.tbl_ChucVu.Find(macv);
                    db.tbl_ChucVu.Remove(cv);
                    db.SaveChanges();
                    HienThiDSChucVu();
                    setNull();
                }    
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa");
            }           
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvChucVu.Rows[e.RowIndex];
                txtMaCV.Text = row.Cells[0].Value.ToString();
                txtTenCV.Text = row.Cells[1].Value.ToString();
            }
            catch { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            setNull();
        }
    }
}