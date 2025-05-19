using System.Threading.Tasks;
using DotNetEnv;
using JANORM.Core.repositories;
using JANORM.Core.repositories.implementation;
using JANORM.Core.services;
using JANORM.Core.services.Implementation;
using JANORM.Core.utils;
using Microsoft.Extensions.DependencyInjection;
using testProject.repositories;

namespace testProject;
public class Program
{
    public static async Task Main(string[] args)
    {
        Env.Load();
        var services = new ServiceCollection();
        // 0) Configuração do SQLite
        string connString = Utils.GetConnectionString();

        // 1) Fábrica e serviço de DB
        services.AddSingleton<IDBFactory>(provider => new SqliteConnectionFactory(connString));
        services.AddTransient<IDBService, SqliteDBService>();

        // 2) Repositório genérico
        services.AddTransient(
            typeof(IRepository<,>),
            typeof(JanRepository<,>)
        );

        // 3) Repositórios específicos
        services.AddTransient<TestRepository>();
        services.AddTransient<CarRepository>();

        var provider = services.BuildServiceProvider();

        Test t1 = new("Name02", 20, "Description02", 1.78f, 65.0f);

        var testRepository = provider.GetRequiredService<TestRepository>();

        // Insert

        // Test r1 = await testRepository.Insert(t1);
        // Console.WriteLine("Inserted Test: " + r1.Id);

        Car car1 = new("Car01", 2020, 4, "Brand01", "Model01", 20000.0f);
        var carRepository = provider.GetRequiredService<CarRepository>();

        // Car c1 = await carRepository.Insert(car1);
        // Console.WriteLine("Inserted Car: " + c1.Id);

        //Find by ID
        // Car c2 = await carRepository.FindById(1);
        // Console.WriteLine("Found Car: " + c2.Id);
        // Console.WriteLine("Found Car: " + c2.Name);
        // Console.WriteLine("Found Car: " + c2.Year);
        // Console.WriteLine("Found Car: " + c2.Doors);
        // Console.WriteLine("Found Car: " + c2.Brand);
        // Console.WriteLine("Found Car: " + c2.Model);
        // Console.WriteLine("Found Car: " + c2.Price);

        Guid idT = Guid.Parse("86BB7A5C-1258-4A01-8CD1-A457D6C6C1E1");
        // Console.WriteLine("ID: " + id);
        // Test t2 = await testRepository.FindById(id);
        // if (t2 == null)
        // {
        //     Console.WriteLine("Test not found");
        //     return;
        // }
        // Console.WriteLine("Found Test: " + t2.Id);
        // Console.WriteLine("Found Test: " + t2.Name);
        // Console.WriteLine("Found Test: " + t2.Age);
        // Console.WriteLine("Found Test: " + t2.Description);
        // Console.WriteLine("Found Test: " + t2.Height);
        // Console.WriteLine("Found Test: " + t2.Weight);


        // Find all

        var allTests = await testRepository.FindAll();
        // foreach (var test in allTests)
        // {
        //     Console.WriteLine("Test Id: " + test.Id);
        //     Console.WriteLine("Test Name: " + test.Name);
        //     Console.WriteLine("Test Age:" + test.Age);
        //     Console.WriteLine("Test Description: " + test.Description);
        //     Console.WriteLine("Test Height: " + test.Height);
        //     Console.WriteLine("Test Weight: " + test.Weight);
        //     Console.WriteLine();
        // }

        // var allCars = await carRepository.FindAll();
        // foreach (var car in allCars)
        // {
        //     Console.WriteLine("Car Id: " + car.Id);
        //     Console.WriteLine("Car Name: " + car.Name);
        //     Console.WriteLine("Car Year:" + car.Year);
        //     Console.WriteLine("Car Doors: " + car.Doors);
        //     Console.WriteLine("Car Brand: " + car.Brand);
        //     Console.WriteLine("Car Model: " + car.Model);
        //     Console.WriteLine("Car Price: " + car.Price);
        //     Console.WriteLine();
        // }


        // Update

        // t1.Name = "Updated Name";
        // t1.Age = 30;
        // t1.Description = "Updated Description";
        // t1.Height = 1.80f;
        // t1.Weight = 70.0f;
        // Test updatedTest = await testRepository.Update(t1, idT);
        // Console.WriteLine("Updated Test Id: " + updatedTest.Id);
        // Console.WriteLine("Updated Test Name: " + updatedTest.Name);
        // Console.WriteLine("Updated Test Age: " + updatedTest.Age);
        // Console.WriteLine("Updated Test Description: " + updatedTest.Description);
        // Console.WriteLine("Updated Test Height: " + updatedTest.Height);
        // Console.WriteLine("Updated Test Weight: " + updatedTest.Weight);

        // car1.Name = "Updated Car";
        // car1.Year = 2021;
        // car1.Doors = 2;
        // car1.Brand = "Updated Brand";
        // car1.Model = "Updated Model";
        // car1.Price = 25000.0f;
        // Car updatedCar = await carRepository.Update(car1, 1);
        // Console.WriteLine("Updated Car Id: " + updatedCar.Id);
        // Console.WriteLine("Updated Car Name: " + updatedCar.Name);
        // Console.WriteLine("Updated Car Year: " + updatedCar.Year);
        // Console.WriteLine("Updated Car Doors: " + updatedCar.Doors);
        // Console.WriteLine("Updated Car Brand: " + updatedCar.Brand);
        // Console.WriteLine("Updated Car Model: " + updatedCar.Model);
        // Console.WriteLine("Updated Car Price: " + updatedCar.Price);

        // Delete

        // await testRepository.Delete(idT);
        // Console.WriteLine("Deleted Test: " + idT);
        // await carRepository.Delete(1);
        // Console.WriteLine("Deleted Car: " + 1);

        // findOne

        var condition = new Dictionary<string, object>
        {
            { "Name", "Name01" },

        };

        var test = await testRepository.FindOne(condition);
        if (test != null)
        {
            Console.WriteLine("Found Test: " + test.Id);
            Console.WriteLine("Found Test: " + test.Name);
            Console.WriteLine("Found Test: " + test.Age);
            Console.WriteLine("Found Test: " + test.Description);
            Console.WriteLine("Found Test: " + test.Height);
            Console.WriteLine("Found Test: " + test.Weight);
        }
        else
        {
            Console.WriteLine("Test not found");
        }
    }

}