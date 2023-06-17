using System.Collections.Generic;

namespace View.Models.Entities;

public class Student : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Class? Class { get; set; }

    public List<Grade> Grades { get; set; } = new();
    public List<Absence> Absences { get; set; } = new();
    public List<Average> Averages { get; set; } = new();

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}