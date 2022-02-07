using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quads.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public bool IsUrgent { get; set; }
        [Required]
        public bool IsImportant { get; set; }
        public bool IsCompleted { get; set; }

        //Build foreign Key Relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }

}

