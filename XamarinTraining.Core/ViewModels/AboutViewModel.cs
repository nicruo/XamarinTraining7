using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.IO;
using Xamarin.Essentials;

namespace XamarinTraining.Core.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public RelayCommand SaveDataCommand => new RelayCommand(SaveData);

        private void SaveData()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(folder, "test.txt");
            File.WriteAllText(filePath, "hello world");
            DataContent = File.ReadAllText(filePath);
        }

        private string dataContent;
        public string DataContent
        {
            get => dataContent;
            set => Set(nameof(DataContent), ref dataContent, value);
        }

        public string AboutTitle
        {
            get => Preferences.Get("about_title", "");
            set
            {
                Preferences.Set("about_title", value);
                RaisePropertyChanged(nameof(AboutTitle));
            }
        }
    }
}