namespace ECommerce.Lib.DAL
{
    public class CustomerDetails : IBaseDAL<Lib.BE.CustomerDetails>
    {
        BE.CustomerDetails IBaseDAL<BE.CustomerDetails>.create(BE.CustomerDetails entity)
        {
            throw new NotImplementedException();
        }

        BE.CustomerDetails IBaseDAL<BE.CustomerDetails>.delete(BE.CustomerDetails entity)
        {
            throw new NotImplementedException();
        }

        List<BE.CustomerDetails> IBaseDAL<BE.CustomerDetails>.readAll()
        {
            throw new NotImplementedException();
        }

        BE.CustomerDetails IBaseDAL<BE.CustomerDetails>.update(BE.CustomerDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}