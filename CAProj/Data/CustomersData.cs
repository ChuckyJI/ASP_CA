using CAProj.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;

namespace CAProj.Data;

public class CustomersData
{
    public static Customers GetCustomersData(string username)
    {
        Customers customers = new Customers();
        
        string conn = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        using (MySqlConnection connnection = new MySqlConnection(conn))
        {
            connnection.Open();
            string mysql = @"select userId,userName,userPwd from Customers where userName=@userName";
            MySqlCommand cmd = new MySqlCommand(mysql, connnection);
            cmd.Parameters.AddWithValue("@userName", username);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customers.customerId = (int)reader["userId"];
                customers.customerName = (string)reader["userName"];
                customers.customerPwd = (string)reader["userPwd"];
            }
        }
        return customers;
    }

    public static string SessionToCustomer(string sessonId)
    {
        Customers customers = new Customers();

        string conn = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";

        using (MySqlConnection connnection = new MySqlConnection(conn))
        {
            connnection.Open();
            string mysql = @"select C.userName from Customers C, userSession S where C.userId = S.userSid and S.userSessionId = @userSesionId ";
            MySqlCommand cmd = new MySqlCommand(mysql, connnection);
            cmd.Parameters.AddWithValue("@userSesionId", sessonId);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customers.customerName = (string)reader["userName"];
            }
        }

        return customers.customerName;
    }
}