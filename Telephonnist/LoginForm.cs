﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephonnist
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            string User = txtUser.Text;
            string Pass = txtPass.Text;

            //  Send Request;
            bool isCorrect = true;

            if (isCorrect)
            {
                MainFrame main = new MainFrame();
                main.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show("Username or Password was wrong!!!");
            }
        }
    }
}
