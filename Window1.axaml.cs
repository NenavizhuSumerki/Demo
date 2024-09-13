using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo.EntityModels;
using System.Collections.Generic;
using System.Linq;

namespace Demo;

public partial class Window1 : Window
{
    private string name;
    private bool Isvisible;
    private List<Service> allUslugi; // ������ ��� �������� ���� �����
    public Window1()
    {
        InitializeComponent();
        Listbox.ItemsSource = Context.ListUslugi;
        allUslugi = Context.ListUslugi.ToList(); // �������� ��� ������ �� ���������
        Listbox.ItemsSource = allUslugi; // ������������� �������� ������
    }
    public Window1(string name)
    {
    InitializeComponent();

        allUslugi = Context.ListUslugi.ToList(); // �������� ��� ������ �� ���������
        Listbox.ItemsSource = allUslugi; // ������������� �������� ������

        Listbox.ItemsSource = Context.ListUslugi;
        this.name = name;

        if (name == "admin")
        {
            Dobavit.IsVisible = true;
        }
        else
        {
            Dobavit.IsVisible = false;
        }


    }

    private void Click_Dobavit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Dobavit().Show();
        
    }

    private void KeyUp_Poisk(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        // �������� ���������� ��� ������� �������
        FilterList();
    }

    private void ComboBox_Discount(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        // �������� ���������� ��� ��������� ������ �������������
        FilterList();
    }

    private void ComboBox_Cena(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        // �������� ���������� ��� ��������� ������ ����
        FilterList();
    }

    private void FilterList()
    {
        string searchText = ProductSearchTextBox.Text?.ToLower() ?? string.Empty;
        string selectedCategory = ComboDiscount.SelectedItem as string; // ��������������, ��� ��� ������
        decimal? selectedPrice = ComboPrice.SelectedItem as decimal?; // ��������������, ��� ��� �����

        // ���������� �����
        var filteredUslugi = allUslugi.Where(usluga =>
            (string.IsNullOrEmpty(searchText) || usluga.Title.ToLower().Contains(searchText)) &&
            
            (!selectedPrice.HasValue || usluga.Cost <= selectedPrice.Value) // ��������������, ��� � ��� ���� �������� Cost
        ).ToList();

        Listbox.ItemsSource = filteredUslugi; // ��������� �������� ������ ��� ListBox
    }
}