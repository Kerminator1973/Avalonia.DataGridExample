# Project description

The application was generated by using an Avalonia Template (0.10.18.6). The platform is .NET 6.

On the first step I have attached:

- a model (Model/Banknote.cs) with some fake data
- a DataGrid (see: "MainWindow")

Also, some styles were added to the "App.xaml", because without them we can't visualize any data in the DataGrid:

``` csharp
<Application.Styles>
    <StyleInclude Source="avares://Avalonia.Themes.Default/DefaultTheme.xaml"/>
    <StyleInclude Source="avares://Avalonia.Themes.Default/Accents/BaseLight.xaml"/>
    <StyleInclude Source="avares://Avalonia.Controls.DataGrid/Themes/Default.xaml"/>
</Application.Styles>
```

## XAML Behaviors

I also added, I included the Avalonia.XAML.Behaviors package to the .csproj and restored the dependencies.

Next, I added references to the namespace of Avalonia.XAML.Behaviors to the window header:

``` csharp
<Window xmlns="https://github.com/avaloniaui" ...
		xmlns:int="clr-namespace:Avalonia.Xaml.Interactivity;assembly=Avalonia.Xaml.Interactivity"
        xmlns:ia="clr-namespace:Avalonia.Xaml.Interactions.Core;assembly=Avalonia.Xaml.Interactions"
```

The last part of the code change is adding the trigger to the XAML:

``` csharp
<Window.Styles>
    <Style Selector="DataGridCell.statusColumn">
        <Setter Property="FontSize" Value="24"/>
        <Setter Property="(int:Interaction.Behaviors)">
            <int:BehaviorCollectionTemplate>
                <int:BehaviorCollection>
                    <ia:DataTriggerBehavior Binding="{Binding Status}" ComparisonCondition="Equal" Value="Rejected">
                        <ia:ChangePropertyAction TargetObject="DataGridCell" PropertyName="Background" Value="Red" />
                    </ia:DataTriggerBehavior>
                </int:BehaviorCollection>
            </int:BehaviorCollectionTemplate>
        </Setter>
    </Style>
</Window.Styles>
```

## The problem - the DataTriggerBehavior uses wrong data context

When I run the application under debugger, it duplicates massages to the output window:

``` output
[Binding] Error in binding to 'Avalonia.Xaml.Interactions.Core.DataTriggerBehavior'.'Binding': 'Could not find a matching property accessor for 'Status' on 'Avalonia.DataGridExample.ViewModels.MainWindowViewModel'' (DataTriggerBehavior #20745743)
[Binding] Error in binding to 'Avalonia.Xaml.Interactions.Core.DataTriggerBehavior'.'Binding': 'Could not find a matching property accessor for 'Status' on 'Avalonia.DataGridExample.ViewModels.MainWindowViewModel'' (DataTriggerBehavior #2683661)
```

The selector is good, because it changes the font size of the cells in the 'Status' column. The ChangePropertyAction is also good: when I use some property in my MainWindowViewModel, Xaml.Behaviors changes the Background color to red.

Under the debugger, the Developer Console (F12) definitely says that DataGridRow and its children (DataGridCells) refer to a Banknote object (the element of the ObservableCollection).

All the sings claim that the DataContext of the ChangePropertyAction refers to the data context of the ViewModel.
