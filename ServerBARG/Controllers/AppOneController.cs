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
            request.ContentType = "application/json : ";
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
            //HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/call.json?orderBy=\"status\"&equalTo=0");
            request.Method = "Get";
            request.ContentType = "application/json : ";
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
                if(json[a.Key]["status"].ToString() == "2")
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
        public HttpResponseMessage FindDriver()
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
                var json = JsonConvert.DeserializeObject(Read);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
        }
        #endregion

    }
}
