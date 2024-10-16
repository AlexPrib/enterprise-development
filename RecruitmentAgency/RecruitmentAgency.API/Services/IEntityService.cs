﻿namespace RecruitmentAgency.API.Services;
/// <summary>
///  Интерфейс для сервисов сущностей
/// </summary>
public interface IEntityService<T, CreateDTO>
{
    /// <summary>
    /// Получение всех сущностей
    /// </summary>
    public List<T> GetAll();

    /// <summary>
    /// Получение сущности при помощи id
    /// </summary>
    T? GetById(int id);

    /// <summary>
    /// Добавление сущности
    /// </summary>
    bool Add(CreateDTO entity);

    /// <summary>
    /// Удаление сущности
    /// </summary>
    bool Delete(int id);

    /// <summary>
    /// Изменение сущности
    /// </summary>
    bool Update(int id, CreateDTO updatedEntity);
}