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
		private IList<Die> CurrentDice { get; set; }
		private int NumberOfRolls { get; set; }
		private int Score { get; set; }

		public Turn()
		{
			NumberOfRolls = 0;
			Score = 0;
			CurrentDice = new List<Die>();
		}
		public int TurnMain(Button button1)
		{
			AddDice();
			//button1.Content = CurrentDice[0].Value;
			//RollAllDice();
			/*To do:
			 * interface with the dice
			 * Repeat
			 * Count rolls
			 * Return Score
			 */
			return 0;//Later will return the score for the turn
		}

		private void AddDice()
		{
			if (CurrentDice == null)
			{
				for (var i = 0; i < 6; i++)
					CurrentDice.Add(new Die(i));
			}
		}

		private void RollAllDice()
		{
			for (var i = 0; i < 6; i++)
				CurrentDice[i].RollDie();
			
		}
	}
}
