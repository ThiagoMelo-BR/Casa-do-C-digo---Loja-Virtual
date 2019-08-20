using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        IList<Produto> GetProdutos();
        void SaveProdutos(IList<Livro> livros);
    }

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public void SaveProdutos(IList<Livro> livros)
        {
            foreach (var produto in livros)
            {
                dbSet.Add(new Produto(produto.Codigo, produto.Nome, produto.Preco));
            }
            contexto.SaveChanges();
        }

        public void DeletarProduto(Produto p)
        {
            dbSet.Remove(p);
            contexto.SaveChanges();
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }
    }
    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}


