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
			thisGame.StartOfAChickenGame(this.Dice1);//Can I get the buttons in an array/list?
		}

		private void RollTheDice(object sender, RoutedEventArgs e)
		{
			thisGame.Roll();
			SetDiceValues();
		}

	    private void SetDiceValues()
	    {
		    var valuesOfTheDice = thisGame.FindDiceValues();
			Dice1.Content = valuesOfTheDice[0];
			Dice2.Content = valuesOfTheDice[1];
			Dice3.Content = valuesOfTheDice[2];
			Dice4.Content = valuesOfTheDice[3];
			Dice5.Content = valuesOfTheDice[4];
			Dice6.Content = valuesOfTheDice[5];
	    }
    }
}
