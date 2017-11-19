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

        class DriverBox
        {
            private GroupBox box;
            private Label name, lat, lng;
            private Button button;

            public GroupBox Box { get => box; set => box = value; }
            public Button Button { get => button; set => button = value; }
            public Label Name { get => name; set => name = value; }
            public Label Lat { get => lat; set => lat = value; }
            public Label Lng { get => lng; set => lng = value; }
        };

        private DriverBox[] DriverBoxs;

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
            HttpWebRequest webResquest = WebRequest.CreateHttp("http://localhost:56081/api/managerappone/getinformationcall/" + tbPhone.Text);
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
                tbFrom.Text = user.Address;
                tbTo.Text = user.AddressFormated;
                if (user.TypeCar == 0)
                {
                    rdbStandard.Checked = true;
                    rdbPremium.Checked = false;
                }
                else
                {
                    rdbStandard.Checked = false;
                    rdbPremium.Checked = true;
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
                    webResquest = WebRequest.CreateHttp("http://localhost:56081/api/managerappone/addcall" + user.Phone);
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
            HttpWebRequest webRequest = WebRequest.CreateHttp("http://localhost:56081/api/managerappone/getinformationaddress/");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            var buff = Encoding.UTF8.GetBytes(json);
            webRequest.ContentLength = buff.Length;
            webRequest.GetRequestStream().Write(buff, 0, buff.Length);
            HttpWebResponse webResponse = null;
            try
            {
                webResponse = webRequest.GetResponse() as HttpWebResponse;
                if (webResponse.StatusCode != HttpStatusCode.OK)
                {
                    if (webResponse != null)
                        webResponse.Close();
                    return;
                }
                using (var jsonStream = new StreamReader(webResponse.GetResponseStream()))
                {
                    var buffReader = jsonStream.ReadToEnd();
                    drivers = JsonConvert.DeserializeObject<Driver[]>(buffReader);
                    DriverBoxs = new DriverBox[drivers.Length];
                    for (int ii = 0; ii < DriverBoxs.Length; ii++)
                    {
                        DriverBoxs[ii] = new DriverBox();
                        tabDriver.Controls.Add(DriverBoxs[ii].Box);
                        DriverBoxs[ii].Box.Height = 60;
                        DriverBoxs[ii].Box.Width = tabDriver.Width;
                        DriverBoxs[ii].Box.Text = "Driver" + ii.ToString();

                        DriverBoxs[ii].Name = new Label();
                        DriverBoxs[ii].Box.Controls.Add(DriverBoxs[ii].Name);
                        DriverBoxs[ii].Name.Width = DriverBoxs[ii].Box.Width;
                        DriverBoxs[ii].Name.Text = "Name: "+ drivers[ii].Name;

                        DriverBoxs[ii].Lat = new Label();
                        DriverBoxs[ii].Box.Controls.Add(DriverBoxs[ii].Lat);
                        DriverBoxs[ii].Lat.Width = DriverBoxs[ii].Box.Width;
                        DriverBoxs[ii].Lat.Text = "Lat: " + drivers[ii].Lat;

                        DriverBoxs[ii].Lng = new Label();
                        DriverBoxs[ii].Box.Controls.Add(DriverBoxs[ii].Lng);
                        DriverBoxs[ii].Lng.Width = DriverBoxs[ii].Box.Width;
                        DriverBoxs[ii].Lng.Text = "Lng: " + drivers[ii].Lng;

                        DriverBoxs[ii].Button = new Button();
                        DriverBoxs[ii].Box.Controls.Add(DriverBoxs[ii].Button);
                        DriverBoxs[ii].Button.Width = DriverBoxs[ii].Box.Width;
                        DriverBoxs[ii].Button.Text = "Book this car";
                        DriverBoxs[ii].Button.Left = (DriverBoxs[ii].Box.Width - DriverBoxs[ii].Button.Width) / 2 - 1;
                    }
                }
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
