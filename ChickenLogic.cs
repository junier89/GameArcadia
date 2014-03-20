using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameArcadia
{
	public class ChickenLogic
	{
		public void ChickenMain(Button button1)
		{
			var thisTurn = new Turn();
			var score = thisTurn.TurnMain(button1);
			/* Collect Score
			 * Count Score
			 * Repeat
			 * End
			 * Return to the MainWindow
			 */
		}
	}
}