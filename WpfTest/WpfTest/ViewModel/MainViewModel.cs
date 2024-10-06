using System.Windows.Input;
using WpfTest.Base;
using WpfTest.View;

namespace WpfTest.ViewModel;
public class MainViewModel
{
    public ICommand OpenCalculatorCommand { get; }

    public MainViewModel()
    {
        OpenCalculatorCommand = new RelayCommand(OpenCalculatorView);
    }

    private void OpenCalculatorView()
    {
        CalculatorView calculatorView = new CalculatorView();
        calculatorView.ShowDialog();
    }
}
