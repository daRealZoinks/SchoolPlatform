using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.AbsenceCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorAbsenceCommands
{
    private readonly IAbsenceCollectionService? _absenceCollectionService;

    public AdministratorAbsenceCommands()
    {
        _absenceCollectionService = App.Current.Services.GetService<IAbsenceCollectionService>();

        Absences = new ObservableCollection<Absence>();

        Refresh();

        if (_absenceCollectionService == null) return;

        InsertAbsenceCommand = new RelayCommand(() =>
        {
            AbsenceInsertWindow absenceInsertWindow = new();
            absenceInsertWindow.Show();

            absenceInsertWindow.OnAbsenceInserted += absence =>
            {
                _absenceCollectionService.Insert(absence);
                Refresh();
                MessageBox.Show("Absence has been added");
            };
        });

        DeleteAbsenceCommand = new RelayCommand<Absence>(selectedAbsence =>
        {
            if (selectedAbsence == null)
            {
                MessageBox.Show("You need to select an absence first");
                return;
            }

            _absenceCollectionService.Delete(selectedAbsence);
            Refresh();
            MessageBox.Show("Absence has been deleted");
        });

        UpdateAbsenceCommand = new RelayCommand<Absence>(selectedAbsence =>
        {
            if (selectedAbsence == null)
            {
                MessageBox.Show("You need to select an absence first");
                return;
            }

            AbsenceUpdateWindow absenceUpdateWindow = new(selectedAbsence);
            absenceUpdateWindow.Show();

            absenceUpdateWindow.OnAbsenceUpdated += absence =>
            {
                _absenceCollectionService.Update(absence);
                Refresh();
                MessageBox.Show("Absence has been updated");
            };
        });
    }

    public ObservableCollection<Absence> Absences { get; }

    public IRelayCommand? InsertAbsenceCommand { get; }
    public IRelayCommand? DeleteAbsenceCommand { get; }
    public IRelayCommand? UpdateAbsenceCommand { get; }

    private void Refresh()
    {
        if (_absenceCollectionService == null) return;

        Absences.Clear();

        foreach (var absence in _absenceCollectionService.GetAll()) Absences.Add(absence);
    }
}