using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityframe.Models;

namespace MvcEntityframe.Controllers
{
    public class HomeController : Controller
    {
        testEntities ts = new testEntities();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var db=ts.forms.ToList();
            person uf = new person();
            foreach (var i in db) 
            {
                person f=new person();
                f.id = i.id;
                f.firstname = i.firstname;
                f.lastname = i.lastname;
                f.email = i.email;
                f.number = i.number;
                f.city = i.city;
                uf.user.Add(f);
            }
            return View(uf);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(person uf)
        {
            try
            {
                // TODO: Add insert logic here
                form f = new form();
                f.firstname = uf.firstname;
                f.lastname = uf.lastname;
                f.email = uf.lastname;
                f.number = uf.number;
                f.city = uf.city;
                ts.forms.AddObject(f);
                ts.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Home/Edit/5
 
        public ActionResult Edit(int id)
        {
            person f = new person();
            var t = ts.forms.Where(x => x.id == id).SingleOrDefault();
            f.id = t.id;
            f.firstname = t.firstname;
            f.lastname = t.lastname;
            f.email = t.lastname;
            f.number = t.number;
            f.city = t.city;
            return View(f);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, person f)
        {
            try
            {
                // TODO: Add update logic here
                
                var t = ts.forms.Where(x => x.id == id).SingleOrDefault();
                t.id = f.id;
                t.firstname = f.firstname;
                t.lastname = f.lastname;
                t.email = f.lastname;
                t.number = f.number;
                t.city = f.city;
                ts.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5
 
        public ActionResult Delete(int id)
        {
                var pv = ts.forms.Where(x => x.id == id).SingleOrDefault();
                ts.DeleteObject(pv);
                ts.SaveChanges();
                return RedirectToAction("Index");
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
