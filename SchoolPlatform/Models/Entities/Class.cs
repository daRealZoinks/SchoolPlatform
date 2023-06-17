using System.Collections.Generic;

namespace View.Models.Entities;

public class Class : BaseEntity
{
    public string Name { get; set; }

    public Year Year { get; set; }
    public Specialization Specialization { get; set; }
    public Teacher ClassMaster { get; set; }

    public List<SubjectClass> SubjectClasses { get; set; } = new();
    public List<Student> Students { get; set; } = new();

    public override string ToString()
    {
        return Name;
    }
}