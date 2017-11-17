using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace Telephonnist
{
    public partial class LoginForm : Form
    {
        private bool mainFrameOpened;

        public LoginForm()
        {
            InitializeComponent();
        }

        public bool MainFrameOpened { get => mainFrameOpened; set => mainFrameOpened = value; }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            string User = txtUser.Text;
            string Pass = txtPass.Text;

            //  Send Request;
            HttpClient client = new HttpClient();

            bool isCorrect = true;
            // get Response
            string Url = "https://www.google.com/maps";

            if (isCorrect)
            {
                MainFrame main = (mainFrameOpened ? (MainFrame)Application.OpenForms["MainFrame"] : new MainFrame(Url));
                main.Visible = true;
                Visible = false;
                mainFrameOpened = true;
            }
            else
            {
                MessageBox.Show("Username or Password was wrong!!!");
            }
        }
    }
}
