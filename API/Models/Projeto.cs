using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Projeto
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [DataType(DataType.MultilineText)]
        public string Responsaveis { get; set; }
        
       public IList<Problema> Problemas { get; set; }
    }
}
