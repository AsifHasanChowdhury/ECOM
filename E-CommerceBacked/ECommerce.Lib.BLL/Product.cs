namespace ECommerce.Lib.BLL
{
    public class Product
    {
        private readonly Lib.DAL.IBaseDAL<Lib.BE.Product> product;
        public Product(DAL.Product product)
        {
            this.product = product;
            
        }
        
        public List<Lib.BE.Product> getAllData(string ConnectionString)
        {
            return product.readAll();
        }

       
    }
}