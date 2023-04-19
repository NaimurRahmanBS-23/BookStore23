using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int ? id)
        {
            if(id == null|| id==0)
            {
                return NotFound();
            }
           var name=_db.Books.Find(id).AuthorName;
            var bookList= _db.Books.Where(book => book.AuthorName == name).ToList();
         
            return View(bookList);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var name = _db.Books.Find(id);
            
        
            return View(name);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book,IFormFile image)
        {
            if (book == null)
            {
                return NotFound();
            }

            if (image != null && image.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var folderPath = "/Images/" + fileName;
                var filePath = Path.Combine("wwwroot/Images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    image.CopyTo(stream);
                }
                book.AuthorImage = folderPath;
            }
            var name = _db.Books.Find(book.Id).AuthorName;
            var books=_db.Books.Where(newBook=>newBook.AuthorName == name).ToList();
            foreach (var tempBook in books)
            {
                tempBook.AuthorName=book.AuthorName;
                //_db.Books.Update(book);
                tempBook.AuthorImage=book.AuthorImage;
            }
            _db.Books.UpdateRange(books);
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var name = _db.Books.Find(id);


            return View(name);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Book obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
           // var imagePath = "wwwroot"+obj.AuthorImage;
            var name = _db.Books.Find(obj.Id).AuthorName;
            var books = _db.Books.Where(x => x.AuthorName == name).ToList();
            foreach (var book in books)
            {
                book.AuthorName = obj.AuthorName;
                //_db.Books.Update(book);

            }
            _db.Books.RemoveRange(books);
            _db.SaveChanges();
            /*if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }*/
            return RedirectToAction("Index", "Home");
        }
    }
}
