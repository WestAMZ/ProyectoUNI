﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAEDUCA.Models;

namespace PAEDUCA.Controllers
{
    public class GestionIntrumentosController : Controller
    {
        private ApplicationDbContext db =  ApplicationDbContext.Create();
        // GET: GestionIntrumentos
        public ActionResult AAC()
        {
            List<AspectoAAC>  aspectos = db.AspectoAAC.ToList();
            return View(aspectos);
        }
    }
}