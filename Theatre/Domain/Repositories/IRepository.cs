namespace Domain.Repositories;

public interface IRepository<T>
    where T : class
{
    public List<T> GetAll();
    public void Create( T item );
    public void Remove( T item );
    public void Save();
}