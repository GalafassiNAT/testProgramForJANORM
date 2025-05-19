using JANORM.Core.attributes;

namespace testProject;

[Entity(TABLE_NAME)]
public class Car
{
    public const string TABLE_NAME = "Car";

    [Id(GenerationMethod.AUTO_INCREMENT)]
    public int? Id { get; set; }

    public string Name { get; set; }

    public int Year { get; set; }
    public int Doors { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public float? Price { get; set; }

    public Car()
    {
        Id = null;
        Name = string.Empty;
        Year = 0;
        Doors = 0;
        Brand = string.Empty;
        Model = string.Empty;
        Price = null;
    }

    public Car(string name, int year, int doors, string brand, string model, float? price, int? id = null)
    {
        Name = name;

        if (id != null)
        {
            Id = id;
        }

        Year = year;
        Doors = doors;
        Brand = brand;
        Model = model;
        Price = price;
    }
}
