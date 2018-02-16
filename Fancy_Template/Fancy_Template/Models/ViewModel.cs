using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fancy_Template.Models
{
    public class ViewModel
    {
        public List<Feature_Boxes> _feature_boxs { get; set; }
        public List<Blog> _blog { get; set; }
        public List<Industry> _industry { get; set; }
        public List<Service_Area> _service_area { get; set; }
        public List<Service_Area_Contents> _service_content { get; set; }
        public List<Testimonials_Slider> _test_slider { get; set; }
        public List<Category> _category { get; set; }
    }
}