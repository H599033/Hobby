 

using System;
using Xamarin.Forms;

namespace Hobby.Views
{	
	public partial class FinnHoobySide : ContentPage
	{	
		public FinnHoobySide ()
		{
			InitializeComponent ();

            Title = "Finn Hobby";

            BindingContext = this;
		}
        int count = 0;
        String countDisplay = "Click me!";

       public String CountDisplay
        {
            get => countDisplay;
            set
            {
                if(value == countDisplay)
                {
                    return;
                }
                countDisplay = value;
                OnPropertyChanged();

            }
        }

        private void ButtonClick_ckliked(Object sender, EventArgs e)
        {
            count++;
            CountDisplay = $"You cliced {count} time(s)";

        }

        private void Fjern_clicked(Object sender, EventArgs e)
        {
            count = 0;
            CountDisplay = $"Start på nytt";
        }

        private async void TestPage_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TestPage()); // NySide er den nye siden du vil navigere til
        }

        private async void AktivitetSide_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AktivitetSide()); // NySide er den nye siden du vil navigere til
        }

    }
}

