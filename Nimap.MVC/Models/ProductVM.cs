using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nimap.MVC.Models
{
    public class ProductVM
    {
        public long Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter Price")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Price { get; set; }

        [Display(Name = "Category Id")]
        //[Required(ErrorMessage = "Please enter Category Id")]
        public long CategoryId { get; set; }

        [Display(Name = "Category Name")]
        //[Required(ErrorMessage = "Please enter Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Active")]
        public string IsActiveText { get; set; }
        public List<CategoryVM> categories { get; set; }
    }
}