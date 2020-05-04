using AutoMapper;
using LoLesports.Logic;
using LoLesports.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoLesports.Web.Controllers
{
    public class JatekosController : Controller
    {
        IJatekosLogic jatekosLogic;
        IMapper mapper;
        JatekosokViewModel model;

        public JatekosController()
        {
            jatekosLogic = new JatekosLogic();
            mapper = MapperFactory.CreateMapper();
            model = new JatekosokViewModel();
            model.Editedjatekos = new Jatekos();

            var jatekosok = jatekosLogic.GetAll();
            model.JatekosList = mapper.Map<IList<Data.Jatekos>, List<Models.Jatekos>>(jatekosok);
        }

        private Jatekos GetJatekosModel(string felhasznalonev)
        {
            Data.Jatekos jatekos = jatekosLogic.GetOne(felhasznalonev);
            return mapper.Map<Data.Jatekos, Jatekos>(jatekos);
        }

        // GET: Jatekos
        public ActionResult Index()
        {
            ViewData["editAction"] = "AddNew";
            return View("JatekosIndex", model);
        }

        // GET: Jatekos/Details/5
        public ActionResult Details(string felhasznalonev)
        {
            return View("JatekosDetails", GetJatekosModel(felhasznalonev));
        }

        public ActionResult Remove(string felhasznalonev)
        {
            TempData["editResult"] = "Delete FAIL";
            if (jatekosLogic.DeleteJatekosElement(felhasznalonev)) TempData["editResult"] = "Delete OK";
            return RedirectToAction("Index");
        }

        // GET: Jatekos/Edit/5
        public ActionResult Edit(string felhasznalonev)
        {
            ViewData["editAction"] = "Edit";
            model.Editedjatekos = GetJatekosModel(felhasznalonev);
            return View("JatekosIndex", model);
        }

        // POST: Jatekos/Edit/5
        [HttpPost]
        public ActionResult Edit(Jatekos jatekos, string editAction)
        {
            if (ModelState.IsValid && jatekos != null)
            {
                List<object> jatekoslist = new List<object>();
                jatekoslist.Add(jatekos.Felhasznalonev);
                jatekoslist.Add(jatekos.Vezeteknev);
                jatekoslist.Add(jatekos.Keresztnev);
                jatekoslist.Add(jatekos.Eletkor);
                jatekoslist.Add(jatekos.Pozicio);
                jatekoslist.Add(jatekos.Nemzetiseg);
                jatekoslist.Add(jatekos.Csapatnev);

                TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    jatekosLogic.CreateJatekosElement(jatekoslist);
                }
                else
                {
                    if (!jatekosLogic.UpdateJatekosElement(jatekoslist))
                    {
                        TempData["editResult"] = "Edit FAIL";
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["editAction"] = "Edit";
                model.Editedjatekos = jatekos;
                return View("JatekosIndex", model);
            }
        }
    }
}
