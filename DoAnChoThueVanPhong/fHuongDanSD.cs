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

namespace DoAnChoThueVanPhong
{
    public partial class fHuongDanSD : DevExpress.XtraEditors.XtraForm
    {
        public fHuongDanSD()
        {
            InitializeComponent();
        }

        private void wbHDSD_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
        }

        private void fHuongDanSD_Load(object sender, EventArgs e)
        {
            wbHDSD.Navigate(@"C:\Users\asus\Desktop\Hướng dẫn chức năng.mht");
        }
    }
}