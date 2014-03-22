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
			thisGame.StartOfAChickenGame(this.Dice0);//Can I get the buttons in an array/list?
			//This should make the dice visible
		}

		private void RollTheDice(object sender, RoutedEventArgs e)
		{
			thisGame.Roll();
			SetDiceValues();
		}

	    private void SetDiceValues()
	    {
		    var valuesOfTheDice = thisGame.FindDiceValues();
			Dice0.Content = valuesOfTheDice[0];
			Dice1.Content = valuesOfTheDice[1];
			Dice2.Content = valuesOfTheDice[2];
			Dice3.Content = valuesOfTheDice[3];
			Dice4.Content = valuesOfTheDice[4];
			Dice5.Content = valuesOfTheDice[5];
	    }
		private void DiceClick(object sender, RoutedEventArgs e)
		{
			var button = (Button)sender;
			var numberOfButtonClicked = Convert.ToInt32(button.Name.Substring(4, 1));
			var theDieClicked = thisGame.ChangeWhenTheDieIsClicked(numberOfButtonClicked);
			if (theDieClicked.Equals("TemporarilySetAside"))
				button.BorderBrush = Brushes.Blue;
			else if (theDieClicked.Equals("Unclicked"))
				button.BorderBrush = Brushes.Black;
			else
				button.BorderBrush = Brushes.Red;
		}
    }
}
