using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._10___Arbeta__StoryApp
{
    internal class Skoputs : Affären
    {


        public Skoputs(string name, int moneyEarnd, int exhaustionPoints, string mood)
            : base(name, moneyEarnd, exhaustionPoints, mood)
        {
            MoneyEarnd = moneyEarnd;
            ExhaustionPoints = exhaustionPoints;
            Mood = mood;
        }



        public override void Workday()
        {
            base.Workday();
        }

    }
}
