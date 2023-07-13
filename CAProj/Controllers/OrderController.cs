using System.Configuration;
using System.Globalization;
using CAProj.Data;
using CAProj.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CAProj.Controllers;

public class OrderController:Controller
{
    [Route("Cart")]
    public IActionResult Cart(string itemnamedisplay)
    {
        AddToCart(itemnamedisplay);
        
        List<Cart> carts = CartData.GetAllCart();
        ViewBag.cart = carts;
        return View();
    }

    public void AddToCart(string itemnamedisplay)
    {
        string username;
        string? sessionId = Request.Cookies["SessionId"];
        if (sessionId == null)
        {
            username = "tourist";
        }
        else
        {
            username = LoginController.TestLogin(sessionId);
        }
        

        string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string mysql = @"INSERT INTO cart (cartName, cartQty, userName) VALUES (@cartName,@cartQty, @userName)";

            try 
            {
                MySqlParameter param1 = new MySqlParameter
                {
                    ParameterName = "@cartName",
                    Value = itemnamedisplay
                };
        
                MySqlParameter param2 = new MySqlParameter
                {
                    ParameterName = "@cartQty",
                    Value = 1
                };
                
                MySqlCommand cmd = new MySqlCommand(mysql, connection);
                cmd.Parameters.AddWithValue("@username", username);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                string mysqlupdate = @"update cart set cartQty = cartQty+1 where cartName=@cartName";
                
                MySqlCommand cmd = new MySqlCommand(mysqlupdate, connection);
                cmd.Parameters.AddWithValue("@cartName", itemnamedisplay);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

    public void EmptyCart()
    {
        string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        using (MySqlConnection emptyconn = new MySqlConnection(connectionString))
        {
            emptyconn.Open();
            string emptySql = @"delete from cart";
            MySqlCommand emptycmd = new MySqlCommand(emptySql, emptyconn);
            emptycmd.ExecuteNonQuery();
            emptyconn.Close();
        }
    }

    public void BackToStore(List<string> upadtedata)
    {
        List<string> cartItemName = new List<string>();
        for (int i = 0; i < upadtedata.Count-1; i=i+2)
        {
            cartItemName.Add(upadtedata[i]);
        }
        List<string> cartItemQty = new List<string>();
        for (int i = 0; i < upadtedata.Count-1; i=i+2)
        {
            cartItemQty.Add(upadtedata[i+1]);
        }
        
        string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";
        
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            for (int i = 0; i < cartItemName.Count; i++)
            {
                string emptySql = @"update cart set cartQty = @cartQty where cartName=@cartName";
                MySqlCommand cmd = new MySqlCommand(emptySql, connection);
                cmd.Parameters.AddWithValue("@cartName", cartItemName[i]);
                cmd.Parameters.AddWithValue("@cartQty", cartItemQty[i]);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    [Route("MyPurchase")]
    public IActionResult MyPurchase(List<string> carttoorder ,List<string> details,List<string> carttoorder2)
    {
        string sessionId = Request.Cookies["SessionId"];
        if (sessionId == null)
        {
            return RedirectToAction("login", "Login");
        }

        Session session = SessionData.GetSessionData(sessionId);
        if (session == null)
        {
            return RedirectToAction("login", "Login");
        }
        
        string name = LoginController.TestLogin(sessionId);

        CartToOrder(carttoorder);
        UpdateReview(details);

        if (name == "admin")
        {
            List<Orders> ordersList = OrderData.GetAllOrder();
            ViewBag.orderListPassValue = ordersList;
            return View();
        }
        else
        {
            List<Orders> ordersList = OrderData.GetUsersOrder(name);

            // List<Orders> ordersList2 = new List<Orders>();
            // for (int i = 0; i < PickuptheSum(carttoorder2); i++)
            // {
            //     ordersList2.Add(ordersList[i]);
            // }
            ViewBag.orderListPassOriginalValue = ordersList;
            return View();
        }
    }

    public IActionResult CartToOrder(List<string> carttoorder)
    {
        string sesionId = Request.Cookies["SessionId"];
        string name = LoginController.TestLogin(sesionId);
        if (name == "")
        {
            return Json(new { success = false});
        }
        else
        {
            
            List<string> orderNameList = new List<string>();
            for (int i = 0; i < carttoorder.Count-1; i=i+4)
            {
                orderNameList.Add(carttoorder[i]);
            }
            
            List<float> orderPriceList = new List<float>();
            for (int i = 0; i < carttoorder.Count-1; i=i+4)
            {
                orderPriceList.Add(Convert.ToSingle(carttoorder[i+2]));
            }

            List<DateTime> orderDayList = new List<DateTime>();
            for (int i = 0; i < carttoorder.Count-1; i=i+4)
            {
                orderDayList.Add(Convert.ToDateTime(carttoorder[i+3]));
            }
            
            List<int> orderQtyList = new List<int>();
            for (int i = 0; i < carttoorder.Count-1; i=i+4)
            {
                int isZero = Convert.ToInt32(carttoorder[i + 1]);
                orderQtyList.Add(isZero);
            }

            for (int i = 0; i < orderQtyList.Count; i++)
            {
                if (orderQtyList[i] == 0)
                {
                    orderPriceList.RemoveAt(i);
                    orderDayList.RemoveAt(i);
                    orderQtyList.RemoveAt(i);
                    orderNameList.RemoveAt(i);
                }
            }
            
            string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                for (int i = 0; i < orderNameList.Count; i++)
                {
                    string mysql =
                    @"INSERT INTO `order`(orderQty,orderPrice,orderReview,orderTime,orderName,userName) VALUES (@orderQty,@orderPrice,@orderReview,@orderTime,@orderName,@userName)";
                    MySqlCommand cmd = new MySqlCommand(mysql, connection);
                
                    cmd.Parameters.AddWithValue("@orderQty",orderQtyList[i]);
                    cmd.Parameters.AddWithValue("@orderPrice",orderPriceList[i]);
                    cmd.Parameters.AddWithValue("@orderReview", 0);
                    cmd.Parameters.AddWithValue("@orderTime",orderDayList[i]);
                    cmd.Parameters.AddWithValue("@orderName", orderNameList[i]);
                    cmd.Parameters.AddWithValue("@userName", name);
                    cmd.ExecuteNonQuery();
                }
                
                //delete the cart
                string deletedqlfromcart = @"delete from cart";
                MySqlCommand cmdcart = new MySqlCommand(deletedqlfromcart,connection);
                cmdcart.ExecuteNonQuery();
                connection.Close();
            }
            return Json(new { success = true });
        }
    }
    public void UpdateReview(List<string> details)
    {
        int isEmptyList = 0;
        if (details.Count == 0)
        { isEmptyList = 0; }
        else
        { isEmptyList = details.Count; }

        List<string> detailsName = new List<string>();
        for (int i = 0;i < isEmptyList-1; i = i+3)
        {
            detailsName.Add(details[i+1]);
        }
        List<string> detailsTime = new List<string>();
        for (int i = 0; i < isEmptyList-1; i = i+3)
        {
            detailsTime.Add(details[i+2]);
        }

        List<string> detailsReview = new List<string>();
        for (int i = 0; i < isEmptyList-1; i = i+3)
        {
            detailsReview.Add(details[i]);
        }

        string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";

        using (var connectionupdate = new MySqlConnection(connectionString))
        {
            connectionupdate.Open();
            for (int i = 0; i < detailsReview.Count; i++)
            {
                string updatesql =
                    @"update `order` set orderReview=@orderReview where orderName=@orderName and orderTime=@orderTime";
                MySqlCommand updatecmd = new MySqlCommand(updatesql, connectionupdate);
                updatecmd.Parameters.AddWithValue("@orderName", Convert.ToString(detailsName[i]));
                updatecmd.Parameters.AddWithValue("@orderTime", Convert.ToDateTime(detailsTime[i]));
                updatecmd.Parameters.AddWithValue("@orderReview", Convert.ToSingle(detailsReview[i]));
                updatecmd.ExecuteNonQuery();
            }
            connectionupdate.Close();
        }
    }

    public IActionResult showcurrent(string number)
    {
        int numberInt = Convert.ToInt32(number);
        List<Orders> ordersList = new List<Orders>();
        string sessionid = Request.Cookies["SessionId"];
        string username = LoginController.TestLogin(sessionid);

        if (username != "admin")
        {
            string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string mysql =
                    @"select orderQty,orderPrice,orderTime,orderName,orderReview,itemID,userName from `order` , products where `order`.orderName = products.itemName and userName=@userName order by orderTime desc limit @number";
                MySqlCommand cmd = new MySqlCommand(mysql, connection);
                cmd.Parameters.AddWithValue("@number", numberInt);
                cmd.Parameters.AddWithValue("@userName", username);
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
        }
        else
        {
            List<Orders> ordersList0 = new List<Orders>();
            ordersList0 = OrderData.GetAllOrder();
            if(Convert.ToInt32(number) == 1 || Convert.ToInt32(number) == 5)
            for (int i = 0; i < Convert.ToInt32(number); i++)
            {
                ordersList.Add(ordersList0[i]);
            }
            else
            {
                ordersList = ordersList0;
            }
        }
        ViewBag.orderListPassOriginalValue = ordersList;
        return PartialView("MypurchaseView");
    }

    public int PickuptheSum(List<string> carttoorder1)
    {
        int sumCartItem = carttoorder1.Count / 4;
        return sumCartItem;
    }
}