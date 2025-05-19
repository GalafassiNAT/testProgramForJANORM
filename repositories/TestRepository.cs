using JANORM.Core.repositories.implementation;
using JANORM.Core.services;

namespace testProject.repositories;

public class TestRepository : JanRepository<Test, Guid>
{
    public TestRepository(IDBService dbService) : base(dbService){}

}
