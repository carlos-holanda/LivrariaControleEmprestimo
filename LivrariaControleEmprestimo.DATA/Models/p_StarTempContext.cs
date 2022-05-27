﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LivrariaControleEmprestimo.DATA.Models
{
    public partial class p_StarTempContext : DbContext
    {
        public p_StarTempContext()
        {
        }

        public p_StarTempContext(DbContextOptions<p_StarTempContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MNSNT051;Initial Catalog=p_StarTemp;Persist Security Info=True;User ID=ffStarTemp;Password=S!@r.123UQ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.CliBairro).IsUnicode(false);

                entity.Property(e => e.CliCidade).IsUnicode(false);

                entity.Property(e => e.CliCpf).IsUnicode(false);

                entity.Property(e => e.CliEndereco).IsUnicode(false);

                entity.Property(e => e.CliNome).IsUnicode(false);

                entity.Property(e => e.CliNumero).IsUnicode(false);

                entity.Property(e => e.CliTelefoneCelular).IsUnicode(false);

                entity.Property(e => e.CliTelefoneFixo).IsUnicode(false);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.Property(e => e.LivroAutor).IsUnicode(false);

                entity.Property(e => e.LivroEdicao).IsUnicode(false);

                entity.Property(e => e.LivroEditora).IsUnicode(false);

                entity.Property(e => e.LivroNome).IsUnicode(false);
            });

            modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
            {
                entity.HasOne(d => d.LceIdClienteNavigation)
                    .WithMany(p => p.LivroClienteEmprestimo)
                    .HasForeignKey(d => d.LceIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Cliente_Emprestimo_Livro1");

                entity.HasOne(d => d.LceIdLivroNavigation)
                    .WithMany(p => p.LivroClienteEmprestimo)
                    .HasForeignKey(d => d.LceIdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Cliente_Emprestimo_Cliente1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}