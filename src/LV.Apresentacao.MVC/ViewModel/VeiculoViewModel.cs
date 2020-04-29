using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LV.Apresentacao.MVC.Models
{
    public class VeiculoViewModel
    {

        [Key]
        public int Id { get; set; }

        [DisplayName("Fabricante")]
        [Required(ErrorMessage = "Fabricante deve ser informado!")]
        [MinLength(3, ErrorMessage = "Descrição deve ter no mínimo {0} dígitos.")]
        [MaxLength(50, ErrorMessage = "Descrição deve ter no máximo {0} dígitos.")]
        public string Fabricante { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "Modelo deve ser informado!")]
        [MinLength(3, ErrorMessage = "Descrição deve ter no mínimo {0} dígitos.")]
        [MaxLength(50, ErrorMessage = "Descrição deve ter no máximo {0} dígitos.")]
        public string Modelo { get; set; }

        [DisplayName("Ano do modelo")]
        [Required(ErrorMessage = "Ano do modelo deve ser informado!")]
        public int AnoModelo { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Categoria deve ser informado!")]
        [Range(typeof(int), "1", "5")]
        public int Categoria { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "Valor de ser informado")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999,99")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float Valor { get; set; }

        [DisplayName("Valor (fidelidade)")]
        [Required(ErrorMessage = "Valor para plano fidelidade deve ser informado")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999,99")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float ValorFidelidade { get; set; }

        [DisplayName("Valor (FDS)")]
        [Required(ErrorMessage = "Valor para finais de semana")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999,99")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float ValorFds { get; set; }

        [DisplayName("Valor (fidelidade - FDS)")]
        [Required(ErrorMessage = "Valor para plano fidelidade durante finais de semana deve ser informado")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999,99")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float ValorFidelidadeFds { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Fidelidade")]
        public bool Fidelidade { get; set; }

        [DisplayName("Data inicial")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [DisplayName("Fabricante")]
        public List<Fabricante> Fabricantes { get; set; }

        public List<Modelo> Modelos { get; set; }

    }
}