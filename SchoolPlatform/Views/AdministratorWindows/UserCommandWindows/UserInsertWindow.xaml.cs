using System;
using System.Windows;
using View.Models.Entities;
using View.Models.Enums;

namespace View.Views.AdministratorWindows.UserCommandWindows;

/// <summary>
///     Interaction logic for UserInsertWindow.xaml
/// </summary>
public partial class UserInsertWindow
{
    public UserInsertWindow()
    {
        InitializeComponent();
        RoleComboBox.ItemsSource = Enum.GetValues(typeof(Role));
    }

    public Action<User>? OnUserInserted { get; set; }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
    {
        if (UsernameTextBox.Text == string.Empty)
        {
            MessageBox.Show("Username can't be empty");
            return;
        }

        if (PasswordTextBox.Text == string.Empty)
        {
            MessageBox.Show("Password can't be empty");
            return;
        }

        if (!int.TryParse(EntityIdTextBox.Text, out _))
        {
            MessageBox.Show("Invalid Id");
            return;
        }

        User user = new()
        {
            Username = UsernameTextBox.Text,
            Password = PasswordTextBox.Text,
            Role = (Role)RoleComboBox.SelectedValue,
            EntityId = int.Parse(EntityIdTextBox.Text)
        };

        OnUserInserted?.Invoke(user);
    }
}