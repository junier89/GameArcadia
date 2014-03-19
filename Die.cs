using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArcadia
{
	class Die : OneTurn
	{
			public int Value { get; set; }
			public int Position { get; set; }
		

		private int RollDie()
		{
			var randomNumberGenerator = new Random();
			return randomNumberGenerator.Next(1, 7);
		}
	}
}
