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
    [RoutePrefix("product")]
    [RedirectToErrorPage]
    public class ProductController : Controller
    {
        //test
        string ErrorClass = "ProductController";

        DalCategory dalCategory;
        DalProduct dalProduct;

        public ProductController()
        {
            dalCategory = new DalCategory();
            dalProduct = new DalProduct();
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {

            ProductVM productVM = new ProductVM();

            var Issuccess = GetAllCategoryByIsActive(out List<CategoryVM> categoriesVM);

            if (Issuccess)
            {
                productVM.categories = categoriesVM;
                return View(productVM);
            }
            else
            {
                throw new Exception();
            }

        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(ProductVM productVM)
        {
            string ErrorMessage = string.Empty;

            //TODO : Dropdown        
            var Issuccess = GetAllCategoryByIsActive(out List<CategoryVM> categoriesVM);

            if (Issuccess)
            {
                productVM.categories = categoriesVM;

            }
            else
            {
                throw new Exception();
            }


            if (ModelState.IsValid)
            {
                //TODO : Mapping
                Product product = new Product()
                {
                    Id = productVM.Id,
                    Name = productVM.Name,
                    Price = productVM.Price,
                    CategoryId = productVM.CategoryId,
                    IsActive = productVM.IsActive,
                };

                //TODO : Calling Data Layer
                var IsSuccess = dalProduct.Insert(out ErrorMessage, product);

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

            return View(productVM);

        }

        [HttpGet]
        [Route("getall")]
        public ActionResult GetAll()
        {
            string ErrorMessage = string.Empty;
            List<Product> products = new List<Product>();
            List<ProductVM> productsVM = new List<ProductVM>();

            //TODO : Calling Data Layer
            var IsSuccess = dalProduct.GetAll(out ErrorMessage, out products);


            if (IsSuccess)
            {
                if (products.Count > 0)
                {
                    //TODO : Mapping
                    foreach (var item in products)
                    {
                        productsVM.Add(new ProductVM
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Price = item.Price,
                            CategoryId = item.CategoryId,
                            CategoryName = item.CategoryName,
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

            return View(productsVM);
        }

        [HttpGet]
        [Route("get/{Id:long}")]
        public ActionResult Get(long Id)
        {
            string ErrorMessage = string.Empty;

            Product product = new Product();
            ProductVM productVM = new ProductVM();

            //TODO : Calling Data Layer
            var IsSuccess = dalProduct.GetById(out ErrorMessage, out product, Id);


            if (IsSuccess)
            {
                if (product != null)
                {
                    //TODO : Mapping
                    productVM.Id = product.Id;
                    productVM.Name = product.Name;
                    productVM.Price = product.Price;
                    productVM.CategoryId = product.CategoryId;
                    productVM.IsActive = product.IsActive;
                    productVM.IsActiveText = product.IsActive ? "Yes" : "No";
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

            return View(productVM);
        }

        [HttpGet]
        [Route("Edit/{Id:long}")]
        public ActionResult Edit(long Id)
        {
            string ErrorMessage = string.Empty;

            Product product = new Product();
            ProductVM productVM = new ProductVM();

            //TODO : Dropdown        
            var Issuccess = GetAllCategoryByIsActive(out List<CategoryVM> categoriesVM);

            if (Issuccess)
            {
                productVM.categories = categoriesVM;

            }
            else
            {
                throw new Exception();
            }

            //TODO : Calling Data Layer
            var IsSuccess = dalProduct.GetById(out ErrorMessage, out product, Id);

            //TODO : Mapping
            if (IsSuccess)
            {
                if (product != null)
                {
                    productVM.Id = product.Id;
                    productVM.Name = product.Name;
                    productVM.Price = product.Price;
                    productVM.CategoryId = product.CategoryId;
                    productVM.IsActive = product.IsActive;
                    productVM.IsActiveText = product.IsActive ? "Yes" : "No";
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

            return View(productVM);
        }

        [HttpPost]
        [Route("get")]
        public ActionResult Edit(ProductVM productVM)
        {
            string ErrorMessage = string.Empty;

            Product product = new Product();

            //TODO : Dropdown        
            var Issuccess = GetAllCategoryByIsActive(out List<CategoryVM> categoriesVM);

            if (Issuccess)
            {
                productVM.categories = categoriesVM;

            }
            else
            {
                throw new Exception();
            }

            //TODO : Mapping
            product.Id = productVM.Id;
            product.Name = productVM.Name;
            product.Price = productVM.Price;
            product.CategoryId = productVM.CategoryId;
            product.IsActive = productVM.IsActive;

            //TODO : Calling Data Layer
            var IsSuccess = dalProduct.UpdateById(out ErrorMessage, product);

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

        [HttpPost]
        [Route("Delete/{Id:long}")]
        public ActionResult Delete(long Id)
        {
            string ErrorMessage = string.Empty;

            //TODO : Calling Data Layer
            var IsSuccess = dalProduct.DeleteById(out ErrorMessage, Id);

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

        [NonAction]
        public bool GetAllCategoryByIsActive(out List<CategoryVM> categoriesVM)
        {
            categoriesVM = new List<CategoryVM>();
            List<Category> categories = new List<Category>();
            string ErrorMessage = string.Empty;

            //TODO : Calling Data Layer
            var IsSuccess = dalCategory.GetAllByIsActive(out ErrorMessage, out categories);

            //TODO : Mapping
            if (IsSuccess)
            {
                if (categories.Count > 0)
                {
                    foreach (var item in categories)
                    {
                        categoriesVM.Add(new CategoryVM
                        {
                            Id = item.Id,
                            Name = item.Name,
                            IsActive = item.IsActive,
                            //IsActiveText = item.IsActive ? "Yes" : "No"
                        });
                    }
                }
                else
                {
                    ErrorMessage = ErrorClass + " | " + "No rows!";
                    throw new Exception(ErrorMessage);
                }

                return IsSuccess;
            }
            else
            {
                IsSuccess = false;
                ErrorMessage = ErrorClass + " | " + ErrorMessage;
                return IsSuccess;

                throw new Exception(ErrorMessage);
            }

        }
    }
}