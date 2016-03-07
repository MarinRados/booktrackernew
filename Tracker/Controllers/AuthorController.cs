using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PagedList;
using System.Threading.Tasks;
using Tracker.Common.Filters;
using Tracker.Model;
using Tracker.Model.Common;
using Tracker.Service.Common;
using Tracker.DAL;
using Tracker.Models;

namespace Tracker.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService Service;

        public AuthorController(IAuthorService service)
        {
            Service = service;
        }

        public AuthorController()
        {
        }

        public async Task<ActionResult> Index(string searchString, string currentFilter, int pageNumber = 0, int pageSize = 0)
        {
            var at = await Service.GetAllAsync(new Common.Filters.GenericFilter(searchString, pageNumber, pageSize));
            return View(at);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AuthorModel atm)
        {
            if(ModelState.IsValid)
            {
                await Service.AddAsync(AutoMapper.Mapper.Map<Author>(atm));
                return RedirectToAction("Index");
            }
            return View(atm);
        }

        public async Task<ActionResult> Delete (Guid id)
        {
            var atToDelete = await Service.GetByIdAsync(id);
            if(atToDelete == null)
            {
                return HttpNotFound();
            }
            return View(atToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAuthor(Guid id)
        {
            await Service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}