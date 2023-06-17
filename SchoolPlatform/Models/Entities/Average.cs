namespace View.Models.Entities;

public class Average : BaseEntity
{
    public int Value { get; set; }

    public Student Student { get; set; }
    public Subject Subject { get; set; }
}