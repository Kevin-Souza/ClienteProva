using ClienteProva.Context;
using ClienteProva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClienteProva.Controllers
{
    public class ClientesController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(context.clientes.OrderBy(c => c.Nome));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            context.clientes.Add(cliente);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = context.clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Cliente cliente = context.clientes.Find(id);
            context.clientes.Remove(cliente);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}