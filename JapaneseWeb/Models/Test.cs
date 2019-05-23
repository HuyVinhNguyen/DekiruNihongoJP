using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JapaneseWeb.Models
{
    public class Test
    {
        [Key]
        public int Idtest { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Bài kiểm tra")]
        public string Name { get; set; }
        
        [StringLength(500)]
        [DisplayName("Chi tiết")]
        public string Detail { get; set; }
        
        [ForeignKey("level")]
        public int levelId { get; set; }
        public Level level { get; set; }
        
        public ICollection<Question> questions { get; set; }
    }
}