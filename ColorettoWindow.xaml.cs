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
	/// Interaction logic for ColorettoWindow.xaml
	/// </summary>
	public partial class ColorettoWindow : Window
	{
		public static int NumberOfPlayers;
		public ColorettoWindow()
		{
			NumberOfPlayers = 0;
			InitializeComponent();
		}

		private void NewGameClick(object sender, RoutedEventArgs e)
		{
			var colorettoGameSetup = new ColorettoGameSetup();
			colorettoGameSetup.ShowDialog();
		}
	}
}
