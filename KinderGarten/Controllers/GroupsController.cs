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
        // GET: Activities
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Create(Group group)
        {
            UnitOfWork.UOW.GroupRepository.Create(group);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }

        



        [HttpGet]
        public ActionResult Read()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<Group> allGroups = UnitOfWork.UOW.GroupRepository.Read();
            return View(allGroups);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Group group = UnitOfWork.UOW.GroupRepository.Update(id);
            return View(group);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Update(Group group)
        {

            UnitOfWork.UOW.GroupRepository.Update(group);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }



        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Group group = UnitOfWork.UOW.GroupRepository.Delete(id);
            return View(group);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            DataStructure.Group group = UnitOfWork.UOW.GroupRepository.Delete(id);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            List<Kid> allKids = UnitOfWork.UOW.KidRepository.GetAll();
     
            Group group = UnitOfWork.uow.GroupRepository.GetByID(id);
            List<Kid> kidsInTheGroup = allKids.Where(x => x.Groups.Id == group.Id).ToList();
            group.Kids = kidsInTheGroup;
            return View(group);
        }
    }
}