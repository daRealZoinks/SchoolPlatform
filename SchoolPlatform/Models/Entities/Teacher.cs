using System.Collections.Generic;

namespace View.Models.Entities;

public class Teacher : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<SubjectClass> SubjectClasses { get; set; } = new();

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}