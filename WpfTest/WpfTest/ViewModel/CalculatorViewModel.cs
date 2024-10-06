using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WpfTest.Base;

namespace WpfTest.ViewModel;

public class CalculatorViewModel : INotifyPropertyChanged
{
    #region Constructor

    public CalculatorViewModel()
    {
        Model = new CalculatorModel();
        CalculateCommand = new RelayCommand(Calculate);
    }

    public ICommand CalculateCommand { get; }
    public CalculatorModel Model { get; set; }

    #endregion

    #region Property

    public long? TimeSpan
    {
        get => Model.TimeSpan;
        set
        {
            Model.TimeSpan = value;
            OnPropertyChanged(nameof(TimeSpan));
        }
    }

    public double? Fund
    {
        get => Model.Fund;
        set
        {
            Model.Fund = value;
            OnPropertyChanged(nameof(Fund));
        }
    }

    public double? Result
    {
        get => Model.Result;
        set
        {
            Model.Result = value;
            OnPropertyChanged(nameof(Result));
        }
    }

    #endregion

    #region Method

    private void Calculate()
    {
        var list = new List<double> { (double)Fund! };
        double result = 0;
        var timeSpan = TimeSpan - 31;

        for (int i = 0; i < timeSpan; i++)
        {
            var income = DailyProfit(list.Sum(x => x));

            if (list.Count == 30)
                list.RemoveAt(0);

            list.Add(income);
        }
        
        var removeCounter = 0;
        var deleteOnCount = 30 - list.Count;

        for (int i = 0; i < 30; i++)
        {
            var income = DailyProfit(list.Sum(x => x));

            if (removeCounter == deleteOnCount)
                list.RemoveAt(0);
            else
                removeCounter += 1;

            result += income;
        }

        Result = result;
    }

    public double DailyProfit(double fund)
    {
        return fund * 5 / 100;
    }

    #endregion

    #region Other

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}