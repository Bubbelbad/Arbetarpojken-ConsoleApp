using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._10___Arbeta__StoryApp
{
    internal class Skoputs : Affären
    {
        public int ConsecutiveDays { get; set; }


        public Skoputs(string name, int moneyEarnd, int exhaustionPoints, string mood, int consecutiveDays = 0)
            :base(name, moneyEarnd, exhaustionPoints, mood)
        {
            MoneyEarnd = moneyEarnd;
            ExhaustionPoints = exhaustionPoints;
            Mood = mood;
            ConsecutiveDays = consecutiveDays;
        }


        //Här saknas det en funktion som håller koll på om en har arbetat 5 dagar i rad för bonusen. Men hur!?!?
        public override void Workday()
        {
            base.Workday();
          //  if (daysPassed > 0)
          //  {
          //      return;
          //  }
        }
    }
}
