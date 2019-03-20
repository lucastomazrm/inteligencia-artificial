using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Variavel
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        public long ProblemaId { get; set; }
        public Problema Problema { get; set; }
    }
}
