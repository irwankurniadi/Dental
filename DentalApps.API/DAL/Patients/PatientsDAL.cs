using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalApps.API.DAL.Interface;
using DentalApps.API.Data;
using DentalApps.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalApps.API.DAL.Patients
{
    public class PatientsDAL : IPatients
    {
        private readonly ApplicationDbContext _db;
        public PatientsDAL(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Patient> Create(Patient objEntity)
        {
            try
            {
                //jika masih belum ada patient dengan tenant ini
                var mrnumber = await GetLastMedicalRecordNumber(objEntity.TenantID);

                var tenant = await (from t in _db.Tenants 
                        where t.TenantID==objEntity.TenantID 
                        select t).FirstOrDefaultAsync();
                if(tenant==null) throw new Exception($"tenant tidak ditemukan");

                string strNumber = string.Empty;
                if(mrnumber==-1)
                {
                    strNumber = $"{tenant.PrefixMR}0000000001";
                }
                else
                {
                    mrnumber++;
                    strNumber = tenant.PrefixMR + mrnumber.ToString().PadLeft(10,'0');
                }
                
                objEntity.MedicalRecordNumber = strNumber;
                await _db.Patients.AddAsync(objEntity);
                await _db.SaveChangesAsync();

                return objEntity;
            }
            catch(DbUpdateException dbEx)
            {
                throw new Exception($"{dbEx.InnerException.Message}");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var delPatient = await GetById(id);
                _db.Patients.Remove(delPatient);
                await _db.SaveChangesAsync();
            }
            catch(DbUpdateException dbEx)
            {
                throw new Exception(dbEx.InnerException.Message);
            }
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            var patients = await (from p in _db.Patients
                                  orderby p.MedicalRecordNumber ascending 
                                  select p).AsNoTracking().ToListAsync(); 
            return patients;
        }

        public async Task<Patient> GetById(string id)
        {
            var patient = await (from p in _db.Patients
                                 where p.PatientID==id
                                 select p).FirstOrDefaultAsync();

            if(patient==null) throw new ArgumentNullException($"patient id: {id} tidak ditemukan");
            return patient;
        }

        public async Task<int> GetLastMedicalRecordNumber(string tenantId)
        {
            var patient = await (from p in _db.Patients 
                where p.TenantID == tenantId
                orderby p.MedicalRecordNumber descending
                select p).FirstOrDefaultAsync();
            if(patient==null) return -1;
            int lastnumber = Convert.ToInt32(patient.MedicalRecordNumber.Substring(2,10));
            return lastnumber;
        }

        public async Task<Patient> Update(string id, Patient objEntity)
        {
            try
            {
                var editPatient =  await GetById(id);
                editPatient.FullName = objEntity.FullName;
                editPatient.Email = objEntity.Email;
                await _db.SaveChangesAsync();
                return editPatient;
            }
            catch(DbUpdateException dbEx)
            {
                throw new Exception(dbEx.InnerException.Message);
            }
        }
    }
}