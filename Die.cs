using System;

namespace GameArcadia
{
	class Die
	{
		public int Value { get; private set; }

		public DieState State { get; set; }

		public Die()
		{
			Value = 0;
			State = DieState.Unclicked;
		}

		public void RollDie(Random randomNumberGenerator)
		{
			Value = randomNumberGenerator.Next(1, 7);
		}
	}
}
