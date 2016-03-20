using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2M5_fin5_1.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}