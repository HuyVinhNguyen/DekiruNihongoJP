using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace JapaneseWeb.Models
{
    public class Question
    {
        [Key]
        public int Idquestion { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Câu hỏi")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Lựa chọn 1")]
        public string Option1 { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Lựa chọn 2")]
        public string Option2 { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Lựa chọn 3")]
        public string Option3 { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Lựa chọn 4")]
        public string Option4 { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Câu trả lời")]
        public string Answer { get; set; }

        [ForeignKey("test")]
        public int testId { get; set; }
        public Test test { get; set; }
    }
}