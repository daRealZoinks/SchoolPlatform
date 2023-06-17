using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.SpecializationCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorSpecializationCommands
{
    private readonly ISpecializationCollectionService? _specializationCollectionService;

    public AdministratorSpecializationCommands()
    {
        _specializationCollectionService = App.Current.Services.GetService<ISpecializationCollectionService>();

        Specializations = new ObservableCollection<Specialization>();

        Refresh();

        if (_specializationCollectionService == null) return;

        InsertSpecializationCommand = new RelayCommand(() =>
        {
            SpecializationInsertWindow specializationInsertWindow = new();
            specializationInsertWindow.Show();

            specializationInsertWindow.OnSpecializationInserted += specialization =>
            {
                _specializationCollectionService.Insert(specialization);
                Refresh();
                MessageBox.Show("Specialization added");
            };
        });

        DeleteSpecializationCommand = new RelayCommand<Specialization>(selectedSpecialization =>
        {
            if (selectedSpecialization == null)
            {
                MessageBox.Show("You need to select a specialization first");
                return;
            }

            _specializationCollectionService.Delete(selectedSpecialization);
            Refresh();
            MessageBox.Show("Specialization deleted");
        });

        UpdateSpecializationCommand = new RelayCommand<Specialization>(selectedSpecialization =>
        {
            if (selectedSpecialization == null)
            {
                MessageBox.Show("You need to select a class first");
                return;
            }

            SpecializationUpdateWindow classUpdateWindow = new(selectedSpecialization);
            classUpdateWindow.Show();

            classUpdateWindow.OnSpecializationUpdated += specialization =>
            {
                _specializationCollectionService.Update(specialization);
                Refresh();
                MessageBox.Show("Specialization updated");
            };
        });
    }

    public ObservableCollection<Specialization> Specializations { get; }

    public IRelayCommand? InsertSpecializationCommand { get; }
    public IRelayCommand? DeleteSpecializationCommand { get; }
    public IRelayCommand? UpdateSpecializationCommand { get; }

    private void Refresh()
    {
        if (_specializationCollectionService == null) return;

        Specializations.Clear();

        foreach (var specialization in _specializationCollectionService.GetAll()) Specializations.Add(specialization);
    }
}