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
    public class LocationsController : Controller
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
        public ActionResult Create(Location location)
        {
            UnitOfWork.UOW.LocationRepository.Create(location);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));

        }



        [HttpGet]
        [Authorize]
        public ActionResult Read()
        {
            List<Location> allLocations = UnitOfWork.UOW.LocationRepository.Read();
            return View(allLocations);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Update(int id)
        {
            Location location = UnitOfWork.UOW.LocationRepository.Update(id);
            return View(location);
        }

        [HttpPost]
        public ActionResult Update(Location location)
        {

            UnitOfWork.UOW.LocationRepository.Update(location);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }



        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            DataStructure.Location location = UnitOfWork.UOW.LocationRepository.Delete(id);
            UnitOfWork.UOW.Save();
            return RedirectToAction(nameof(Read));
        }

    }
}