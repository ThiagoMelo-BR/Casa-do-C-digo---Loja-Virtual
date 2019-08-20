using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(p => p.Id);

            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Itens).WithOne(p => p.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cadastro).WithOne(p => p.Pedido).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(i => i.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(i => i.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(i => i.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(c => c.Id);
            modelBuilder.Entity<Cadastro>().HasOne(c => c.Pedido);

        }

    }
}
