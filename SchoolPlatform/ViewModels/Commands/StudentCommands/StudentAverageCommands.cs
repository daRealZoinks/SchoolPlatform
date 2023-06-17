using System.Collections.Generic;
using View.Models.Entities;
using View.Views.StudentWindows;

namespace View.ViewModels.Commands.StudentCommands;

public class StudentAverageCommands
{
    public StudentAverageCommands()
    {
        Averages = StudentMainWindow.Student.Averages;
    }

    public List<Average> Averages { get; }
}