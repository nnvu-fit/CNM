using System;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Collections.Generic;

namespace Telephonnist
{
    public partial class MainFrame : Form
    {
        private User user;
        private ChromiumWebBrowser browser;
        List<Driver> drivers;
        class DriverBox
        {
            public DriverBox()
            {
                box = new GroupBox();
                Name = new Label();
                Lat = new Label();
                Lng = new Label();
                button = new Button();
            }
            private GroupBox box;
            private Label name, lat, lng;
            private Button button;

            public GroupBox Box
            {
                get
                {
                    return box;
                }

                set
                {
                    box = value;
                }
            }



            public Button Button
            {
                get
                {
                    return button;
                }

                set
                {
                    button = value;
                }
            }

            public Label Lat
            {
                get
                {
                    return lat;
                }

                set
                {
                    lat = value;
                }
            }

            public Label Lng
            {
                get
                {
                    return lng;
                }

                set
                {
                    lng = value;
                }
            }

            public Label Name
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }
        };

        private DriverBox[] DriverBoxs;

        public ChromiumWebBrowser Browser
        {
            get
            {
                return browser;
            }

            set
            {
                browser = value;
            }
        }

        public MainFrame()
        {
            InitializeComponent();
        }

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
            //rdbPremium.Checked = false;
            //rdbStandard.Checked = true;
            user.TypeCar = 0;
        }

        private void RdbPremium_CheckedChanged(object sender, EventArgs e)
        {
            //rdbPremium.Checked = true;
            //rdbStandard.Checked = false;
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
            label_his_phone.Text = tbPhone.Text;
            label_his_addr.Text = tbFrom.Text;
            label_his_status.Text = "0";
            label_his_type.Text = user.TypeCar.ToString();
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
                tbFrom.Text = user.AddressFormated;
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

                label_his_phone.Text = user.Phone;
                label_his_addr.Text = user.AddressFormated;
                //        0 : 
                //    1 : đang tìm xe
                //    2 : đã định vị
                //    3 : 
                switch (user.Status)
                {
                    case 0:
                        label_his_status.Text = "chưa xac định tọa độ";
                        break;
                    case 1:
                        label_his_status.Text = "đang tìm xe";
                        break;
                    case 2:
                        label_his_status.Text = "đã định vị";
                        break;
                    case 3:
                        label_his_status.Text = "không có xe";
                        break;
                }
                if (user.TypeCar == 0)
                    label_his_type.Text = "xe thường";
                else
                    label_his_type.Text = "xe vip";
                btLook.Show();
                btFind.Hide();
            }
            catch (WebException Exec)
            {
                if (Exec.Status == WebExceptionStatus.ProtocolError)
                {
                    webResponse = (HttpWebResponse)Exec.Response;
                    //MessageBox.Show("Error code: " + webResponse.StatusCode.ToString());
                    var json = JsonConvert.SerializeObject(
                        new
                        {
                            phone = tbPhone.Text,
                            address = tbFrom.Text,
                            addressFormated = "",
                            status = 0,
                            time = user.Time,
                            typeCar = user.TypeCar,
                            lat = 0,
                            lng = 0
                        });
                    webResquest = WebRequest.CreateHttp("http://localhost:56081/api/managerappone/addcall");
                    webResquest.Method = "PUT";
                    webResquest.ContentType = "application/json";
                    var buff = Encoding.UTF8.GetBytes(json);
                    webResquest.ContentLength = buff.Length;
                    webResquest.GetRequestStream().Write(buff, 0, buff.Length);
                    try
                    {
                        webResponse = webResquest.GetResponse() as HttpWebResponse;
                        MessageBox.Show("Đã thêm cuộc gọi");
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
            tabControl.SelectedTab = tabHistory;

        }

        private void BtLook_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabDriver;
            double lat = 0;
            double lng = 0;
            drivers = new List<Driver>();
            if (tbFrom.Text.Length < 1)
                return;

            HttpWebRequest webRequest = WebRequest.CreateHttp("http://localhost:56081/api/managerappone/getinformationaddress/" + tbFrom.Text);
            webRequest.Method = "GET";
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
                    string buffReader = jsonStream.ReadToEnd();
                    buffReader = buffReader.Trim('\"');
                    string[] latlng = buffReader.Split(',');
                    lat = double.Parse(latlng[0]);
                    lng = double.Parse(latlng[1]);
                }
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
            //find driver
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
            new
            {
                lat = lat,
                lng = lng,
                typeCar = 0,
                radius = 60000
            });
            webRequest = WebRequest.CreateHttp("http://localhost:56081/api/managerappone/finddriver");
            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            webRequest.ContentLength = buffer.Length;
            webRequest.GetRequestStream().Write(buffer, 0, buffer.Length);
            webResponse = null;
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
                    var t = 0;
                    string buffReader = jsonStream.ReadToEnd();
                    drivers = JsonConvert.DeserializeObject<List<Driver>>(buffReader);
                    DriverBoxs = new DriverBox[drivers.Count];
                    for (int ii = 0; ii < DriverBoxs.Length; ii++)
                    {
                        DriverBoxs[ii] = new DriverBox();
                        tabDriver.Controls.Add(DriverBoxs[ii].Box);
                        DriverBoxs[ii].Box.Height = 115;
                        DriverBoxs[ii].Box.Width = tabDriver.Width;
                        DriverBoxs[ii].Box.Text = "Driver " + ii.ToString();
                        DriverBoxs[ii].Box.Top = t;
                        t += 120;

                        DriverBoxs[ii].Box.Controls.Add(DriverBoxs[ii].Name);
                        DriverBoxs[ii].Name.Width = DriverBoxs[ii].Box.Width;
                        DriverBoxs[ii].Name.Text = "Name: " + drivers[ii].Name;
                        DriverBoxs[ii].Name.Top = 15;

                        DriverBoxs[ii].Box.Controls.Add(DriverBoxs[ii].Lat);
                        DriverBoxs[ii].Lat.Width = DriverBoxs[ii].Box.Width;
                        DriverBoxs[ii].Lat.Text = "Lat: " + drivers[ii].Lat;
                        DriverBoxs[ii].Lat.Top = 40;

                        DriverBoxs[ii].Box.Controls.Add(DriverBoxs[ii].Lng);
                        DriverBoxs[ii].Lng.Width = DriverBoxs[ii].Box.Width;
                        DriverBoxs[ii].Lng.Text = "Lng: " + drivers[ii].Lng;
                        DriverBoxs[ii].Lng.Top = 65;

                        DriverBoxs[ii].Box.Controls.Add(DriverBoxs[ii].Button);
                        DriverBoxs[ii].Button.Width = DriverBoxs[ii].Box.Width;
                        DriverBoxs[ii].Button.Text = "Book this car";
                        DriverBoxs[ii].Button.Left = (DriverBoxs[ii].Box.Width - DriverBoxs[ii].Button.Width) / 2 - 1;
                        DriverBoxs[ii].Button.Top = 90;
                        DriverBoxs[ii].Button.Name = ii.ToString();
                        DriverBoxs[ii].Button.Click += new System.EventHandler(BtBookCar_Click);
                    }
                }
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

        private void BtBookCar_Click(object sender, EventArgs e)
        {
            Button btnBookCar = (Button)sender;
            int index = int.Parse(btnBookCar.Name);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
            new
            {
                id = drivers[index].Id,
                lat = drivers[index].Lat,
                lng = drivers[index].Lng,
                name = drivers[index].Name,
                status = 1,
                typeCar = drivers[index].TypeCard
            });
            string url = "http://localhost:56081/api/managerappone/book/" + drivers[index].Id.ToString();
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            webRequest.ContentLength = buffer.Length;
            webRequest.GetRequestStream().Write(buffer, 0, buffer.Length);
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
                else {
                    tbDriverID.Text = drivers[index].Id.ToString();
                    tbDriveName.Text = drivers[index].Name;
                    for (int i = 1; i < drivers.Count; i++)
                    { 
                        if (i == index)
                            continue;
                        DriverBoxs[i].Box.Hide();
                    }
                }
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
    }
}
