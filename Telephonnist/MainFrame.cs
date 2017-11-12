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

namespace Telephonnist
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            wbMap.Url = new Uri(String.Format("file:///{0}/../../Maps/Maps.html", curDir));
        }

        private void MainFrame_Close(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void View_Click(object sender, EventArgs e)
        {
        }
    }
}
