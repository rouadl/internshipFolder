using GP.Domain.Entities;
using GP.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Web.Controllers
{
    public class DossierController : Controller
    {
        // GET: DossierController
        private readonly IDossierService Dossierservice;

        public DossierController(IDossierService _dossierservice)
        {
            Dossierservice = _dossierservice;
        }
        public ActionResult Index()
        {
            return View(Dossierservice.GetMany());
        }

        // GET: DossierController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DossierMedical = Dossierservice.GetMany()
                .FirstOrDefault(d => d.CIN == id);
            if (DossierMedical == null)
            {
                return NotFound();
            }

            return View(DossierMedical);
        }
        // GET: DossierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DossierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DossierMedical d)
        {
            try
            {
                Dossierservice.Add(d);
                Dossierservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: DossierController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DossierMedical = Dossierservice.GetMany()
                .FirstOrDefault(dm => dm.CIN == id);
            if (DossierMedical == null)
            {
                return NotFound();
            }

            return View(DossierMedical);
        }

        // POST: DossierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DossierMedical dms)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Dossierservice.Update(dms);
                    Dossierservice.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DossierMedicalExists(dms.CIN))
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

            return View(dms);
        }

        private bool DossierMedicalExists(int cIN)
        {
            throw new NotImplementedException();
        }

        // GET: DossierController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dms = Dossierservice.GetMany()
                .FirstOrDefault(dm => dm.CIN == id);
            if (dms == null)
            {
                return NotFound();
            }

            return View(dms);
        }

        // POST: DossierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(int id)
        {
            var dossierMedical = Dossierservice.GetById(id);
            Dossierservice.Delete(dossierMedical);
            Dossierservice.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool MedecinExists(int id)
        {
            return Dossierservice.GetMany().Any(l => l.CIN == id);
        }
    }
}