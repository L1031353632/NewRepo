using CZBK.HeiMaOA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data;
using CZBK.HeiMaOA.Model;
using System.Net;

namespace CZBK.HeiMaOA.WebApplication.Controllers
{
    public class WorkerController : Controller
    {
        // GET: Worker

        //IWorkerManager WorkerManager = new CZBK.HeiMaOA.BLL.WorkerManager();
        IWorkerManager WorkerManager { get; set; }

        //public ActionResult Index()
        //{
        //    return View(WorkerManager.LoadEntities(w => true).ToList());
        //}

        //public ViewResult Index(string sortOrder)
        //{
        //    ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
        //    ViewBag.LastNameSortParm = sortOrder == "last" ? "last_desc" : "last";
        //    var workers = from w in WorkerManager.LoadEntities(w => true)
        //                  select w;
        //    switch (sortOrder)
        //    {
        //        case "first_desc":
        //            workers = workers.OrderByDescending(w => w.FirstName);
        //            break;
        //        case "last_desc":
        //            workers = workers.OrderByDescending(w => w.LastName);
        //            break;
        //        case "last":
        //            workers = workers.OrderBy(w => w.LastName);
        //            break;
        //        default:
        //            workers = workers.OrderBy(w => w.FirstName);
        //            break;
        //    }
        //    return View(workers.ToList());
        //}

        //public ViewResult Index(string sortOrder, string searchString)
        //{
        //    ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
        //    ViewBag.LastNameSortParm = sortOrder == "last" ? "last_desc" : "last";
        //    var workers = from w in WorkerManager.LoadEntities(w => true)
        //                  select w;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        workers = workers.Where(w => w.FirstName.Contains(searchString)
        //                                || w.LastName.Contains(searchString));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "first_desc":
        //            workers = workers.OrderByDescending(w => w.FirstName);
        //            break;
        //        case "last_desc":
        //            workers = workers.OrderByDescending(w => w.LastName);
        //            break;
        //        case "last":
        //            workers = workers.OrderBy(w => w.LastName);
        //            break;
        //        default:
        //            workers = workers.OrderBy(w => w.FirstName);
        //            break;
        //    }
        //    return View(workers.ToList());
        //}

        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var workers = from w in WorkerManager.LoadEntities(w => true)
                          select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.FirstName.Contains(searchString)
                                        || w.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.FirstName);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.LastName);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.LastName);
                    break;
                default:
                    workers = workers.OrderBy(w => w.FirstName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber, pageSize));
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Sex, Rating")] Worker worker)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WorkerManager.AddEntity(worker);
                    //WorkerManager.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("unableToSave", "Unable to save changes.Try again, and if the problem persists see your system administrator.");
            }
            return View(worker);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = WorkerManager.FindEntity(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = WorkerManager.FindEntity(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, FirstName, LastName, Sex, Rating")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                WorkerManager.UpdateEntity(worker);//.State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Worker workerToDelete = new Worker() { ID = id };
                WorkerManager.DeleteEntity(workerToDelete);//.State = EntityState.Deleted;
                //db.SaveChanges();
            }
            catch (DataException/*dex*/)
            {
                return RedirectToAction("Index", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}