using System.Collections.Generic;
using View.Models.Entities;
using View.Views.StudentWindows;

namespace View.ViewModels.Commands.StudentCommands;

public class StudentGradeCommands
{
    public StudentGradeCommands()
    {
        Grades = StudentMainWindow.Student.Grades;
    }

    public List<Grade> Grades { get; }
}