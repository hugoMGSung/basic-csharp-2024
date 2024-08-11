using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs99_winform_app
{
    public partial class FrmSignup : Form
    {
        public FrmSignup()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (Commons.frmLogin != null)
            {
                Commons.frmLogin.Show();
            }
            else
            {
                Commons.frmLogin = new FrmLogin();
                Commons.frmLogin.Show();
            }

            this.Close();
        }

        private void FrmSignup_Load(object sender, EventArgs e)
        {

        }
    }
}
