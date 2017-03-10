using System;
using System.Collections.Generic;

namespace aspnetcore_lab2.infra.data.Models
{
    public class Student
    {
        public Student(){
            this.CreateDate = DateTime.Now;
        }

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public DateTime CreateDate { get; private set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
