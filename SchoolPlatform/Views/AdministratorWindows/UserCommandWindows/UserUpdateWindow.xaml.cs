using System;
using System.Windows;
using View.Models.Entities;
using View.Models.Enums;

namespace View.Views.AdministratorWindows.UserCommandWindows;

/// <summary>
///     Interaction logic for UserUpdateWindow.xaml
/// </summary>
public partial class UserUpdateWindow
{
    private readonly User _user;

    public UserUpdateWindow(User user)
    {
        InitializeComponent();

        _user = user;

        UsernameTextBox.Text = user.Username;
        PasswordTextBox.Text = user.Password;
        RoleComboBox.SelectedValue = user.Role;
        EntityIdTextBox.Text = user.EntityId.ToString();

        RoleComboBox.ItemsSource = Enum.GetValues(typeof(Role));
    }

    public Action<User>? OnUserUpdated { get; set; }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
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

        _user.Username = UsernameTextBox.Text;
        _user.Password = PasswordTextBox.Text;
        _user.Role = (Role)RoleComboBox.SelectedValue;
        _user.EntityId = int.Parse(EntityIdTextBox.Text);

        OnUserUpdated?.Invoke(_user);
    }
}