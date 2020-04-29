using LV.Dados.Contexto;
using LV.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LV.Dados.Repositorio
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {

        protected LocadoraVeiculoContexto contexto = new LocadoraVeiculoContexto();


        public void Inserir(TEntity obj)
        {
            contexto.Set<TEntity>().Add(obj);
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var obj = Pesquisar(id);
            contexto.Set<TEntity>().Remove(obj);
            contexto.SaveChanges();
        }

        public TEntity Pesquisar(int id)
        {
            return contexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Listar()
        {
            return contexto.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> filtro)
        {
            return contexto.Set<TEntity>().Where(filtro);
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
        
    }
}
