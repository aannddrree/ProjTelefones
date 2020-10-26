using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjTelefones.Controllers
{
    
    public class ItensController : Controller
    {

        private BancoEntities db = new BancoEntities();

        // GET: Itens
        public ActionResult ListarItens(int id)
        {
            var lista = db.tb_telefone.Where(t => t.tb_pessoa.id == id);
            ViewBag.Pessoa = id;
            return PartialView(lista);
        }

        public ActionResult SalvarTelefones(string numero, string tipo, int idPessoa)
        {
            var telefone = new tb_telefone()
            {
                numero = numero,
                tipo = tipo,
                tb_pessoa = db.tb_pessoa.Find(idPessoa)
            };

            db.tb_telefone.Add(telefone);
            db.SaveChanges();

            return Json(new { Resultado = telefone.id }, JsonRequestBehavior.AllowGet);
        }
    }
}