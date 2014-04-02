using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameArcadia
{
	public partial class ChickenWindow
	{
		readonly ChickenLogic chickenLogic = new ChickenLogic();
		public ChickenWindow()
		{
			InitializeComponent();
		}

		private void NewGameClick(object sender, RoutedEventArgs e)
		{
			//chickenLogic.StartOfAChickenGame();//Can I get the buttons in an array/list?
			//This should make the dice visible
		}

		private void RollTheDice(object sender, RoutedEventArgs e)
		{
			chickenLogic.Roll();
			SetDiceValues();
			ChangeAllColorsToCorrectColor();
			TempScoringLabel.Content = Convert.ToString(chickenLogic.Score);
			IsScorable.Content = ScratchCheck.CheckIfThereIsSomethingToScore(chickenLogic);
		}

		private void SetDiceValues()
		{
			var valuesOfTheDice = chickenLogic.FindDiceValues();
			Die0.Content = valuesOfTheDice[0];
			Die1.Content = valuesOfTheDice[1];
			Die2.Content = valuesOfTheDice[2];
			Die3.Content = valuesOfTheDice[3];
			Die4.Content = valuesOfTheDice[4];
			Die5.Content = valuesOfTheDice[5];
		}
		private void DiceClickOne(object sender, RoutedEventArgs e)
		{
			ChangeColorOnClickToCorrectColor(sender as Button, 0);
		}

		private void DiceClickTwo(object sender, RoutedEventArgs e)
		{
			ChangeColorOnClickToCorrectColor(sender as Button, 1);
		}

		private void DiceClickThree(object sender, RoutedEventArgs e)
		{
			ChangeColorOnClickToCorrectColor(sender as Button, 2);
		}

		private void DiceClickFour(object sender, RoutedEventArgs e)
		{
			ChangeColorOnClickToCorrectColor(sender as Button, 3);
		}

		private void DiceClickFive(object sender, RoutedEventArgs e)
		{
			ChangeColorOnClickToCorrectColor(sender as Button, 4);
		}

		private void DiceClickSix(object sender, RoutedEventArgs e)
		{
			ChangeColorOnClickToCorrectColor(sender as Button, 5);
		}
		private void ChangeColorOnClickToCorrectColor(Button button, int index)
		{
			var postClickDieState = chickenLogic.ChangeIfTheDieIsClicked(index);
			button.BorderBrush = GetColorForButtonBorder(postClickDieState);
		}

		private void ChangeAllColorsToCorrectColor()
		{
			var diceButtons = new [] { Die0, Die1, Die2, Die3, Die4, Die5 };
			for (var index = 0; index < diceButtons.Count(); ++index)
			{
				var diceButton = diceButtons[index];
				var dieState = chickenLogic.FindDieState(index);
				diceButton.BorderBrush = GetColorForButtonBorder(dieState);
			}
		}

		private Brush GetColorForButtonBorder(DieState dieState)
		{
			switch (dieState)
			{
				case DieState.Unclicked:
					return Brushes.Gray;
				case DieState.TemporarilySetAside:
					return Brushes.Blue;
				case DieState.PermanentlySetAside:
					return Brushes.Red;
				default:
					throw new InvalidOperationException("Invalid die state encountered.");
			}
		}
	}
}
