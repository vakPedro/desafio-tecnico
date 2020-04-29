using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Dominio.Entidades
{
    public class Aluguel
    {

        public string Email { get; set; }
        
        public bool Fidelidade { get; set; }
        
        public DateTime DataInicio { get; set; }
        
        public DateTime DataFim { get; set; }

    }
}
