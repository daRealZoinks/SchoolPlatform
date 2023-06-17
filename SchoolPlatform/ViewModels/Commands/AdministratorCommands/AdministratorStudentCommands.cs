using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.StudentCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorStudentCommands
{
    private readonly IStudentCollectionService? _studentCollectionService;

    public AdministratorStudentCommands()
    {
        _studentCollectionService = App.Current.Services.GetService<IStudentCollectionService>();

        Students = new ObservableCollection<Student>();

        Refresh();

        if (_studentCollectionService == null) return;

        InsertStudentCommand = new RelayCommand(() =>
        {
            StudentInsertWindow studentInsertWindow = new();
            studentInsertWindow.Show();

            studentInsertWindow.OnStudentInserted += student =>
            {
                _studentCollectionService.Insert(student);
                Refresh();
                MessageBox.Show("Student added");
            };
        });

        DeleteStudentCommand = new RelayCommand<Student>(selectedStudent =>
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("You need to select a class first");
                return;
            }

            _studentCollectionService.Delete(selectedStudent);
            Refresh();
            MessageBox.Show("Student deleted");
        });

        UpdateStudentCommand = new RelayCommand<Student>(selectedStudent =>
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("You need to select a class first");
                return;
            }

            StudentUpdateWindow studentUpdateWindow = new(selectedStudent);
            studentUpdateWindow.Show();

            studentUpdateWindow.OnStudentUpdated += student =>
            {
                _studentCollectionService.Update(student);
                Refresh();
                MessageBox.Show("Student updated");
            };
        });
    }

    public ObservableCollection<Student> Students { get; }

    public IRelayCommand? InsertStudentCommand { get; }
    public IRelayCommand? DeleteStudentCommand { get; }
    public IRelayCommand? UpdateStudentCommand { get; }

    private void Refresh()
    {
        if (_studentCollectionService == null) return;

        Students.Clear();

        foreach (var student in _studentCollectionService.GetAll()) Students.Add(student);
    }
}