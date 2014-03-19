using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArcadia
{
	class OneTurn : ChickenLogic
	{
		private IList<Die> CurrentDice { get; set; }
		private int NumberOfRolls { get; set; }
		private int Score { get; set; }

		public OneTurn()
		{
			NumberOfRolls = 0;
			Score = 0;
		}
		public int OneTurnMain()
		{
			/*To do:
 * Add dice to iList
 * Roll all the dice
 * interface with the dice
 * Repeat
 * Count rolls
 * Return Score
 */
			return 0;
		}
	}
}
