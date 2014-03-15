using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameArcadia
{
    public class ChickenLogic
    {
        private int[,] SetOfCurrentDice { get; set; }
        private int NumberOfRolls { get; set; }
        private int Score { get; set; }

        public ChickenLogic()
        {
            NumberOfRolls = 0;
            Score = 0;
            SetOfCurrentDice =
        }
        }

        public void ChickenMain()
        {
            
        }

        private int RollAllDice()
        {
            for (var i = 0; i < 7; i++)
            {
                setOfCurrentDice[i,0] = RollOneDie();
            }
        }

        private int RollOneDie()
        {
            var randomNumberGenerator = new Random();
            return randomNumberGenerator.Next(1, 7);
        }

    }
}
