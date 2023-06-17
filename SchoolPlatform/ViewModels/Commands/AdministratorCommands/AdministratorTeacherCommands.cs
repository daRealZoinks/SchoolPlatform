using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.TeacherCommandWindow;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorTeacherCommands
{
    private readonly ITeacherCollectionService? _teacherCollectionService;

    public AdministratorTeacherCommands()
    {
        _teacherCollectionService = App.Current.Services.GetService<ITeacherCollectionService>();

        Teachers = new ObservableCollection<Teacher>();

        Refresh();

        if (_teacherCollectionService == null) return;

        InsertTeacherCommand = new RelayCommand(() =>
        {
            TeacherInsertWindow teacherInsertWindow = new();
            teacherInsertWindow.Show();
            teacherInsertWindow.OnTeacherInserted += teacher =>
            {
                _teacherCollectionService.Insert(teacher);
                Refresh();
                MessageBox.Show("Teacher added");
            };
        });

        DeleteTeacherCommand = new RelayCommand<Teacher>(selectedTeacher =>
        {
            if (selectedTeacher == null)
            {
                MessageBox.Show("You need to select a teacher first");
                return;
            }

            _teacherCollectionService.Delete(selectedTeacher);
            Refresh();
            MessageBox.Show("Teacher deleted");
        });

        UpdateTeacherCommand = new RelayCommand<Teacher>(selectedTeacher =>
        {
            if (selectedTeacher == null)
            {
                MessageBox.Show("You need to select a teacher first");
                return;
            }

            TeacherUpdateWindow teacherUpdateWindow = new(selectedTeacher);
            teacherUpdateWindow.Show();
            teacherUpdateWindow.OnTeacherUpdated += teacher =>
            {
                _teacherCollectionService.Update(teacher);
                Refresh();
                MessageBox.Show("Teacher updated");
            };
        });
    }

    public ObservableCollection<Teacher> Teachers { get; }

    public IRelayCommand? InsertTeacherCommand { get; }
    public IRelayCommand? DeleteTeacherCommand { get; }
    public IRelayCommand? UpdateTeacherCommand { get; }

    private void Refresh()
    {
        if (_teacherCollectionService == null) return;

        Teachers.Clear();

        foreach (var teacher in _teacherCollectionService!.GetAll()) Teachers.Add(teacher);
    }
}