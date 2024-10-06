using System.Windows;
using WpfTest.ViewModel;

namespace WpfTest.View;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}