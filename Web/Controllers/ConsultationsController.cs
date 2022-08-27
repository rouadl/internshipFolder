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
    public class ConsultationsController : Controller
    {
        // GET: ConsultationsController
        private readonly IConsultationService consultationservice;

        public ConsultationsController(IConsultationService _consultationservice)
        {
            consultationservice = _consultationservice;
        }
        public ActionResult Index()
        {
            return View(consultationservice.GetMany());
        }

        // GET: ConsultationsController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = consultationservice.GetMany()
                .FirstOrDefault(n => n.CodeConsultation == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
           
        }

        // GET: ConsultationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsultationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consultation ct)
        {
            try
            {
                consultationservice.Add(ct);
                consultationservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConsultationsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = consultationservice.GetMany()
                .FirstOrDefault(n => n.CodeConsultation == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // POST: ConsultationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consultation cons)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    consultationservice.Update(cons);
                   consultationservice.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultationExists(cons.CodeConsultation))
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

            return View(cons);
        }

       

        // GET: ConsultationsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cons = consultationservice.GetMany()
                .FirstOrDefault(n => n.CodeConsultation == id);
            if (cons == null)
            {
                return NotFound();
            }

            return View(cons);
        }

        // POST: ConsultationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var consultation = consultationservice.GetById(id);
          consultationservice.Delete(consultation);
            consultationservice.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultationExists(int id)
        {
            return consultationservice.GetMany().Any(i => i.CodeConsultation == id);
        }
    }
}
