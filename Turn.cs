using System.Collections.Generic;
using System.Linq;

namespace GameArcadia
{
	public class Turn
	{
		public IList<Die> CurrentDice { get; private set; }
		public int Score { get; set; }

		public Turn()
		{
			Score = 0;
			CurrentDice = new List<Die>();
			for (var i = 0; i < 6; i++)
				CurrentDice.Add(new Die());
		}
		public int FindDieValue(int dieNumber)
		{
			return CurrentDice[dieNumber].Value;
		}
			/* Collect Score
			 * Count Score
			 * Repeat
			 * End
			 * Return to the MainWindow
			 */
		
		private void RollUnclickedDice()
		{
			for (var i = 0; i < 6; i++)
				if (CurrentDice[i].State.Equals(DieState.Unclicked))
					CurrentDice[i].RollDie();
		}

		public void ChangeTheDiesClickedValue(int dieNumber)
		{
			if (CurrentDice[dieNumber].State.Equals(DieState.Unclicked))
				CurrentDice[dieNumber].State = DieState.TemporarilySetAside;
			else if (CurrentDice[dieNumber].State.Equals(DieState.TemporarilySetAside))
				CurrentDice[dieNumber].State = DieState.Unclicked;
		}
		public DieState FindDieState(int dieNumber)
		{
			return CurrentDice[dieNumber].State;
		}
		public void Roll()
		{
			ScoringClass.ScoreAllSetAsideDice(this);
			RollUnclickedDice();
			ReorderDice();
		}
		private void ReorderDice()
		{
			CurrentDice = CurrentDice.OrderBy(x => x.State).ToList();
		}
	}
}
