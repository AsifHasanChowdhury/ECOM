namespace ECommerce.Lib.DAL
{
    public class Product : IBaseDAL<Lib.BE.Product>
    {
        

        public BE.Product create(BE.Product entity)
        {
            throw new NotImplementedException();
        }

        public BE.Product delete(BE.Product entity)
        {
            throw new NotImplementedException();
        }


        public BE.Product update(BE.Product entity)
        {
            throw new NotImplementedException();
        }

        List<BE.Product> IBaseDAL<BE.Product> .readAll()
        {
            throw new NotImplementedException();
        }
    }
}