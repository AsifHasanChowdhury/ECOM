namespace ECommerce.Lib.BE
{
    public class CustomerDetails : BaseBE
    {
        public CustomerDetails() { }


        public string customerName { get; set; }
        public string customerContact { get; set; }
        public string customerEmail { get; set; }
        public string customerAddress{ get; set; }
        public string customerCity { get; set; }
        public string customerOrderCount { get; set; }



    }
}