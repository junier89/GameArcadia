using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameArcadia
{
	public class ChickenLogic
	{
		Turn thisTurn = new Turn();
		public void StartOfAChickenGame(Button button1)
		{
			var score = thisTurn.TurnMain();
			/* Collect Score
			 * Count Score
			 * Repeat
			 * End
			 * Return to the MainWindow
			 */
		}

		public void Roll()
		{
			if (thisTurn.NumberOfSetsOfRolls == 0)
			{
				thisTurn.AddDice();
				thisTurn.RollAllDice();
				thisTurn.NumberOfSetsOfRolls++;
			}
			else if (thisTurn.NumberOfSetsOfRolls > 1)
			{
				//Add logic so that it can determine how many to roll and to keep score.
			}
		}

		public List<int> FindDiceValues()
		{
			var listOfDiceValues = new List<int>();
			for (var i = 0; i < 6; i++)
				listOfDiceValues.Add(thisTurn.CurrentDice[i].Value);
			return listOfDiceValues;
		}

		public string ChangeWhenTheDieIsClicked(int positionOfDie)
		{
			return thisTurn.ChangeIfTheDieIsClicked(positionOfDie);
		}
	}
}