using LV.Dominio.Interface.Servicos;
using LV.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LV.Dominio.Servicos
{
    public abstract class Servico<TEntity> : IServico<TEntity> where TEntity : class
    {

        private readonly IRepositorio<TEntity> _repositorio;

        protected Servico(IRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }


        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> filtro)
        {
            return _repositorio.Buscar(filtro);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public void Excluir(int id)
        {
            _repositorio.Excluir(id);
        }

        public void Inserir(TEntity obj)
        {
            _repositorio.Inserir(obj);
        }

        public IEnumerable<TEntity> Listar()
        {
            return _repositorio.Listar();
        }

        public TEntity Pesquisar(int id)
        {
            return _repositorio.Pesquisar(id);
        }
    }
}
