using System.Windows;

namespace GameArcadia
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void LoadChicken(object sender, RoutedEventArgs e)
		{
			var chickenWindow = new ChickenWindow();
			chickenWindow.Show();
			Close();
		}

		private void LoadDotWars(object sender, RoutedEventArgs e)
		{
			var dotWarsWindow = new DotWarsWindow();
			dotWarsWindow.Show();
			Close();
		}

		private void LoadColoretto(object sender, RoutedEventArgs e)
		{
			var colorettoWindow = new ColorettoWindow();
			colorettoWindow.Show();
			Close();
		}

		private void LoadHelp(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Help!");
		}
	}
}
