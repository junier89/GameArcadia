using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Label = System.Windows.Controls.Label;

namespace GameArcadia
{
	class Turn
	{
		readonly Random randomNumberGenerator = new Random();
		public IList<Die> CurrentDice { get; set; }
		public int NumberOfSetsOfRolls { get; set; }
		private int Score { get; set; }

		public Turn()
		{
			NumberOfSetsOfRolls = 0;
			Score = 0;
			CurrentDice = new List<Die>();
		}
		public int TurnMain()
		{
			//RollAllDice();
			/*To do:
			 * interface with the dice
			 * Repeat
			 * Count rolls
			 * Return Score
			 */
			return 0;//Later will return the score for the turn
		}

		private int SetOfRolls(int score)
		{
			return 0;
		}

		public void AddDice()
		{
			if (!CurrentDice.Any())
			{
				for (var i = 0; i < 6; i++)
					CurrentDice.Add(new Die(i));
			}
		}

		public void RollAllDice()
		{
			for (var i = 0; i < 6; i++)
				CurrentDice[i].RollDie(randomNumberGenerator);
		}

		public void ChangeIfTheDieIsClicked(int positionOfDie)
		{
			CurrentDice[positionOfDie].IsClicked = !CurrentDice[positionOfDie].IsClicked;
		}
	}
}
