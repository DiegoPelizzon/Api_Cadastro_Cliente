using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Dominio.Interface
{
   public interface IRepositorioGenerico<TEntity>:IDisposable where TEntity:class
    {
        public void create(TEntity entidade);
        public List<TEntity> GetAll();
        public TEntity FindById(int id);
        public void Update(TEntity entidade);
        public void Delete(int id);
        public int SalvarNoBanco();
    }
}
