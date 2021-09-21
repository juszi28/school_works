using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	public class Bajnokság
	{
		public int Baj_id { get; set; }
		public string Név { get; set; }
		public string Ország { get; set; }

		public override string ToString()
		{
			return Név;
		}
	}
}
