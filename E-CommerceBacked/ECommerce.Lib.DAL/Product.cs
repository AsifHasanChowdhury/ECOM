using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

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
        public List<BE.Product>  readAll()
        {
            List<ECommerce.Lib.BE.Product> productList = new();
            try
            {
                string connectionString = "";

                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();
                string loadInforamtion = "SELECT * FROM product";
                SqlCommand comm = new SqlCommand(loadInforamtion, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ECommerce.Lib.BE.Product product = new BE.Product();
                        Convert.ToString(dt.Rows[i]["ProductName"]);
                        Convert.ToString(dt.Rows[i]["ProductCode"]);
                        Convert.ToString(dt.Rows[i]["ProductDescription"]);
                        Convert.ToString(dt.Rows[i]["ProductCategory"]);
                        Convert.ToString(dt.Rows[i]["ProductListingDate"]);
                        Convert.ToString(dt.Rows[i]["ProductCount"]);
                        Convert.ToString(dt.Rows[i]["ImagePath"]);


                    }


                }
           

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new List<BE.Product>();
        }


        private static void MakeBEFromDR()
        {

        }
       
    }
}