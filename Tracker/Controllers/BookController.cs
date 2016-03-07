using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tracker.Common;
using Tracker.DAL;
using Tracker.Model;
using Tracker.Model.Common;
using Tracker.Service.Common;
using Tracker.Models;
using PagedList;

namespace Tracker.Controllers
{
    public class BookController : Controller
    {

        protected IBookService BookService { get; private set; }
        protected IAuthorService AuthorService { get; private set; }

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            BookService = bookService;
            AuthorService = authorService;
        }

        public BookController()
        {
        }

        public async Task<ActionResult> Index(string searchString, string currentFilter, int pageNumber = 0, int pageSize = 0)
        {
            var bk = await BookService.GetAllBooks(new Common.Filters.GenericFilter(searchString, pageNumber, pageSize));
            return View(bk);
        }


        public async Task<ActionResult> AddBook()
        {
            ViewBag.Author = await AuthorService.GetAllAsync(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddBook([Bind(Include = "Id, Name, DateRead, Rating, AuthorId")] BookModel bkm)
        {
            if (ModelState.IsValid)
            {

                await BookService.AddBook(AutoMapper.Mapper.Map<Book>(bkm));
                return RedirectToAction("Index");
            }
            ViewBag.Author = await AuthorService.GetAllAsync(null);

            return View(bkm);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                IBook bk = await BookService.FindByIdAsync(id);

                if (bk == null)
                    return HttpNotFound();

                return View(bk);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.Author = await AuthorService.GetAllAsync(null);

            IBook book = await BookService.FindByIdAsync(id);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Name, DateRead, Rating, AuthorId")] BookModel bkm)
        {
            try
            {
                ViewBag.Author = await AuthorService.GetAllAsync(null);

                if (ModelState.IsValid)
                {
                    await BookService.UpdateBook(AutoMapper.Mapper.Map<Book>(bkm));
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Delete(Guid id) //must be nullable
        {
            //if (id == null)
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var bookToDelete = await BookService.FindByIdAsync(id);
            if (bookToDelete == null)
                return HttpNotFound();

            return View(bookToDelete);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePost(Guid id)
        {
            await BookService.DeleteBook(id);
            return RedirectToAction("Index");
        }

    }
}