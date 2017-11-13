using Newtonsoft.Json;
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
        [Route("api/managerapp1/putcall")]
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
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/" + call.Phone + "/.json");
            request.Method = "PUT";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return Request.CreateResponse(response);
        }

        [HttpGet]
        [Route("api/managerapp1/getcall/{phone}")]
        public HttpResponseMessage GetCall(string phone)
        {
            string res;
            HttpWebRequest request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/" + phone + "/.json");
            request.Method = "Get";
            request.ContentType = "application/json : ";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response.GetResponseStream())
            {
                StreamReader Read = new StreamReader(responsestream, Encoding.UTF8);
                res = Read.ReadToEnd();
                Console.WriteLine(Read.ReadToEnd());
            }
                return Request.CreateResponse(res);
        }
    }
}
