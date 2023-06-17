using System.Collections.Generic;
using View.Models.Entities;
using View.Views.StudentWindows;

namespace View.ViewModels.Commands.StudentCommands;

public class StudentAbsenceCommands
{
    public StudentAbsenceCommands()
    {
        Absences = StudentMainWindow.Student.Absences;
    }

    public List<Absence> Absences { get; }
}