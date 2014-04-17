using System;

namespace GameArcadia
{
	public class Die
	{
		public int Value { get; private set; }

		public DieState State { get; set; }

		public Die()
		{
			Value = 0;
			State = DieState.Unclicked;
		}

		public void RollDie()
		{
			var randomNumberGenerator = new Random((int)DateTime.Now.Ticks);
			Value = randomNumberGenerator.Next(1, 7);
		}
	}
}
