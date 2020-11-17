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
using DevExpress.Utils.Text;

namespace DoAnChoThueVanPhong
{
    public partial class fLapHopDong : DevExpress.XtraEditors.XtraForm
    {
        VanPhongDBContext db = new VanPhongDBContext();
        public static string mavp;
        public static string gia;
        public fLapHopDong()
        {
            InitializeComponent();
        }

        private void fLapHopDong_Load(object sender, EventArgs e)
        {
            HienThiPhong();
            HienThiChonVanPhong();
            cboTimKiem.SelectedIndex = 0;
        }

        private void HienThiPhong()
        {
            int dem = 0;
            List<tbl_VanPhong> vanPhongs = db.tbl_VanPhong.ToList();
            foreach (var it in vanPhongs)
            {
                ListViewItem item = new ListViewItem(it.TenVanPhong.ToString());
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, it.MaVanPhong.ToString());
                string tinhtrang = it.TinhTrang.ToString();
                switch (tinhtrang)
                {
                    case "Trống":
                        item.ImageIndex = 0;
                        break;
                    case "Đang Thuê":
                        item.ImageIndex = 1;
                        break;
                    default:
                        item.ImageIndex = 0;
                        break;
                }
                item.SubItems.Add(subItem);
                lsvVanPhong.Items.Add(item);
                if (tinhtrang == "Trống")
                {
                    dem = dem + 1;
                    txtTrong.Text = dem.ToString();
                }
                txtSoVP.Text = vanPhongs.Count.ToString();
            }
        }

        public void HienThiChonVanPhong()
        {
            string x = "Trống";
            var listVanPhong = db.tbl_VanPhong.Select(c => new { c.MaVanPhong, c.TenVanPhong, c.TinhTrang, c.Tang, c.Gia, c.DVT }).Where(m=>m.TinhTrang.Contains(x)).ToList();
            dgvVP.DataSource = listVanPhong;
        }
        
        public int kiemtrachon()
        {
            int dem = 0;
            for(int i = 0; i < dgvVP.RowCount; i++)
            {
                if(Convert.ToBoolean(dgvVP.Rows[i].Cells[0].Value) == true)
                {
                    dem = dem + 1;
                }
            }
            if(dem == 1)
            {
                fHopDong frm = new fHopDong();
                mavp = timMaVP();
                frm.ShowDialog();
                return dem;
            }
            else
            {
                XtraMessageBox.Show("Chỉ được chọn 1 văn phòng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dem;
        }

        public string timMaVP()
        {
            string x = "";
            for(int i = 0; i< dgvVP.RowCount; i++)
            {
                if(Convert.ToBoolean(dgvVP.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvVP.Rows[i].Cells[1].Value);
                }
            }
            return x;
        }

        public string timGia()
        {
            string x = "";
            for (int i = 0; i < dgvVP.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvVP.Rows[i].Cells[0].Value) == true)
                {
                    x = Convert.ToString(dgvVP.Rows[i].Cells[5].Value);
                }
            }
            return x;
        }

        private void lsvVanPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<tbl_VanPhong> vanPhongs = db.tbl_VanPhong.ToList();
            if(lsvVanPhong.SelectedItems.Count > 0)
            {
                string st = lsvVanPhong.SelectedItems[0].SubItems[1].Text;
                foreach(var it in vanPhongs)
                {
                    if(st == it.MaVanPhong.ToString())
                    {
                        if (st == it.MaVanPhong.ToString())
                            txtMaVP.Text = it.MaVanPhong.ToString();
                        txtTenVP.Text = it.TenVanPhong.ToString();
                        txtTinhTrang.Text = it.TinhTrang.ToString();
                        txtTang.Text = it.Tang.ToString();
                        txtGia.Text = it.Gia.ToString();
                        txtDVT.Text = it.DVT.ToString();
                    }
                }
            }
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            float num = 0;
            if (float.TryParse(txtGia.Text, out num))
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                float value = float.Parse(txtGia.Text, System.Globalization.NumberStyles.AllowThousands);
                txtGia.Text = String.Format(culture, "{0:N0}", value);
                txtGia.Select(txtGia.Text.Length, 0);
            }
        }

        private void dgvVP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { }
            catch { }            
        }

        public void TimTheoMa()
        {
            string mavp = schTimKiem.Text;
            var listVanPhong = db.tbl_VanPhong.Select(c => new { c.MaVanPhong, c.TenVanPhong, c.TinhTrang, c.Tang, c.Gia, c.DVT }).Where(m => m.MaVanPhong.Contains(mavp)).ToList();
            dgvVP.DataSource = listVanPhong;
        }

        public void TimTheoTen()
        {
            string tenvp = schTimKiem.Text;
            var listVanPhong = db.tbl_VanPhong.Select(c => new { c.MaVanPhong, c.TenVanPhong, c.TinhTrang, c.Tang, c.Gia, c.DVT }).Where(m => m.TenVanPhong.Contains(tenvp)).ToList();
            dgvVP.DataSource = listVanPhong;
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

        private void btnThemKH_Click(object sender, EventArgs e)
        {            
            fKhachHang frm = new fKhachHang();
            frm.ShowDialog();
        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {           
            try
            {
                kiemtrachon();
                mavp = timMaVP().ToString();
                gia = timGia().ToString();
                //if (Convert.ToBoolean(dgvVP.Rows[dgvVP.CurrentRow.Index].Cells[dgvVP.CurrentCell.ColumnIndex].Value) == true)
                //{
                //    fHopDong frm = new fHopDong();
                //    frm.ShowDialog();
                //}
            }
            catch { }
        }
    }
}