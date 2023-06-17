using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.ClassMasterWindows;

namespace View.ViewModels.Commands.ClassMasterCommands;

public class ClassMasterAbsenceCommands
{
    private Motivated _motivated;

    private Student? _student;
    private Subject? _subject;

    public ClassMasterAbsenceCommands()
    {
        var absenceCollectionService = App.Current.Services.GetService<IAbsenceCollectionService>();

        Absences = new ObservableCollection<Absence>();

        Refresh();

        if (absenceCollectionService == null) return;

        MotivateAbsenceCommand = new RelayCommand<Absence>(selectedAbsence =>
        {
            if (selectedAbsence == null)
            {
                MessageBox.Show("You need to select an absence first");
                return;
            }

            selectedAbsence.Motivated = true;
            absenceCollectionService.Update(selectedAbsence);
            Refresh();
            MessageBox.Show("Absence has been motivated");
        });
    }

    public ObservableCollection<Absence> Absences { get; }

    public IRelayCommand? MotivateAbsenceCommand { get; }

    public Student? Student
    {
        get => _student;
        set
        {
            _student = value;
            Refresh();
        }
    }

    public Subject? Subject
    {
        get => _subject;
        set
        {
            _subject = value;
            Refresh();
        }
    }

    public Motivated Motivated
    {
        get => _motivated;
        set
        {
            _motivated = value;
            Refresh();
        }
    }

    private void Refresh()
    {
        Absences.Clear();

        List<Absence> absences = new();

        if (ClassMasterMainWindow.Class == null) return;

        foreach (var student in ClassMasterMainWindow.Class.Students)
        {
            if (student.Absences != null)
            {
                absences.AddRange(student.Absences);
            }
        }

        if (Student != null) absences = absences.FindAll(absence => absence.Student == Student);
        if (Subject != null) absences = absences.FindAll(absence => absence.Subject == Subject);

        absences = Motivated switch
        {
            Motivated.Motivated => absences.FindAll(absence => absence.Motivated),
            Motivated.Unmotivated => absences.FindAll(absence => !absence.Motivated),
            Motivated.All => absences,
            _ => absences
        };

        foreach (var absence in absences) Absences.Add(absence);
    }
}

public enum Motivated
{
    All,
    Motivated,
    Unmotivated
}