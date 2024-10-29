using AutoMapper;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain.Entity;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.API.Services;

public class PositionService(IEntityRepository<Position> repository, IMapper mapper) : IEntityService<PositionDTO, PositionCreateDTO>
{
    public IEnumerable<PositionDTO> GetAll() => repository.GetAll().Select(mapper.Map<PositionDTO>);

    public PositionDTO? GetById(int id) => mapper.Map<PositionDTO>(repository.GetById(id));

    public PositionDTO Add(PositionCreateDTO newPosition) => mapper.Map<PositionDTO>(repository.Add(mapper.Map<Position>(newPosition)));

    public bool Delete(int id)
    {
        var position = repository.GetById(id);
        if (position == null)
        {
            return false;
        }
        repository.Delete(position);
        return true;
    }

    public PositionDTO? Update(int id, PositionCreateDTO updatedPosition)
    {
        var position = repository.GetById(id);
        if (position == null)
        {
            return null;
        }
        position.Section = updatedPosition.Section;
        position.PositionName = updatedPosition.PositionName;
        return mapper.Map<PositionDTO>(repository.Update(position));
    }
}
