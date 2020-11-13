using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArgusDiner
{

    public class OrderController : ApiController
    {
        public readonly Service _service;

        public OrderController(Service service)
        {
            _service = service;
        }


        [Route("placeorder")]
        [HttpPost]
        public HttpResponseMessage PlaceOrder([FromBody]OrderModel order)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _service.Add(order));
        }
        

    }

}
