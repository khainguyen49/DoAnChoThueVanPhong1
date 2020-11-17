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
using DevExpress.DirectX.Common.Direct2D;
using DevExpress.XtraReports.UI;

namespace DoAnChoThueVanPhong
{
    public partial class fQuanLyChiTiet : DevExpress.XtraEditors.XtraForm
    {
        bool Flag;
        VanPhongDBContext db = new VanPhongDBContext();
        public fQuanLyChiTiet()
        {
            InitializeComponent();
        }

        private void fQuanLyChiTiet_Load(object sender, EventArgs e)
        {
            cboTimKiem.SelectedIndex = 0;
            HienThiChiTietHD();
            setNull();
            setButton(true);
            setKhoa(true);
        }

        void setNull()
        {
            txtMaCT.Text = "";
            txtMaVP.Text = "";
            txtMaHD.Text = "";
            txtTienCoc.Text = "";
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
            txtMaCT.ReadOnly = !a;
            txtMaHD.ReadOnly = a;
            txtMaVP.ReadOnly = a;
            dtpNgayLap.Enabled = !a;
            txtTienCoc.ReadOnly = a;
        }

        void setKhoa(bool a)
        {
            txtMaCT.ReadOnly = a;
            txtMaHD.ReadOnly = !a;
            txtMaVP.ReadOnly = !a;
            dtpNgayLap.Enabled = !a;
            txtTienCoc.ReadOnly = !a;
        }

        public void HienThiChiTietHD()
        {
            var list = db.tbl_ChiTietHopDong.Select(c => new { c.MaChiTiet, c.MaVanPhong, c.MaHopDong, c.NgayLap, c.TienDatCoc }).ToList();
            dgvChiTietHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHD.DataSource = list;
        }

        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvChiTietHD.Rows[e.RowIndex];
                txtMaCT.Text = row.Cells[0].Value.ToString();
                txtMaVP.Text = row.Cells[1].Value.ToString();
                txtMaHD.Text = row.Cells[2].Value.ToString();
                dtpNgayLap.Text = row.Cells[3].Value.ToString();
                txtTienCoc.Text = row.Cells[4].Value.ToString();
            }
            catch { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHD.SelectedRows.Count > 0)
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
                string mact = txtMaCT.Text;
                string mavp = txtMaVP.Text;
                string mahd = txtMaHD.Text;
                float tiencoc = float.Parse(txtTienCoc.Text);
                DateTime ngaylap = DateTime.Parse(dtpNgayLap.Value.ToString("dd/MM/yyyy"));
                if (Flag == true)
                {
                    if (db.tbl_ChiTietHopDong.SqlQuery("select * from tbl_ChiTietHopDong").Where(m => m.MaChiTiet.Contains(txtMaCT.Text)).Count() > 0)
                    {
                        XtraMessageBox.Show("Mã chi tiết nhập sai hoặc bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtMaCT.Text == "")
                        {
                            XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                        }
                        else
                        {
                            tbl_ChiTietHopDong ct = new tbl_ChiTietHopDong();
                            ct.MaChiTiet = mact;
                            ct.MaVanPhong = mavp;
                            ct.MaHopDong = mahd;
                            ct.TienDatCoc = tiencoc;
                            ct.NgayLap = ngaylap;
                            db.tbl_ChiTietHopDong.Add(ct);
                            db.SaveChanges();
                            HienThiChiTietHD();
                            XtraMessageBox.Show("Thêm chi tiết thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    tbl_ChiTietHopDong ct = db.tbl_ChiTietHopDong.Where(m => m.MaChiTiet == mact).FirstOrDefault();
                    ct.MaVanPhong = mavp;
                    ct.MaHopDong = mahd;
                    ct.TienDatCoc = tiencoc;
                    ct.NgayLap = ngaylap;
                    if (ct == null)
                    {
                        XtraMessageBox.Show("Chi tiết hợp đồng không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        db.Entry(ct).State = EntityState.Modified;
                        db.SaveChanges();
                        HienThiChiTietHD();
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
            if (dgvChiTietHD.SelectedRows.Count > 0)
            {
                DialogResult dr = XtraMessageBox.Show("Bạn có muốn xóa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    string mact = txtMaCT.Text;
                    tbl_ChiTietHopDong ct = db.tbl_ChiTietHopDong.Find(mact);
                    db.tbl_ChiTietHopDong.Remove(ct);
                    db.SaveChanges();
                    HienThiChiTietHD();
                    setNull();
                }
            }
            else
                XtraMessageBox.Show("Vui lòng chọn dòng cần xóa");
        }

        private void txtTienCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
            string mact = schTimKiem.Text;
            var list = db.tbl_ChiTietHopDong.Select(c => new { c.MaChiTiet, c.MaVanPhong, c.MaHopDong, c.NgayLap, c.TienDatCoc }).Where(m => m.MaChiTiet.Contains(mact)).ToList();
            dgvChiTietHD.DataSource = list;
        }

        public void TimTheoVP()
        {
            string vp = schTimKiem.Text;
            var list = db.tbl_ChiTietHopDong.Select(c => new { c.MaChiTiet, c.MaVanPhong, c.MaHopDong, c.NgayLap, c.TienDatCoc }).Where(m => m.MaVanPhong.Contains(vp)).ToList();
            dgvChiTietHD.DataSource = list;
        }

        private void schTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboTimKiem.SelectedIndex == 0)
            {
                TimTheoMa();
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
            else
            {
                TimTheoVP();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            rptChiTiet rpt = new rptChiTiet();
            rpt.ShowPreviewDialog();
        }
    }
}