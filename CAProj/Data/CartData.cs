using CAProj.Models;
using MySql.Data.MySqlClient;

namespace CAProj.Data;

public class CartData
{
    public static List<Cart> GetAllCart()
    {
        List<Cart> cartList = new List<Cart>();

        string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string mysql =
                @"select cartName,cartQty,itemPrice,itemID from cart , products where cart.cartName = products.itemName";
            MySqlCommand cmd = new MySqlCommand(mysql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cart cart = new Cart()
                {
                    cartName = (string)reader["cartName"],
                    cartQty = (int)reader["cartQty"],
                    itemPrice = (float)reader["itemPrice"],
                    itemID = (string)reader["itemID"]
                };
                cartList.Add(cart);
            }
        }
        return cartList;
    }
}