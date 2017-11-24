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
                JArray listcar = findCar(Read, find);
                if (listcar == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, listcar);
            }
        }

        private JArray findCar(string listcar, FindCar find)
        {
            JArray array = new JArray();
            List<Car> list = JsonConvert.DeserializeObject<List<Car>>(listcar);
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
        [Route("api/managerappone/book")]
        public HttpResponseMessage BookCar([FromBody]Car car)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    id = car.Id,
                    name = car.Name,
                    typeCar = car.TypeCar,
                    status = car.Status,
                    lat = car.Lat,
                    lng = car.Lng
                });
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver/" + car.Id + ".json");
            request.Method = "PUT";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return Request.CreateResponse(response.StatusCode);
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
