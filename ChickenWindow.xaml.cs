using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameArcadia
{
	public partial class ChickenWindow
	{
		readonly ChickenLogic thisGame = new ChickenLogic();
		public ChickenWindow()
		{
			InitializeComponent();
		}

		private void NewGameClick(object sender, RoutedEventArgs e)
		{
			//thisGame.StartOfAChickenGame();//Can I get the buttons in an array/list?
			//This should make the dice visible
		}

		private void RollTheDice(object sender, RoutedEventArgs e)
		{
			thisGame.Roll();
			SetDiceValues();
			ChangeAllColorsToCorrectColor();
			TempScoringLabel.Content = Convert.ToString(thisGame.Score);
		}

		private void SetDiceValues()
		{
			var valuesOfTheDice = thisGame.FindDiceValues();
			Die0.Content = valuesOfTheDice[0];
			Die1.Content = valuesOfTheDice[1];
			Die2.Content = valuesOfTheDice[2];
			Die3.Content = valuesOfTheDice[3];
			Die4.Content = valuesOfTheDice[4];
			Die5.Content = valuesOfTheDice[5];
		}
		private void DiceClick(object sender, RoutedEventArgs e)
		{
			var button = (Button)sender;
			ChangeColorOnClickToCorrectColor(button);
		}
		private void ChangeColorOnClickToCorrectColor(Button thisButton)
		{
			var numberOfButtonClicked = Convert.ToInt32(thisButton.Name.Substring(3, 1));
			var theDieClicked = thisGame.ChangeIfTheDieIsClicked(numberOfButtonClicked);
			if (theDieClicked.Equals(DieState.TemporarilySetAside))
				thisButton.BorderBrush = Brushes.Blue;
			else if (theDieClicked.Equals(DieState.Unclicked))
				thisButton.BorderBrush = Brushes.Gray;
			else
				thisButton.BorderBrush = Brushes.Red;
		}

		private void ChangeAllColorsToCorrectColor()
		{
			var diceButtons = new [] { Die0, Die1, Die2, Die3, Die4, Die5 };
			for (var index = 0; index < diceButtons.Count(); ++index)
			{
				var diceButton = diceButtons[index];
				if (thisGame.FindThePositionOfTheDie(index).Equals(DieState.TemporarilySetAside))
					diceButton.BorderBrush = Brushes.Blue;
				else if (thisGame.FindThePositionOfTheDie(index).Equals(DieState.Unclicked))
					diceButton.BorderBrush = Brushes.Gray;
				else
					diceButton.BorderBrush = Brushes.Red;
			}
		}
	}
}
