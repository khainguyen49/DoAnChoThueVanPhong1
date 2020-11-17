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
    public partial class fDoiMK : DevExpress.XtraEditors.XtraForm
    {
        VanPhongDBContext db = new VanPhongDBContext();
        public fDoiMK()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void setNull()
        {
            txtTenDN.Text = "";
            txtMKCu.Text = "";
            txtMKMoi.Text = "";
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            VanPhongDBContext dBContext = new VanPhongDBContext();
            List<tbl_TaiKhoan> tbl_Tais = dBContext.tbl_TaiKhoan.ToList();
            string tendn = txtTenDN.Text;
            string mkcu = txtMKCu.Text;
            string mkmoi = txtMKMoi.Text;
            try
            {
                if (txtTenDN.Text.Count() == 0 || txtMKCu.Text.Count() == 0 || txtMKMoi.Text.Count() == 0)
                    throw new Exception("Bạn chưa nhập đầy đủ thông tin");
                else
                {
                    foreach(var item in tbl_Tais)
                    {
                        if (item.TenDangNhap == txtTenDN.Text && item.MatKhau == txtMKCu.Text)
                        {
                            tbl_TaiKhoan tk = db.tbl_TaiKhoan.Where(m => m.TenDangNhap == tendn).FirstOrDefault();
                            //tk.MatKhau = mkcu;
                            tk.MatKhau = mkmoi;
                            db.Entry(tk).State = EntityState.Modified;
                            db.SaveChanges();
                            setNull();
                            MessageBox.Show("Đã đổi thành công!", "Thông Báo");                           
                        }
                        else
                        {
                            MessageBox.Show("Tài Khoản và mật khẩu không tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fDoiMK_Load(object sender, EventArgs e)
        {

        }
    }
}