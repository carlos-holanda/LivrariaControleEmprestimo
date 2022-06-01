using LivrariaControleEmprestimo.DATA.Models;
using LivrariaControleEmprestimo.DATA.Services;
using LivrariaControleEmprestimo.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaControleEmprestimo.WEB.Controllers
{
    public class EmprestimosController : Controller
    {
        private EmprestimoService oEmprestimoService = new EmprestimoService();

        public IActionResult Index()
        {
            List<VwLivroClienteEmprestimo> oListEmprestimo = oEmprestimoService.oRepositoryEmprestimo.SelecionarTodos();
            return View(oListEmprestimo);
        }

        public IActionResult Create()
        {
            EmprestimoViewModel oEmprestimoViewModel = new EmprestimoViewModel();
            List<Livro> oListLivro = oEmprestimoService.oRepositoryLivro.SelecionarTodos();
            List<Cliente> oListCliente = oEmprestimoService.oRepositoryCliente.SelecionarTodos();

            oEmprestimoViewModel.oListCliente = oListCliente;
            oEmprestimoViewModel.oListLivro = oListLivro;
            return View(oEmprestimoViewModel);
        }

        [HttpPost]
        public IActionResult Create(VwLivroClienteEmprestimo model) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            oEmprestimoService.oRepositoryEmprestimo.Incluir(model);

            return RedirectToAction("Index");
        }
    }
}
