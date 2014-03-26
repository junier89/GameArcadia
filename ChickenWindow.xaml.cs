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
		public void ChangeColorOnClickToCorrectColor(Button thisButton)
		{
			var numberOfButtonClicked = Convert.ToInt32(thisButton.Name.Substring(3, 1));
			var theDieClicked = thisGame.ChangeIfTheDieIsClicked(numberOfButtonClicked);
			if (theDieClicked.Equals("TemporarilySetAside"))
				thisButton.BorderBrush = Brushes.Blue;
			else if (theDieClicked.Equals("Unclicked"))
				thisButton.BorderBrush = Brushes.Gray;
			else
				thisButton.BorderBrush = Brushes.Red;
		}

		public void ChangeAllColorsToCorrectColor()
		{
			var diceArray = new Button[]{Die0, Die1, Die2, Die3, Die4, Die5};
			foreach (Button thisButton in diceArray)
			{
				var count = 0;
				if (thisGame.FindThePositionOfTheDie(count).Equals("TemporarilySetAside"))//Check syntax here
					thisButton.BorderBrush = Brushes.Blue;
				else if (thisGame.FindThePositionOfTheDie(count).Equals("Unclicked"))//Check syntax here
					thisButton.BorderBrush = Brushes.Gray;
				else
					thisButton.BorderBrush = Brushes.Red;
				count++;
			}
		}
    }
}
