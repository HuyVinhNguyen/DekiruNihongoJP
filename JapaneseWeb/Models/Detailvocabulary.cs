using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseWeb.Models
{
    public class Detailvocabulary
    {
        [Key, Column(Order = 0)]
        public int GrammarId { get; set; }

        [Key, Column(Order = 1)]
        public int DocumentId { get; set; }

        [DisplayName("Miêu tả")]
        public string Description { get; set; }

        public virtual Vocabulary Vocabulary { get; set; }
        public virtual Document Document { get; set; }
    }
}