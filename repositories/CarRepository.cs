using JANORM.Core.services;
using JANORM.Core.repositories.implementation;

namespace testProject.repositories;

public class CarRepository : JanRepository<Car, int>
{
    public CarRepository(IDBService dbService) : base(dbService)
    {
    }


}
