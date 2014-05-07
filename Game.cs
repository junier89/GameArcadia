using System.Collections.Generic;

namespace GameArcadia
{
	class Game
	{
		private Turn turn;

		public int Score { get; private set; }

		public int TurnNumber { get; set; }

		private bool HasAchievedA500 { get; set; }

		public Game()
		{
			turn = new Turn();
			Score = 0;
			TurnNumber = 0;
			HasAchievedA500 = false;
		}

		public void RollTheDice()
		{
			turn.Roll();
		}

		public void DieClick(int dieNumber)
		{
			turn.ChangeTheDiesClickedValue(dieNumber);
		}

		public int FindDieValue(int dieNumber)
		{
			return turn.FindDieValue(dieNumber);
		}

		public DieState FindDieState(int dieNumber)
		{
			return turn.FindDieState(dieNumber);
		}

		public int GetTurnScore()
		{
			return turn.Score;
		}
		public bool GetIsScorable()
		{
			return turn.IsScorable;
		}

		public void StopTheTurn()
		{
			ScoringClass.ScoreAllSetAsideDice(turn);
			Score += turn.Score;
			turn.IsScorable = true;
			turn = new Turn();
			turn.Roll();
			TurnNumber += 1;
		}
	}
}
