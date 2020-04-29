using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LV.Aplicacao.Interface
{
    public interface IServicoAplicacao<TEntity> where TEntity : class
    {

        void Inserir(TEntity obj);

        void Excluir(int id);

        TEntity Pesquisar(int id);

        IEnumerable<TEntity> Listar();

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> filtro);

        void Dispose();
    }
}
