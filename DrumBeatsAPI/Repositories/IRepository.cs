namespace DrumBeatsAPI.Repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> Get();
    
    Task<T> Get(int id);

    Task<T> Create(T obj);

    Task Update(T obj);

    Task Delete(int id);
}