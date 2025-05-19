using JANORM.Core.attributes;

namespace testProject;

[Entity(TABLE_NAME)]
public class Test 
{
    public const string  TABLE_NAME = "Test";

    [Id(GenerationMethod.UUID)]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    public int Age { get; set; } 

    public float Height { get; set; } = 0.0f;

    public float? Weight { get; set; } = 0.0f;

    public Test() {
        Id = Guid.NewGuid();
        Name = string.Empty;
        Age = 0;
        Description = string.Empty;
        Height = 0.0f;
        Weight = 0.0f;

    }

    public Test(string name, int age, string description, float height, float? weight, Guid? id = null) 
    {
        Name = name;

        if (id != null) 
        {
            Id = (Guid)id;
        } 

        Age = age;
        Description = description;
        Height = height;
        Weight = weight; 
    } 
}