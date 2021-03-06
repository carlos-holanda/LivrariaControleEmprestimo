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
            oEmprestimoViewModel.dataEmprestimo = DateTime.Now;
            oEmprestimoViewModel.dataEntrega = DateTime.Now.AddDays(7);
            return View(oEmprestimoViewModel);
        }

        [HttpPost]
        public IActionResult Create(EmprestimoViewModel oEmprestimoViewModel) 
        {
            LivroClienteEmprestimo oLivroClienteEmprestimo = new LivroClienteEmprestimo();
            oLivroClienteEmprestimo.LcedataEmprestimo = oEmprestimoViewModel.dataEmprestimo;
            oLivroClienteEmprestimo.LcedataEntrega = oEmprestimoViewModel.dataEntrega;
            oLivroClienteEmprestimo.LceEntregue = false;
            oLivroClienteEmprestimo.LceIdCliente = oEmprestimoViewModel.idCliente;
            oLivroClienteEmprestimo.LceIdLivro = oEmprestimoViewModel.idLivro;

            if (!ModelState.IsValid)
            {
                return View();
            }

            oEmprestimoService.oRepositoryLivroClienteEmprestimo.Incluir(oLivroClienteEmprestimo);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            oEmprestimoService.oRepositoryLivroClienteEmprestimo.Excluir(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) 
        {
            EmprestimoViewModel oEmprestimoViewModel = new EmprestimoViewModel();
            oEmprestimoViewModel.oListCliente = oEmprestimoService.oRepositoryCliente.SelecionarTodos();
            oEmprestimoViewModel.oListLivro = oEmprestimoService.oRepositoryLivro.SelecionarTodos();
            LivroClienteEmprestimo oLivroClienteEmprestimo = oEmprestimoService.oRepositoryLivroClienteEmprestimo.SelecionarPk(id);
           
            oEmprestimoViewModel.oLivroClienteEmprestimo = oLivroClienteEmprestimo;
            return View(oEmprestimoViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmprestimoViewModel oEmprestimoViewModel)
        {
            if (!ModelState.IsValid)
            {
                oEmprestimoViewModel.oListCliente = oEmprestimoService.oRepositoryCliente.SelecionarTodos();
                oEmprestimoViewModel.oListLivro = oEmprestimoService.oRepositoryLivro.SelecionarTodos();
                return View();
            }

            oEmprestimoService.oRepositoryLivroClienteEmprestimo.Alterar(oEmprestimoViewModel.oLivroClienteEmprestimo);

            return RedirectToAction("Index");
        }

    }
}
