using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fancy_Template.Models;

namespace Fancy_Template.Controllers
{
    public class PartialsController : Controller
    {
        Fancy_TemplateEntities db = new Fancy_TemplateEntities();
        // GET: Partials
        public PartialViewResult Footer()
        {
            var _view_model = new FooterViewModel();
            _view_model._category = db.Categories.ToList();
            _view_model._contact = db.Contacts.First();


            return PartialView(_view_model);
        }
    }
}