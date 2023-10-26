using System;
using System.Linq;
using System.Threading.Tasks;
using Hobby.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace Hobby.ViewModels
{
	public class AktivitetSide_VModel: ViewModelBase
    {
		public ObservableRangeCollection<Aktivitet> aktivitet { get; set; }
        public ObservableRangeCollection<Grouping<String,Aktivitet>> aktivitetGruppe { get; set; }

		public AsyncCommand RefreshCommand { get; }
        public AsyncCommand SelectedCommand { get; }
        public AktivitetSide_VModel()
		{
			aktivitet = new ObservableRangeCollection<Aktivitet>();
			aktivitetGruppe = new ObservableRangeCollection<Grouping<string, Aktivitet>>();

			aktivitet.Add(new Aktivitet { Katogori = Katogori_Enum.KAFFE, AktivitetNavn = "Ta en kopp kaffe"  });
            aktivitet.Add(new Aktivitet { Katogori = Katogori_Enum.BRETTSPILL, AktivitetNavn = "Spile DnD" });
            aktivitet.Add(new Aktivitet { Katogori = Katogori_Enum.SPORT,AktivitetNavn = "FrisbeeGolf fyllingen" });
            aktivitet.Add(new Aktivitet { Katogori = Katogori_Enum.SPORT, AktivitetNavn = "FrisbeeGolf åsane" });

			//aktivitetGruppe.Add(new Grouping<string, Aktivitet>("DnD", new[] { aktivitet })) ;
            aktivitetGruppe.Add(new Grouping<string, Aktivitet>("FrisbeeGolf",aktivitet.Take(2) ));
            RefreshCommand = new AsyncCommand(Refresh);
			

        }

		Aktivitet selectedAktivitet;
		public Aktivitet SelectedAkticitet
		{
			get => selectedAktivitet;
			set => SetProperty(ref selectedAktivitet, value);
        }

		async Task Selected (Aktivitet aktivitet)
		{
			if (aktivitet == null)
				return;

			await Application.Current.MainPage.DisplayAlert("Selected", aktivitet.AktivitetNavn, "OK");
		}

		async Task Refresh()
		{
			IsBusy = true;

			await Task.Delay(2000);
		

			IsBusy = false;
		}



	}
}

