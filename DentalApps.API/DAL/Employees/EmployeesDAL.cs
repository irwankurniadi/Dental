using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalApps.API.DAL.Interface;
using DentalApps.API.Data;
using DentalApps.Models;
using Microsoft.EntityFrameworkCore;


namespace DentalApps.API.DAL.Employees;


public class EmployeesDAL : IEmployees
{
        private readonly ApplicationDbContext _db;
        public EmployeesDAL(ApplicationDbContext db)
        {
            _db = db;
        }

    public async Task<Employee> Create(Employee objEntity)
    {
        try
            {
                //jika masih belum ada employee dengan tenant ini
                var tenant = await (from t in _db.Tenants 
                        where t.TenantID==objEntity.TenantID 
                        select t).FirstOrDefaultAsync();
                if(tenant==null) throw new Exception($"tenant tidak ditemukan");

                object value = await _db.Employees.AddAsync(objEntity);
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
                var delEmployee = await GetById(id);
                _db.Employees.Remove(delEmployee);
                await _db.SaveChangesAsync();
            }
            catch(DbUpdateException dbEx)
            {
                throw new Exception(dbEx.InnerException.Message);
            }
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        var results = await _db.Employees.OrderBy(e => e.EmployeeID).AsNoTracking().ToListAsync();
            return results;
    }

    public async Task<Employee> GetById(string id)
    {
        var result = await _db.Employees.Where(e => e.EmployeeID == id).FirstOrDefaultAsync();
            if (result == null) throw new ArgumentNullException($"Error: Data tidak ditemukan");
            return result;
    }

    public async Task<Employee> Update(string id, Employee objEntity)
    {
            try
            {
                var editEmployee =  await GetById(id);
                editEmployee.FullName = objEntity.FullName;
                editEmployee.Email = objEntity.Email;
                await _db.SaveChangesAsync();
                return editEmployee;
            }
            catch(DbUpdateException dbEx)
            {
                throw new Exception(dbEx.InnerException.Message);
            }
    }
}
