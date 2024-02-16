using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using WebApplication6.Banco;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private readonly BancoContexto _contexto;

        public HomeController(BancoContexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Acao(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.cadastro_clientes.Add(cliente);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Cadastro", cliente);
        }
    }
}
