using HMIS_AC.Models;
namespace HMIS_AC.IServices
{
    public interface IBaseService<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        void Add(T model);
        void Update(T model);
        void Delete(int id);
        List<T> Search(string name);

    }
}
