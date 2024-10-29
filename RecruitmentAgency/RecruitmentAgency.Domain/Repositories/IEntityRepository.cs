
namespace RecruitmentAgency.Domain.Repositories;

public interface IEntityRepository<T>
{
    /// <summary>
    /// Получение всех сущностей
    /// </summary>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Получение сущности при помощи id
    /// </summary>
    public T? GetById(int id);

    /// <summary>
    /// Добавление сущности
    /// </summary>
    public T Add(T entity);

    /// <summary>
    /// Удаление сущности
    /// </summary>
    public void Delete(T entity);

    /// <summary>
    /// Изменение сущности
    /// </summary>
    public T Update(T entity);
}
