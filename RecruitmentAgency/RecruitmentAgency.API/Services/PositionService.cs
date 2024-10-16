using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Services;

public class PositionService : IEntityService<Position, PositionCreateDTO>
{
    private readonly List<Position> _position = [];

    private int _id = 1;

    public List<Position> GetAll() => _position;

    public Position? GetById(int id) => _position.FirstOrDefault(o => o.Id == id);

    public bool Add(PositionCreateDTO newPosition)
    {
        var position = new Position
        {
            Id = _id++,
            Section = newPosition.Section,
            PositionName = newPosition.PositionName
        };
        _position.Add(position);
        return true;
    }

    public bool Delete(int id)
    {
        var position = GetById(id);
        if (position == null)
        {
            return false;
        }
        _position.Remove(position);
        return true;
    }

    public bool Update(int id, PositionCreateDTO updatedPosition)
    {
        var position = GetById(id);
        if (position == null)
        {
            return false;
        }
        position.Section = updatedPosition.Section;
        position.PositionName = updatedPosition.PositionName;
        return true;
    }
}
