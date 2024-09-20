namespace AlzaProduct.Core.Interfaces.Persistent;

public interface IRepository<T>
{
    T GetById(string id);

    IEnumerable<T> GetList();

    void Save(T item);

    void Update(string id, T item);

    void Delete(string id);
}
