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
using System.Web.UI.WebControls;

namespace KinderGarten.Controllers
{
    public class KidsController : Controller
    {
        // GET: Activities
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public UnitOfWork uow = UnitOfWork.UOW;


        [HttpGet]
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<Parent> allParents = UnitOfWork.UOW.ParentRepository.GetAll();
                SelectList selectParentList = new SelectList(allParents, "Id", "Name");
                ViewData["select"] = selectParentList;
                //ViewBag.select = selectParentList;
                List<Group> allGroups = uow.GroupRepository.GetAll();
                SelectList selectGroupList = new SelectList(allGroups, "ID", "Name");
                ViewData["Groups"] = selectGroupList;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
                Age = kidViewModel.Age,
                EGN = kidViewModel.EGN,
                Sex = kidViewModel.Sex,
                Parents = currentParent,
                Groups = uow.GroupRepository.GetByID(kidViewModel.GroupID)
            };
            UnitOfWork.UOW.KidRepository.Create(kid);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Index));

        }



        [HttpGet]
        public ActionResult Index()
        {
            List<Kid> allKids = UnitOfWork.UOW.KidRepository.Index();
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
            Kid kid = UnitOfWork.UOW.KidRepository.GetByID(id);
            List<Group> allGroups = uow.GroupRepository.GetAll();
            SelectList selectGroupList = new SelectList(allGroups, "ID", "Name");
            ViewData["Groups"] = selectGroupList;
            KidViewModel kidViewModel = new KidViewModel(kid);
            return View(kidViewModel);
        }

        [HttpPost]
        public ActionResult Update(KidViewModel kidViewModel)
        {

            List<Kid> allKids = UnitOfWork.UOW.KidRepository.GetAll();
            Kid kid = allKids.Where(x => x.Id == kidViewModel.Id).FirstOrDefault();
            List<Group> allGroups = UnitOfWork.UOW.GroupRepository.GetAll();
            Group group = allGroups.Where(x => x.Id == kidViewModel.GroupID).FirstOrDefault();
            kid.Groups = group;
            kid.Id = kidViewModel.Id;
            kid.Name = kidViewModel.Name;
            kid.Age = kidViewModel.Age;
            kid.EGN = kidViewModel.EGN;
            kid.Sex = kidViewModel.Sex;
            uow.KidRepository.Update(kid);
            uow.Save();
            return RedirectToAction(nameof(Index));

            //Kid kid = Transform(kidViewModel);
            //List<Group> allGroups =uow.GroupRepository.GetAll();
            //Group group = allGroups.Where(x => x.Id == kidViewModel.GroupID).FirstOrDefault();
            //kidViewModel.Groups = group;
            //kid.Groups = kidViewModel.Groups;
            //UnitOfWork.UOW.KidRepository.Update(kid);
            //UnitOfWork.UOW.Save();
            //return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }



        private Kid Transform(KidViewModel kidViewModel)
        {
            return new Kid()
            {
                Id = kidViewModel.Id,
                Name = kidViewModel.Name,
                Age = kidViewModel.Age,
                EGN = kidViewModel.EGN,
                Sex = kidViewModel.Sex,
                Groups = kidViewModel.Groups
            };
        }

    }

}