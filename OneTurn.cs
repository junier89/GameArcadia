using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArcadia
{
	class OneTurn : ChickenLogic
	{
		private IList<Die> CurrentDice { get; set; }
		private int NumberOfRolls { get; set; }
		private int Score { get; set; }

		public OneTurn()
		{
			NumberOfRolls = 0;
			Score = 0;
		}
		public int OneTurnMain()
		{
			AddDice();
			RollDice();
			/*To do:
			 * interface with the dice
			 * Repeat
			 * Count rolls
			 * Return Score
			 */
			return 0;
		}

		private void AddDice()
		{
			if (CurrentDice[5].Value <= 7 && CurrentDice[5].Value >= 0)//E: Can this be changed to "if not null"?
			for (var i = 0; i < 6; i++)
			{
				CurrentDice.Add(new Die(i));
			}
		}

		private void RollDice()
		{
			for (var i = 0; i < 6; i++)
				CurrentDice[i].RollDie();
		}
	}
}
