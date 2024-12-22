## How to change data dynamically 

The code of the application is simple to make it clear.

We can make a few changes to demonstrate how the data can be changed dynamically.

First, we need to provide a way to inform a DataGrid about changes in the model. The DataGrid used in the application is bound to an ObservableCollection containing some records of type Banknote:

```csharp
public MainWindowViewModel()
{
    this.Banknotes = new ObservableCollection<Banknote>(new List<Banknote> {
        new Banknote { Id = 1, Currency = "EUR", Denomination = "20", Status="" },
        new Banknote { Id = 2, Currency = "EUR", Denomination = "50", Status="" },
        new Banknote { Id = 3, Currency = "EUR", Denomination = "100", Status="Rejected" },
        new Banknote { Id = 4, Currency = "USD", Denomination = "100", Status="" },
        new Banknote { Id = 5, Currency = "USD", Denomination = "0", Status="Jammed" }
    });
}
```

So, if you need to notify the DataGrid that any status field in the collection has changed, you need to implement INotifyPropertyChanged.

For simplicity, the only one field sends the PropertyChanged event:

```csharp
public class Banknote : INotifyPropertyChanged
{
    public int Id { get; set; }
    public string Currency { get; set; } = null!;
    public string Denomination { get; set; } = null!;

    private string _status;
    public string Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

Let's run a timer for two seconds and change some records when it's finished. It'll dynamically change the DataGrid presentation. For instance let's change the status "Rejected" to "Jammed":

```csharp
{
    public MainWindow()
    {
        InitializeComponent();

        StartTimer();
    }

    private void StartTimer()
    {
        var timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(2) // Set the interval to 2 seconds
        };

        timer.Tick += Timer_Tick;

        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        var timer = sender as DispatcherTimer;
        timer.Stop();

        var context = DataContext as MainWindowViewModel;
        if (context != null)
        {
            var item = context.Banknotes.FirstOrDefault(p => p.Status.Equals("Rejected", StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.Status = "Jammed";
            }
        }
    }
}
```
