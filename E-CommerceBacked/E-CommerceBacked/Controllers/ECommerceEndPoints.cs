using System.Runtime.InteropServices.ComTypes;
using ECommerce.Lib.BE;
using ECommerce.Lib.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace E_CommerceBacked.Controllers
{

    [ApiController]
    
    [Route("Products")]
    public class ECommerceEndPoints : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ECommerce.Lib.BLL.Product _product; 
        private readonly ECommerce.Lib.BE.Util.DBService _databaseSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ECommerceEndPoints(IConfiguration configuration,
            ECommerce.Lib.BLL.Product product, 
            IOptions<ECommerce.Lib.BE.Util.DBService> databaseSettings,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _configuration = configuration;
            _product= product;
            _databaseSettings = databaseSettings.Value;// holds database key
            _webHostEnvironment = webHostEnvironment;
        }

        
        [HttpPost]
        [ProducesResponseType(200)]
        [Route("getAllProduct")]
        public async Task<List<ECommerce.Lib.BE.Product>> getAllProduct()
        {

            List<ECommerce.Lib.BE.Product> products = new();
            IdentityOptions identityOptions = new(); //study this
            IdentityUser identityUser = new(); //study this
            
            products =_product.getAllData();
            return products;
        }


        [HttpPost]
        //[Authorize(Policy = "IsAdminClaimAccess")]
        [Route("getAllProductbyAdmin")]
        public async Task<IActionResult> getAllProductbyAdmin()
        {

            List<ECommerce.Lib.BE.Product> prodList = new();

            prodList = _product.getAllData();

            return Ok(200);

        }

        [HttpPost]
        [ProducesResponseType(200)]
        [Route("getProductbyID")]
        public async Task<ECommerce.Lib.BE.Product> getProductbyID(ECommerce.Lib.BE.login login)
        {

            ECommerce.Lib.BE.Product product = new();
            return product;
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
        public async Task<IActionResult> signup(ECommerce.Lib.BE.login logo)
        {
            ECommerce.Lib.BLL.UserVerification
                .createrPasswordHash(logo.password,out byte [] PasswordHash, out byte[] passwordSalt);

            ECommerce.Lib.BE.RegisterModel  user= new ()
            {
                email = logo.email,
                passwordHash = PasswordHash,
                passwordSalt = passwordSalt,
                verificationToken = ECommerce.Lib.BLL.UserVerification.VerificationToken()
            };

            foreach(byte data in  user.passwordHash)
            {
                Console.Write(data);
            }
            Console.WriteLine();

            foreach (byte data in user.passwordSalt)
            {
                Console.Write(data);
            }
            Console.WriteLine();

            Console.WriteLine(user.verificationToken);

            ECommerce.Lib.BE.DB.JSONDatabase.UserList.Add(user);
            return Ok("You have been Registered");

        }


        [HttpPost]
        [Route("userLogin")]
        public async Task<IActionResult> userLogin(ECommerce.Lib.BE.login login)
        {

            return null;

        }


        /// <summary>
        /// File Upload Lesson
        /// </summary>
        /// <param name="imageFile"></param>
        /// <returns></returns>

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    // Save the 'filePath' in your database or return it to the client.
                    return Ok(new { imagePath = "/images/" + uniqueFileName });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            else
            {
                return BadRequest("No image file was uploaded.");
            }
        }


    }
}
