﻿using DataAccess.Repositories;
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

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
                return View();
        }   

        [HttpPost]
        public ActionResult Create(DataStructure.Activity activity)
        {
            UnitOfWork.UOW.ActivityRepository.Create(activity);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }



        [HttpGet]
        [Authorize]
        public ActionResult Read()
        {
            List<DataStructure.Activity> allActivities = UnitOfWork.UOW.ActivityRepository.Read();
            return View(allActivities);     
        }



        [HttpGet]
        [Authorize]
        public ActionResult Update(int id)
        {
            DataStructure.Activity activity = UnitOfWork.UOW.ActivityRepository.Update(id);
            return View(activity);
            
        }

        [HttpPost]
        public ActionResult Update(DataStructure.Activity activity)
        {
                
           UnitOfWork.UOW.ActivityRepository.Update(activity);
           UnitOfWork.UOW.Save();
           return RedirectToAction(nameof(Read));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            DataStructure.Activity activity = UnitOfWork.UOW.ActivityRepository.Delete(id);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));

        }

    }
}
