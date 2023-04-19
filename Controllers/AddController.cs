using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class AddController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AddController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Book book, IFormFile image)
        {
            if(image!=null && image.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var folderPath = "/Images/"+fileName;
                var filePath = Path.Combine("wwwroot/Images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create,FileAccess.Write))
                {
                    image.CopyTo(stream);
                }
                book.CoverImage = folderPath;
            }
            if(book == null) return NotFound();
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Edit(int ? id)
        {
            if(id == null || id <= 0)
            {
                return NotFound();
            }
            var book = _db.Books.Find(id);
            if(book == null)return NotFound();

            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var folderPath = "/Images/" + fileName;
                var filePath = Path.Combine("wwwroot/Images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    image.CopyTo(stream);
                }
                book.CoverImage = folderPath;
            }

            if (book==null)return NotFound();
            _db.Books.Update(book);
            _db.SaveChanges();

            return RedirectToAction("Index","Home");
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var book = _db.Books.Find(id);
            if (book == null) return NotFound();
           ViewBag.Book = book;
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var book = _db.Books.Find(id);
            if (book == null) return NotFound();

            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Book book)
        {
           /* var imagePath=book.CoverImage;*/
            _db.Books.Remove(book);
            _db.SaveChanges();
           /* if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }*/
            return RedirectToAction("Index", "Home");
        }
    }
}
