using LV.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace LV.Dominio.Interface.Servicos
{
    public interface IServicoVeiculo : IServico<Veiculo>
    {
        
        IEnumerable<Veiculo> ListarPorCategoria(int categoria);

        Veiculo PesquisaMenorValor(bool fidelidade, DateTime dataInicio, DateTime dataFim, string email);
    
    }
}
