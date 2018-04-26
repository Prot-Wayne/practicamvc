using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using usermvc.Models;



namespace usermvc.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var db = new practicaEntities();
            List<usuario> users = db.usuarios.ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(usuario u)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var db = new practicaEntities();
                db.usuarios.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError("", "Error al adicionar registro " + e.Message);
                return View();
            }
        }
    }
}