using System.Runtime.InteropServices.ComTypes;
using ECommerce.Lib.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace E_CommerceBacked.Controllers
{

    [ApiController]
    
    [Route("Products")]
    public class ECommerceEndPoints : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ECommerce.Lib.BLL.Product _product;
        public ECommerceEndPoints(IConfiguration configuration,
            ECommerce.Lib.BLL.Product product)
        {
            _configuration = configuration;
            _product= product;
        }

        [MTAThread]
        [HttpPost]
        [ProducesResponseType(200)]
        [Route("getAllProduct")]
        public async Task<List<ECommerce.Lib.BE.Product>> getAllProduct()
        {
            List<ECommerce.Lib.BE.Product> products = new();
            IdentityOptions identityOptions = new();
            IdentityUser identityUser = new();
            
            products =_product.getAllData();
            return products;
        }

        [HttpPost]
        [Authorize(Policy = "IsAdminClaimAccess")]
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



    }
}
