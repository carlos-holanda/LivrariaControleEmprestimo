using LivrariaControleEmprestimo.DATA.Models;
using LivrariaControleEmprestimo.DATA.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaControleEmprestimo.WEB.Controllers
{
    public class LivroController : Controller
    {

        private LivroService oLivroService = new LivroService();

        // GET: LivroController
        public IActionResult Index()
        {
            List<Livro> oListLivro = oLivroService.oRepositoryLivro.SelecionarTodos();
            return View(oListLivro);
        }

        // GET: LivroController/Details/5
        public IActionResult Details(int id)
        {
            Livro oLivro = oLivroService.oRepositoryLivro.SelecionarPk(id);
            return View(oLivro);
        }

        // GET: LivroController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LivroController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            oLivroService.oRepositoryLivro.Incluir(livro);

            return RedirectToAction("Index");
        }

        // GET: LivroController/Edit/5
        public IActionResult Edit(int id)
        {
            Livro oLivro = oLivroService.oRepositoryLivro.SelecionarPk(id);
            return View(oLivro);
        }

        // POST: LivroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Livro livro)
        {
            Livro oLivro = oLivroService.oRepositoryLivro.Alterar(livro);

            int id = oLivro.Id;

            return RedirectToAction("Details", new { id });
        }

        // GET: LivroController/Delete/5
        public IActionResult Delete(int id)
        {
            oLivroService.oRepositoryLivro.Excluir(id);
            return RedirectToAction("Index");
        }

        //// POST: LivroController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
