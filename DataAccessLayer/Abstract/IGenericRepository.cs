

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetListAll();
        T GetByID(int id);
    }
}
