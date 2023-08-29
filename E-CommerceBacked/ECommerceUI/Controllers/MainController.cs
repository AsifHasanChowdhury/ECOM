using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using ECommerce.Lib.BE.Util;
using Microsoft.Extensions.Options;

namespace ECommerceUI.Controllers
{
    [Authorize(Roles="Admin")]
    public class MainController : Controller
    {
        private readonly List<ECommerce.Lib.BE.Product> productList;
        public MainController(IOptions<List<ECommerce.Lib.BE.Product>> prdocutsList)
        {
            this.productList = prdocutsList.Value;

        }


        [ExceptionHelper]
        //[EnableCors("AllowsAll")]
        public IActionResult Index()
        {
            ECommerce.Lib.BE.Product product = new();
            product.productName = "Iphone";
            product.productCategory = "Technology";
            product.productCount = "two";
            product.productDescription = "This is very good";
            product.imagePath = "Hello";


            ECommerce.Lib.BE.Product product2 = new();
            product2.productName = "SAMSUNG";
            product2.productCategory = "Technology";
            product2.productCount = "5";
            product2.productDescription = "This is very good";
            product2.imagePath = "Android";

            List<ECommerce.Lib.BE.Product> prodList = new();
            Console.WriteLine(User.Identities.Where(p => p.Name == "Admin"));

            prodList.Add(product);
            prodList.Add(product2);
            productList.Add(product2);

            return View(productList);
        }
    }
}
