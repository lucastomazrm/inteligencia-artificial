using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProblemaVariavel
    {
        public ProblemaVariavel(long problemaId, long variavelId)
        {
            ProblemaId = problemaId;
            VariavelId = variavelId;
        }

        [Key]
        public long Id { get; set; }

        public long ProblemaId { get; set; }
        public Problema Problema { get; set; }

        public long VariavelId { get; set; }
        public Variavel Varivavel { get; set; }
    }
}
