using System;
using System.Collections.Generic;
using System.Linq;
using APBD11.Models;

namespace APBD11.Services
{
    public class EfDbService :IDbService
    {
        private PrescriptionsDbContext _dbContext;
        
        public EfDbService(PrescriptionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void seedDb()
        {
            //doctors
            _dbContext.Doctor.Add(new Doctor {FirstName = "Marcin", LastName = "Kowalski", Email = "mkowalski@gmail.com"});
            _dbContext.Doctor.Add(new Doctor {FirstName = "Damian", LastName = "Malewski", Email = "dmalewski@gmail.com"});
            _dbContext.Doctor.Add(new Doctor {FirstName = "Jakub", LastName = "Sawczuk", Email = "jsawczuk@gmail.com"});
            //patients
            _dbContext.Patient.Add(new Patient{FirstName = "Maciej",LastName = "Petrykowski",BirthDate = DateTime.Parse("03-07-1999")});
            _dbContext.Patient.Add(new Patient{FirstName = "Daniel",LastName = "Petrykowski",BirthDate = DateTime.Parse("29-02-1996")});
            _dbContext.Patient.Add(new Patient{FirstName = "Barbara",LastName = "Bis",BirthDate = DateTime.Parse("09-02-2000")});
            //prescriptions
            _dbContext.Prescription.Add(new Prescription {Date = DateTime.Today,IdDoctor = 1,IdPatient = 1,DueDate = DateTime.Now});
            //Medicamnts
            _dbContext.Medicament.Add(new Medicament {Name = "dwad", Dose = 2});
            _dbContext.SaveChanges();

        }

        public ICollection<Doctor> getDoctors()
        {
            return _dbContext.Doctor.ToList();
        }

        public Doctor createDoctor(Doctor doctor)
        {
            _dbContext.Doctor.Add(doctor);
            _dbContext.SaveChanges();
            return _dbContext.Doctor.Where(d =>
                    d.FirstName == doctor.FirstName && d.LastName == doctor.LastName && d.Email == doctor.Email)
                .FirstOrDefault();
        }

        public Doctor updateDoctor(Doctor doctor)
        {
          Doctor doctorToUpdate=_dbContext.Doctor.Where(d => d.IdDoctor == doctor.IdDoctor).FirstOrDefault();
          doctorToUpdate.Email = doctor.Email;
          doctorToUpdate.Prescriptions = doctor.Prescriptions;
          doctorToUpdate.FirstName = doctor.FirstName;
          doctorToUpdate.LastName = doctor.LastName;
          _dbContext.SaveChanges();
          Doctor newDoctor = _dbContext.Doctor.Where(d => d.IdDoctor == doctor.IdDoctor).FirstOrDefault();
          return doctor;
        }

        public Doctor deleateDoctor(int id)
        {
            Doctor doctor= _dbContext.Doctor.Where(d => d.IdDoctor == id).FirstOrDefault();
            _dbContext.Doctor.Remove(doctor);
            _dbContext.SaveChanges();
            return doctor;
        }
    }
}