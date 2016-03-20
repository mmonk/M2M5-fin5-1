using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M2M5_fin5_1.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }

        public string AssignmentName { get; set; }
    }
}