using LivrariaControleEmprestimo.DATA.Models;
using LivrariaControleEmprestimo.DATA.Services;
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
            return View();
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
