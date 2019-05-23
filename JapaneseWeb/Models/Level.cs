using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseWeb.Models
{
    public class Level
    {
        [Key]

        [DisplayName("Cấp độ")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Idlevel { get; set; }

        public ICollection<Test> tests { get; set; }
        public ICollection<Vocabulary> vocabularies { get; set; }
    }
}