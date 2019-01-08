using Projeto_Livraria.Aplicacao.Interfaces.Base;
using Projeto_Livraria.Dominio.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace Projeto_Livraria.Aplicacao.Services.Base
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _servicebase;
        public AppServiceBase(IServiceBase<TEntity> servicebase)
        {
            _servicebase = servicebase;
        }

        public virtual void ADD(TEntity obj)
        {
            _servicebase.ADD(obj);
        }

        public TEntity GetById(Guid id)
        {
            return _servicebase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _servicebase.GetAll();
        }

        public virtual void Update(TEntity obj)
        {
            _servicebase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _servicebase.Remove(obj);
        }

        public void Dispose()
        {
            _servicebase.Dispose();
        }
    }
}
