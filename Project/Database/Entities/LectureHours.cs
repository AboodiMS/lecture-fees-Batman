using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Database.Entities
{
    public class LectureHours
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal NumberOfHours { get; set; }
        public List<TheForm> TheForms { get; set; }
    }
}