using System;
using Hobby.Models;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.IO;
using System.Collections.Generic;

namespace Hobby.Services
{
	public class BrukerService

	{
        static SQLiteAsyncConnection db;
        public BrukerService()
		{
		}

        //Lager databasen. 
        static async Task Init()
        {
            if (db != null)
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            //krever at Bruker har en parameterløs konstruktør.
            await db.CreateTableAsync<Bruker>();
        }

        public static async Task LeggTilBruker(String brukerNavn)
        {
            await Init();
            if (await brukerNavnFinnes(brukerNavn))
            {
                var bruker = new Bruker
                {
                    BrukerNavn = brukerNavn
                };
                var id = db.InsertAsync(bruker);
            }
            else
            {

            }
        }

        public static async Task FjernBruker(String brukerNavn)
        {
            await Init();
            //TODO
        }

        //Bruker metoden i AktivitetService, men skal lagre den i listen sin. Admin er bruerNavn til den som lager
        public static async Task LagAktivitet(String admin, String aktivitetNavn)
        {
            await Init();
            //TODO
        }
        // Tilsvarende over
        public static async Task FjernAktivitet(String admin, String aktivitetNavn)
        {
            await Init();
            //TODO
        }
        //Bruker metoden i AktivitetService, men skal lagre den i listen sin.
        public static async Task MeldPaaAktivitet(String brukerNavn, String aktivitetNavn)
        {
            await Init();
            //TODO
        }
        // Tilsvarende over
        public static async Task MeldAvAktivitet(String brukerNavn, String aktivitetNavn)
        {
            await Init();
            //TODO
        }

        //Denne bør kun returnere en bruker siden brukerNavn er Unique
        public static async Task<Bruker> FinnBruker(String brukerNavn)
        {
            await Init();
            var query = db.Table<Bruker>().Where(b => b.BrukerNavn.Equals(brukerNavn));
            var bruker = await query.FirstOrDefaultAsync();
            return bruker;
        }

        public static async Task<bool> brukerNavnFinnes(String brukerNavn)
        {
            await Init();
            var result = await db.Table<Bruker>().Where(b => b.BrukerNavn.Equals(brukerNavn)).ToListAsync();
            return result.Count>0;
        }
    }
}

