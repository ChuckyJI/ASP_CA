using MySql.Data.MySqlClient;
using CAProj.Models;

namespace CAProj.Data;

public class SessionData
{
    public static Session GetSessionData(string sessionId)
    {
        Session session = new Session();
        
        string conn = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        using (MySqlConnection connnection = new MySqlConnection(conn))
        {
            connnection.Open();
            string mysql = @"select userSessionId, userSid from userSession where userSessionId=@userSessionId";
            MySqlCommand cmd = new MySqlCommand(mysql, connnection);
            cmd.Parameters.AddWithValue("@userSessionId", sessionId);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                session.SessionId = (string)reader["userSessionId"];
                session.customerId = (int)reader["userSid"];
            }
        }
        return session;
    }

    public static int CreateSession(Session session)
    {
        string conn = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        using (MySqlConnection connnection = new MySqlConnection(conn))
        {
            connnection.Open();
            string mysql = @"insert into userSession (userSessionId,userSid) values (@userSessionId, @userSid)";
            MySqlCommand cmd = new MySqlCommand(mysql, connnection);
            cmd.Parameters.AddWithValue("@userSessionId", session.SessionId);
            cmd.Parameters.AddWithValue("@userSid", session.customerId);
            return cmd.ExecuteNonQuery();
        }
    }
    
    public static int DeleteSession(string SessionId)
    {
        string conn = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        using (MySqlConnection connnection = new MySqlConnection(conn))
        {
            connnection.Open();
            string mysql = @"delete from userSession where userSessionId = @userSessionId";
            MySqlCommand cmd = new MySqlCommand(mysql, connnection);
            cmd.Parameters.AddWithValue("@userSessionId", SessionId);
            return cmd.ExecuteNonQuery();
        }
    }
}