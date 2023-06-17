using System.Windows;
using View.ViewModels.Commands.MainWindowCommands;

namespace View;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ConnectButton_Click(object sender, RoutedEventArgs e)
    {
        ConnectionParameters connectionParameters = new()
        {
            Username = UsernameTextBox.Text,
            Password = PasswordPasswordBox.Password
        };

        MainWindowCommands mainWindowCommands = new();
        mainWindowCommands.ConnectCommand?.Execute(connectionParameters);
    }
}