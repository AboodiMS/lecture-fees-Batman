using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Database.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ScientificRankCode { get; set; }   
        public ScientificRank ScientificRank { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<TheForm> TheForms { get; set; }
    }
}