using System;
using System.Collections.Generic;
using System.Text;
using LivrariaControleEmprestimo.DATA.Repositories;

namespace LivrariaControleEmprestimo.DATA.Services
{
    public class EmprestimoService
    {
        public RepositoryVwLivroClienteEmprestimo oRepositoryEmprestimo { get; set; }

        public EmprestimoService()
        {
            oRepositoryEmprestimo = new RepositoryVwLivroClienteEmprestimo();
        }
    }
}
