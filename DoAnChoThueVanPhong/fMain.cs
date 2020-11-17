using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DoAnChoThueVanPhong.Models;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraReports.UI;

/*Trong fLogin đã tạo một biến dữ liệu idLoginSuccess để chứ tên tài khoản hiện đang đăng nhập vào
 * hệ thống, từ đó biến này, trong mọi chức năng dùng câu điều kiện rẽ nhánh để phân quyền chức năng,
 * dùng câu lệnh truy vấn linq để thực hiện lấy dữ liệu.
 */

namespace DoAnChoThueVanPhong
{
    public partial class fMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        fLogin frm;
        public fMain()
        {
            InitializeComponent();
        }

        //Chỉnh màu giao diện
        public void Skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Office 2019 Colorful";
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            PhanQuyenChucNang(false);
            Skins();
            fImageSlider frm = new fImageSlider();
            ViewForm(frm);
            // test splash
            for(int i = 0; i < 100; i ++)
            {
                Thread.Sleep(80);
            }    
        }

        //Hàm điều kiện để các form được mở không lặp lại
        private bool KiemTraForm(Form form)
        {
            bool flag = false;
            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (form.Name == item.Name) // Kiểm tra tab
                    {
                        xtraTabbedMdiManager1.Pages[item].MdiChild.Activate();
                        flag = true;
                    }
                }
            }
            return flag;
        }

        //Set form
        private void ViewForm(Form _form)
        {
            if (!KiemTraForm(_form))
            {
                _form.MdiParent = this;
                _form.Show();
            }
        }

        private void barbtnQLNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            fNhanVien frm = new fNhanVien();
            ViewForm(frm);
        }

        private void barbtnQLKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            fQuanLyKhachHang frm = new fQuanLyKhachHang();
            ViewForm(frm);
        }

        private void barbtnQLVP_ItemClick(object sender, ItemClickEventArgs e)
        {
            fVanPhong frm = new fVanPhong();
            ViewForm(frm);
        }

        // Viết sự kiện frmDangNhap đóng
        void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
        }

        private void barbtnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm = new fLogin();            
            this.Hide();
            frm.ShowDialog();
            if (fLogin.flagCheckLogin)
            {               
                if (fLogin.Quyen == "Nhân Viên")
                {                   
                    PhanQuyenUser(true);
                }
                else
                {
                    PhanQuyenChucNang(true);
                }               
            }
            this.Show();
        }

        private void barbtnChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            fChucVu frm = new fChucVu();
            frm.ShowDialog();
            this.Show();
        }

        public void PhanQuyenChucNang(bool state)
        {
            // Đối tượng Admin  
                barbtnDangNhap.Enabled = !state;
                barbtnDangXuat.Enabled = state;
                barbtnQLNV.Enabled = state;
                barbtnQLKH.Enabled = state;
                barbtnQLVP.Enabled = state;
                barbtnChucVu.Enabled = state;
                barbtnDoiMK.Enabled = state;
                barbtnPhanQuyen.Enabled = state;
                barbtnSaoLuu.Enabled = state;
                barbtnKhoiPhuc.Enabled = state;
                barbtnDoanhThu.Enabled = state;
                barbtnSLKhach.Enabled = state;
                barbtnSLNhanVien.Enabled = state;
                barbtnThang.Enabled = state;
                barbtnQuy.Enabled = state;
                barbtnThueVP.Enabled = state;
                barbtnLapHopDong.Enabled = state;
                barbtnHopD.Enabled = state;
                barbtnCT.Enabled = state;
                barbtnHoaDon.Enabled = state;
                barbtnCongTy.Enabled = state;
                barbtnHDSD.Enabled = state;
                barbtnLienHe.Enabled = state;
        }

        //Phân quyền chức vụ User
        void PhanQuyenUser(bool state)
        {
            barbtnDangNhap.Enabled = !state;
            barbtnDangXuat.Enabled = state;
            barbtnQLNV.Enabled = state;
            barbtnQLKH.Enabled = state;
            barbtnQLVP.Enabled = state;
            barbtnChucVu.Enabled = state;
            barbtnDoiMK.Enabled = state;
            barbtnPhanQuyen.Enabled = !state;
            barbtnSaoLuu.Enabled = !state;
            barbtnKhoiPhuc.Enabled = !state;
            barbtnDoanhThu.Enabled = !state;
            barbtnSLKhach.Enabled = state;
            barbtnSLNhanVien.Enabled = state;
            barbtnThang.Enabled = state;
            barbtnQuy.Enabled = state;
            barbtnThueVP.Enabled = state;
            barbtnLapHopDong.Enabled = state;
            barbtnHopD.Enabled = state;
            barbtnCT.Enabled = state;
            barbtnHoaDon.Enabled = state;
            barbtnCongTy.Enabled = state;
            barbtnHDSD.Enabled = state;
            barbtnLienHe.Enabled = state;
        }

        private void barbtnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barbtnHoaDon_ItemClick(object sender, ItemClickEventArgs e)
        {
            fQuanLyHoaDon frm = new fQuanLyHoaDon();
            ViewForm(frm);
        }

        private void barbtnDoiMK_ItemClick(object sender, ItemClickEventArgs e)
        {
            fDoiMK frm = new fDoiMK();
            frm.ShowDialog();
            this.Show();
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(XtraMessageBox.Show("Bạn thật sự muốn thoát chương trình ?", "Thông Báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }    
        }

        private void barbtnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {           
            fLogin.idLoginSuccess = "";
            fLogin.flagCheckLogin = false;
            //phân quyền tắt hết chức năng đi chỉ còn đăng nhập
            PhanQuyenChucNang(false);
        }

        private void barbtnPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            fNguoiDung frm = new fNguoiDung();
            frm.ShowDialog();
            this.Show();
        }

        private void barbtnLapHopDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            fLapHopDong frm = new fLapHopDong();
            ViewForm(frm);
        }

        private void barbtnHopD_ItemClick(object sender, ItemClickEventArgs e)
        {
            fQuanLyHopDong frm = new fQuanLyHopDong();
            ViewForm(frm);
        }

        private void barbtnCongTy_ItemClick(object sender, ItemClickEventArgs e)
        {
            fThongTinCT frm = new fThongTinCT();
            ViewForm(frm);
        }

        private void barbtnCT_ItemClick(object sender, ItemClickEventArgs e)
        {
            //fQuanLyChiTiet frm = new fQuanLyChiTiet();
            //ViewForm(frm);
        }

        private void barbtnThueVP_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptVanPhong rpt = new rptVanPhong();
            rpt.ShowPreviewDialog();
        }

        private void barbtnSLKhach_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptKhachHang rpt = new rptKhachHang();
            rpt.ShowPreviewDialog();
        }

        private void barbtnSLNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptNhanVien rpt = new rptNhanVien();
            rpt.ShowPreviewDialog();
        }

        private void barbtnHDSD_ItemClick(object sender, ItemClickEventArgs e)
        {
            fHuongDanSD frm = new fHuongDanSD();
            ViewForm(frm);
        }
    }
}