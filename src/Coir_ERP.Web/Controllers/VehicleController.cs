using AutoMapper;
using Coir_ERP.Generics;
using Coir_ERP.Vehicles;
using Coir_ERP.Vehicles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coir_ERP.Web.Controllers
{
    public class VehicleController : Controller
    {
        

        // GET: Vehicle
        public ActionResult Index()
        {
            return View("~/Views/Vehicle/Index.cshtml");
        }

        public ActionResult Create()
        {
            return View("~/Views/Vehicle/Create.cshtml");
        }
    }
}