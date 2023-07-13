using System.Diagnostics;
using CAProj.Data;
using Microsoft.AspNetCore.Mvc;
using CAProj.Models;
using Microsoft.VisualBasic.CompilerServices;
using MySql.Data.MySqlClient;

namespace CAProj.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        // string? sessionid = Request.Cookies["Sessionid"];
        // string name = LoginController.TestLogin(sessionid);
        // ViewBag.loginName = name;
        
        List<Products> productsList = ProductsData.GetAllProduct();
        ViewBag.productsListPassValue = productsList;
        
        List<Cart> carts = CartData.GetAllCart();
        ViewBag.cart = carts;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public List<Products> SearchContentData(string text)
    {
        List<Products> searchlist = new List<Products>();
        string contents = Convert.ToString(text);
        string connectionString = @"Server=localhost;Port=3306;Uid=root;Pwd=jcy901110;Database=caproject;";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string mysql =
                @"select itemName,itemPrice,itemDescription,itemID,ss.avg as itemReview from products , (select `order`.orderName,round(avg(`order`.orderReview),2) as avg from `order` group by `order`.ordername) ss where products.itemName=ss.orderName and (itemName like @itemName or itemDescription like @itemDescription)";
            MySqlCommand cmd = new MySqlCommand(mysql, connection);
            cmd.Parameters.AddWithValue("@itemName", "%"+contents+"%");
            cmd.Parameters.AddWithValue("@itemDescription", "%"+contents+"%");
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
                searchlist.Add(products);
            }
        }
        return searchlist;
    }
    
    public IActionResult SearchContent(string content)
    {
        List<Products> searchlist = SearchContentData(content);
        ViewBag.productsListPassValue = searchlist;
        return PartialView("SearchContent");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

