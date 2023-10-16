using System;
using System.Collections.Generic;
using SQLite;

namespace Hobby.Models
{
	public class Bruker
	{
        //TODO Eventuelt mail osv må legges til senere
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // Unik ID for brukeren Må fikses
        [Unique]
        public string BrukerNavn { get; set; }
        public List<Aktivitet> MineAktiviteter { get; set; }
        public List<Aktivitet> PaaMeldtAktiviteter { get; set; }

    
        public Bruker()
		{
            MineAktiviteter = new List<Aktivitet>();
            PaaMeldtAktiviteter = new List<Aktivitet>();
        }
	}
}

