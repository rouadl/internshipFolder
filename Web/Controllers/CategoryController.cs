using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//
using GP.Data;
using GP.Service;
using GP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GP.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController

        private readonly ICategoryService categoryservice;

        public CategoryController(ICategoryService _categoryservice)
        {
            categoryservice = _categoryservice;
        }
        public ActionResult Index()
        {
            return View(categoryservice.GetMany());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = categoryservice.GetMany()
                .FirstOrDefault(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category c)
        {
            try
            {
                categoryservice.Add(c);
                categoryservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = categoryservice.GetMany()
                .FirstOrDefault(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
           
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryservice.Update(cat);
                    categoryservice.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(cat.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(cat);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = categoryservice.GetMany()
                .FirstOrDefault(m => m.CategoryId == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var category = categoryservice.GetById(id);
            categoryservice.Delete(category);
            categoryservice.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return categoryservice.GetMany().Any(e => e.CategoryId == id);
        }
    }
}
