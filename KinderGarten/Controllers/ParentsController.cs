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
    public class ParentsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Parent parent)
        {
            UnitOfWork.UOW.ParentRepository.Create(parent);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));

        }



        [HttpGet]
        [Authorize]
        public ActionResult Read()
        {
            List<Parent> allParents = UnitOfWork.UOW.ParentRepository.Read();
            return View(allParents);
        }



        [HttpGet]
        [Authorize]
        public ActionResult Update(int id)
        {
            Parent parent = UnitOfWork.UOW.ParentRepository.Update(id);
            return View(parent);
        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "Id, Name, EGN, Sex, PhoneNumber")]Parent parent)
        {

            UnitOfWork.UOW.ParentRepository.Update(parent);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            DataStructure.Parent parent = UnitOfWork.UOW.ParentRepository.Delete(id);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }

    }
}