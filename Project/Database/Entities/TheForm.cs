using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Database.Entities
{
    public class TheForm
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int ScientificRankCode { get; set; }
        public ScientificRank ScientificRank { get; set; }
        public int SubjectCode { get; set; }
        public Subject Subject { get; set; }
        public DateTimeOffset FormDate { get; set; }
    }
}