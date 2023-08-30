using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMPLEADO_ASP.NET.Models;
using EMPLEADO_ASP.NET.StoredProcedures;

namespace EMPLEADO_ASP.NET.Controllers
{
    public class EmpleadoController : Controller
    {
        private Mi_EmpresaEntities1 db = new Mi_EmpresaEntities1();
        StoredProc sp = new StoredProc();

        // GET: Empleado
        public ActionResult Index()
        {
            return View(db.Empleado.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "Cédula,Nombre,Apellido,Fecha_Nacimiento,Teléfono,Dirección,Sexo,Edad")]*/ Empleado empleado)
        {
            bool IsInserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = sp.InsertEmpleado(empleado);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Empleado creado exitosamente.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "El empleado ya existe / No se pudo crear el empleado.";
                    }
                    //db.Empleado.Add(empleado);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

            //return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Cédula,Nombre,Apellido,Fecha_Nacimiento,Teléfono,Dirección,Sexo,Edad")]*/ Empleado empleado)
        {
            bool IsUpdated = false;
            try
            {
                if (ModelState.IsValid)
                {
                    IsUpdated = sp.UpdateEmpleado(empleado);
                    if (IsUpdated)
                    {
                        TempData["SuccessMessage"] = "Empleado editado exitosamente.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "El empleado no existe / No se pudo actualizar el empleado.";
                    }
                    //db.Empleado.Add(empleado);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(empleado).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            bool IsDeleted = false;
            try
            {
                Empleado empleado = db.Empleado.Find(id);
                if (ModelState.IsValid)
                {
                    IsDeleted = sp.DeleteEmpleado(empleado.Cédula);
                    if (IsDeleted)
                    {
                        TempData["SuccessMessage"] = "Empleado eliminado exitosamente.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "El empleado no existe / No se pudo eliminar el empleado.";
                    }
                    //db.Empleado.Add(empleado);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            //Empleado empleado = db.Empleado.Find(id);
            //db.Empleado.Remove(empleado);
            //db.SaveChanges();
            //return RedirectToAction("Index");
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
