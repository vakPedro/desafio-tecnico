using LV.Aplicacao.Interface;
using LV.Dominio.Entidades;
using LV.Dominio.Interface.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Aplicacao.Servico
{
    public class ServicoAplicacaoVeiculo : ServicoAplicacao<Veiculo>, IServicoAplicacaoVeiculo
    {

        private readonly IServicoVeiculo _servicoVeiculo;

        public ServicoAplicacaoVeiculo(IServicoVeiculo servicoVeiculo) :base(servicoVeiculo)
        {
            _servicoVeiculo = servicoVeiculo;
        }


        public IEnumerable<Veiculo> ListarPorCategoria(int categoria)
        {
            return _servicoVeiculo.ListarPorCategoria(categoria);
        }


        public Veiculo PesquisaMenorValor(bool fidelidade, DateTime dataInicio, DateTime dataFim, string email)
        {
            return _servicoVeiculo.PesquisaMenorValor(fidelidade, dataInicio, dataFim, email);
        }

    }
}
