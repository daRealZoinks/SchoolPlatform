using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.TeacherWindows;
using View.Views.TeacherWindows.AverageCommandWindows;

namespace View.ViewModels.Commands.TeacherCommands;

public class TeacherAverageCommands
{
    public TeacherAverageCommands()
    {
        var averageCollectionService = App.Current.Services.GetService<IAverageCollectionService>();

        Averages = new ObservableCollection<Average>();

        Refresh();

        if (averageCollectionService == null) return;

        InsertAverageCommand = new RelayCommand(() =>
        {
            AverageInsertWindow averageInsertWindow = new();
            averageInsertWindow.Show();

            averageInsertWindow.OnAverageInserted += average =>
            {
                averageCollectionService.Insert(average);
                Refresh();
                MessageBox.Show("Average added");
            };
        });

        DeleteAverageCommand = new RelayCommand<Average>(selectedAverage =>
        {
            if (selectedAverage == null)
            {
                MessageBox.Show("You need to select an average first");
                return;
            }

            averageCollectionService.Delete(selectedAverage);
            Refresh();
            MessageBox.Show("Average deleted");
        });

        UpdateAverageCommand = new RelayCommand<Average>(selectedAverage =>
        {
            if (selectedAverage == null)
            {
                MessageBox.Show("You need to select an average first");
                return;
            }

            AverageUpdateWindow averageUpdateWindow = new(selectedAverage);
            averageUpdateWindow.Show();

            averageUpdateWindow.OnAverageUpdated += average =>
            {
                averageCollectionService.Update(average);
                Refresh();
                MessageBox.Show("Average updated");
            };
        });
    }

    public ObservableCollection<Average> Averages { get; }

    public IRelayCommand? InsertAverageCommand { get; }
    public IRelayCommand? DeleteAverageCommand { get; }
    public IRelayCommand? UpdateAverageCommand { get; }

    private void Refresh()
    {
        Averages.Clear();

        foreach (var average in TeacherMainWindow.Teacher.SubjectClasses.SelectMany(subjectClass =>
                     subjectClass.Subject.Averages))
            Averages.Add(average);
    }
}