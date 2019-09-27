using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Laboratorio_5_OOP_201902.Cards;

namespace Laboratorio_5_OOP_201902
{
    static class Visualization
    {
        static Visualization()
        {

        }

        static void ShowHand(Hand hand)
        {

        }

        static void ShowDecks(List<Deck> decks)
        {
            Console.WriteLine("Select one deck:");
            int counter = 0;
            foreach (Deck deck in decks)
            {
                Console.WriteLine($"({counter}) Deck ${counter}");
                Console.ReadLine();     //como en este metodo no se elige el mazo. Solo
                counter += 1;           //se deben mostrar los mazos, y como los mazos no tienen nombre.
            }                           //Hago que se muestre un counter por cantidad de mazos
        }

        static void ShowCaptains(List<SpecialCard> captains)
        {
            Console.WriteLine("Select one Captain:");
            int counter = 0;
            foreach (SpecialCard captain in captains)
            {
                if (captain.Type == Enums.EnumType.captain)
                {
                    Console.WriteLine($"({counter})",captain.Name, captain.Effect);
                    Console.ReadLine();
                    counter += 1;
                }
            }
        }

        static void GetUserInput(int maxInput, bool stopper = false)
        {
            string Input = Console.ReadLine();
            int UserInput = Convert.ToInt32(Input);
            if (stopper == true)
            {
                if (UserInput <= maxInput & UserInput >= -1)
                {
                    
                }
            }
        }

        static void ConsoleError(string message)
        {

        }

        static void ShowProgramMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void ShowListOptions(List<string> options, string message = null)
        {

        }

        static void ClearConsole()
        {

        }
    }
}
