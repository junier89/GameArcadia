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
	}
}
