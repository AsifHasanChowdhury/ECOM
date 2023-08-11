namespace ECommerce.Lib.BE
{
    public class Product : BaseBE
    {
        public Product() { }

        public string productName { get; set; }
        public string productCode { get; set; }
        public string productDescription { get; set; }
        public string productCategory { get; set; }
        public string productListingDate { get; set;}
        public string productCount { get; set; }
        public string imagePath { get; set; }

    }
}