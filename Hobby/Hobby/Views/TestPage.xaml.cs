using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hobby.Views
{

	public partial class TestPage : ContentPage
	{	
		public TestPage ()
		{
			InitializeComponent ();

            Title = "Test Page";

            //lager en Command med void metode. Husk increasCount blir referansen i Xaml
            FinnHobbySide = new Command(TilFinnHobby);
            // henter variabler fra denne klasse. 
            BindingContext = this;
        }
        ICommand FinnHobbySide { get; }

        async void TilFinnHobby()
        {
            await Navigation.PushAsync(new FinnHoobySide());
        }

        private async void FinnHobbySide_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinnHoobySide()); // NySide er den nye siden du vil navigere til
        }

        private async void AktivitetSide_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AktivitetSide()); // NySide er den nye siden du vil navigere til
        }
        
    }
}

