using System;
using System.Collections.Generic;
using System.Diagnostics;
using Hobby.Models;
using Hobby.Services;
using Xamarin.Forms;

namespace Hobby.Views
{	
	public partial class AktivitetSide : ContentPage
	{	
		public AktivitetSide ()
		{
			InitializeComponent ();
        }

        private async void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var aktivitet = ((ListView)sender).SelectedItem as Aktivitet;
            if (aktivitet == null)
                return;
            await DisplayAlert("Aktivitet valgt ", aktivitet.AktivitetNavn, "ok");
        }

        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            //hvis noe er selected så blir den av selected med en gang 
            ((ListView)sender).SelectedItem = null;
        }

        private async void MenuItem_Clicked(System.Object sender, System.EventArgs e)
        {
            var aktivitet = ((MenuItem)sender).BindingContext as Aktivitet;

            await DisplayAlert("Aktivitet ", aktivitet.AktivitetNavn, " til favorit");
        }
    }
}
 
