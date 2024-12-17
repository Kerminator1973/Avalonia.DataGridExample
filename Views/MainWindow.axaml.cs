using Avalonia.Controls;
using Avalonia.DataGridExample.ViewModels;
using Avalonia.Threading;
using System;
using System.Linq;

namespace Avalonia.DataGridExample.Views;

public partial class MainWindow : Window
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