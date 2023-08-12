using ECommerceUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ECommerceUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [Route("getAllProduct")]
        public async Task<IActionResult> getAllProduct()
        {
            string securityToken = "1234";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Products/getAllProduct", securityToken);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return Ok(responseBody);
            }
            else
            {
                // Handle error scenarios
                return StatusCode((int)response.StatusCode, "API call failed");
            }
            return Ok(400);
        }

        [HttpPost]
        [Route("getAllProductbyAdmin")]
        public async Task<IActionResult> getAllProductbyAdmin()
        {
            return Ok(200);

        }

        [HttpPost]
        [Route("getProductbyID")]
        public async Task<string> getProductbyID()
        {
            return "This is juicy";
        }

        [HttpPost]
        [Route("updateBatchProductDetails")]

        public async Task<IActionResult> updateBatchProductDetails()
        {
            return Ok(200);

        }


        [HttpPost]
        [Route("updateBatchProductDetailsbyOid")]

        public async Task<IActionResult> updateBatchProductDetailsbyOid()
        {
            return Ok(200);

        }


        [HttpPost]
        [Route("FilterProduct")]
        public async Task<IActionResult> FilterProduct()
        {
            return Ok(200);

        }


        [HttpPost]
        [Route("updateProductOrder")]
        public async Task<IActionResult> updateProductOrder()
        {
            return Ok(200);

        }


        [HttpPost]
        [ProducesResponseType(200)]
        [Route("getTextbyOid")]
        public async Task<IActionResult> getTextbyOid()
        {
            return Ok(200);
        }

        [HttpPost]
        [Route("getProductOrderList")]
        public async Task<IActionResult> getProductOrderList()
        {
            return null;

        }


        [HttpPost]
        [Route("getProductOrderdDetailsbyOid")]
        public async Task<IActionResult> getProductOrderdDetailsbyOid()
        {
            return null;

        }

        [HttpPost]
        [Route("getProductDeliverableLocationList")]
        public async Task<IActionResult> getProductDeliverableLocationList()
        {
            return null;

        }


        [HttpPost]
        [Route("orderProduct")]
        public async Task<IActionResult> OrderProduct()
        {
            return null;

        }
        [HttpPost]
        [Route("trackMyOrder")]
        public async Task<IActionResult> trackMyOrder()
        {
            return null;

        }

        [HttpPost]
        [Route("signUp")]
        public async Task<IActionResult> signUp()
        {
            return null;

        }


        [HttpPost]
        [Route("userLogin")]
        public async Task<IActionResult> userLogin()
        {
            return null;

        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}