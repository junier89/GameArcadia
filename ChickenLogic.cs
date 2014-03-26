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
	class ChickenLogic
	{
		readonly Random randomNumberGenerator = new Random();
		public IList<Die> CurrentDice { get; set; }
		public int NumberOfSetsOfRolls { get; set; }
		public string Score { get; set; }

		public ChickenLogic()
		{
			NumberOfSetsOfRolls = -1;
			Score = "";
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

		private void RollUnclickedDice()
		{
			for (var i = 0; i < 6; i++)
				if (CurrentDice[i].Position.Equals(ScoringClass.UNCLICKED))
					CurrentDice[i].RollDie(randomNumberGenerator);
		}

		public string ChangeIfTheDieIsClicked(int positionOfDie)
		{
			ChangeTheDiesClickedValue(positionOfDie);
			return CurrentDice[positionOfDie].Position;
		}

		public void ChangeTheDiesClickedValue(int positionOfDie)
		{
			if (CurrentDice[positionOfDie].Position.Equals(ScoringClass.UNCLICKED))
				CurrentDice[positionOfDie].Position = ScoringClass.TEMPORARILY_SET_ASIDE;
			else if (CurrentDice[positionOfDie].Position.Equals(ScoringClass.TEMPORARILY_SET_ASIDE))
				CurrentDice[positionOfDie].Position = ScoringClass.UNCLICKED;
		}

		public string FindThePositionOfTheDie(int positionOfDie)
		{
			return CurrentDice[positionOfDie].Position;
		}
		public void Roll()
		{
			if (NumberOfSetsOfRolls == -1)
			{
				AddDice();
				NumberOfSetsOfRolls++;
			}
			if (NumberOfSetsOfRolls == 0)
			{
				RollAllDice();
				NumberOfSetsOfRolls++;
			}
			else if (NumberOfSetsOfRolls > 0)
			{
				ScoringClass.ScoreAllSetAsideDice(this);
				RollUnclickedDice();
				NumberOfSetsOfRolls++;
			}
		}
	}
}
