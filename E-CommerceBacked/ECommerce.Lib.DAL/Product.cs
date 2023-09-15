using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

namespace ECommerce.Lib.DAL
{
    public class Product : IBaseDAL<Lib.BE.Product>
    {
        private readonly ECommerce.Lib.BE.Util.DBService _databaseSettings;

        public Product(BE.Util.DBService databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }
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

        public BE.Product getDetailsbyOid(BE.Product entity)
        {

            throw new NotImplementedException();
        }

        public List<BE.Product> readAll()
        {
            List<ECommerce.Lib.BE.Product> productList = new();
            try
            {
                string connectionString = "";
                string sql = "GetAllProduct";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;


                connection.Open();

                SqlDataReader dr = command.ExecuteReader();


                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        ECommerce.Lib.BE.Product product = new BE.Product();
                        MakeBEFromDr(dr, product);
                        productList.Add(product);

                    }

                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return productList;
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



        //public List<BE.Product>  readAll()
        //{
        //    List<ECommerce.Lib.BE.Product> productList = new();
        //    try
        //    {
        //        string connectionString = "";

        //        SqlConnection connection = new SqlConnection(connectionString);

        //        connection.Open();
        //        string loadInforamtion = "SELECT * FROM product";
        //        SqlCommand comm = new SqlCommand(loadInforamtion, connection);
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comm);
        //        DataTable dt = new DataTable();
        //        sqlDataAdapter.Fill(dt);

        //        if (dt.Rows.Count > 0)
        //        {

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                ECommerce.Lib.BE.Product product = new BE.Product();
        //                Convert.ToString(dt.Rows[i]["ProductName"]);
        //                Convert.ToString(dt.Rows[i]["ProductCode"]);
        //                Convert.ToString(dt.Rows[i]["ProductDescription"]);
        //                Convert.ToString(dt.Rows[i]["ProductCategory"]);
        //                Convert.ToString(dt.Rows[i]["ProductListingDate"]);
        //                Convert.ToString(dt.Rows[i]["ProductCount"]);
        //                Convert.ToString(dt.Rows[i]["ImagePath"]);


        //            }


        //        }


        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    return new List<BE.Product>();
        //}


    }
}