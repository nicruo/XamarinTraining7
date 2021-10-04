using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading.Tasks;
using XamarinTraining.Core.Domain;
using XamarinTraining.Core.Services;

namespace XamarinTraining.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private IDataService dataService;
        private IToastService toastService;
        private readonly INavigationService navigationService;
        private int counter;

        public RelayCommand LoadDataCommand => new RelayCommand(LoadApplicationTitleAsync);
        public RelayCommand NavigateToAboutCommand => new RelayCommand(NavigateToAbout);

        private void NavigateToAbout()
        {
            navigationService.NavigateTo(nameof(CharactersViewModel));
        }

        private string applicationTitle;
        public string ApplicationTitle
        {
            get => applicationTitle;
            set => Set(nameof(ApplicationTitle), ref applicationTitle, value);
        }

        public HomeViewModel(IDataService dataService, IToastService toastService, INavigationService navigationService)
        {
            this.dataService = dataService;
            this.toastService = toastService;
            this.navigationService = navigationService;
        }

        private async void LoadApplicationTitleAsync()
        {
            toastService.ShowToast("button clicked");
            await Task.Delay(1000);
            ApplicationTitle = counter++ + " volta(s)";
            Character result = await dataService.GetCharacterAsync(2);
            ApplicationTitle = "Result = " + result;
        }        
    }
}