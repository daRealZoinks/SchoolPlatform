using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.AverageCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorAverageCommands
{
    private readonly IAverageCollectionService? _averageCollectionService;

    public AdministratorAverageCommands()
    {
        _averageCollectionService = App.Current.Services.GetService<IAverageCollectionService>();

        Averages = new ObservableCollection<Average>();

        Refresh();

        if (_averageCollectionService == null) return;

        InsertAverageCommand = new RelayCommand(() =>
        {
            AverageInsertWindow averageInsertWindow = new();
            averageInsertWindow.Show();

            averageInsertWindow.OnAverageInserted += average =>
            {
                _averageCollectionService.Insert(average);
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

            _averageCollectionService.Delete(selectedAverage);
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
                _averageCollectionService.Update(average);
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
        if (_averageCollectionService == null) return;

        Averages.Clear();

        foreach (var average in _averageCollectionService.GetAll()) Averages.Add(average);
    }
}