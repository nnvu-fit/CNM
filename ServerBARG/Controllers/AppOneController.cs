using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerBARG.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ServerBARG.Controllers
{
    public class AppOneController : ApiController
    {

        #region  thêm một cuộc gọi đặt xe
        [HttpPut]
        [Route("api/managerappone/addcall")]
        public HttpResponseMessage PutCall([FromBody]Call call)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    address = call.Address,
                    addressFormated = call.AddressFormated,
                    status = call.Status,
                    time = call.Time,
                    typeCar = call.TypeCar,
                    lat = call.Lat,
                    lng = call.Lng
                });
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/call/" + call.Phone + ".json");
            request.Method = "PUT";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return Request.CreateResponse(response.StatusCode);
        }
        #endregion

        #region get thông tin cuộc gọi để tìm trạng thái trước đó (lịch sử)
        [HttpGet]
        [Route("api/managerappone/getinformationcall/{phone}")]
        public HttpResponseMessage GetCall(string phone)
        {
            JObject json;
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/call/" + phone + ".json");
            request.Method = "Get";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "null")
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                json = JObject.Parse(Read);
            }
            return Request.CreateResponse(HttpStatusCode.OK, json);
        }
        #endregion

        #region tìm địa chỉ đã đặt thành công
        [HttpGet]
        [Route("api/managerappone/getinformationaddress/{address}")]
        public HttpResponseMessage GetDriver(string address)
        {
            JObject json;
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
                    return Request.CreateResponse(HttpStatusCode.NotFound, "chưa xác định tọa độ");
                json = JObject.Parse(Read);
            }
            

            foreach (var a in json)
            {
                if(json[a.Key]["status"].ToString() != "0")
                {
                    lat = json[a.Key]["lat"].ToString();
                    lng = json[a.Key]["lng"].ToString();
                    break;
                }
            }

            //URL = "https://barg-9f201.firebaseio.com/driver.json?orderBy=\"latlng\"&equalTo=\""+ lat +","+ lng +"\"";
            //request = WebRequest.CreateHttp(URL);

            //json[0] 
            if (lat == "" || lng == "")
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "chưa xác định tọa độ");
            }
            return Request.CreateResponse(HttpStatusCode.OK,lat+","+lng);

        }
        #endregion

        #region tìm xe trong khu vực
        [HttpPut]
        [Route("api/managerappone/finddriver")]
        public HttpResponseMessage FindDriver([FromBody]FindCar find)
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
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                JArray listcar = findCarRadius(Read, find);
                if (listcar == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, listcar);
            }
        }

        private JArray findCarRadius(string listcar, FindCar find)
        {
            JArray array = new JArray();
            List<Car> list = new List<Car>();
            JObject js_listcar = JObject.Parse(listcar);
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
                if(distance <= (find.Radius) / 1000 && tem.Status == 0)
                {
                    var json = JsonConvert.SerializeObject(tem, Formatting.Indented);
                    JObject jobject = JObject.Parse(json);
                    array.Add(jobject);
                }
            }
            return array;
        }
        #endregion

        #region  Đặt xe
        [HttpPut]
        [Route("api/managerappone/book/{idcar}")]
        public HttpResponseMessage BookCar(string idcar)
        {
            JObject js_infodriver;
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + idcar+ ".json");
            request.Method = "Get";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "null")
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                js_infodriver = JObject.Parse(Read);
            }
            Car infodriver = JsonConvert.DeserializeObject<Car>(js_infodriver.ToString());
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
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
            return Request.CreateResponse(response.StatusCode);
        }
        #endregion

        #region  Đăng ký xe
        [HttpPost]
        [Route("api/managerappdriver/register")]
        public HttpResponseMessage RegisterDriver ([FromBody]Car car)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    name = car.Name,
                    typeCar = car.TypeCar,
                    status = 0,
                    lat = car.Lat,
                    lng = car.Lng,
                    pass = car.Pass
                });
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver.json");
            request.Method = "POST";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return Request.CreateResponse(response.StatusCode);
        }
        #endregion

        #region  Thay đổi thông tin xe
        [HttpPut]
        [Route("api/managerappone/updatestatus")]
        public HttpResponseMessage UpdateStatus(Car car)
        {
            JObject js_infodriver;
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + car.Id + ".json");
            request.Method = "Get";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "null")
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                js_infodriver = JObject.Parse(Read);
            }
            Car infodriver = JsonConvert.DeserializeObject<Car>(js_infodriver.ToString());
            if(car.Pass == infodriver.Pass)
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
                   pass = car.Pass
               });
                request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + car.Id + ".json");
                request.Method = "PUT";
                request.ContentType = "application/json";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                response = request.GetResponse() as HttpWebResponse;
                return Request.CreateResponse(response.StatusCode);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
           
        }
        #endregion

        #region  Kiểm tra thông tin xe
        [HttpGet]
        [Route("api/managerappdriver/checkinfo/{idcar}")]
        public HttpResponseMessage CheckInfo(string idCar)
        {
            JObject js_infodriver;
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + idCar + ".json");
            request.Method = "Get";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                var Read = new StreamReader(responsestream).ReadToEnd();
                if (Read == "null")
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                js_infodriver = JObject.Parse(Read);
            }
            return Request.CreateResponse(HttpStatusCode.OK, js_infodriver);
        }
        #endregion

    }
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
