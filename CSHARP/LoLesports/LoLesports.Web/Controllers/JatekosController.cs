using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoLesports.Web.Controllers
{
    public class JatekosController : Controller
    {
        // GET: Jatekos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Jatekos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jatekos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jatekos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jatekos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jatekos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jatekos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jatekos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
