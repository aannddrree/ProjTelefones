using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjTelefones;

namespace ProjTelefones.Controllers
{
    public class tb_telefoneController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: tb_telefone
        public ActionResult Index()
        {
            var tb_telefone = db.tb_telefone.Include(t => t.tb_pessoa);
            return View(tb_telefone.ToList());
        }

        // GET: tb_telefone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_telefone tb_telefone = db.tb_telefone.Find(id);
            if (tb_telefone == null)
            {
                return HttpNotFound();
            }
            return View(tb_telefone);
        }

        // GET: tb_telefone/Create
        public ActionResult Create()
        {
            ViewBag.id_pessoa = new SelectList(db.tb_pessoa, "id", "nome");
            return View();
        }

        // POST: tb_telefone/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,numero,tipo,id_pessoa")] tb_telefone tb_telefone)
        {
            if (ModelState.IsValid)
            {
                db.tb_telefone.Add(tb_telefone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pessoa = new SelectList(db.tb_pessoa, "id", "nome", tb_telefone.id_pessoa);
            return View(tb_telefone);
        }

        // GET: tb_telefone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_telefone tb_telefone = db.tb_telefone.Find(id);
            if (tb_telefone == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pessoa = new SelectList(db.tb_pessoa, "id", "nome", tb_telefone.id_pessoa);
            return View(tb_telefone);
        }

        // POST: tb_telefone/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,numero,tipo,id_pessoa")] tb_telefone tb_telefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_telefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pessoa = new SelectList(db.tb_pessoa, "id", "nome", tb_telefone.id_pessoa);
            return View(tb_telefone);
        }

        // GET: tb_telefone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_telefone tb_telefone = db.tb_telefone.Find(id);
            if (tb_telefone == null)
            {
                return HttpNotFound();
            }
            return View(tb_telefone);
        }

        // POST: tb_telefone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_telefone tb_telefone = db.tb_telefone.Find(id);
            db.tb_telefone.Remove(tb_telefone);
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
