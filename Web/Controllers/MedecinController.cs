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
    public class MedecinController : Controller
    {
        // GET: MedecinController
        private readonly IMedecinService Medecinservice;

        public MedecinController(IMedecinService _Medecinservice)
        {
            Medecinservice = _Medecinservice;
        }
        public ActionResult Index()
        {
            return View(Medecinservice.GetMany());
        }

        // GET: MedecinController/Details/5
        public ActionResult Details(int? id)

        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin = Medecinservice.GetMany()
                .FirstOrDefault(me => me.MedecinId == id);
            if (medecin == null)
            {
                return NotFound();
            }

            return View(medecin);
        }


        // GET: MedecinController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedecinController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medecin med)
        {
            try
            {
                Medecinservice.Add(med);
                Medecinservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedecinController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin = Medecinservice.GetMany()
                .FirstOrDefault(me => me.MedecinId == id);
            if (medecin == null)
            {
                return NotFound();
            }

            return View(medecin);
        }

        // POST: MedecinController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medecin mc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Medecinservice.Update(mc);
                    Medecinservice.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedecinExists(mc.MedecinId))
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

            return View(mc);
        }



        // GET: MedecinController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mc = Medecinservice.GetMany()
                .FirstOrDefault(med => med.MedecinId == id);
            if (mc == null)
            {
                return NotFound();
            }

            return View(mc);
        }

        // POST: MedecinController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var Medecin = Medecinservice.GetById(id);
            Medecinservice.Delete(Medecin);
            Medecinservice.Commit();
            return RedirectToAction(nameof(Index));
        }

          private bool MedecinExists(int id)
          {
              return Medecinservice.GetMany().Any(a => a.MedecinId == id);
          }
      }
    
}
