using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.ViewModels.Services;
using View.Views.AdministratorWindows.UserCommandWindows;

namespace View.ViewModels.Commands.AdministratorCommands;

public class AdministratorUserCommands
{
    private readonly IUserCollectionService? _userCollectionService;

    public AdministratorUserCommands()
    {
        _userCollectionService = App.Current.Services.GetService<IUserCollectionService>();

        Users = new ObservableCollection<User>();

        Refresh();

        if (_userCollectionService == null) return;

        InsertUserCommand = new RelayCommand(() =>
        {
            UserInsertWindow userInsertWindow = new();
            userInsertWindow.Show();

            userInsertWindow.OnUserInserted += user =>
            {
                _userCollectionService.Insert(user);
                Refresh();
                MessageBox.Show("User added");
            };
        });

        DeleteUserCommand = new RelayCommand<User>(selectedUser =>
        {
            if (selectedUser == null)
            {
                MessageBox.Show("You need to select a student first");
                return;
            }

            _userCollectionService.Delete(selectedUser);
            Refresh();
            MessageBox.Show("User deleted");
        });

        UpdateUserCommand = new RelayCommand<User>(selectedUser =>
        {
            if (selectedUser == null)
            {
                MessageBox.Show("You need to select a student first");
                return;
            }

            UserUpdateWindow userUpdateWindow = new(selectedUser);
            userUpdateWindow.Show();

            userUpdateWindow.OnUserUpdated += user =>
            {
                _userCollectionService.Update(user);
                Refresh();
                MessageBox.Show("User updated");
            };
        });
    }

    public ObservableCollection<User> Users { get; }

    public IRelayCommand? InsertUserCommand { get; }
    public IRelayCommand? DeleteUserCommand { get; }
    public IRelayCommand? UpdateUserCommand { get; }

    private void Refresh()
    {
        if (_userCollectionService == null) return;

        Users.Clear();

        foreach (var user in _userCollectionService.GetAll()) Users.Add(user);
    }
}