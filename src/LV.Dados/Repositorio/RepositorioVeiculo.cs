using LV.Dominio.Entidades;
using LV.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace LV.Dados.Repositorio
{
    public class RepositorioVeiculo : Repositorio<Veiculo>, IRepositorioVeiculo
    {

        public IEnumerable<Veiculo> ListarPorCategoria(int categoria)
        {
            return Buscar(v => v.Categoria == categoria);
        }

    }
}
