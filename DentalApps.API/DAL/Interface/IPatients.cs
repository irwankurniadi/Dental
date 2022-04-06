using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalApps.Models;

namespace DentalApps.API.DAL.Interface
{
    public interface IPatients : ICrud<Patient>
    {
        Task<int> GetLastMedicalRecordNumber(string id);
    }
}