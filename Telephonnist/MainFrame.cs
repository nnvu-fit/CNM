using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using CefSharp;
using CefSharp.WinForms;

namespace Telephonnist
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        public ChromiumWebBrowser browser;

        public MainFrame(string Url)
        {
            InitializeComponent();

            var settings = new CefSettings();
            settings.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";

            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

            browser = new ChromiumWebBrowser(Url);

            gbMaps.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            int iWidth = tabDriver.Width;
            tabDriver.Controls.Add(new Button()
            {
                Width = iWidth
            });
        }

        public void MainFrame_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void BtLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = (LoginForm)Application.OpenForms["LoginForm"];
            loginForm.Visible = true;
            Visible = false;
        }

        private void rdbStandard_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
