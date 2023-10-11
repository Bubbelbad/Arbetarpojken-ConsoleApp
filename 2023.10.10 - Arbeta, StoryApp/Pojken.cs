using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._10___Arbeta__StoryApp
{
    internal class Pojken
    {
        public int Money {  get; set; }
        public int Exhaustion { get; set; } //Lägg till exhaustion i manager.

        public Pojken (int money = 0, int exhaustion = 0)
        {
            Money = money;
            Exhaustion = exhaustion;
        }
    }
}
