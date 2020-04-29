using LV.Dominio.Entidades;
using LV.Dominio.Interface.Servicos;
using LV.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LV.Dominio.Servicos
{
    public class ServicoVeiculo : Servico<Veiculo>, IServicoVeiculo
    {
        private readonly IRepositorioVeiculo _repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo) : base(repositorioVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
        }

        public IEnumerable<Veiculo> ListarPorCategoria(int categoria)
        {
            return Buscar(v => v.Categoria == categoria);
        }

        public Veiculo PesquisaMenorValor(bool fidelidade, DateTime dataInicio, DateTime dataFim, string email)
        {
            List<Veiculo> lista;
            string tituloEmail, mensagemEmail;
            lista = ListarVeiculosMenorValor(fidelidade, dataInicio, dataFim);
            if (lista.Count > 0 && !string.IsNullOrEmpty(email)){
                tituloEmail = "Valores da locação";
                mensagemEmail = "No período de " + dataInicio.ToString("dd/MM/yyyy") + " à " + dataFim.ToString("dd/MM/yyyy") +
                                "o veículo de menor valor é " + lista[0].Fabricante + " - " + lista[0].Modelo + " (" + lista[0].AnoModelo + ") da categoria " + lista[0].Categoria;
                Util.EnvioEmail.enviarEmail(tituloEmail, mensagemEmail, email);
            }
            return lista.FirstOrDefault();
        }

        private List<Veiculo> ListarVeiculosMenorValor(bool fidelidade, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                List<Veiculo> lista;
                int qtdDiasFds = 0, qtdDias = (int)dataFim.Subtract(dataInicio).TotalDays; ;
                DateTime data = dataInicio;
                float menorValor;

                while (data != dataFim)
                {
                    if ((data.DayOfWeek == DayOfWeek.Sunday) || (data.DayOfWeek == DayOfWeek.Saturday))
                    {
                        qtdDiasFds += 1;
                    }
                    data.AddDays(1);
                }

                if ((qtdDias - qtdDiasFds > qtdDiasFds) ||
                    (qtdDias == 1 && dataInicio.DayOfWeek != DayOfWeek.Sunday && dataInicio.DayOfWeek != DayOfWeek.Saturday))
                {
                    lista = _repositorioVeiculo.Listar().OrderBy(l => (fidelidade ? l.ValorFidelidade : l.Valor)).ToList();
                    menorValor = (fidelidade ? lista[0].ValorFidelidade : lista[0].Valor);
                    lista = lista.Where(l => l.Valor == menorValor).ToList();
                }
                else
                {
                    lista = _repositorioVeiculo.Listar().OrderBy(l => (fidelidade ? l.ValorFidelidadeFds : l.ValorFds)).ToList();
                    menorValor = (fidelidade ? lista[0].ValorFidelidadeFds : lista[0].ValorFds);
                    lista = lista.Where(l => (fidelidade ? l.ValorFidelidadeFds : l.ValorFds) == menorValor).ToList();
                }

                lista = lista.OrderByDescending(l => l.Categoria).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
