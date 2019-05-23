using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseWeb.Models
{
    public class Vocabulary
    {
        [Key, Column(Order = 0)]
        public int levelId { get; set; }

        [Key, Column(Order = 1)]
        public int topicId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Hán tự")]
        public string Kanji { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Hiragana")]
        public string Hiragana { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Katakana")]
        public string Katakana { get; set; }

        [Required]
        [StringLength(70)]
        [DisplayName("Nghĩa")]
        public string Meaning { get; set; }

        public virtual Level Level { get; set; }
        public virtual Topicvocabulary Topicvocabulary { get; set; }

        public ICollection<Detailvocabulary> detailvocabularies { get; set; }
    }
}