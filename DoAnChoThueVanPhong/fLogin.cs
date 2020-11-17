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
using DevExpress.Utils.Filtering;

namespace DoAnChoThueVanPhong
{
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        VanPhongDBContext db = new VanPhongDBContext();
        //Tạo đối tượng dữ liệu static 
        public static DataTable dtTaiKhoan;
        public static bool flagCheckLogin = false;
        public static string idLoginSuccess;
        public static string Quyen;
        public static string id;
        public static string mk;

        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {//bắt lỗi khi đăng nhập sai thông tin 
            try
            {
                if (txtUser.Text.Count() == 0 || txtPass.Text.Count() == 0)
                    throw new Exception("Bạn chưa nhập đầy đủ thông tin");
                else
                {
                    var login = db.tbl_TaiKhoan.FirstOrDefault(tk => tk.TenDangNhap.ToString() == txtUser.Text && tk.MatKhau.ToString() == txtPass.Text);
                    if (login != null)
                    {
                        XtraMessageBox.Show("Đăng nhập thành công", "Thông báo");
                        //Sau khi đăng nhập thành công, lấy dữ liệu
                        flagCheckLogin = true;
                        idLoginSuccess = txtUser.Text;

                        //Lấy quyền sở hữu tài khoản
                        var linqQuyen = from tk in db.tbl_TaiKhoan where tk.TenDangNhap == txtUser.Text select tk.Quyen;
                        Quyen = linqQuyen.FirstOrDefault().ToString();
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo");
                    }
                }    
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void ptEye_MouseDown(object sender, MouseEventArgs e)
        {
            // doi trang thai textbox pass
            txtPass.PasswordChar = '\0';
        }

        private void ptEye_MouseUp(object sender, MouseEventArgs e)
        {
            // doi trang thai textbox pass che thông tin
            txtPass.PasswordChar = '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}