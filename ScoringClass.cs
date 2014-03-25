using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArcadia
{
	static class ScoringClass
	{
		//Need to score each method and call the method
		public static void ScoreAllSetAsideDice(ChickenLogic thisGame)
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
		}

		private static int NumberToBeChecked(ChickenLogic thisGame)
		{
			var numberSetAside = 0;
			for (var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].Position.Equals("TemporarilySetAside"))
					numberSetAside++;
			return numberSetAside;
		}

		private static void CheckForSixOfAKind(ChickenLogic thisGame)
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
			}
		}


		private static void CheckForPairs(ChickenLogic thisGame)
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
			}
		}

		private static void CheckForRunOfSix(ChickenLogic thisGame)
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
			}
		}

		private static void SetAllToPermanentlySetAside(ChickenLogic thisGame)
		{
			for (var i = 0; i < 6; i++)
				SetOneToPermanentlySetAside(thisGame, i);
		}

		private static void SetOneToPermanentlySetAside(ChickenLogic thisGame, int dieNumber)
		{
			thisGame.CurrentDice[dieNumber].Position = "PermanentlySetAside";
		}
		private static void CheckForThreeOfAKind(ChickenLogic thisGame)
		{
			for (var i = 0; i < 4; i++)
				if (thisGame.CurrentDice[i].Position.Equals("TemporarilySetAside"))
					for (var j = i + 1; j < 5; j++)
						if (thisGame.CurrentDice[j].Position.Equals("TemporarilySetAside") 
							&& thisGame.CurrentDice[i].Value == thisGame.CurrentDice[j].Value)
							for (var k = j + 1; k < 6; k++)
								if (thisGame.CurrentDice[k].Position.Equals("TemporarilySetAside")
								    && thisGame.CurrentDice[i].Value == thisGame.CurrentDice[k].Value)
								{
									SetOneToPermanentlySetAside(thisGame, i);
									SetOneToPermanentlySetAside(thisGame, j);
									SetOneToPermanentlySetAside(thisGame, k);
								}
		}

		private static void CheckForSingles(ChickenLogic thisGame)
		{
			for (var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].Position.Equals("TemporarilySetAside")
				    && (thisGame.CurrentDice[i].Value == 1 || thisGame.CurrentDice[i].Value == 5))
				{
					SetOneToPermanentlySetAside(thisGame, i);
				}

		}

		private static int CountQuantityOfAValue(int valueToBeChecked, ChickenLogic thisGame)
		{
			var quantityOfValueToBeChecked = 0;
			for (var i = 0; i < 6; i++)
				if (thisGame.CurrentDice[i].Value == valueToBeChecked)
					quantityOfValueToBeChecked++;
			return quantityOfValueToBeChecked;
		}
	}
}
