using Cliente.Dominio.Interface;
using Cliente.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Infra.Repositorio
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {

        protected readonly BancoContext _banco;
        protected readonly DbSet<TEntity> _DbSet;

        public  RepositorioGenerico(BancoContext bancocontext)
        {
            _banco = bancocontext;
            _DbSet = _banco.Set<TEntity>();
        }

        public void create(TEntity entidade)
        {
            _DbSet.Add(entidade);
        }

        public List<TEntity> GetAll()
        {
            return _DbSet.ToList();
        }

        public TEntity FindById(int id)
        {
            return _DbSet.Find(id);
        }

        public void Update(TEntity entidade)
        {
            _DbSet.Update(entidade);
        }

        public void Delete(int id)
        {
            _DbSet.Remove(_DbSet.Find(id));
        }

        public int SalvarNoBanco()
        {
            return _banco.SaveChanges();

        }


        public void Dispose()
        {
            _banco.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
