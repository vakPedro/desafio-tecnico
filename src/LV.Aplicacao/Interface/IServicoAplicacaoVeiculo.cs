using LV.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace LV.Aplicacao.Interface
{
    public interface IServicoAplicacaoVeiculo : IServicoAplicacao<Veiculo>
    {

        IEnumerable<Veiculo> ListarPorCategoria(int categoria);

        Veiculo PesquisaMenorValor(bool fidelidade, DateTime dataInicio, DateTime dataFim, string email);

    }
}
