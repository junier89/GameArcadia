using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameArcadia
{
    /// <summary>
    /// Interaction logic for ChickenWindow.xaml
    /// </summary>
    public partial class ChickenWindow : Window
    {
		ChickenLogic thisGame = new ChickenLogic();
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
			if (theDieClicked.Equals(ScoringClass.TEMPORARILY_SET_ASIDE))
				thisButton.BorderBrush = Brushes.Blue;
			else if (theDieClicked.Equals(ScoringClass.UNCLICKED))
				thisButton.BorderBrush = Brushes.Gray;
			else
				thisButton.BorderBrush = Brushes.Red;
		}

	    private void ChangeAllColorsToCorrectColor()
		{
			ChangeDieToCorrectColor(Die0);
			ChangeDieToCorrectColor(Die1);
			ChangeDieToCorrectColor(Die2);
			ChangeDieToCorrectColor(Die3);
			ChangeDieToCorrectColor(Die4);
			ChangeDieToCorrectColor(Die5);
		}

	    private void ChangeDieToCorrectColor(Button thisButton)
		{
			var numberOfButtonClicked = Convert.ToInt32(thisButton.Name.Substring(3, 1));
			if (thisGame.FindThePositionOfTheDie(numberOfButtonClicked).Equals(ScoringClass.TEMPORARILY_SET_ASIDE))
				thisButton.BorderBrush = Brushes.Blue;
			else if (thisGame.FindThePositionOfTheDie(numberOfButtonClicked).Equals(ScoringClass.UNCLICKED))
				thisButton.BorderBrush = Brushes.Gray;
			else
				thisButton.BorderBrush = Brushes.Red;
	    }
    }
}
