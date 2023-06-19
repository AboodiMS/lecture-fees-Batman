using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Database.Entities
{
    public class ScientificRank
    {
        [Key]
        public int Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<Professor> Professors { get; set; }
        public List<TheForm> TheForms { get; set; }
    }
}