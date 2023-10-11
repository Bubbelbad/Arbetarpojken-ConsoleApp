using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._10___Arbeta__StoryApp
{
    internal class Gruvan : Affären
    {


        public Gruvan(string name, int moneyEarnd, int exhaustionPoints, string mood)
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
