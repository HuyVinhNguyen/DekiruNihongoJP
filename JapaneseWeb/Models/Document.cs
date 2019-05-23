using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JapaneseWeb.Models
{
    public class Document
    {
        [Key]
        public int Iddocument { get; set; }

       
        [DisplayName("Tài liệu")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Ngày tháng")]
        public DateTime Date { get; set; }

        public ICollection<Detailgrammar> detailgrammars { get; set; }
        public ICollection<Detailvocabulary> detailvocabularies { get; set; }
    }
}