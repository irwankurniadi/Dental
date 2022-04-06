using DentalApps.API.Data;
using DentalApps.API.DAL.Interface;
using DentalApps.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalApps.API.DAL.Tenants
{
    public class TenantsDAL : ITenants
    {
        private ApplicationDbContext _db;
        public TenantsDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Tenant> Create(Tenant objEntity)
        {
            try
            {
                await _db.Tenants.AddAsync(objEntity);
                await _db.SaveChangesAsync();
                return objEntity;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var deleteTenant = await GetById(id);
                if(deleteTenant==null) throw new ArgumentNullException($"Data {id} tidak ditemukan");
                _db.Tenants.Remove(deleteTenant);
                await _db.SaveChangesAsync();
            }
            catch(DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task<IEnumerable<Tenant>> GetAll()
        {
            var results = await _db.Tenants.OrderBy(t => t.TenantName).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Tenant> GetById(string id)
        {
            var result = await _db.Tenants.Where(t => t.TenantID == id).FirstOrDefaultAsync();
            if (result == null) throw new ArgumentNullException($"Error: Data tidak ditemukan");
            return result;
        }

        public async Task<Tenant> Update(string id, Tenant objEntity)
        {
            try
            {
                var updateTenant = await GetById(id);
                updateTenant.TenantName = objEntity.TenantName;
                updateTenant.Address = objEntity.Address;
                updateTenant.PrefixMR = objEntity.PrefixMR;
                updateTenant.TenantStatus = objEntity.TenantStatus;
                updateTenant.JoinDate = objEntity.JoinDate;
                await _db.SaveChangesAsync();
                return updateTenant;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
            catch(Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
