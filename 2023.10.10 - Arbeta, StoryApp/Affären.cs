using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._10___Arbeta__StoryApp
{
    internal class Affären
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MoneyEarnd {  get; set; }
        public int ExhaustionPoints { get; set; }
        public string Mood { get; set; }

        public static int daysPassed = 0;
        public static int nextID = 1;

        public Affären(string name, int moneyEarnd, int exhaustionpoints, string mood)
        {
            this.Name = name;
            MoneyEarnd = moneyEarnd;
            ExhaustionPoints = exhaustionpoints;
            Mood = mood;
            this.Id = nextID++;
        }


        public virtual void Workday()
        {
            Console.Clear();
            Console.WriteLine($"Pojken arbetar i {this.Name} och lyckas tjäna ihop {this.MoneyEarnd} kronor efter dagens slut.\n" +
                              $"Efter den här arbetsdagen känner sig pojken {this.Mood}.");
            daysPassed++;
        }
    }
}
