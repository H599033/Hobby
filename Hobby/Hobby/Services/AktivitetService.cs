using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hobby.Models;
using SQLite;
using Xamarin.Essentials;

namespace Hobby.Services
{
	public class AktivitetService
	{
		static SQLiteAsyncConnection db;

		public AktivitetService()
		{ }

        //Lager databasen. 
        static async Task Init()
        {
            if (db != null)
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            //krever at Bruker har en parameterløs konstruktør.
            await db.CreateTableAsync<Aktivitet>();
        }

        public static async Task LagAktivitetForTest(String aktivitetNavn)
        {
            await Init();
            var aktivitet = new Aktivitet
            {
                AktivitetNavn = aktivitetNavn,
            };
            var id = await db.InsertAsync(aktivitet);
        }

        // Admin skal være brukernavn til admin.
        public static async Task LagAktivitet(String aktivitetNavn, String admin, Katogori_Enum katogori)
        {
            await Init();
            var adminBruker = await BrukerService.FinnBruker(admin);

               if(adminBruker != null)
            {
                var aktivitet = new Aktivitet
                {
                    AktivitetNavn = aktivitetNavn,
                    AdMin = adminBruker,
                    Katogori = katogori
                };

                // Legg aktiviteten inn i databasen og sett id lik verdien som blir returnert
                var id = await db.InsertAsync(aktivitet);
            }
            else
            {
                //TODO gir en feil melding om admin ikke funker.
                //Må være logget inn osv så tar dette senere
                
            }
        }


        public static async Task FjernAktivitet(int id )
        {
            await Init();

            await db.DeleteAsync<Aktivitet>(id);

        }


        //TODO må fikse slik at avstand kan bli bestemt. (Fikser grunnleggende ting før gps blir lagt til. gps finnes i nudgets)
        // Kanksje ha en maks avstand hvis ikke valgt.
        // Eller sortere listen basert på avstand. 
        public static async Task <IEnumerable<Aktivitet>> FinnAktivitetKatogori(Katogori_Enum katogori)
        {
            await Init();

            var aktivitetliste = db.Table<Aktivitet>().Where(aktivitet => aktivitet.Katogori.Equals(katogori));
            var aktivitetene = await aktivitetliste.ToListAsync();
            return aktivitetene;
        }

        public static async Task<IEnumerable<Aktivitet>> AlleAktiviteter()
        {
            await Init();

            var alleAktiviteter = await db.Table<Aktivitet>().ToListAsync();
            return alleAktiviteter;
        }

        public static async Task MeldPaaAktivitet(String brukerNavn, String aktivitetNavn)
        {
            await Init();
            //TODO
        }

        public static async Task FjernMedlem(String aktivitetNavn,  String brukerNavn)
        {
            await Init();
            //TODO
        }

        public static async Task BestemKatogori(Katogori_Enum katogori)
        {
            await Init();
            //TODO
        }

    }

}


