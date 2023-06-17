using System.Collections.Generic;

namespace View.Models.Entities;

public class Year : BaseEntity
{
    public int Value { get; set; }

    public List<Class> Classes { get; set; } = new();

    public override string ToString()
    {
        return $"{Value}";
    }
}