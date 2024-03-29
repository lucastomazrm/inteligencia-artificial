﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Problema
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        public IList<ProblemaVariavel> ProblemasVariaveis { get; set; }
     
        public long ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
