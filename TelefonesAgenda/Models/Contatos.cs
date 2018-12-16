using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonesAgenda.Models
{
    public class Contatos
    {
        [Key]
        public virtual int id { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório", AllowEmptyStrings = false)]
        public virtual string Nome { get; set; }

        [Required(ErrorMessage = "Telefone Obrigatório", AllowEmptyStrings = false)]
        public virtual string Telefone { get; set; }

        public virtual string Email { get; set; }

        public virtual string Empresa { get; set; }

        [Display(Name = "Endereço")]
        public virtual string Endereco { get; set; }

        [Display(Name = "Classificação")]
        [Required(ErrorMessage = "Classificação Obrigatório")]
        public virtual string Classificacao { get; set; }
   
    }

}