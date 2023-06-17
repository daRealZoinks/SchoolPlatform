namespace View.Models.Entities;

public class SubjectClass : BaseEntity
{
    public Subject Subject { get; set; }
    public Class Class { get; set; }
    public Teacher? Teacher { get; set; }
}