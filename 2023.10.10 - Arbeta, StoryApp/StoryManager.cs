using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._10___Arbeta__StoryApp
{
    internal class StoryManager
    {


        public int daysPassed = 0; //För att räkna dagarna - spelet är slut efter fem dagar. 
        public int counter = 0; //För att räkna dagar i rad som pojken putsat skor. 


        //Skapar objekt från klasserna, samt en lista till affärerna.
        List<Affären> jobbLista = new List<Affären>();

        Affären affären = new Affären("affären", 130, 1, "lite trött");
        Skoputs skoputs = new Skoputs("skoputsningen", 15, 0, "glad");
        Gruvan gruvan = new Gruvan("gruvan", 300, 3, "utmattad");
        Pojken pojken = new Pojken();



        //Lägger till affärerna i en lista med objekt.
        public void Run()
        {
            jobbLista.Add(affären);
            jobbLista.Add(skoputs);
            jobbLista.Add(gruvan);
        }



        //Konstruktor till Storymanager som importerar klasser, visar introt och menyn.
        public StoryManager()
        {
            Run();
            FirstDay();
            Menu();
        }




        //Main menu som kommer att loopas till spelet är vunnet eller förlorat:
        public void Menu()
        {
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Vill du välja att arbeta med...\n\n" +
                                  "Affären                      [1]\n" +
                                  "Skoputs                      [2]\n" +
                                  "Gruvan                       [3}\n\n" +
                                  "Eller - Ta en vilodag        [4]");
                
                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Workday(choice);
                            counter = 0;
                            break;
                        case 2:
                            Workday(choice, counter);
                            counter++;
                            break;
                        case 3:
                            Workday(choice);
                            counter = 0;
                            break;
                        case 4:
                            Restday();
                            counter = 0;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Vänligen skriv en siffra mellan 1-4\n");
                            break;
                    }

                    FiveDaysCheck();

                }
                catch
                {
                    Console.WriteLine("Vänligen skriv en siffra mellan 1 - 4");
                }
                
            }
            
        }





        //Introduktion till berättelsen: 
        public void FirstDay()
        {
            Console.WriteLine("Det var en gång en pojke som så gärna ville köpa ett leksakståg.\n" +
                              "I den lokala leksaksaffären kostar tåget 400 kronor.\n" +
                              "För att få råd med tåget letar pojken efter arbeten och får tre jobberbjudanden..\n\n" +
                              "Klicka enter för att fortsätta");

            Console.ReadLine();
            Console.Clear();
        }




        //En arbetsdag passerar i spelet och funktionen hämtar information från klasserna genom listan.
        public void Workday(int choice)
        {
            foreach (Affären affär in jobbLista)
            {
                if (choice == affär.Id)
                {
                    affär.Workday();
                    pojken.Money += affär.MoneyEarnd;
                    pojken.Exhaustion += affär.ExhaustionPoints;
                    daysPassed++;
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
            }
        }





        //En overload-funktion för att hålla koll på skoputsgningen. 
        //Har pojken putsat skor fem dagar i rad kommer han få en bonus på 5 000 SEK.
        public void Workday(int choice, int counter)
        {

            foreach (Affären affär in jobbLista)
            {
                if (choice == affär.Id)
                {
                    affär.Workday();
                    pojken.Money += affär.MoneyEarnd;
                    pojken.Exhaustion += affär.ExhaustionPoints;
                    daysPassed++;
                }
            }

            if (counter == 4)
            {
                pojken.Money += 5000;
                Console.WriteLine("\n*** Pojken har putsat skor fem dagar i rad och får 5 000 *** \n" +
                                    "    kronor i dricks av en tät gammal dam!");
            }
            Console.ReadLine();
            Console.Clear();
        }





        //Vilodag. Pojken får färre utmattningspoäng, men en dag passerar utan betalt.
        private void Restday()
        {
            Console.Clear();
            Console.WriteLine("Pojken har fått vila och har återfått en del energi.");
            pojken.Exhaustion -= 2;
            daysPassed++;
            Console.ReadLine();
            Console.Clear();
        }



        //För att kolla om fem dagar gått eller om pojken har bränt ut sig.
        public void FiveDaysCheck()
        {
            if (daysPassed == 5)
            {
                Console.Clear();
                Console.WriteLine("Fem dagar har passerat och pojken räknar ihop sina pengar.\n" +
                                  $"Han har fått ihop {pojken.Money} kronor efter arbetsveckan.\n\n");
                if (pojken.Money >= 400)
                {
                    Console.WriteLine("Du har vunnit spelet! Pojken köper sitt tåg och alla blir lyckliga.\n" +
                                      "Snipp, snapp, snut osv. ");
                    Console.ReadLine();
                    PlayAgain();
                }
                else
                {
                    Console.WriteLine("Du har förlorat. Pojken har för lite pengar.\n");
                                    
                    PlayAgain();
                }
            }
            else if (pojken.Exhaustion >= 4)
            {
                Console.Clear();
                Console.WriteLine("Snipp, snapp, snut - pojken är slut. " +
                                "\nHan är helt utmattad och kan inte arbeta mer.");
                Console.ReadLine();
                PlayAgain();
            }
        }



        //Spela igen eller avsluta.
        private void PlayAgain()
        {
            Console.Clear();
            Console.WriteLine("Vill du spela igen?     \n\n" +
                              "Spela igen               [1]\n" +
                              "Avsluta spelet           [2]");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Console.Clear();
                    ResetGame();
                    FirstDay();
                    Menu();
                    break;
                case "2":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Skriv in en siffra mellan 1-2");
                    break;
            }
        }




        //Function to counters, money and exhaustion for new game. 
        public void ResetGame()
        {
            daysPassed = 0;
            counter = 0;
            pojken.Exhaustion = 0;
            pojken.Money = 0;
        }
    }
}
