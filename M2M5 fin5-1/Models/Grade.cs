using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2M5_fin5_1.Models
{
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }

        public int GradeReceived { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int AssignmentID { get; set; }
        public Assignment Assignment { get; set; }

        //public virtual List<Student> Students { get; set; }
        //public virtual List<Assignment> Assignments { get; set; }
    }
}