namespace cs99_winform_app
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("TEST");
            Commons.frmSignup = new FrmSignup();
            Commons.frmSignup.Show();
            this.Hide();
        }

        private void FrmLogin_Activated(object sender, EventArgs e)
        {
            this.Show();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
