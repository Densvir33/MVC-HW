using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using University_Manager_v2.Models.Entity.Models;

namespace University_Manager_v2.Models
{
    public class GroupViewModels
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}