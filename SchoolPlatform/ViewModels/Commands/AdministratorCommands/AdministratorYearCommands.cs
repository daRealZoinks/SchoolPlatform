using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.YearCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorYearCommands
{
    private readonly IYearCollectionService? _yearCollectionService;

    public AdministratorYearCommands()
    {
        _yearCollectionService = App.Current.Services.GetService<IYearCollectionService>();

        Years = new ObservableCollection<Year>();

        Refresh();

        if (_yearCollectionService == null) return;

        InsertYearCommand = new RelayCommand(() =>
        {
            YearInsertWindow yearInsertWindow = new();
            yearInsertWindow.Show();

            yearInsertWindow.OnYearInserted += year =>
            {
                _yearCollectionService.Insert(year);
                Refresh();
                MessageBox.Show("Year added");
            };
        });

        DeleteYearCommand = new RelayCommand<Year>(selectedYear =>
        {
            if (selectedYear == null)
            {
                MessageBox.Show("You need to select a year first");
                return;
            }

            _yearCollectionService.Delete(selectedYear);
            Refresh();
            MessageBox.Show("Year deleted");
        });

        UpdateYearCommand = new RelayCommand<Year>(selectedYear =>
        {
            if (selectedYear == null)
            {
                MessageBox.Show("You need to select a student first");
                return;
            }

            YearUpdateWindow yearUpdateWindow = new(selectedYear);
            yearUpdateWindow.Show();

            yearUpdateWindow.OnYearUpdated += year =>
            {
                _yearCollectionService.Update(year);
                Refresh();
                MessageBox.Show("Year updated");
            };
        });
    }

    public ObservableCollection<Year> Years { get; }

    public IRelayCommand? InsertYearCommand { get; }
    public IRelayCommand? DeleteYearCommand { get; }
    public IRelayCommand? UpdateYearCommand { get; }

    private void Refresh()
    {
        if (_yearCollectionService == null) return;

        Years.Clear();

        foreach (var year in _yearCollectionService.GetAll()) Years.Add(year);
    }
}