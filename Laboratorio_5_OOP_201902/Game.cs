using Laboratorio_5_OOP_201902.Cards;
using Laboratorio_5_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Laboratorio_5_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private List<SpecialCard> captains;
        private Board boardGame;

        //Constructor
        public Game()
        {
            decks = new List<Deck>();
            captains = new List<SpecialCard>();
            players = new Player[] { new Player(), new Player()};
            Random rand = new Random();
            int random = rand.Next(0, 2);
            activePlayer = players[random];
            boardGame = new Board();
            players[0].Board = boardGame;
            players[1].Board = boardGame;
            AddCaptains();
            AddDecks();
        }
        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public List<SpecialCard> Captains
        {
            get
            {
                return this.captains;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0 && players[1].LifePoints > 0)
            {
                return 1;
            }
            else if (players[1].LifePoints == 0 && players[0].LifePoints > 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public void Play()
        {
            List<string> options = new List<string>() { "Change Card", "Pass" };
            string message = "Change 3 cards or ready to play";
            Visualization.ShowProgramMessage($"Player {ActivePlayer.Id} select Deck and Captain");
            Visualization.ShowDecks(Decks);
            int input = Visualization.GetUserInput(2, false);
            ActivePlayer.Deck = Decks[input];
            Visualization.ShowCaptains(Captains);
            int input2 = Visualization.GetUserInput(2, false);
            ActivePlayer.ChooseCaptainCard(Captains[input2]);
            ActivePlayer.FirstHand();
            Visualization.ShowHand(ActivePlayer.Hand);
            Visualization.ShowListOptions(options, message);
            int input3 = Visualization.GetUserInput(2, false);
            if (input3 == 0)
            {
                Console.WriteLine($"Player {ActivePlayer.Id} change cards:");
                Console.WriteLine("Hand:");
                Visualization.ShowHand(ActivePlayer.Hand);
                Console.WriteLine("Input the number of cards to change (max 3). To stop enter -1");
                int input4 = Visualization.GetUserInput(4, true);
                while (input4 > 0) // si el input es 0 o -1 nunca entra al while asi que lo dejo asi tal cual
                {
                    Console.WriteLine("Enter the Card ID you want to change");
                    int cardid = Visualization.GetUserInput(10, true);
                    ActivePlayer.ChangeCard(cardid);
                    input4 -= 1;
                }
            }
            else
            {
                Console.WriteLine($"Player {ActivePlayer.Id} passed");
            }
            Console.WriteLine($"Player {ActivePlayer.Id} turn has finished");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Visualization.ClearConsole();
        }
        public void AddDecks()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"\Files\Decks.txt";
            StreamReader reader = new StreamReader(path);
            int deckCounter = 0;
            List<Card> cards = new List<Card>();


            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string [] cardDetails = line.Split(",");

                if (cardDetails[0] == "END")
                {
                    decks[deckCounter].Cards = new List<Card>(cards);
                    deckCounter += 1;
                }
                else
                {
                    if (cardDetails[0] != "START")
                    {
                        if (cardDetails[0] == nameof(CombatCard))
                        {
                            cards.Add(new CombatCard(cardDetails[1], (EnumType) Enum.Parse(typeof(EnumType),cardDetails[2]), cardDetails[3], Int32.Parse(cardDetails[4]), bool.Parse(cardDetails[5])));
                        }
                        else
                        {
                            cards.Add(new SpecialCard(cardDetails[1], (EnumType)Enum.Parse(typeof(EnumType), cardDetails[2]), cardDetails[3]));
                        }
                    }
                    else
                    {
                        decks.Add(new Deck());
                        cards = new List<Card>();
                    }
                }

            }
            
        }
        public void AddCaptains()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"\Files\Captains.txt";
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] cardDetails = line.Split(",");
                captains.Add(new SpecialCard(cardDetails[1], (EnumType)Enum.Parse(typeof(EnumType), cardDetails[2]), cardDetails[3]));
            }
        }
    }
}
