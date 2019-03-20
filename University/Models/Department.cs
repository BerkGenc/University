using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class Department
    {
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        public virtual IList<Student> Students { get; set; }
    }
}
