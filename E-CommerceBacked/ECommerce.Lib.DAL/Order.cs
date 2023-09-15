using Microsoft.Data.SqlClient;
using System.Data;

namespace ECommerce.Lib.DAL
{
    public class Order : IBaseDAL<Lib.BE.Order>

    {
        public BE.Order create(BE.Order entity)
        {
            throw new NotImplementedException();
        }

        public BE.Order delete(BE.Order entity)
        {
            throw new NotImplementedException();
        }

        public List<BE.Order> readAll()
        {
            List<ECommerce.Lib.BE.Product> productList = new();
            try
            {
                string connectionString = "";
                string sql = "GetData";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command  = new SqlCommand();
                command.Connection  = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;


                connection.Open();

                SqlDataReader dr = command.ExecuteReader();


                if (dr.HasRows )
                {

                    while (dr.Read())
                    {
                        ECommerce.Lib.BE.Product product = new BE.Product();
                        MakeBEFromDr(dr,product);
                        productList.Add(product);

                    }
                    
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new List<BE.Order>();
        }


        public BE.Order update(BE.Order entity)
        {
            throw new NotImplementedException();
        }


        private void MakeBEFromDr(SqlDataReader dr, BE.Product prod)
        {
            prod.productName = Convert.ToString(dr["ProductName"]);
            prod.productCode = Convert.ToString(dr["ProductCode"]);
            prod.productDescription = Convert.ToString(dr["ProductDescription"]);
            prod.productCategory = Convert.ToString(dr["ProductCategory"]);
            prod.productListingDate = Convert.ToString(dr["ProductListingDate"]);
            prod.productCount = Convert.ToString(dr["ProductCount"]);
            prod.imagePath = Convert.ToString(dr["ImagePath"]);

        }
    }
}