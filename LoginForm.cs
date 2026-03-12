using System;
using System.Windows.Forms;

namespace QLSinhVienVaLopHoc
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        // them ghi chu 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "quanTD" && txtPassword.Text == "0022568")
            {
                MainForm mainForm = new MainForm();
                this.Hide(); 
                mainForm.ShowDialog(); 
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}