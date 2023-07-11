using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PhotoStore.Data;
using PhotoStore.Models;

namespace PhotoStore.Controllers {
    public class PhotoController : Controller {
        private readonly ApplicationDbContext _db;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public PhotoController(ApplicationDbContext db, IStringLocalizer<SharedResource> sharedLocalizer) {
            _db = db;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index(string q) {

            var photoList = from photo in _db.Photos
                            join user in _db.Users
                            on photo.UserId equals user.Id
                            select new PhotoCard {
                                Id = photo.Id,
                                Title = photo.Title,
                                ImageUrl = photo.ImageUrl,
                                CreatedAt = photo.CreatedAt,
                                UserAvatar = user.Avatar,
                                UserDisplayName = user.DisplayName
                            };
            if (!String.IsNullOrEmpty(q)) {
                photoList = photoList.Where(s => s.Title!.Contains(q));
            }
            return View(photoList);
        }

        // GET
        public IActionResult Create() {
            if (HttpContext.Session.GetString("UserId") == null) {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Photo photo) {
            if (HttpContext.Session.GetString("UserId") == null) {
                return RedirectToAction("Index");
            }
            photo.UserId = Int32.Parse(HttpContext.Session.GetString("UserId"));
            if (!ModelState.IsValid) {
                return View(photo);
            }
            _db.Photos.Add(photo);
            _db.SaveChanges();
            TempData["success"] = (string)_sharedLocalizer["noti.createPhoto"];
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id) {
            if (HttpContext.Session.GetString("UserId") == null) {
                TempData["error"] = (string)_sharedLocalizer["noti.noPermissionEdit"];
                return RedirectToAction("Index");
            }
            int userId = Int32.Parse(HttpContext.Session.GetString("UserId"));
            if (id == null) {
                return NotFound();
            }
            var photo = _db.Photos.Find(id);
            if (photo == null) {
                return NotFound();
            }
            if (photo.UserId != userId) {
                TempData["error"] = (string)_sharedLocalizer["noti.noPermissionEdit"];
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Photo photo) {
            if (HttpContext.Session.GetString("UserId") == null) {
                return RedirectToAction("Index");
            }
            int userId = Int32.Parse(HttpContext.Session.GetString("UserId"));
            if (photo.UserId != userId) {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid) {
                _db.Photos.Update(photo);
                _db.SaveChanges();
                TempData["success"] = (string)_sharedLocalizer["noti.updatePhoto"];
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id) {
            if (HttpContext.Session.GetString("UserId") == null) {
                return RedirectToAction("Index");
            }
            int userId = Int32.Parse(HttpContext.Session.GetString("UserId"));
            var photo = _db.Photos.Find(id);

            if (photo == null) {
                return NotFound();
            }

            if (photo.UserId != userId) {
                return RedirectToAction("Index");
            }

            _db.Photos.Remove(photo);
            _db.SaveChanges();
            TempData["success"] = (string)_sharedLocalizer["noti.deletePhoto"];
            return RedirectToAction("Index");
        }
    }
}
