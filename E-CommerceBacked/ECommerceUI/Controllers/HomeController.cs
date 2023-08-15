using ECommerceUI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ECommerceUI.Controllers
{
    //[Authorize(Roles = "AsifHasan")]

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

        [HttpGet]
        public IActionResult login()
        {
            return View(new ECommerce.Lib.BE.login());
        }

        [HttpPost]
        public IActionResult login(ECommerce.Lib.BE.login login)
        {
            //return View();

            if (login.email == null || login.password == null)
            {
                return View(new ECommerce.Lib.BE.login());
            }

           
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.email),
                new Claim("FullName", login.password),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(5000000),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };



            HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);


            return RedirectToAction("Index", "Main");

        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login", "Home");

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