namespace DentalApps.API.DAL.Interface
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Create(T objEntity);
        Task<T> Update(string id, T objEntity);
        Task Delete(string id);
    }
}
