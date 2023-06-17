using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.ClassCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorClassCommands
{
    private readonly IClassCollectionService? _classCollectionService;

    public AdministratorClassCommands()
    {
        _classCollectionService = App.Current.Services.GetService<IClassCollectionService>();

        Classes = new ObservableCollection<Class>();

        Refresh();

        if (_classCollectionService == null) return;

        InsertClassCommand = new RelayCommand(() =>
        {
            ClassInsertWindow classInsertWindow = new();
            classInsertWindow.Show();

            classInsertWindow.OnClassInserted += @class =>
            {
                _classCollectionService.Insert(@class);
                Refresh();
                MessageBox.Show("Class added");
            };
        });

        DeleteClassCommand = new RelayCommand<Class>(selectedClass =>
        {
            if (selectedClass == null)
            {
                MessageBox.Show("You need to select a class first");
                return;
            }

            _classCollectionService.Delete(selectedClass);
            Refresh();
            MessageBox.Show("Class deleted");
        });

        UpdateClassCommand = new RelayCommand<Class>(selectedClass =>
        {
            if (selectedClass == null)
            {
                MessageBox.Show("You need to select a class first");
                return;
            }

            ClassUpdateWindow classUpdateWindow = new(selectedClass);
            classUpdateWindow.Show();

            classUpdateWindow.OnClassUpdated += @class =>
            {
                _classCollectionService.Update(@class);
                Refresh();
                MessageBox.Show("Class updated");
            };
        });
    }

    public ObservableCollection<Class> Classes { get; }

    public IRelayCommand? InsertClassCommand { get; }
    public IRelayCommand? DeleteClassCommand { get; }
    public IRelayCommand? UpdateClassCommand { get; }

    private void Refresh()
    {
        if (_classCollectionService == null) return;

        Classes.Clear();

        foreach (var classEntity in _classCollectionService.GetAll()) Classes.Add(classEntity);
    }
}