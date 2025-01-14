using Deliceria.Data;
using Deliceria.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Deliceria.API.Repository;

public class RecenziiRepository
{
    private readonly DeliceriaContext _dataContext;
    public RecenziiRepository(DeliceriaContext dataContext) { 
        _dataContext = dataContext;
    }

    public EntityEntry<Recenzie> Add(Recenzie recenzie)
    {
        var entry = _dataContext.Recenzii.Add(recenzie);
        _dataContext.SaveChanges();
        return entry;
    }

    public List<Recenzie> GetAll()
    {
        return _dataContext.Recenzii.ToList();
    }
}