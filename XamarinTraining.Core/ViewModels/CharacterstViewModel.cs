using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinTraining.Core.Domain;

namespace XamarinTraining.Core.ViewModels
{
    public class CharactersViewModel : ViewModelBase
    {
        private ObservableCollection<Character> characters = new ObservableCollection<Character>();
        public ObservableCollection<Character> Characters
        {
            get => characters;
            set => Set(nameof(Characters), ref characters, value);
        }

        public async void LoadDataAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                Characters.Add(new Character { Name = "Test" + Characters.Count });
            }

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                Characters.RemoveAt(0);
            }
        }
    }
}