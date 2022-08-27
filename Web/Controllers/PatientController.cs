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
    public class PatientController : Controller
    {
        // GET: PatientController
        private readonly IPatientService Patientservice;

        public PatientController(IPatientService _patientservice)
        {
            Patientservice = _patientservice;
        }
        public ActionResult Index()
        {
            return View(Patientservice.GetMany());

        }

        // GET: PatientController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = Patientservice.GetMany()
                .FirstOrDefault(p => p.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient pa)
        {
            try
            {
                Patientservice.Add(pa);
                Patientservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = Patientservice.GetMany()
                .FirstOrDefault(p => p.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }


        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient pat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Patientservice.Update(pat);
                    Patientservice.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(pat.PatientId))
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

            return View(pat);
        }

      /*  private bool PatientExists(int patientId)
        {
            throw new NotImplementedException();
        }*/

        // GET: PatientController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pat = Patientservice.GetMany()
                .FirstOrDefault(p => p.PatientId == id);
            if (pat == null)
            {
                return NotFound();
            }

            return View(pat);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var patient = Patientservice.GetById(id);
            Patientservice.Delete(patient);
            Patientservice.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return Patientservice.GetMany().Any(t => t.PatientId == id);
        }
    }
}
