using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.CourseEnrollments = new HashSet<StudentCourse>() ;
            this.HomeworkSubmissons = new HashSet<Homework>() ;
        }
        [Key]
        public int StudentId { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        [Column(TypeName ="char(10)")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }

        public virtual ICollection<Homework> HomeworkSubmissons { get; set; }
    }
}
