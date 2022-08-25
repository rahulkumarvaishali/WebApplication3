using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Databases;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RahulRajEntities obj = new RahulRajEntities();
            var strx = obj.RahulTables.ToList();
            List<Demo> objcal = new List<Demo>();
            foreach (var item in strx)
            {
                objcal.Add(new Demo
                {
                    Id=item.Id,
                    Name=item.Name,
                    Email=item.Email,
                    Mobile=item.Mobile,
                    Salary=item.Salary,
                    Depat=item.Depat,
                    ZipCode=item.ZipCode
                });
            }


            return View(objcal);
        }
        public ActionResult Delete(int Id)
        {
            RahulRajEntities obj = new RahulRajEntities();
            var delobj = obj.RahulTables.Where(m => m.Id == Id).First();
            obj.RahulTables.Remove(delobj);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MyForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyForm(RahulTable obj)
        {
            RahulRajEntities raju = new RahulRajEntities();
            RahulTable rajudata = new RahulTable();

            rajudata.Id = obj.Id;
            rajudata.Name = obj.Name;
            rajudata.Email = obj.Email;
            rajudata.Mobile = obj.Mobile;
            rajudata.Salary = obj.Salary;
            rajudata.Depat = obj.Depat;
            rajudata.ZipCode = obj.ZipCode;

            if (obj.Id==0)
            {

            raju.RahulTables.Add(rajudata);
            raju.SaveChanges();

            }
            else
            {
                raju.Entry(rajudata).State = System.Data.Entity.EntityState.Modified;
                raju.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            RahulRajEntities obj = new RahulRajEntities();
            var editobj = obj.RahulTables.Where(m => m.Id == Id).First();
            Demo dobj = new Demo();

            dobj.Id = editobj.Id;
            dobj.Name = editobj.Name;
            dobj.Email = editobj.Email;
            dobj.Mobile = editobj.Mobile;
            dobj.Salary = editobj.Salary;
            dobj.Depat = editobj.Depat;
            dobj.ZipCode = editobj.ZipCode;

            return View("MyForm", dobj);
        }

        public ActionResult ShowTable()
        {
            RahulRajEntities obj = new RahulRajEntities();
            var Raj = obj.RahulTables.ToList();
            return View(Raj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}