using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DentalApps.Models;
using DentalApps.Models.DTO;

namespace DentalApps.API.Profiles
{
    public class TenantsProfile : Profile
    {
        public TenantsProfile()
        {
            CreateMap<Tenant,TenantReadDto>();
            CreateMap<TenantCreateDto,Tenant>();
            CreateMap<Patient,PatientReadDto>();
            CreateMap<PatientCreateDto,Patient>();
            CreateMap<Employee,EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, Employee>();
        }
    }
}