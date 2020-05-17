using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APBD11.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}