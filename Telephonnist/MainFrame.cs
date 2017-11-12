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

namespace Telephonnist
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        public MainFrame(string Url)
        {
            InitializeComponent();
            wbMaps.Navigate(Url);
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
    }
}
