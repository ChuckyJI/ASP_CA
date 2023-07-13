using CAProj.Models;
using MySql.Data.MySqlClient;
namespace CAProj.Data;

public class OrderData
{
    public static List<Orders> GetUsersOrder(string uesrname)
    {
        List<Orders> ordersList = new List<Orders>();
        
        string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string mysql = @"select orderQty,orderPrice,orderTime,orderName,orderReview,itemID,userName from `order` , products where `order`.orderName = products.itemName and userName=@userName order by orderTime desc ";
            MySqlCommand cmd = new MySqlCommand(mysql,conn);
            cmd.Parameters.AddWithValue("@userName", uesrname);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Orders orders = new Orders()
                {
                    orderQty = (int)reader["orderQty"],
                    orderPrice = (float)reader["orderPrice"],
                    orderTime = (DateTime)reader["orderTime"],
                    orderName = (string)reader["orderName"],
                    orderReview = (float)reader["orderReview"],
                    itemID = (string)reader["itemID"],
                    userName = (string)reader["userName"]
                };
                ordersList.Add(orders);
            }
        }
        return ordersList;
    }
    
    public static List<Orders> GetAllOrder()
    {
        List<Orders> ordersList = new List<Orders>();
        
        string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string mysql = @"select orderQty,orderPrice,orderTime,orderName,orderReview,itemID,userName from `order` , products where `order`.orderName = products.itemName order by orderTime desc ";
            MySqlCommand cmd = new MySqlCommand(mysql,conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Orders orders = new Orders()
                {
                    orderQty = (int)reader["orderQty"],
                    orderPrice = (float)reader["orderPrice"],
                    orderTime = (DateTime)reader["orderTime"],
                    orderName = (string)reader["orderName"],
                    orderReview = (float)reader["orderReview"],
                    itemID = (string)reader["itemID"],
                    userName = (string)reader["userName"]
                };
                ordersList.Add(orders);
            }
        }
        return ordersList;
    }
}