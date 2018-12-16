using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace TelefonesAgenda.Models
{
    public class ContatosMap : ClassMap<Contatos>
    {
        public ContatosMap()
        {
            Id(x => x.id);
            Map(x => x.Nome);
            Map(x => x.Telefone);
            Map(x => x.Email);
            Map(x => x.Empresa);
            Map(x => x.Endereco);
            Map(x => x.Classificacao);
            Table("tbl_contatos");
        }
    }
}