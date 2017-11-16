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
                    typeCar = call.TypeCar
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

        [HttpGet]
        [Route("api/managerappone/getinformationaddress/{address}")]
        public HttpResponseMessage GetDriver(string address)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/driver.json");
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

    }
}
