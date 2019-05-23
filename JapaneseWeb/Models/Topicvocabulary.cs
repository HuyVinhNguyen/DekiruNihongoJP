using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseWeb.Models
{
    public class Topicvocabulary
    {
        [Key]
        public int Idtopic { get; set; }

        [Required]
        [DisplayName("Chủ đề từ vựng")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Miêu tả")]
        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<Vocabulary> vocabularies { get; set; }
    }
}