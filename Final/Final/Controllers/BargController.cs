using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.IO;

namespace Final.Controllers
{
    [Produces("application/json")]
    [Route("api/managerappone")]
    public class BargController : Controller
    {
        #region Them cuoc dat xe
        // PUT: api/managerappone/addcall
        [HttpPut("addcall")]
        public void PutCall([FromBody]Newtonsoft.Json.Linq.JObject call)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
            new
            {
                address = call.SelectToken("address"),
                addressFormated = call.SelectToken("addressFormated"),
                status = call.SelectToken("status"),
                time = call.SelectToken("time"),
                typeCar = call.SelectToken("typeCard"),
                lat = call.SelectToken("lat"),
                lng = call.SelectToken("lng")
            });
            var phone = (string)call.SelectToken("phone");
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/call/" + phone + ".json");
            request.Method = "PUT";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

        }
        #endregion


        #region Get thong tin xe
        // GET: api/managerappone/00000000
        [HttpGet("getinformationcall/{phone}", Name = "GetCall")]
        public Newtonsoft.Json.Linq.JObject GetCall(string phone)
        {
            Newtonsoft.Json.Linq.JObject json;
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/call/" + phone + ".json");
            request.Method = "Get";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "null")
                    return null;
                json = Newtonsoft.Json.Linq.JObject.Parse(Read);
            }
            return json;
        }
        #endregion


        #region Tim dia chi thanh cong <-- Loi
        // GET: api/managerappone/getinformationaddress/{address}
        [HttpGet("getinformationaddress/{address}", Name = "GetDriver")]
        public Newtonsoft.Json.Linq.JObject GetDriver(string address)
        {
            Console.Write(address);
            Newtonsoft.Json.Linq.JObject json;
            string lat = "";
            string lng = "";
            string URL = "https://barg-9f201.firebaseio.com/call.json?orderBy=\"addressFormated\"&equalTo=" + "\"" + address + "\"";
            HttpWebRequest request = WebRequest.CreateHttp(URL);
            request.Method = "Get";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "{}")
                    return null;
                json = Newtonsoft.Json.Linq.JObject.Parse(Read);
            }
            if (lat == "" || lng == "")
            {
                return null;
            }

            return json;
        }

        #endregion


        #region Tim xe trong khu vuc
        // PUT: api/managerappone/finddriver
        [HttpPut("finddriver", Name = "FindDriver")]
        public JArray FindDriver([FromBody] FindCar find)
        {
            string URL = "https://barg-9f201.firebaseio.com/driver.json";
            HttpWebRequest request = WebRequest.CreateHttp(URL);
            request.Method = "Get";
            request.ContentType = "application/json : ";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "null")
                    return null;
                JArray listcar = findCarRadius(Read, find);
                if (listcar == null)
                {
                    return null;
                }
                return listcar;
            }

        }

        private JArray findCarRadius(string listcar, FindCar find)
        {
            JArray array = new JArray();
            List<Car> list = new List<Car>();
            Newtonsoft.Json.Linq.JObject js_listcar = Newtonsoft.Json.Linq.JObject.Parse(listcar);
            foreach (var a in js_listcar)
            {
                Car car = JsonConvert.DeserializeObject<Car>(a.Value.ToString());
                car.Id = a.Key.ToString();
                list.Add(car);
            }
            foreach (Car tem in list)
            {
                var distance = new Coordinates(find.Lat, find.Lng)
                .DistanceTo(
                    new Coordinates(tem.Lat, tem.Lng),
                    UnitOfLength.Kilometers
                );
                if (distance <= (find.Radius) / 1000 && tem.Status == 0)
                {
                    var json = JsonConvert.SerializeObject(tem, Formatting.Indented);
                    Newtonsoft.Json.Linq.JObject jobject = Newtonsoft.Json.Linq.JObject.Parse(json);
                    array.Add(jobject);
                }
            }
            return array;
        }

        #endregion


        #region Dat xe
        [HttpPut("book/{idcar}", Name = "BookCar")]
        public bool BookCar(string idcar)
        {
            Newtonsoft.Json.Linq.JObject js_infodriver;
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + idcar + ".json");
            request.Method = "Get";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "null")
                    return false;
                js_infodriver = Newtonsoft.Json.Linq.JObject.Parse(Read);
            }
            Car infodriver = JsonConvert.DeserializeObject<Car>(js_infodriver.ToString());
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    username = infodriver.Username,
                    id = infodriver.Id,
                    name = infodriver.Name,
                    typeCar = infodriver.TypeCar,
                    status = 1,
                    lat = infodriver.Lat,
                    lng = infodriver.Lng,
                    pass = infodriver.Pass
                });
            request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + idcar + ".json");
            request.Method = "PUT";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            response = request.GetResponse() as HttpWebResponse;
            return true;
        }

        #endregion


        #region Dang ky xe
        [HttpPost("register", Name = "RegisterDriver")]
        public bool RegisterDriver([FromBody] Newtonsoft.Json.Linq.JObject car)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
            new
            {
                username = car.SelectToken("username"),
                name = car.SelectToken("name"),
                typeCar = car.SelectToken("typeCar"),
                status = 0,
                lat = car.SelectToken("lat"),
                lng = car.SelectToken("lng"),
                pass = car.SelectToken("pass")
            });
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver.json");
            request.Method = "POST";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return response.StatusCode == HttpStatusCode.OK ? true : false;
        }

        #endregion


        #region Thay doi thong tin xe
        [HttpPut("updatestatus", Name = "UpdateStatus")]
        public int UpdateStatus([FromBody] Car car)
        {
            Newtonsoft.Json.Linq.JObject js_infodriver;
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + car.Id + ".json");
            request.Method = "Get";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "null")
                    return 404;
                js_infodriver = Newtonsoft.Json.Linq.JObject.Parse(Read);
            }
            Car infodriver = JsonConvert.DeserializeObject<Car>(js_infodriver.ToString());
            if (car.Pass == infodriver.Pass)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    id = car.Id,
                    name = car.Name,
                    typeCar = car.TypeCar,
                    status = car.Status,
                    lat = car.Lat,
                    lng = car.Lng,
                    pass = car.Pass,
                    username = car.Username
                });
                request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + car.Id + ".json");
                request.Method = "PUT";
                request.ContentType = "application/json";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                response = request.GetResponse() as HttpWebResponse;
                return (int)response.StatusCode;
            }
            else
            {
                return 401;
            }

        }

        #endregion


        #region Kiem tra thong tin xe
        [HttpGet("checkinfo/{idcar}", Name = "CheckInfo")]
        public Newtonsoft.Json.Linq.JObject CheckInfo(string idcard)
        {
            Newtonsoft.Json.Linq.JObject js_infodriver;
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + idCar + ".json");
            request.Method = "Get";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "null")
                    return null;
                js_infodriver = Newtonsoft.Json.Linq.JObject.Parse(Read);
            }
            return js_infodriver;
        }

        #endregion    }

        public class Coordinates
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
    public static class CoordinatesDistanceExtensions
    {
        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates)
        {
            return DistanceTo(baseCoordinates, targetCoordinates, UnitOfLength.Kilometers);
        }

        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates, UnitOfLength unitOfLength)
        {
            var baseRad = Math.PI * baseCoordinates.Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            var theta = baseCoordinates.Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return unitOfLength.ConvertFromMiles(dist);
        }
    }
    public class UnitOfLength
    {
        public static UnitOfLength Kilometers = new UnitOfLength(1.609344);
        public static UnitOfLength NauticalMiles = new UnitOfLength(0.8684);
        public static UnitOfLength Miles = new UnitOfLength(1);

        private readonly double _fromMilesFactor;

        private UnitOfLength(double fromMilesFactor)
        {
            _fromMilesFactor = fromMilesFactor;
        }

        public double ConvertFromMiles(double input)
        {
            return input * _fromMilesFactor;
        }
    }

}
