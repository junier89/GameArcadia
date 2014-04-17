namespace GameArcadia
{
	public static class ScratchCheck
	{
		public static bool CheckIfThereIsSomethingToScore(Turn thisGame)
		{
			if (NumberToBeChecked(thisGame) == 6)
			{
				if (CheckForSixOfAKind(thisGame) || CheckForPairs(thisGame) || CheckForRunOfSix(thisGame))
					return true;
			}
			if (NumberToBeChecked(thisGame) >= 3)
				if (CheckForThreeOfAKind(thisGame))
					return true;
			return CheckForSingles(thisGame);
		}

		private static int NumberToBeChecked(Turn thisGame)
		{
			var numberSetAside = 0;
			for (var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].State.Equals(DieState.Unclicked))
					numberSetAside++;
			return numberSetAside;
		}

		private static bool CheckForSixOfAKind(Turn thisGame)
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
			return isSixOfAKind;
		}

		private static bool CheckForPairs(Turn thisGame)
		{
			var isPairs = false;
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
				isPairs = true;
			return isPairs;
		}

		private static bool CheckForRunOfSix(Turn thisGame)
		{
			int[] quantityOfEachValue = { 0, 0, 0, 0, 0, 0 };
			for (var i = 1; i <= 6; i++)
				for (var j = 0; j < 6; j++)
					if (i == thisGame.CurrentDice[j].Value)
						quantityOfEachValue[i - 1]++;
			var thereIsOneOfEachValue = true;
			for (var i = 0; i < 6; i++)
				if (quantityOfEachValue[i] != 1)
					thereIsOneOfEachValue = false;
			return thereIsOneOfEachValue;
		}
		private static bool CheckForThreeOfAKind(Turn thisGame)
		{
			for (var i = 0; i < 4; i++)
				if (thisGame.CurrentDice[i].State.Equals(DieState.Unclicked))
					for (var j = i + 1; j < 5; j++)
						if (thisGame.CurrentDice[j].State.Equals(DieState.Unclicked)
							&& thisGame.CurrentDice[i].Value == thisGame.CurrentDice[j].Value)
							for (var k = j + 1; k < 6; k++)
								if (thisGame.CurrentDice[k].State.Equals(DieState.Unclicked)
									&& thisGame.CurrentDice[i].Value == thisGame.CurrentDice[k].Value)
									return true;
			return false;
		}

		private static bool CheckForSingles(Turn thisGame)
		{
			for (var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].State.Equals(DieState.Unclicked)
				    && (thisGame.CurrentDice[i].Value == 1 || thisGame.CurrentDice[i].Value == 5))
					return true;
			return false;
		}
		private static int CountQuantityOfAValue(int valueToBeChecked, Turn thisGame)
		{
			var quantityOfValueToBeChecked = 0;
			for (var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].Value == valueToBeChecked && thisGame.CurrentDice[i].State == DieState.Unclicked)
					quantityOfValueToBeChecked++;
			return quantityOfValueToBeChecked;
		}
	}
}
