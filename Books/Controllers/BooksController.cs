using Books.Models;
using Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Books.Controllers
{
    public class BooksController : Controller
    {

        private readonly ApplicationDbContext _Context;
       

        public BooksController()
            {
            _Context = new ApplicationDbContext();
            }
        // GET: Books
        public ActionResult Index()
        {
            var books = _Context.books.Include(m=>m.Category).ToList();
            return View(books);
        }
        public ActionResult Details(int?id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 

                    var book = _Context.books.Include(m=>m.Category).SingleOrDefault(m=>m.id==id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        public ActionResult Create ()
        {
            var viewModel = new BookFormViewModel()
            {

                categories = _Context.categories.ToList()

            };

                 return View("BookForm",viewModel);
        }

        public ActionResult Edit(int?id)
        {
            if (id == null)
            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _Context.books.Find(id);
            if (book == null)
                return HttpNotFound();
            var viewModel = new BookFormViewModel
            {
                id = book.id,
                Title = book.Title,
                Author = book.Author,
                categoryId = book.categoryId,
                Description = book.Description,
                categories = _Context.categories.Where(m => m.isActive).ToList()
                
            };
            return View("BookForm",viewModel);





        }
        [HttpPost]
        [ValidateAntiForgeryToken]
           public ActionResult save(BookFormViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.categories = _Context.categories.Where(m => m.isActive).ToList();
                return View("BookForm",model);
            }
            if (model.id == 0)
            {
                var Book = new book
                {
                    Author = model.Author,
                    Title = model.Title,
                    Description = model.Description,
                    categoryId = model.categoryId,
                };

                _Context.books.Add(Book);
            }
            else
            {
                var book = _Context.books.Find(model.id);
                if (book == null)
                    return HttpNotFound();

                book.id = book.id;
                book.Title = book.Title;
                book.Author = book.Author;
                book.categoryId = book.categoryId;
                book.Description = book.Description;
            } 
            _Context.SaveChanges();
            TempData["Message"] = "savedSuccessfully";
            return RedirectToAction("index");

        }

    }
}