using DataAccess.Repositories;
using DataStructure;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KinderGarten.Controllers
{
    public class KidsController : Controller
    {
        // GET: Activities
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kid kid)
        {
            UnitOfWork.UOW.KidRepository.Create(kid);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));

        }



        [HttpGet]
        public ActionResult Read()
        {
            List<Kid> allKids = UnitOfWork.UOW.KidRepository.Read();
            return View(allKids);
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            Kid kid = UnitOfWork.UOW.KidRepository.Update(id);
            return View(kid);
        }

        [HttpPost]
        public ActionResult Update(Kid kid)
        {
            UnitOfWork.UOW.KidRepository.Update(kid);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }



        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Kid kid = UnitOfWork.UOW.KidRepository.Delete(id);
            return View(kid);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            DataStructure.Kid kid = UnitOfWork.UOW.KidRepository.Delete(id);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }

    }
}