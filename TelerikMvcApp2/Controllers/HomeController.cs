using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikMvcApp2.Models;

namespace TelerikMvcApp2.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult GetStudent()
        //{
        //    var data = db.students.ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetEmployees([DataSourceRequest] DataSourceRequest request)
        {
            //    IEnumerable<UserModel> StudentlistViewModel =
            //        (from objstudent in db.students
            //         select new UserModel()
            //         {
            //             id = objstudent.id,
            //             name = objstudent.name,
            //             address = objstudent.address
            //         }).ToList();
            var StudentlistViewModel = db.students.ToList();
            return Json(StudentlistViewModel.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public void DeleteEmployee(student emp)
        {
            var data = db.students.Find(emp.id);
            db.students.Remove(data);
            db.SaveChanges();
        }

        public void AddEmployee(student emp)
        {
            db.students.Add(emp);
            db.SaveChanges();
        }

        public void UpdateEmployee(student emp)
        {
          
            student objToUpdate = db.students.Find(emp.id);
            objToUpdate.name = emp.name;
            objToUpdate.address = emp.address;


            db.Entry(objToUpdate).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

    }
}