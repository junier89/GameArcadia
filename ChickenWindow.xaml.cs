using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace GameArcadia
{

	public partial class ChickenWindow
	{
		private Game game;
		public ChickenWindow()
		{
			InitializeComponent();
		}

		private void NewGameClick(object sender, RoutedEventArgs e)
		{
			game = new Game();
			game.RollTheDice();
			Redraw();
		}

		private void RollTheDice(object sender, RoutedEventArgs e)
		{
			game.RollTheDice();
			Redraw();
		}

		private void DiceClickZero(object sender, RoutedEventArgs e)
		{
			game.DieClick(0);
			Redraw();
		}

		private void DiceClickOne(object sender, RoutedEventArgs e)
		{
			game.DieClick(1);
			Redraw();
		}

		private void DieClickTwo(object sender, RoutedEventArgs e)
		{
			game.DieClick(2);
			Redraw();
		}

		private void DiceClickThree(object sender, RoutedEventArgs e)
		{
			game.DieClick(3);
			Redraw();
		}

		private void DiceClickFour(object sender, RoutedEventArgs e)
		{
			game.DieClick(4);
			Redraw();
		}

		private void DiceClickFive(object sender, RoutedEventArgs e)
		{
			game.DieClick(5);
			Redraw();
		}

		private void Redraw()
		{
			if (game == null)
			{
				var diceButtons = new[] { Die0, Die1, Die2, Die3, Die4, Die5 };
				for (var index = 0; index < diceButtons.Count(); ++index)
				{
					var diceButton = diceButtons[index];
					diceButton.Visibility = Visibility.Hidden;
				}
				InGameButtonPanel.IsEnabled = !IsEnabled;
				//Draw a 'you haven't started playing yet' screen
			}
			else
			{
				InGameButtonPanel.IsEnabled = IsEnabled;
				var diceButtons = new[] {Die0, Die1, Die2, Die3, Die4, Die5};
				for (var index = 0; index < diceButtons.Count(); ++index)
				{
					var diceButton = diceButtons[index];
					diceButton.Visibility = Visibility.Visible;
					var dieState = game.FindDieState(index);
					diceButton.BorderBrush = GetColorForDieButtonBorder(dieState);
					diceButton.Content = game.FindDieValue(index);
				}
				TempScoringLabel.Content = game.GetTurnScore();
				IsScorable.Content = game.GetIsScorable();
			}
		}

		private Brush GetColorForDieButtonBorder(DieState dieState)
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

		private void ChickenWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			Redraw();
		}
	}
}
