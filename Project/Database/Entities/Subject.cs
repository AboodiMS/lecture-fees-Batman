using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Database.Entities
{
    public class Subject
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public Professor Professor { get; set;}
        public int ProfessorId { get; set; }
        public List<TheForm> TheForms { get; set; }
    }
}