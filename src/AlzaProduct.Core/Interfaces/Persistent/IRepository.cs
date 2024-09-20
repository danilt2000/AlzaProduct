namespace AlzaProduct.Core.Interfaces.Persistent;

public interface IRepository<T>
{
    T GetById(int id);

    IEnumerable<T> GetList();

    void Save(T item);

    void Update(int id, T item);

    void Delete(int id);
}
