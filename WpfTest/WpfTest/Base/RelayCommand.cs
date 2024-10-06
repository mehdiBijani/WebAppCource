using System;
using System.Windows.Input;

namespace WpfTest.Base;
public class RelayCommand : ICommand
{
    private readonly Action _execute;

    public RelayCommand(Action execute)
    {
        _execute = execute;
    }

    public bool CanExecute(object parameter) => true;

    public event EventHandler CanExecuteChanged;

    public void Execute(object parameter)
    {
        _execute?.Invoke();
    }
}
