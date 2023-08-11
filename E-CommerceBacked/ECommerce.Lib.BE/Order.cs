namespace ECommerce.Lib.BE
{
    public class Order : BaseBE
    {
        public Order() { }  

        public string orderName { get; set; }
        public string orderDescription { get; set; }
        public string orderType { get; set; }
        public string orderDate { get; set; }
        public string orderDeadline { get; set;}

     
    }
}