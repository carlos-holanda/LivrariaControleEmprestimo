using System;
using System.Collections.Generic;
using System.Text;
using LivrariaControleEmprestimo.DATA.Repositories;

namespace LivrariaControleEmprestimo.DATA.Services
{
    public class EmprestimoService
    {
        public RepositoryVwLivroClienteEmprestimo oRepositoryEmprestimo { get; set; }

        public RepositoryLivro oRepositoryLivro { get; set; }

        public RepositoryCliente oRepositoryCliente { get; set; }

        public RepositoryLivroClienteEmprestimo oRepositoryLivroClienteEmprestimo { get; set; } 

        public EmprestimoService()
        {
            oRepositoryEmprestimo = new RepositoryVwLivroClienteEmprestimo();
            oRepositoryCliente = new RepositoryCliente();
            oRepositoryLivro = new RepositoryLivro();
            oRepositoryLivroClienteEmprestimo = new RepositoryLivroClienteEmprestimo();
        }
    }
}
