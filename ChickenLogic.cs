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
		public List<int> FindDiceValues()
		{
			var listOfDiceValues = new List<int>();
			for (var i = 0; i < 6; i++)
				listOfDiceValues.Add(CurrentDice[i].Value);
			return listOfDiceValues;
		}
			/*To do:
			 * interface with the dice
			 * Repeat
			 * Count rolls
			 * Return Score
			 */
			/* Collect Score
			 * Count Score
			 * Repeat
			 * End
			 * Return to the MainWindow
			 */

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

		public string ChangeIfTheDieIsClicked(int positionOfDie)
		{
			if (CurrentDice[positionOfDie].Position.Equals("Unclicked"))
				CurrentDice[positionOfDie].Position = "TemporarilySetAside";
			else if (CurrentDice[positionOfDie].Position.Equals("TemporarilySetAside"))
				CurrentDice[positionOfDie].Position = "Unclicked";
			return CurrentDice[positionOfDie].Position;
		}

		public void SetAsideDice()
		{
			for (var i = 0; i < 6; i++)
				SetAsideDie(i);
		}

		public void SetAsideDie(int positionOfDie)
		{
			if (CurrentDice[positionOfDie].Position.Equals("TemporarilySetAside"))
				CurrentDice[positionOfDie].Position = "PermenatlySetAside";
		}
		public void Roll()
		{
			if (NumberOfSetsOfRolls == 0)
			{
				AddDice();
				RollAllDice();
				NumberOfSetsOfRolls++;
			}
			else if (NumberOfSetsOfRolls > 1)
			{
				//Add logic so that it can determine how many to roll and to keep score.
			}
		}

	}
}
