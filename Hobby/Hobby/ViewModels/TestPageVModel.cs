using System;
using System.Windows.Input;
using Android.Content.Res;
using Hobby.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace Hobby.ViewModels
{
    public class TestPageVModel : ViewModelBase
    {
		public TestPageVModel()
		{
            IncreasCount = new Command(OnIncreas);
            DecreasCount = new Command(OnDecreas);
        }
        public ICommand IncreasCount { get; }
        public ICommand DecreasCount { get; }
        ICommand FinnHobbySide { get; }


        int count = 0;
        String countDisplay = "Click me!";

        public String CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
        }

        void OnIncreas()
        {
            count++;
            CountDisplay = $"You cliced {count} time(s)";
        }

        void OnDecreas()
        {
            count = 0;
            CountDisplay = $"Start på nytt";
        }

    }
}

