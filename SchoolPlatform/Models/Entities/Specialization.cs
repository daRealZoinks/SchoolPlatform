using System.Collections.Generic;

namespace View.Models.Entities;

public class Specialization : BaseEntity
{
    public string Name { get; set; }

    public List<Class> Classes { get; set; } = new();

    public override string ToString()
    {
        return Name;
    }
}