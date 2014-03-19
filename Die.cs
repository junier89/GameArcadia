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

		public Die(int position)
		{
			Value = 0;
			Position = position;
		}

		public void RollDie()
		{
			var randomNumberGenerator = new Random();
			this.Value = randomNumberGenerator.Next(1, 7);
		}
	}
}
