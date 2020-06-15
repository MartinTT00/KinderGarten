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
        private UnitOfWork uow = UnitOfWork.UOW;

        
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
                List<Parent> allParents = UnitOfWork.UOW.ParentRepository.GetAll();
                SelectList selectParentList = new SelectList(allParents, "Id", "Name");
                ViewData["select"] = selectParentList;
                List<Group> allGroups = uow.GroupRepository.GetAll();
                SelectList selectGroupList = new SelectList(allGroups, "ID", "Name");
                ViewData["Groups"] = selectGroupList;
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
        [Authorize]
        public ActionResult Index()
        {
           
                List<Kid> allKids = UnitOfWork.UOW.KidRepository.Index();
                return View(allKids);
        }


        [HttpGet]
        [Authorize]
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
        }

        [HttpGet]
        [Authorize]
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