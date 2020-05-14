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
        public ActionResult Create(DataStructure.Activity activity)
        {
            UnitOfWork.UOW.ActivityRepository.Create(activity);
            return RedirectToAction(nameof(Read));

        }

        [HttpGet]
        public ActionResult Read()
        {
            List<DataStructure.Activity> allActivities = UnitOfWork.UOW.ActivityRepository.Read();
            return View(allActivities);
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
        }

        [HttpGet]
        public ActionResult Delete()
        {
        }

        [HttpPost]
        public ActionResult Delete()
        {
        }

    }
}