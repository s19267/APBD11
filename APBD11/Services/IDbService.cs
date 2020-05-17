using System.Collections.Generic;
using APBD11.Models;

namespace APBD11.Services
{
    public interface IDbService
    {
        public void seedDb();
        public ICollection<Doctor> getDoctors();
        public Doctor createDoctor(Doctor doctor);
        public Doctor updateDoctor(Doctor doctor);
        public Doctor deleateDoctor(int id);
    }
}