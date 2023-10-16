using System;
using System.Collections.Generic;
using SQLite;

namespace Hobby.Models
{
	public class Aktivitet
	{
		[PrimaryKey,AutoIncrement]
		public int Id {get; set;} 
		public String AktivitetNavn {get; set;}
        public Bruker AdMin {get; set;}
        public List<Bruker> MeldtPaa {get; set;}
		public Katogori_Enum Katogori {get; set;}

		//TODO Måtte være parameterløs for lagingen av databasen se Init i AktivitetSercie
		public Aktivitet()
		{
			MeldtPaa = new List<Bruker>();
			
		}
	}
}

