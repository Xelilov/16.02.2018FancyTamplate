using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fancy_Template.Models;

namespace Fancy_Template.Controllers
{
    public class HomeController : Controller
    {
        Fancy_TemplateEntities db = new Fancy_TemplateEntities();
        public ActionResult Index()
        {
            var _view_model = new ViewModel();
            _view_model._feature_boxs = db.Feature_Boxes.ToList();
            _view_model._blog = db.Blogs.ToList();
            _view_model._industry = db.Industries.ToList();
            _view_model._service_area = db.Service_Area.ToList();
            _view_model._service_content = db.Service_Area_Contents.ToList();
            _view_model._test_slider = db.Testimonials_Slider.ToList();
            return View(_view_model);
        }
        
        public ActionResult Blog()
        {
            var _view_model = new ViewModel();
            _view_model._category = db.Categories.ToList();
            _view_model._blog = db.Blogs.ToList();
            _view_model._test_slider = db.Testimonials_Slider.ToList();
            return View(_view_model);            
        }

        public ActionResult Contacts()
        {
            var _view_model = new FooterViewModel();
            _view_model._contact = db.Contacts.First();
            return PartialView(_view_model);
        }        
    }
}