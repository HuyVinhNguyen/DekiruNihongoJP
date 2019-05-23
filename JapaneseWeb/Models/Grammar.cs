using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JapaneseWeb.Models
{
    public class Grammar
    {
        [Key]
        public int Idgrammar { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Ngữ pháp")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Công thức")]
        public string Formula { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ví dụ")]
        public string Example { get; set; }

        [ForeignKey("level")]
        public int levelId { get; set; }
        public Level level { get; set; }

        public ICollection<Detailgrammar> detailgrammars { get; set; }
    }
}