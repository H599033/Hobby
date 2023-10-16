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

        private async void OpprettAktivitet_Clicked(object sender, EventArgs e)
        {
            try
            {
                string nyttAktivitetsNavn = aktivitetsNavnEntry.Text;
                if (!string.IsNullOrEmpty(nyttAktivitetsNavn))
                {
                    // Opprett ny aktivitet med navn i databasen
                    await AktivitetService.LagAktivitetForTest(nyttAktivitetsNavn);

                    // Oppdater visningen av aktiviteter på siden
                    OppdaterAktivitetsVisning();
                }
            }
            catch (Exception ex)
            {
                // Logg unntaket for feilsøking
                Debug.WriteLine($"Feil: {ex.Message}");
            }
        }

        private async void OppdaterAktivitetsVisning()
        {
            // Hent alle aktiviteter fra databasen
            var alleAktiviteter = await AktivitetService.AlleAktiviteter();

            // Fjern eksisterende Label-elementer fra stackLayout
            // AktiviteterLayout refereres i XAML koden.
            AktiviteterLayout.Children.Clear();

            // Oppdater visningen på siden med alle aktivitetene
            foreach (var aktivitet in alleAktiviteter)
            {
                var label = new Label
                {
                    Text = aktivitet.AktivitetNavn
                };
                AktiviteterLayout.Children.Add(label);
            }
        }

    }
}

