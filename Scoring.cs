using System.Linq;

namespace GameArcadia
{
	static class ScoringClass
	{
		//Need to score each method and call the method

		public static void ScoreAllSetAsideDice(Turn thisGame)
		{
			if (NumberToBeChecked(thisGame) == 6)
			{
				CheckForSixOfAKind(thisGame);
				CheckForPairs(thisGame);
				CheckForRunOfSix(thisGame);
			}
			if (NumberToBeChecked(thisGame) >= 3)
				CheckForThreeOfAKind(thisGame);
			CheckForSingles(thisGame);
			SetDiceToUnclicked(thisGame);
		}

		private static int NumberToBeChecked(Turn thisGame)
		{
			var numberSetAside = 0;
			for (var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].State.Equals(DieState.TemporarilySetAside))
					numberSetAside++;
			return numberSetAside;
		}

		private static void CheckForSixOfAKind(Turn thisGame)
		{
			var numberToCheck = thisGame.CurrentDice[0].Value;
			var isSixOfAKind = false;
			for (var i = 0; i < 6; i++)
			{
				var currentNumber = thisGame.CurrentDice[i].Value;
				if (currentNumber != numberToCheck)
					break;
				if (i == 6)
				{
					isSixOfAKind = true;
				}
			}
			if (isSixOfAKind)
			{
				SetAllToPermanentlySetAside(thisGame);
				thisGame.Score += 5000;
			}
		}


		private static void CheckForPairs(Turn thisGame)
		{
			var firstValue = thisGame.CurrentDice[0].Value;
			var quantityOfFirstValue = CountQuantityOfAValue(firstValue, thisGame);
			var secondValue = firstValue;
			var i = 0;
			while (firstValue == secondValue && i < 6)
			{
				secondValue = thisGame.CurrentDice[i].Value;
				i++;
			}
			var quantityOfSecondValue = CountQuantityOfAValue(secondValue, thisGame);
			var thirdValue = firstValue;
			var quantityOfThirdValue = 0;
			i = 0;
			while ((firstValue == thirdValue || secondValue == thirdValue) && i < 6)
			{
				thirdValue = thisGame.CurrentDice[i].Value;
				i++;
			}
			if (i != 7)
				quantityOfThirdValue = CountQuantityOfAValue(thirdValue, thisGame);
			if (quantityOfFirstValue == 2 && quantityOfSecondValue == 2 && quantityOfThirdValue == 2)
			{
				SetAllToPermanentlySetAside(thisGame);
				thisGame.Score += 1500;
			}
		}

		private static void CheckForRunOfSix(Turn thisGame)
		{
			int[] quantityOfEachValue = {0, 0, 0, 0, 0, 0};
			for (var i = 1; i <= 6; i++)
				for (var j = 0; j < 6; j++)
					if (i == thisGame.CurrentDice[j].Value)
						quantityOfEachValue[i - 1]++;
			var thereIsOneOfEachValue = true;
			for (var i = 0; i < 6; i++)
				if (quantityOfEachValue[i] != 1)
					thereIsOneOfEachValue = false;
			if (thereIsOneOfEachValue)
			{
				SetAllToPermanentlySetAside(thisGame);
				thisGame.Score += 3000;
			}
		}

		private static void SetAllToPermanentlySetAside(Turn thisGame)
		{
			for (var i = 0; i < 6; i++)
				SetOneToPermanentlySetAside(thisGame, i);
		}

		private static void SetOneToPermanentlySetAside(Turn thisGame, int dieNumber)
		{
			thisGame.CurrentDice[dieNumber].State = DieState.PermanentlySetAside;
		}
		private static void CheckForThreeOfAKind(Turn thisGame)
		{
			var groupsOfThree = thisGame.CurrentDice
				.Where(die => die.State == DieState.TemporarilySetAside)
				.GroupBy(die => die.Value)
				.Where(dieGroup => dieGroup.Count() > 3)
				.Select(dieGroup => 
					new
					{
						dieGroup.Key,
						Dice = dieGroup.Take(3).ToList()
					});
			foreach (var dieGroup in groupsOfThree)
			{
				foreach(var die in dieGroup.Dice)
					die.State = DieState.PermanentlySetAside;
				var dieValue = dieGroup.Key;
				thisGame.Score += dieValue == 1 ? 1000: dieValue * 100;
			}
		}

		private static void CheckForSingles(Turn thisGame)
		{
			for (var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].State.Equals(DieState.TemporarilySetAside)
				    && (thisGame.CurrentDice[i].Value == 1 || thisGame.CurrentDice[i].Value == 5))
				{
					SetOneToPermanentlySetAside(thisGame, i);
					if (thisGame.CurrentDice[i].Value == 1)
						thisGame.Score += 100;
					else
						thisGame.Score += 50;
				}
		}

		private static int CountQuantityOfAValue(int valueToBeChecked, Turn thisGame)
		{
			var quantityOfValueToBeChecked = 0;
			for (var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].Value == valueToBeChecked && thisGame.CurrentDice[i].State == DieState.TemporarilySetAside)
					quantityOfValueToBeChecked++;
			return quantityOfValueToBeChecked;
		}

		private static void SetDiceToUnclicked(Turn thisGame)
		{
			for ( var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].State.Equals(DieState.TemporarilySetAside))
					thisGame.ChangeTheDiesClickedValue(i);
		}
	}
}