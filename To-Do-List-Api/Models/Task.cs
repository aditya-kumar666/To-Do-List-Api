using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_Do_List_Api.Models
{
    [Table("Task")]
    public class Task
    {
        [Key]
        [Required]
        public int id { get; set; }
        [StringLength(50)]
        public String Title { get; set; }
        [StringLength(100)]
        public String Description { get; set; }
        public bool Complete { get; set; }
    }
}
