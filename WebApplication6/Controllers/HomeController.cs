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
        public IActionResult Acao(Cliente cliente, string submit)
        {
            if (submit == "Enviar")
            {

                var clienteExistente = _contexto.cadastro_clientes.FirstOrDefault(c => c.Cpf == cliente.Cpf);
                if (clienteExistente != null)
                {
                    ViewData["message"] = "CPF já existe na base de dados!";
                    return View("Cadastro", cliente);
                }

                _contexto.cadastro_clientes.Add(cliente);
                _contexto.SaveChanges();
                ViewData["message"] = "Cliente cadastrado com sucesso!";
                return View("Cadastro", cliente);


            }
            else if (submit == "Alterar")
            {
                if (ModelState.IsValid)
                {
                    Cliente clienteParaAtualizar = _contexto.cadastro_clientes.Find(cliente.Id);
                    if (clienteParaAtualizar != null)
                    {
                        clienteParaAtualizar.Nome = cliente.Nome;
                        clienteParaAtualizar.Sobrenome = cliente.Sobrenome;
                        _contexto.cadastro_clientes.Update(clienteParaAtualizar);
                        _contexto.SaveChanges();
                        ViewData["message"] = "Cliente Alterado com sucesso!";
                        return View("Cadastro", cliente);
                    }
                    else
                    {
                        ViewData["message"] = "Registro inexistente!";
                        return View("Cadastro", cliente);
                    }

                }
            }
            else if (submit == "Deletar")
            {
                if (ModelState.IsValid)
                {
                    Cliente clienteParaDeletar = _contexto.cadastro_clientes.Find(cliente.Id);

                    if (clienteParaDeletar != null)
                    {
                        _contexto.cadastro_clientes.Remove(clienteParaDeletar);
                        _contexto.SaveChanges();
                        ViewData["message"] = "Cliente Deletado com sucesso!";
                        return View("Cadastro", cliente);
                    }
                    else
                    {
                        ViewData["message"] = "Registro inexistente!";
                        return View("Cadastro", cliente);
                    }
                }
            }
            ViewData["message"] = "Nenhuma ação registrada";
            return View("Cadastro", cliente);
        }
        [HttpGet]
        public IActionResult Consultar(int idCliente)
        {
            var clienteConsultado = _contexto.cadastro_clientes.FirstOrDefault(c => c.Id == idCliente);
            ViewBag.ClienteConsultado = clienteConsultado;
            return View("Cadastro");
        }
    }
}