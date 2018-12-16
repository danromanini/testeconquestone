using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TelefonesAgenda.Models;

namespace TelefonesAgenda.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            using (ISession session = DBHelper.AbrirConexao())
            {
                var contatos = session.Query<Contatos>().OrderBy(p => p.Nome).ToList();
                return View(contatos);
            }
        }


        public ActionResult Pesquisar(string selecionado, string pesquisa)
        {
            using (ISession session = DBHelper.AbrirConexao())
            {
                List<Contatos> resultado = new List<Contatos>();

                if (pesquisa.Equals("") || selecionado == null || pesquisa == null)
                {
                    resultado = session.Query<Contatos>().OrderBy(p => p.Nome).ToList();
                }
                else {
                    if (selecionado == "Nome")
                    {
                        resultado = session.Query<Contatos>().Where(x => x.Nome.Contains(pesquisa)).OrderBy(p => p.Nome).ToList();
                    }
                    else if (selecionado == "Telefone")
                    {
                        resultado = session.Query<Contatos>().Where(x => x.Telefone == pesquisa).OrderBy(p => p.Nome).ToList();
                    }
                    else if (selecionado == "Email")
                    {
                        resultado = session.Query<Contatos>().Where(x => x.Email == pesquisa).OrderBy(p => p.Nome).ToList();
                    }
                }

                var contatos = resultado;

                return View(contatos);
            }
        }
        

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = DBHelper.AbrirConexao())
            {
                var contatos = session.Get<Contatos>(id);
                return View(contatos);
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contatos Contato)
        {
            try
            {
                using (ISession session = DBHelper.AbrirConexao())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(Contato);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            using (ISession session = DBHelper.AbrirConexao())
            {
                var contato = session.Get<Contatos>(id);
                return View(contato);
            }
        }

        
        [HttpPost]
        public ActionResult Edit(int id, Contatos Contato)
        {
            try
            {
                using (ISession session = DBHelper.AbrirConexao())
                {
                    var ContatoNovosDados = session.Get<Contatos>(id);
                    ContatoNovosDados.Nome = Contato.Nome;
                    ContatoNovosDados.Telefone = Contato.Telefone;
                    ContatoNovosDados.Email = Contato.Email;
                    ContatoNovosDados.Empresa = Contato.Empresa;
                    ContatoNovosDados.Endereco = Contato.Endereco;
                    ContatoNovosDados.Classificacao = Contato.Classificacao;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(ContatoNovosDados);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            using (ISession session = DBHelper.AbrirConexao())
            {
                var contato = session.Get<Contatos>(id);
                return View(contato);
            }
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Contatos Contato)
        {
            try
            {
                using (ISession session = DBHelper.AbrirConexao())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Contato);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
