using System;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Telephonnist
{
    public partial class MainFrame : Form
    {
        private User user;
        private ChromiumWebBrowser browser;
        private Driver[] drivers;

        public MainFrame()
        {
            InitializeComponent();
        }

        public ChromiumWebBrowser Browser { get => browser; set => browser = value; }

        public MainFrame(string Url)
        {
            InitializeComponent();

            var settings = new CefSettings
            {
                BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe"
            };

            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

            Browser = new ChromiumWebBrowser(Url);

            gbMaps.Controls.Add(Browser);
            Browser.Dock = DockStyle.Fill;

            user = new User()
            {
                Phone = "",
                Address = "",
                AddressFormated = "",
                Status = 0,
                Time = DateTime.Now.ToString("dd/MM/yyyy"),
                TypeCar = 0
            };
        }

        public void MainFrame_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = (LoginForm)Application.OpenForms["LoginForm"];
            loginForm.Visible = true;
            Visible = false;
        }

        private void RdbStandard_CheckedChanged(object sender, EventArgs e)
        {
            rdbPremium.Checked = false;
            rdbStandard.Checked = true;
            user.TypeCar = 0;
        }

        private void RdbPremium_CheckedChanged(object sender, EventArgs e)
        {
            rdbPremium.Checked = true;
            rdbStandard.Checked = false;
            user.TypeCar = 1;
        }

        private void TbPhone_TextChanged(object sender, EventArgs e)
        {
            user.Phone = this.Text;
            btFind.Show();
            btLook.Hide();
        }

        private void TbFullName_TextChanged(object sender, EventArgs e)
        {
            user.Fullname = this.Text;
        }

        private void BtFind_Click(object sender, EventArgs e)
        {
            if (tbPhone.Text.Length < 1)
                return;
            HttpWebRequest webResquest = WebRequest.CreateHttp("http://localhost:56081/managerappone/getinformationcall/" + tbPhone.Text);
            webResquest.Method = "GET";
            webResquest.ContentType = "application/json";
            HttpWebResponse webResponse = null;
            try
            {
                webResponse = webResquest.GetResponse() as HttpWebResponse;
                using (var jsonStream = new StreamReader(webResponse.GetResponseStream()))
                {
                    var result = JObject.Parse(jsonStream.ReadToEnd());
                    user.Phone = tbPhone.Text;
                    user.Fullname = tbFullName.Text;
                    user.Address = result.Value<string>("address");
                    user.Status = result.Value<int>("status");
                    user.TypeCar = result.Value<int>("typeCar");
                    user.Time = result.Value<string>("time");
                    user.AddressFormated = result.Value<string>("addressFormated");

                    jsonStream.Close();
                }
                btLook.Show();
                btFind.Hide();
            }
            catch (WebException Exec)
            {
                if (Exec.Status == WebExceptionStatus.ProtocolError)
                {
                    webResponse = (HttpWebResponse)Exec.Response;
                    MessageBox.Show("Error code: " + webResponse.StatusCode.ToString());
                    var json = JsonConvert.SerializeObject(
                        new
                        {
                            address = user.Address,
                            addressFormated = user.AddressFormated,
                            status = 0,
                            time = user.Time,
                            typeCar = user.TypeCar
                        });
                    webResquest = WebRequest.CreateHttp("http://localhost:56081/managerappone/addcall" + user.Phone);
                    webResquest.Method = "PUT";
                    webResquest.ContentType = "application/json";
                    var buff = Encoding.UTF8.GetBytes(json);
                    webResquest.ContentLength = buff.Length;
                    webResquest.GetRequestStream().Write(buff, 0, buff.Length);
                    try
                    {
                        webResponse = webResquest.GetResponse() as HttpWebResponse;
                    }
                    catch (WebException Exec1)
                    {
                        webResponse = (HttpWebResponse)Exec1.Response;
                        MessageBox.Show("Error code: " + webResponse.StatusCode.ToString());
                    }
                    finally
                    {
                        if (webResponse != null)
                            webResponse.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Error: " + Exec.Status.ToString());
                }
            }
            finally
            {
                if (webResponse != null)
                    webResponse.Close();
            }
        }

        private void BtLook_Click(object sender, EventArgs e)
        {
            if (tbFrom.Text.Length < 1)
                return;
            var json = JsonConvert.SerializeObject(
                new
                {
                    Phone = tbPhone.Text,
                    address = tbFrom.Text
                });
            HttpWebRequest webRequest = WebRequest.CreateHttp("http://localhost:56081/managerappone/getinformationaddress/");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            var buff = Encoding.UTF8.GetBytes(json);
            webRequest.ContentLength = buff.Length;
            webRequest.GetRequestStream().Write(buff, 0, buff.Length);
            HttpWebResponse webResponse = null;
            try
            {
                webResponse = webRequest.GetResponse() as HttpWebResponse;
                btFind.Show();
                btLook.Hide();
            }
            catch (WebException exec)
            {
                if (exec.Status == WebExceptionStatus.ProtocolError)
                {
                    webResponse = (HttpWebResponse)exec.Response;
                    MessageBox.Show("Error code: " + webResponse.StatusCode.ToString());
                }
                else
                {
                    MessageBox.Show("Error: " + exec.Status.ToString());
                }
            }
            finally
            {
                if (webResponse != null)
                    webResponse.Close();
            }
        }

        private void BtBook_Click(object sender, EventArgs e)
        {

        }
    }
}
