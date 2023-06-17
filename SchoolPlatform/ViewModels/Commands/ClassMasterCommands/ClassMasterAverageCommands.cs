using System.Collections.Generic;
using View.Models.Entities;
using View.Views.ClassMasterWindows;

namespace View.ViewModels.Commands.ClassMasterCommands;

public class ClassMasterAverageCommands
{
    public ClassMasterAverageCommands()
    {
        Averages = new List<Average>();

        Refresh();
    }

    public List<Average> Averages { get; }

    private void Refresh()
    {
        Averages.Clear();

        List<Average> averages = new();

        if (ClassMasterMainWindow.Class == null) return;

        foreach (var student in ClassMasterMainWindow.Class.Students) averages.AddRange(student.Averages);

        foreach (var average in averages) Averages.Add(average);
    }
}