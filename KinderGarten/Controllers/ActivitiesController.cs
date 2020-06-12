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
    public class ActivitiesController : Controller
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
        public ActionResult Create(DataStructure.Activity activity)
        {
            UnitOfWork.UOW.ActivityRepository.Create(activity);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));

        }



        [HttpGet]
        public ActionResult Read()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<DataStructure.Activity> allActivities = UnitOfWork.UOW.ActivityRepository.Read();
            return View(allActivities);
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
                DataStructure.Activity activity = UnitOfWork.UOW.ActivityRepository.Update(id);
            return View(activity);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Update(DataStructure.Activity activity)
        {
                
           UnitOfWork.UOW.ActivityRepository.Update(activity);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }



        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                DataStructure.Activity activity = UnitOfWork.UOW.ActivityRepository.Delete(id);
            return View(activity);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
           DataStructure.Activity activity = UnitOfWork.UOW.ActivityRepository.Delete(id);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }

    }
}