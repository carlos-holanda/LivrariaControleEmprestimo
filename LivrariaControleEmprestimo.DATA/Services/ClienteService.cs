using LivrariaControleEmprestimo.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaControleEmprestimo.DATA.Services
{
    public class ClienteService
    {
        public RepositoryCliente oRepositoryCliente { get; set; }

        public ClienteService()
        {
            oRepositoryCliente = new RepositoryCliente();
        }
    }
}
