using System.Linq;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using View.Models.Entities;
using View.Models.Enums;
using View.ViewModels.Services;
using View.Views.AdministratorWindows;
using View.Views.ClassMasterWindows;
using View.Views.StudentWindows;
using View.Views.TeacherWindows;

namespace View.ViewModels.Commands.MainWindowCommands;

public class MainWindowCommands
{
    public MainWindowCommands()
    {
        var userCollectionService = App.Current.Services.GetService<IUserCollectionService>();

        if (userCollectionService == null) return;

        ConnectCommand = new RelayCommand<ConnectionParameters>(connectionParameters =>
        {
            var users = userCollectionService.GetAll();
            foreach (var user in users.Where(user =>
                         user.Username == connectionParameters.Username &&
                         user.Password == connectionParameters.Password))
            {
                MessageBox.Show("Connected");
                OpenUserWindow(user);
                return;
            }

            MessageBox.Show("Wrong username or password");
        });
    }

    public IRelayCommand? ConnectCommand { get; }

    private static void OpenUserWindow(User user)
    {
        Window? window;

        switch (user.Role)
        {
            case Role.Administrator:
                window = new AdministratorMainWindow();
                break;
            case Role.ClassMaster:
                var teacher = App.Current.Services.GetService<ITeacherCollectionService>()?.GetById(user.EntityId);

                if (teacher == null) return;

                window = new ClassMasterMainWindow(teacher);
                break;
            case Role.Student:
                var student = App.Current.Services.GetService<IStudentCollectionService>()?.GetById(user.EntityId);

                if (student == null) return;

                window = new StudentMainWindow(student);
                break;
            case Role.Teacher:
                teacher = App.Current.Services.GetService<ITeacherCollectionService>()?.GetById(user.EntityId);

                if (teacher == null) return;

                window = new TeacherMainWindow(teacher);
                break;
            default:
                MessageBox.Show("User role not found");
                return;
        }

        window.Show();
    }
}

public readonly struct ConnectionParameters
{
    public string Username { get; init; }
    public string Password { get; init; }
}