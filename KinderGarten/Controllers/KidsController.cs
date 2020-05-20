using DataAccess;
using DataAccess.Repositories;
using DataStructure;
using DataStructure.ViewModels;
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
            List<Parent> allParents = UnitOfWork.UOW.ParentRepository.GetAll();
            SelectList selectParentList = new SelectList(allParents, "Id", "Name");
            ViewData["select"] = selectParentList;
            //ViewBag.select = selectParentList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(KidViewModel kidViewModel)
        {
            List<Parent> allParents = UnitOfWork.UOW.ParentRepository.GetAll();
            Parent currentParent = allParents.Where(x => x.Id == kidViewModel.ParentId).FirstOrDefault();
            Kid kid = new Kid()
            {
                Id = kidViewModel.Id,
                Name = kidViewModel.Name,
                Parents = currentParent,
                Age = kidViewModel.Age,
                EGN = kidViewModel.EGN,
                Sex = kidViewModel.Sex
            };
            UnitOfWork.UOW.KidRepository.Create(kid);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));

        }



        [HttpGet]
        public ActionResult Read(/*KidViewModel kidViewModel*/)
        {
            List<Kid> allKids = UnitOfWork.UOW.KidRepository.Read();
            //List<Parent> allParents = UnitOfWork.UOW.ParentRepository.GetAll();
            //Parent currentParent = allParents.Where(x => x.Id == kidViewModel.ParentId).FirstOrDefault();
            //Kid kid = new Kid()
            //{
            //    Parents = currentParent,
            //    Name = kidViewModel.Name,
            //};
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