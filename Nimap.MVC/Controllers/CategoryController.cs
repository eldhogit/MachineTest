using Nimap.DAL;
using Nimap.Models;
using Nimap.MVC.CustomErrorFilter;
using Nimap.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nimap.MVC.Controllers
{
    [RoutePrefix("category")]
    [RedirectToErrorPage]
    public class CategoryController : Controller
    {
        string ErrorClass = "CategoryController";

        DalCategory dalCategory;
        public CategoryController()
        {
            dalCategory = new DalCategory();
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(CategoryVM categoryVM)
        {
            string ErrorMessage = string.Empty;

            if (ModelState.IsValid)
            {
                //TODO : Mapping
                Category category = new Category()
                {
                    Id = categoryVM.Id,
                    Name = categoryVM.Name,
                    IsActive = categoryVM.IsActive
                };

                //TODO : Calling Data Layer
                var IsSuccess = dalCategory.Insert(out ErrorMessage, category);

                if (IsSuccess)
                {
                    return RedirectToAction("GetAll");
                }
                else
                {
                    ErrorMessage = ErrorClass + " | " + ErrorMessage;
                    throw new Exception(ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Edit/{Id:long}")]
        public ActionResult Edit(long Id)
        {
            string ErrorMessage = string.Empty;

            Category category = new Category();
            CategoryVM categoryVM = new CategoryVM();

            //TODO : Calling Data Layer
            var IsSuccess = dalCategory.GetById(out ErrorMessage, out category, Id);

            //TODO : Mapping
            if (IsSuccess)
            {
                if (category != null)
                {
                    categoryVM.Id = category.Id;
                    categoryVM.Name = category.Name;
                    categoryVM.IsActive = category.IsActive;
                }
                else
                {
                    ErrorMessage = ErrorClass + " | " + "No rows!";
                    throw new Exception(ErrorMessage);
                }
            }
            else
            {
                ErrorMessage = ErrorClass + " | " + ErrorMessage;
                throw new Exception(ErrorMessage);
            }

            return View(categoryVM);
        }

        [HttpPost]
        [Route("get")]
        public ActionResult Edit(CategoryVM categoryVM)
        {
            string ErrorMessage = string.Empty;

            Category category = new Category();

            //TODO : Mapping
            category.Id = categoryVM.Id;
            category.Name = categoryVM.Name;
            category.IsActive = categoryVM.IsActive;

            //TODO : Calling Data Layer
            var IsSuccess = dalCategory.UpdateById(out ErrorMessage, category);

            if (IsSuccess)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                ErrorMessage = ErrorClass + " | " + ErrorMessage;
                throw new Exception(ErrorMessage);
            }
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult GetAll()
        {
            string ErrorMessage = string.Empty;
            List<Category> Categories = new List<Category>();
            List<CategoryVM> categoriesVM = new List<CategoryVM>();

            //TODO : Calling Data Layer
            var IsSuccess = dalCategory.GetAll(out ErrorMessage, out Categories);

            //TODO : Mapping
            if (IsSuccess)
            {
                if (Categories.Count > 0)
                {
                    foreach (var item in Categories)
                    {
                        categoriesVM.Add(new CategoryVM
                        {
                            Id = item.Id,
                            Name = item.Name,
                            IsActive = item.IsActive,
                            IsActiveText = item.IsActive ? "Yes" : "No"
                        });
                    }
                }
                else
                {
                    ErrorMessage = ErrorClass + " | " + "No rows!";
                    throw new Exception(ErrorMessage);
                }

            }
            else
            {
                ErrorMessage = ErrorClass + " | " + ErrorMessage;
                throw new Exception(ErrorMessage);
            }

            return View(categoriesVM);
        }

        [HttpGet]
        [Route("get/{Id:long}")]
        public ActionResult Get(long Id)
        {
            string ErrorMessage = string.Empty;

            Category category = new Category();
            CategoryVM categoryVM = new CategoryVM();

            //TODO : Calling Data Layer
            var IsSuccess = dalCategory.GetById(out ErrorMessage, out category, Id);

            
            if (IsSuccess)
            {
                if (category != null)
                {
                    //TODO : Mapping
                    categoryVM.Id = category.Id;
                    categoryVM.Name = category.Name;
                    categoryVM.IsActive = category.IsActive;
                    categoryVM.IsActiveText = category.IsActive ? "Yes" : "No";
                }
                else
                {
                    ErrorMessage = ErrorClass + " | " + "No rows!";
                    throw new Exception(ErrorMessage);
                }

            }
            else
            {
                ErrorMessage = ErrorClass + " | " + ErrorMessage;
                throw new Exception(ErrorMessage);
            }

            return View(categoryVM);
        }

        [HttpPost]
        [Route("Delete/{Id:long}")]
        public ActionResult Delete(long Id)
        {
            string ErrorMessage = string.Empty;

            //TODO : Calling Data Layer
            var IsSuccess = dalCategory.DeleteById(out ErrorMessage, Id);

            if (IsSuccess)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                ErrorMessage = ErrorClass + " | " + ErrorMessage;
                throw new Exception(ErrorMessage);
            }
        }



    }
}