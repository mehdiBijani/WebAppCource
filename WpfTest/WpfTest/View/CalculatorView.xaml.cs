using System.Globalization;
using System.Windows;
using WpfTest.ViewModel;

namespace WpfTest.View;

public partial class CalculatorView : Window
{
    public CalculatorView()
    {
        InitializeComponent();
        DataContext = new CalculatorViewModel();
    }
}