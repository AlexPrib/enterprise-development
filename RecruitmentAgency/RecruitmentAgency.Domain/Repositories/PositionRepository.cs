using RecruitmentAgency.Domain.Context;
using RecruitmentAgency.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Azure.Core.GeoJson;

namespace RecruitmentAgency.Domain.Repositories;

public class PositionRepository(RecruitmentAgencyContext context) : IEntityRepository<Position>
{
    public IEnumerable<Position> GetAll() => context.Positions;

    public Position? GetById(int id) => context.Positions.Find(id);

    public Position Add(Position newPosition)
    {
        var position = context.Positions.Add(newPosition).Entity;
        context.SaveChanges();
        return position;
    }

    public void Delete(Position position)
    {
        context.Positions.Remove(position);
        context.SaveChanges();
    }

    public Position Update(Position updatedPosition)
    {
        var entry = context.Entry(updatedPosition);
        entry.State = EntityState.Modified;
        context.SaveChanges();
        return entry.Entity;
    }
}
