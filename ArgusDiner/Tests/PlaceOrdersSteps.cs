using System;
using System.Net.Http;
using System.Net.Http.Headers;
using FluentAssertions;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace ArgusDiner.Tests
{
    [Binding]
    public class PlaceOrdersSteps
    {
        private HttpResponseMessage _httpResponseMessage;
        private readonly HttpClient _client;

        private string url = "http://argusdiner.com/test/placeorder";
        private OrderModel _order;

            [Given(@"a new order")]
        public void GivenANewOrder()
        {
            _order = new OrderModel();
        }
        
        [When(@"an order of (.*) starters")]
        public void WhenAnOrderOfStarters(int starters)
        {
            _order.NoOfStarters = starters;
        }
        
        [When(@"an order of (.*) mains")]
        public void WhenAnOrderOfMains(int mains)
        {
            _order.NoOfMains = mains;
        }

        [When(@"an order of (.*) drinks")]
        public void WhenAnOrderOfDrinks(int drinks)
        {
            _order.NoOfDrinks = drinks;
        }


        [When(@"the order is placed")]
        public void WhenTheOrderIsPlaced()
        {
            _httpResponseMessage = _client.PostAsync(url, ToHttpContent(_order)).Result;
        }

        [Then(@"the total bill is (.*) gbp")]
        public void ThenTheTotalBillIsGbp(string amount)
        {
            var requestResult = _httpResponseMessage.Content.ReadAsStringAsync().Result;
            string message = JsonConvert.DeserializeObject<dynamic>(requestResult).message;

            message.Should().Contain(amount);
        }

        private static HttpContent ToHttpContent(OrderModel model)
        {
            var b = JsonConvert.SerializeObject(model);
            var content = new StringContent(b);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }


    }
}
