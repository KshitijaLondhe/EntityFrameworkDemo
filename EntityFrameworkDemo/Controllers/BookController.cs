using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Controllers
{
   
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        BookCrud db;

        public BookController(ApplicationDbContext context)
        {
            this.context = context;
            db = new BookCrud(this.context);
        }
        // GET: BookController
        public ActionResult Index()
        {
            var response = db.GetBooks();
            return View(response);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var response = db.GetBookById(id);
            return View(response);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book bk)
        {
            try
            {
                int response = db.AddBook(bk);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }

        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = db.GetBookById(id);
            return View(res);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book bk)
        {
            try
            {
                int response = db.UpdateBook(bk);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = db.GetBookById(id);
            return View(res);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id, Book bk)
        {
            try
            {
                int response = db.DeleteBook(id);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
