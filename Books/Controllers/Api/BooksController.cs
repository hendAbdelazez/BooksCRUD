using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Books.Controllers.Api
{
    public class BooksController : ApiController
    {
        private readonly ApplicationDbContext _Context;


        public BooksController()
        {
            _Context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = _Context.books.Find(id);
            if (book == null)
                return NotFound();
            _Context.books.Remove(book);
            _Context.SaveChanges();
            return Ok();
        }
    }
}
