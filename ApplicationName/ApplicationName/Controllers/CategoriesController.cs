using ApplicationName.Classes;
using ApplicationName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationNameMongoDB = ApplicationName.Classes.MongoDB;

namespace ApplicationName.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult IndexCategories()
        {
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            var categories = db.GetAllCategories();
            CategoriesModels model = new CategoriesModels();
            model.EntityList = categories.ToList();
            return View(model);
        }

        public ActionResult AddCategory()
        {
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            var categories = db.GetAllCategories();
            CategoriesModels model = new CategoriesModels();
            model.EntityList = categories.ToList();
            ViewBag.Categories = model;
            return View();
        }

        public ActionResult SaveCategory(string name, string id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new MissingFieldException("name cannot be null");
            }
            bool result;
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            if (string.IsNullOrWhiteSpace(id))
            {
                //create new category
                Category category = db.GetCategoryByName(name);
                if (category != null)
                {
                    throw new Exception($"category {name} already exists");
                }
                result = db.InsertCategory(new Category
                {
                    Name = name
                });
                return RedirectToAction("IndexCategories", new { result = result });
            }
            result = db.UpdateCategory(new Category
            {
                ID = id,
                Name = name
            });
            return RedirectToAction("IndexCategories", new { result = result });
        }

        public ActionResult EditCategory(string name)
        {
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            var category = db.GetCategoryByName(name);
            Category model = new Category();
            model.Name = category.Name;
            model.ID = category.ID;
            return View(model);
        }

        public ActionResult DeleteCategory(string name)
        {
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            var category = db.GetCategoryByName(name);
            bool result = db.RemoveCategoryById(category.ID);

            //Category model = new Category();
            //model.Name = category.Name;
            //model.ID = category.ID;
            return RedirectToAction("IndexCategories", new { result = result });
        }

        public ActionResult DetailsCategory(string name)
        {
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            var category = db.GetCategoryByName(name);
            Category model = new Category();
            model.Name = category.Name;
            model.ID = category.ID;
            return View(model);
        }
    }
}