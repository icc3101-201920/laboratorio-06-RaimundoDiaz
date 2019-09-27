using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Laboratorio_5_OOP_201902.Cards;

namespace Laboratorio_5_OOP_201902
{
    static class Visualization
    {
        static Visualization()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        
        static void ShowHand(Hand hand)
        {
            int counter = 0;
            foreach (Card card in hand.Cards)
            {
                if (card.Type == Enums.EnumType.melee ||
                    card.Type == Enums.EnumType.range ||
                    card.Type == Enums.EnumType.longRange)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    CombatCard tempCard = card as CombatCard;
                    Console.Write($"|({counter}) {card.Name} ({card.Type}): {tempCard.AttackPoints} |"); 
                }   // Estoy usando Write en vez de WriteLine porque en el ejemplo lo escribe todo en la misma linea
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"|({counter}) {card.Name} {card.Effect}|");
                }
                counter += 1;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
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
            
            while (true)
            {
                string Input = Console.ReadLine();
                try
                {
                    int UserInput = Convert.ToInt32(Input);
                    if (stopper)
                    {
                        if (UserInput <= maxInput & UserInput >= -1)
                        {
                            ConsoleError($"The option {UserInput} is not valid. Try again");
                            continue;
                        }
                        break;
                    }
                    else
                    {
                        if (UserInput <= maxInput)
                        {
                            ConsoleError($"The option {UserInput} is not valid. Try again");
                            continue;
                        }
                        break;
                    }
                }
                catch (IOException e)
                {
                    TextWriter errorWriter = Console.Error;
                    ConsoleError(e.Message);
                    continue;
                }
            }
        }

        static void ConsoleError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void ShowProgramMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void ShowListOptions(List<string> options, string message = null)
        {
            int counter = 0;
            if (message != null)
            {
                Console.WriteLine(message);
            }
            foreach (string option in options)
            {
                Console.WriteLine($"({counter}) {option}");
            }
        }

        static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
