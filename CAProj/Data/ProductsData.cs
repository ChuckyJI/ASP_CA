using MySql.Data.MySqlClient;
using CAProj.Models;

namespace CAProj.Data;

public class ProductsData
{
    public static List<Products> GetAllProduct()
    {
        List<Products> productsList = new List<Products>();
        
        string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string mysql = @"select itemName,itemPrice,itemDescription,itemID,ss.avg as itemReview from products , (select `order`.orderName,round(avg(`order`.orderReview),2) as avg from `order` group by `order`.ordername) ss where products.itemName=ss.orderName";
            MySqlCommand cmd = new MySqlCommand(mysql,conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products products = new Products()
                {
                    itemName = (string)reader["itemName"],
                    itemPrice = (float)reader["itemPrice"],
                    itemDescription = (string)reader["itemDescription"],
                    itemReview = (double)reader["itemReview"],
                    itemID = (string)reader["itemID"]
                };
                productsList.Add(products);
            }
        }
        return productsList;
    }
}