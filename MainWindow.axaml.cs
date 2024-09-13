using Avalonia.Controls;

namespace Demo;

public partial class MainWindow : Window
{
    private string name;
    public MainWindow()
    {
        InitializeComponent();

    }

    private void User_batton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        name = "user";
        new Window1(name).Show();
        Close();

    }

    private void AdminClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

         Vvod_Parol.IsVisible= true;
        TextEnter.IsVisible= true;
        name = "admin";
    }

    private void TextBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        if (e.Key == Avalonia.Input.Key.Enter)
        {
            
            var inputText = Vvod_Parol.Text;
            if(inputText == "0000" && name == "admin") { new Window1(name).Show();
                Close();
            }

        }
    }

 
}