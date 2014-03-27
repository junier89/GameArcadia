using System;

namespace GameArcadia
{
	class Die
	{
		public int Value { get; private set; }

		public DieState Position { get; set; }

		public Die()
		{
			Value = 0;
			Position = DieState.Unclicked;
		}

		public void RollDie(Random randomNumberGenerator)
		{
			Value = randomNumberGenerator.Next(1, 7);
		}
	}
}
