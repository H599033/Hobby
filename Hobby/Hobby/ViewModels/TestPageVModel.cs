using System;
using System.Windows.Input;
using Android.Content.Res;
using Hobby.Views;
using Xamarin.Forms;

namespace Hobby.ViewModels
{
	public class TestPageVModel : BindableObject
	{
		public TestPageVModel()
		{
            IncreasCount = new Command(OnIncreas);
            DecreasCount = new Command(OnDecreas);
        }
        public ICommand IncreasCount { get; }
        public ICommand DecreasCount { get; }



        int count = 0;
        String countDisplay = "Click me!";

        public String CountDisplay
        {
            get => countDisplay;
            set
            {
                if (value == countDisplay)
                {
                    return;
                }
                countDisplay = value;

                OnPropertyChanged();
            }
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

