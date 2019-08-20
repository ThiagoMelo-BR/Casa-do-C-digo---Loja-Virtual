using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

using CasaDoCodigo.Repositories;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void IniciarDB()
        {
            //Verifica se o banco está criado, se não estiver cria a estrutura. 
            contexto.Database.EnsureCreated();   
                        
            List<Livro> livros = GetProdutos();

            if (livros.Count == 0)
            {
                produtoRepository.SaveProdutos(livros);
            }                           

        }

        private static List<Livro> GetProdutos()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }

    }
}
