using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Cadastro Update(int cadastroId, Cadastro novoCadastro);
        IList<Cadastro> Listar();
        Cadastro GetCadastro(int CadastroId);
    }
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Cadastro GetCadastro(int CadastroId)
        {
            return dbSet
                .Where(c => c.Id == CadastroId)
                .FirstOrDefault();
        }

        public IList<Cadastro> Listar()
        {
            return dbSet.Where(c => !String.IsNullOrEmpty(c.Nome)).ToList();
        }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB = new Cadastro();

            if(cadastroId > 0){
                cadastroDB = dbSet.Where(c => c.Id == cadastroId).FirstOrDefault();
            }
            else
            {
                cadastroDB = novoCadastro;
            }
            
            if(cadastroDB == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDB.Update(novoCadastro);
            contexto.SaveChanges();
            return cadastroDB;
        }
    }
}
