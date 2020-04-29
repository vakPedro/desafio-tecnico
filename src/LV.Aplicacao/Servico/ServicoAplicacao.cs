using LV.Dominio.Interface.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LV.Aplicacao.Servico
{
    public abstract class ServicoAplicacao<TEntity> : IServico<TEntity> where TEntity : class
    {

        private readonly IServico<TEntity> _servico;

        protected ServicoAplicacao(IServico<TEntity> servico)
        {
            _servico = servico;
        }


        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> filtro)
        {
            return _servico.Buscar(filtro);
        }

        public void Dispose()
        {
            _servico.Dispose();
        }

        public void Excluir(int id)
        {
            _servico.Excluir(id);
        }

        public void Inserir(TEntity obj)
        {
            _servico.Inserir(obj);
        }

        public IEnumerable<TEntity> Listar()
        {
            return _servico.Listar();
        }

        public TEntity Pesquisar(int id)
        {
            return _servico.Pesquisar(id);
        }

    }
}
