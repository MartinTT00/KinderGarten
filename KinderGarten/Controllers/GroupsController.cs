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
    public class GroupsController : Controller
    {

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
                return View();
        }

        [HttpPost]
        public ActionResult Create(Group group)
        {
            UnitOfWork.UOW.GroupRepository.Create(group);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }


        [HttpGet]
        [Authorize]
        public ActionResult Read()
        {
            List<Group> allGroups = UnitOfWork.UOW.GroupRepository.Read();
            return View(allGroups);

        }



        [HttpGet]
        [Authorize]
        public ActionResult Update(int id)
        {   
                Group group = UnitOfWork.UOW.GroupRepository.Update(id);
                return View(group);      
        }

        [HttpPost]
        public ActionResult Update(Group group)
        {

            UnitOfWork.UOW.GroupRepository.Update(group);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            DataStructure.Group group = UnitOfWork.UOW.GroupRepository.Delete(id);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }


        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            List<Kid> allKids = UnitOfWork.UOW.KidRepository.GetAll();
     
            Group group = UnitOfWork.UOW.GroupRepository.GetByID(id);
            List<Kid> kidsInTheGroup = allKids.Where(x => x.Groups.Id == group.Id).ToList();
            group.Kids = kidsInTheGroup;
            return View(group);
        }
    }
}