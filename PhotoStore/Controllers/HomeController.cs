using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PhotoStore.Data;
using PhotoStore.Models;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace PhotoStore.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IStringLocalizer<SharedResource> sharedLocalizer) {
            _logger = logger;
            _db = db;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl) {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Privacy() {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}