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
	/// Interaction logic for DotWarsWindow.xaml
	/// </summary>
	public partial class DotWarsWindow : Window
	{
		private DotWarsGame dotWarsGame;
		public DotWarsWindow()
		{
			InitializeComponent();

			var window = new OtherWindow
			{
				UserName = "Pick a username!"
			};
			window.ShowDialog();
			var updatedUserName = window.UserName;
			MessageBox.Show("hello, " + updatedUserName);
		}

		private void NewGameClick(object sender, RoutedEventArgs e)
		{
			dotWarsGame = new DotWarsGame();
		}
	}
}
