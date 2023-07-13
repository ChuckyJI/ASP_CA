using CAProj.Data;
using CAProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace CAProj.Controllers;


public class LoginController : Controller
{
    [Route("login")]
    public IActionResult Login(string usernamelogin, string inputPassword)
    {
        string? sessionId = Request.Cookies["SessionId"];
        if (sessionId != null)
        {
            Session session = SessionData.GetSessionData(sessionId);
            if (session != null)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        if (string.IsNullOrEmpty(usernamelogin) || string.IsNullOrEmpty(inputPassword))
        {
            string msg = "Please input both your username and password.";
            string noMsg = "1";
            List<string> noticeMeg = new List<string>();
            noticeMeg.Add(msg);
            noticeMeg.Add(noMsg);
            ViewBag.msg = noticeMeg;
            return View();
        }

        Customers customers = CustomersData.GetCustomersData(usernamelogin);
        if (usernamelogin == null)
        {
            string msg = "Your username is wrong.";
            string noMsg = "2";
            List<string> noticeMeg = new List<string>();
            noticeMeg.Add(msg);
            noticeMeg.Add(noMsg);
            ViewBag.msg = noticeMeg;
            return View();
        }

        if (customers.customerPwd != inputPassword)
        {
            string msg = "Your password is wrong.";
            string noMsg = "3";
            List<string> noticeMeg = new List<string>();
            noticeMeg.Add(msg);
            noticeMeg.Add(noMsg);
            ViewBag.msg = noticeMeg;
            return View();
        }

        sessionId = Guid.NewGuid().ToString();
        int res = SessionData.CreateSession(new Session
        {
            SessionId = sessionId,
            customerId = customers.customerId
        });

        if (res != 1)
        {
            return StatusCode(500);
        }

        Response.Cookies.Append("SessionId", sessionId);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        string sessionid = Request.Cookies["SessionId"];
        if (sessionid == null)
        {
            return RedirectToAction("Login", "Login");
        }

        int res = SessionData.DeleteSession(sessionid);
        if (res != 1)
        {
            return StatusCode(500);

        }

        Response.Cookies.Delete("SessionId");
        return RedirectToAction("Login", "Login");
    }

    public static string TestLogin(string sessionId)
    {
        string name = "";
        if (sessionId != null)
        {
            Session session = SessionData.GetSessionData(sessionId);
            if (session != null)
            {
                name = CustomersData.SessionToCustomer(sessionId);
            }
        }
        return name;
    }

    public IActionResult layoutOnLoad()
    {
        string? sessionId = Request.Cookies["SessionId"];
        string name = TestLogin(sessionId);
        ViewBag.passName = name;
        // return View(name);
        return PartialView("LoginContent");
    }
}
    
    