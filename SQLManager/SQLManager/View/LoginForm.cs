using SQLManager.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLManager.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            HideError();
        }

        private void HideError() => lbError.Visible = false;

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //login
                RepositoryFactory.Repository.Login(
                    tbServer.Text.Trim(),
                    tbUsername.Text.Trim(),
                    tbPassword.Text.Trim()
                    );
                new MainForm().Show();
                Hide();
            }
            catch (Exception ex)
            {

                lbError.Visible = true;
            }

        }
    }
}
