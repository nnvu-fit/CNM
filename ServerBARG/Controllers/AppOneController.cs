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
        public HttpResponseMessage GetMoney([FromBody]Call call)
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
            var request = WebRequest.CreateHttp("https://barg-9f201.firebaseio.com/" + call.Phone + "/.json");
            request.Method = "PUT";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            return Request.CreateResponse(response);
        }
    }
}
