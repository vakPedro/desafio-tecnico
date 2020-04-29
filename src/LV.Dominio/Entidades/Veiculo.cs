using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Dominio.Entidades
{
    public class Veiculo
    {

        public int Id { get; set; }

        public string Fabricante { get; set; }

        public string Modelo { get; set; }

        public int AnoModelo { get; set; }

        public int Categoria { get; set; }

        public float Valor { get; set; }

        public float ValorFidelidade { get; set; }

        public float ValorFds { get; set; }

        public float ValorFidelidadeFds { get; set; }

    }
}
