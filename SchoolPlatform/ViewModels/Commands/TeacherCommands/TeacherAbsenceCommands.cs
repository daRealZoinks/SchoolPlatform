using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.TeacherWindows;
using View.Views.TeacherWindows.AbsenceCommandWindows;

namespace View.ViewModels.Commands.TeacherCommands;

public class TeacherAbsenceCommands
{
    public TeacherAbsenceCommands()
    {
        var absenceCollectionService = App.Current.Services.GetService<IAbsenceCollectionService>();

        Absences = new ObservableCollection<Absence>();

        Refresh();

        if (absenceCollectionService == null) return;

        InsertAbsenceCommand = new RelayCommand(() =>
        {
            AbsenceInsertWindow absenceInsertWindow = new();
            absenceInsertWindow.Show();

            absenceInsertWindow.OnAbsenceInserted += absence =>
            {
                absenceCollectionService.Insert(absence);
                Refresh();
                MessageBox.Show("Absence added");
            };
        });

        DeleteAbsenceCommand = new RelayCommand<Absence>(selectedAbsence =>
        {
            if (selectedAbsence == null)
            {
                MessageBox.Show("You need to select an absence first");
                return;
            }

            absenceCollectionService.Delete(selectedAbsence);
            Refresh();
            MessageBox.Show("Absence deleted");
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
                absenceCollectionService.Update(absence);
                Refresh();
                MessageBox.Show("Absence updated");
            };
        });
    }

    public ObservableCollection<Absence> Absences { get; }

    public IRelayCommand? InsertAbsenceCommand { get; }
    public IRelayCommand? DeleteAbsenceCommand { get; }
    public IRelayCommand? UpdateAbsenceCommand { get; }

    private void Refresh()
    {
        Absences.Clear();

        foreach (var absence in TeacherMainWindow.Teacher.SubjectClasses.SelectMany(subjectClass =>
                     subjectClass.Subject.Absences))
            Absences.Add(absence);
    }
}