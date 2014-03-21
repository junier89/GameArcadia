using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArcadia
{
	class Die
	{
			public int Value { get; set; }
			public int Position { get; set; }
			public bool IsClicked { get; set; }

		public Die(int position)
		{
			Value = 0;
			Position = position;
			IsClicked = false;
		}

		public void RollDie(Random randomNumberGenerator)
		{
			this.Value = randomNumberGenerator.Next(1, 7);
		}
	}
}
