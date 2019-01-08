using System;
using System.Collections.Generic;

namespace Projeto_Livraria.Aplicacao.Interfaces.Base
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void ADD(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
