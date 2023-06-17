using System;

namespace View.Models.Entities;

public class Grade : BaseEntity
{
    public int Value { get; set; }
    public bool IsThesis { get; set; }
    public DateTime Date { get; set; }

    public Student Student { get; set; }
    public Subject Subject { get; set; }
}