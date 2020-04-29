using LV.Aplicacao.Interface;
using LV.Aplicacao.Servico;
using LV.Dados.Repositorio;
using LV.Dominio.Interface.Servicos;
using LV.Dominio.Interfaces.Repositorio;
using LV.Dominio.Servicos;
using Newtonsoft.Json;
using SimpleInjector;
using System.Web.Http;

namespace LV.Apresentacao.API.App_Start
{
    public class DependenciasAplicacao
    {

        protected readonly global::SimpleInjector.Container _container;

        public DependenciasAplicacao(Container container)
        {
            _container = container;
        }

        public Container Resolver()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Include;

            _container.Register<IServicoAplicacaoVeiculo, ServicoAplicacaoVeiculo>();
            _container.Register<IServicoVeiculo, ServicoVeiculo>();
            _container.Register<IRepositorioVeiculo, RepositorioVeiculo>();

            _container.Verify();
            return _container;
        }

    }
}