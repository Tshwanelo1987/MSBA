using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSBA.Model
{
    public class Project
    {
        [Key]
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

    }
}
