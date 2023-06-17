using System.Collections.Generic;

namespace View.Models.Entities;

public class Subject : BaseEntity
{
    public string Name { get; set; }

    public List<Grade> Grades { get; set; } = new();
    public List<Absence> Absences { get; set; } = new();
    public List<Average> Averages { get; set; } = new();
    public List<SubjectClass> SubjectClasses { get; set; } = new();

    public override string ToString()
    {
        return Name;
    }
}