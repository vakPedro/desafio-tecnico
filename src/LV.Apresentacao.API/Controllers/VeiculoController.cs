using LV.Aplicacao.Interface;
using LV.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LV.Apresentacao.API.Controllers
{
    public class VeiculoController : ApiController
    {

        private readonly IServicoAplicacaoVeiculo _servicoAplicacaoVeiculo;

        public VeiculoController(IServicoAplicacaoVeiculo servicoAplicacaoVeiculo)
        {
            _servicoAplicacaoVeiculo = servicoAplicacaoVeiculo;
        }


        /// <summary>
        /// Retorna a lista de veículos cadastrados
        /// </summary>
        /// <returns></returns>
        // GET: api/Veiculo
        public IEnumerable<Veiculo> Get()
        {
            try
            {
                return _servicoAplicacaoVeiculo.Listar();
            }
            catch (Exception)
            {
                var retorno = new HttpResponseMessage(HttpStatusCode.BadRequest);
                retorno.Content = new StringContent("Não foi possível realizar a consulta! Tente novamente mais tarde.");
                throw new System.Web.Http.HttpResponseException(retorno);
            }
        }

        /// <summary>
        /// Retorna informações do veículo pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        public Veiculo Get(int id)
        {
            try
            {
               return  _servicoAplicacaoVeiculo.Pesquisar(id);
            }
            catch (Exception)
            {
                var retorno = new HttpResponseMessage(HttpStatusCode.BadRequest);
                retorno.Content = new StringContent("Não foi possível realizar a consulta! Tente novamente mais tarde.");
                throw new System.Web.Http.HttpResponseException(retorno);
            }
        }

        /// <summary>
        /// Retorna a lista de veículos cadastrados por categoria (código da categoria)
        /// 1 - Compact Hatch
        /// 2 - Medium Hatc
        /// 3 - Sedan
        /// 4 - Van
        /// 5 - Pickup
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [Route("api/Veiculo/GetCategoria/{categoria}")]
        public IEnumerable<Veiculo> GetCategoria(int categoria)
        {
            try
            {
                return _servicoAplicacaoVeiculo.ListarPorCategoria(categoria);
            }
            catch (Exception)
            {
                var retorno = new HttpResponseMessage(HttpStatusCode.BadRequest);
                retorno.Content = new StringContent("Não foi possível realizar a consulta! Tente novamente mais tarde.");
                throw new System.Web.Http.HttpResponseException(retorno);
            }
        }

        /// <summary>
        /// Retorna o veículo com o aluguel mais barato informando o objeto tipo "Aluguel"
        ///  Obrigatório informar o período: "DataInicio" e "DataFim"
        /// </summary>
        /// <param name="aluguel"></param>
        /// <returns></returns>
        [Route("api/Veiculo/PostPesquisa")]
        public Veiculo PostPesquisa(Aluguel aluguel)
        {
            try
            {
                return _servicoAplicacaoVeiculo.PesquisaMenorValor(aluguel.Fidelidade, aluguel.DataInicio, aluguel.DataFim, aluguel.Email);
            }
            catch (Exception)
            {
                var retorno = new HttpResponseMessage(HttpStatusCode.BadRequest);
                retorno.Content = new StringContent("Não foi possível realizar a consulta! Tente novamente mais tarde.");
                throw new System.Web.Http.HttpResponseException(retorno);
            }
        }

        /// <summary>
        /// Insere o registro de um novo veículo
        /// </summary>
        /// <param name="veiculo"></param>
        // POST: api/Veiculo
        public void Post(Veiculo veiculo)
        {
            try
            {
                _servicoAplicacaoVeiculo.Inserir(veiculo);
            }
            catch (Exception)
            {
                var retorno = new HttpResponseMessage(HttpStatusCode.BadRequest);
                retorno.Content = new StringContent("Não foi possível realizar inclusão! Tente novamente mais tarde.");
                throw new System.Web.Http.HttpResponseException(retorno);
            }
        }

        /// <summary>
        /// Exclui o registro de um veículo pelo ID
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/Veiculo/5
        public void Delete(int id)
        {
            try
            {
                _servicoAplicacaoVeiculo.Excluir(id);
            }
            catch (Exception)
            {
                var retorno = new HttpResponseMessage(HttpStatusCode.BadRequest);
                retorno.Content = new StringContent("Não foi possível realizar a exclusão! Tente novamente mais tarde.");
                throw new System.Web.Http.HttpResponseException(retorno);
            }
        }
    }
}
