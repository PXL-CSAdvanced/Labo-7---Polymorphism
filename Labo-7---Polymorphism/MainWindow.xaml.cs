using Labo_7___Polymorphism.Data;
using Labo_7___Polymorphism.Entities;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labo_7___Polymorphism;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Store<Machine> _dataStore = new Store<Machine>();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ImportButton_Click(object sender, RoutedEventArgs e)
    {
        const char separator = ',';
        OpenFileDialog ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == true)
        {
            using (StreamReader sr = new StreamReader(ofd.FileName))
            {
                sr.ReadLine();
                string[] data = sr.ReadLine().Split(separator);
                Machine newMachine = null;

                while (!sr.EndOfStream)
                {
                    switch (data[0])
                    {
                        case "L":
                            newMachine = new LaserCutter(data[1], double.Parse(data[2]), double.Parse(data[3]), double.Parse(data[4]), double.Parse(data[5]));
                            break;
                        case "R":
                            newMachine = new Router(data[1], double.Parse(data[2]), double.Parse(data[3]), double.Parse(data[4]));
                            break;
                        default:
                            newMachine = new General(data[1]);
                            break;
                    }
                    _dataStore.AddItem(newMachine);
                    data = sr.ReadLine().Split(separator);
                }
                UpdateListBox();
            }
            clearButton.IsEnabled = true;
            sortButton.IsEnabled = true;
            filterButton.IsEnabled = true;
        }
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        if (_dataStore.RemoveItem((Machine)itemsListBox.SelectedItem))
        {
            UpdateListBox();
        }
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        _dataStore.ClearAllItems();
        UpdateListBox();
    }

    private void UseButton_Click(object sender, RoutedEventArgs e)
    {
        int.TryParse(inputTextBox.Text, out int minutes);
        if (minutes > 0)
        {
            ((Machine)itemsListBox.SelectedItem).Use(minutes);
            UpdateListBox();
        }
    }

    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
        _dataStore.SortItems((x, y) => string.Compare(x.Name, y.Name));
        UpdateListBox();
    }

    private void FilterButton_Click(object sender, RoutedEventArgs e)
    {
        string filter = inputTextBox.Text;
        if (!string.IsNullOrEmpty(filter))
        {
            itemsListBox.Items.Clear();
            foreach (var item in _dataStore.FilterItems(x => x.Name.Contains(filter)))
            {
                itemsListBox.Items.Add(item);
            }
        }
    }

    private void UpdateListBox()
    {
        itemsListBox.Items.Clear();
        foreach (Machine item in _dataStore.GetAllItems())
        {
            itemsListBox.Items.Add(item);
        }

        removeButton.IsEnabled = false;
        useButton.IsEnabled = false;
    }

    private void itemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (itemsListBox.SelectedItem is not null)
        {
            useButton.IsEnabled = !((Machine)itemsListBox.SelectedItem).OutOfUse;
            removeButton.IsEnabled = true;
        }
    }
}