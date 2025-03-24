using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Mvvm;
using MauiBookGiveaway.Domain.Data;
using MauiBookGiveaway.Domain.Services;

namespace MauiBookGiveaway.ViewModels;

public partial class MvvmViewModel : ObservableObject {

    [ObservableProperty]
    ObservableCollection<Customer>? customers;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(InitializeCommand))]
    bool isInitialized;

    readonly IDataService dataService;
    readonly IDXPopupService popupService;
    public MvvmViewModel(IDataService dataService, IDXPopupService popupService) {
        this.dataService = dataService;
        this.popupService = popupService;
    }

    [RelayCommand(CanExecute = nameof(CanInitialize))]
    async Task InitializeAsync() {
        Customers = new ObservableCollection<Customer>(await dataService.GetCustomersAsync());
        IsInitialized = true;
    }

    bool CanInitialize() => !IsInitialized;

    Random rnd = new Random();

    [RelayCommand]
    async Task SelectNextWinner()
    {
        Customer winner = customers[rnd.Next(0, customers.Count)];
        popupService.ShowAlert(new DXPopupSettings() { Title = "Winner", TitleIcon = "star", Message = $"The winner is: {winner.FirstName} {winner.LastName}. Congratulations!!!" }, "OK", "Candel");
    }
}
