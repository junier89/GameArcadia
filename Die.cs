using System;

namespace GameArcadia
{
	public class Die
	{
		public int Value { get; private set; }

		public DieState State { get; set; }

		private static readonly Random RandomNumberGenerator = new Random();

		public Die()
		{
			Value = 0;
			State = DieState.Unclicked;
		}

		public void RollDie()
		{
			Value = RandomNumberGenerator.Next(1, 7);
		}
	}
}
