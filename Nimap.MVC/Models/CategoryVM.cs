using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nimap.MVC.Models
{
    public class CategoryVM
    {
        [Display(Name="Id")] 
        public long Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        [Required(ErrorMessage = "Please set Status")]
        public bool IsActive { get; set; }


        [Display(Name = "Active")]
        public string IsActiveText { get; set; }
        //public List<ProductVM> Products { get; set; }
    }
}