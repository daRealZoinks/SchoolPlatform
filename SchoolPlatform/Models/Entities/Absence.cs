using System;

namespace View.Models.Entities;

public class Absence : BaseEntity
{
    public bool Motivated { get; set; }
    public DateTime Date { get; set; }

    public Student Student { get; set; }
    public Subject Subject { get; set; }
}