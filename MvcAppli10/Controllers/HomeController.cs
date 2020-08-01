using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppli10.Models;

namespace MvcAppli10.Controllers
{
    public class HomeController : Controller
    {
        private hdfcDBContext db = new hdfcDBContext();

        public ActionResult Index()
        {
            return View(db.Emploes.ToList());
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        {
            //db.Emploes.Where(x => employeeIdsToDelete.Contains(x.ID)).ToList().ForEach(db.Emploes.DeleteObject);
            //db.Emploes.RemoveRange(db.Emploes.Where(d => employeeIdsToDelete.Contains(d.ID)));
            db.Emploes.Where(d => employeeIdsToDelete.Contains(d.ID)).ToList().ForEach(s => db.Emploes.Remove(s));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        //{
        //    Emplo emp = new Emplo();
        //    foreach (int id in employeeIdsToDelete)
        //    {
        //        emp = db.Emploes.Find(id);
        //        db.Emploes.Remove(emp);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
        
    }
}
