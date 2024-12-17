using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AppExamen.Controllers
{
    public class AsignacionesController : Controller
    {
        private DataBaseGestionPersonalProyectosEntities db = new DataBaseGestionPersonalProyectosEntities();

        // GET: Asignaciones
        public ActionResult Index()
        {
            var asignaciones = db.Asignaciones.Include(a => a.Empleados).Include(a => a.Proyectos);
            return View(asignaciones.ToList());
        }

        // GET: Asignaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaciones asignaciones = db.Asignaciones.Find(id);
            if (asignaciones == null)
            {
                return HttpNotFound();
            }
            return View(asignaciones);
        }

        // GET: Asignaciones/Create
        public ActionResult Create()
        {
            ViewBag.ID_Empleado = new SelectList(db.Empleados, "ID_Empleado", "NombreCompleto");
            ViewBag.ID_Proyecto = new SelectList(db.Proyectos, "ID_Proyecto", "NombreProyecto");
            return View();
        }

        // POST: Asignaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Asignacion,ID_Empleado,ID_Proyecto,FechaAsignacion")] Asignaciones asignaciones)
        {
            if (ModelState.IsValid)
            {
                db.Asignaciones.Add(asignaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Empleado = new SelectList(db.Empleados, "ID_Empleado", "NombreCompleto", asignaciones.ID_Empleado);
            ViewBag.ID_Proyecto = new SelectList(db.Proyectos, "ID_Proyecto", "NombreProyecto", asignaciones.ID_Proyecto);
            return View(asignaciones);
        }

        // GET: Asignaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaciones asignaciones = db.Asignaciones.Find(id);
            if (asignaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Empleado = new SelectList(db.Empleados, "ID_Empleado", "NombreCompleto", asignaciones.ID_Empleado);
            ViewBag.ID_Proyecto = new SelectList(db.Proyectos, "ID_Proyecto", "NombreProyecto", asignaciones.ID_Proyecto);
            return View(asignaciones);
        }

        // POST: Asignaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Asignacion,ID_Empleado,ID_Proyecto,FechaAsignacion")] Asignaciones asignaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Empleado = new SelectList(db.Empleados, "ID_Empleado", "NombreCompleto", asignaciones.ID_Empleado);
            ViewBag.ID_Proyecto = new SelectList(db.Proyectos, "ID_Proyecto", "NombreProyecto", asignaciones.ID_Proyecto);
            return View(asignaciones);
        }

        // GET: Asignaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaciones asignaciones = db.Asignaciones.Find(id);
            if (asignaciones == null)
            {
                return HttpNotFound();
            }
            return View(asignaciones);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignaciones asignaciones = db.Asignaciones.Find(id);
            db.Asignaciones.Remove(asignaciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
