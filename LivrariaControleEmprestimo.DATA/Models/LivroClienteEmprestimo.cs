﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LivrariaControleEmprestimo.DATA.Models
{
    [Table("Livro_Cliente_Emprestimo")]
    public partial class LivroClienteEmprestimo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int LceIdLivro { get; set; }
        public int LceIdCliente { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LcedataEmprestimo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LcedataEntrega { get; set; }
        public bool LceEntregue { get; set; }

        [ForeignKey(nameof(LceIdCliente))]
        [InverseProperty(nameof(Livro.LivroClienteEmprestimo))]
        public virtual Livro LceIdClienteNavigation { get; set; }
        [ForeignKey(nameof(LceIdLivro))]
        [InverseProperty(nameof(Cliente.LivroClienteEmprestimo))]
        public virtual Cliente LceIdLivroNavigation { get; set; }
    }
}