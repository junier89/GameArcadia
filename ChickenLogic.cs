using System;
using System.Collections.Generic;
using System.Linq;

namespace GameArcadia
{
	public class ChickenLogic
	{
		readonly Random randomNumberGenerator = new Random();
		public IList<Die> CurrentDice { get; private set; }
		private int NumberOfSetsOfRolls { get; set; }
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
			/* Collect Score
			 * Count Score
			 * Repeat
			 * End
			 * Return to the MainWindow
			 */

		private void AddDice()
		{
			if (!CurrentDice.Any())
			{
				for (var i = 0; i < 6; i++)
					CurrentDice.Add(new Die());
			}
		}

		private void RollAllDice()
		{
			for (var i = 0; i < 6; i++)
				CurrentDice[i].RollDie(randomNumberGenerator);
		}

		private void RollUnclickedDice()
		{
			for (var i = 0; i < 6; i++)
				if (CurrentDice[i].State.Equals(DieState.Unclicked))
					CurrentDice[i].RollDie(randomNumberGenerator);
		}

		public DieState ChangeIfTheDieIsClicked(int stateOfDie)
		{
			ChangeTheDiesClickedValue(stateOfDie);
			return CurrentDice[stateOfDie].State;
		}

		public void ChangeTheDiesClickedValue(int stateOfDie)
		{
			if (CurrentDice[stateOfDie].State.Equals(DieState.Unclicked))
				CurrentDice[stateOfDie].State = DieState.TemporarilySetAside;
			else if (CurrentDice[stateOfDie].State.Equals(DieState.TemporarilySetAside))
				CurrentDice[stateOfDie].State = DieState.Unclicked;
		}

		public DieState FindDieState(int stateOfDie)
		{
			return CurrentDice[stateOfDie].State;
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
				ReorderDice();
				RollUnclickedDice();
				NumberOfSetsOfRolls++;
			}
		}

		public void ReorderDice()
		{
			CurrentDice = CurrentDice.OrderBy(x => x.State).ToList();
		}
	}
}
