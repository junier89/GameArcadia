﻿using System;
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
			InitializeComponent();
		}

		private void CancelClick(object sender, RoutedEventArgs e)
		{
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
	}
}
