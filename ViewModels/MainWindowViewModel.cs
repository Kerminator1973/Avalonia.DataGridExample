using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.DataGridExample.Models;

namespace Avalonia.DataGridExample.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Banknote> Banknotes { get; }

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
}