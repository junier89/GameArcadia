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
	/// Interaction logic for ColorettoGameSetup.xaml
	/// </summary>
	public partial class ColorettoGameSetup : Window
	{
		public ColorettoGameSetup()
		{
			ColorettoWindow.NumberOfPlayers = 0;
			InitializeComponent();
			StartColorettoButton.IsEnabled = false;
		}

		private void CancelClick(object sender, RoutedEventArgs e)
		{
			ColorettoWindow.NumberOfPlayers = 0;
			Close();
		}

		private void StartColorettoClick(object sender, RoutedEventArgs e)
		{
			var numberOfPlayers = 0;
			if (TwoRadioButton.IsChecked == true)
				numberOfPlayers = 2;
			else if (TwoRadioButton.IsChecked == true)
				numberOfPlayers = 3;
			else if (FourRadioButton.IsChecked == true)
				numberOfPlayers = 4;
			else if (FiveRadioButton.IsChecked == true)
				numberOfPlayers = 5;
			if (numberOfPlayers != 0)
			{
				
				Close();
			}
		}

		private void TwoPlayerClick(object sender, RoutedEventArgs e)
		{
			ColorettoWindow.NumberOfPlayers = 2;
			StartColorettoButton.IsEnabled = true;
		}

		private void ThreePlayerClick(object sender, RoutedEventArgs e)
		{
			ColorettoWindow.NumberOfPlayers = 3;
			StartColorettoButton.IsEnabled = true;
		}

		private void FourPlayerClick(object sender, RoutedEventArgs e)
		{
			ColorettoWindow.NumberOfPlayers = 4;
			StartColorettoButton.IsEnabled = true;
		}

		private void FivePlayerClick(object sender, RoutedEventArgs e)
		{
			ColorettoWindow.NumberOfPlayers = 5;
			StartColorettoButton.IsEnabled = true;
		}
	}
}
