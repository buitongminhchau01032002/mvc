using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PhotoStore.Data;
using PhotoStore.Models;
using System.Security.Cryptography;
using System.Text;

namespace PhotoStore.Controllers {
    public class UserController : Controller {
        private readonly ApplicationDbContext _db;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public UserController( ApplicationDbContext db, IStringLocalizer<SharedResource> sharedLocalizer) {
            _db = db;
            _sharedLocalizer = sharedLocalizer;
        }
        public ActionResult GetSelf(int id) {
            string? username = HttpContext.Session.GetString("Username");
            string? avatar = HttpContext.Session.GetString("Avatar");
            string? displayName = HttpContext.Session.GetString("DisplayName");
            if (username == null) {
                return RedirectToAction("Index", "Home");
            }
            ViewData["Username"] = username;
            ViewData["Avatar"] = avatar;
            ViewData["DisplayName"] = displayName;
            return View();
        }


        //GET: Register

        public ActionResult Register() {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user) {
            if (!ModelState.IsValid) {
                return View();
            }

            user.Password = GetMD5(user.Password);
            _db.Users.Add(user);
            _db.SaveChanges();
            TempData["success"] = "Register successfully!";
            return Redirect("/");

        }

        public ActionResult Login() {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login loginData) {
            if (!ModelState.IsValid) {
                return View();
            }

            var hashPassword = GetMD5(loginData.Password);
            User user = _db.Users.FirstOrDefault(s => s.Username.Equals(loginData.Username) && s.Password.Equals(hashPassword));
            if (user != null) {
                //add session
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("Username", user.Username.ToString());
                HttpContext.Session.SetString("Avatar", user.Avatar.ToString());
                HttpContext.Session.SetString("DisplayName", user.DisplayName.ToString());

                TempData["success"] = (string)_sharedLocalizer["noti.loginSuccess"];
                return Redirect("/");
            } else {
                TempData["success"] = (string)_sharedLocalizer["noti.loginFail"];
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout() {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
        // Validate unique username
        [AcceptVerbs("Get", "Post")]
        public bool UniqueUsername(string username) {
            var existUsername = _db.Users.FirstOrDefault(s => s.Username == username);
            if (existUsername != null) {
                return false;
            }
            return true;
        }


        //create a string MD5
        public static string GetMD5(string str) {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++) {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
