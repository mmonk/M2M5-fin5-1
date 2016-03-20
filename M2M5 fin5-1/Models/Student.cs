using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2M5_fin5_1.Models
{
    public class Student
    {

        [Key]
        public int StudentID { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public virtual List<Course> Course { get; set; }
    }
}