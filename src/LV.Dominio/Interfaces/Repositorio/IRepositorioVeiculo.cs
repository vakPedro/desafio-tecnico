using LV.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioVeiculo : IRepositorio<Veiculo>
    {

        IEnumerable<Veiculo> ListarPorCategoria(int categoria);

    }
}
