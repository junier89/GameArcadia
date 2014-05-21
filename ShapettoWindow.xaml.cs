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
	/// Interaction logic for ShapettoWindow.xaml
	/// </summary>
	public partial class ShapettoWindow : Window
	{
		public ShapettoWindow()
		{
			InitializeComponent();
		}

		private void NewGameClick(object sender, RoutedEventArgs e)
		{
			var shapettoGameSetup = new ShapettoGameSetup();
			shapettoGameSetup.Show();
		}
	}
}
