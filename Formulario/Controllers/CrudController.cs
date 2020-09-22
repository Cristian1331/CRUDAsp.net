using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Formulario.Controllers;
using Formulario.Models;
using Formulario.Models.ViewModels;

namespace Formulario.Controllers
{
    public class CrudController : Controller
    {
        // GET: Crud
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateUser(CrudViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(FormEntities1 db = new FormEntities1())
                    {
                        var oCrud = new TB_Form();
                        oCrud.nombre = model.Nombre;
                        oCrud.apellido = model.Apellido;
                        oCrud.correo = model.Correo;
                        oCrud.pais = model.Pais;
                        oCrud.telefono = model.Telefono;

                        db.TB_Form.Add(oCrud);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public ActionResult Dashboard()
        {
            List<ListCrudViewModel> lst;
            using (FormEntities1 db = new FormEntities1())
            {
                lst = (from d in db.TB_Form
                       select new ListCrudViewModel
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Apellido = d.apellido,
                           Correo = d.correo,
                           Telefono = d.telefono,
                           Pais = d.pais
                           
                       }).ToList();
            }
                return View(lst);
        }

        public ActionResult Delete(int id)
        {
            FormEntities1 db = new FormEntities1();
            TB_Form eliminar = db.TB_Form.Where(d => d.id == id).First();

            db.TB_Form.Remove(eliminar);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public ActionResult Update()
        {
            return View();
        }
    }
}