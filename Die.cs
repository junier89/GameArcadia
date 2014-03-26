using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArcadia
{
	class Die
	{
			public int Value { get; private set; }

			public string Position { get; set; }

		public Die()
		{
			Value = 0;
			Position = ScoringClass.UNCLICKED;
		}

		public void RollDie(Random randomNumberGenerator)
		{
			Value = randomNumberGenerator.Next(1, 7);
		}
	}
}
