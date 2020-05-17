using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APBD11.Models
{
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}