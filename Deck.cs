using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;

namespace Endstep_Analysis
{
    internal class Deck
    {
        bool deckAvailable;
        public bool DeckAvailable { get => deckAvailable; }
        Dictionary<string, int> mainBoard;
        Dictionary<string, int> sideBoard;

        /// <summary>
        /// Populate a new deck.
        /// d must contain a "cards" and "sideboard" property, each of which is an array of objects with "name" and "quantity" properties
        /// </summary>
        private Deck(dynamic d)
        {
            mainBoard = new Dictionary<string, int>();
            sideBoard = new Dictionary<string, int>();
            if (d.cards != null)
            {
                deckAvailable = true;
                foreach (dynamic c in d.cards)
                {
                    mainBoard.Add((string)c.name, (int)c.quantity);
                }
                
                foreach (dynamic c in d.sideboard)
                {
                    sideBoard.Add((string)c.name, (int)c.quantity);
                }
            }
            else
            {
                deckAvailable = false;
                Console.WriteLine("Dead deck");
            }
        }
        private Deck()
        {
            deckAvailable = false;
        }

        /// <summary>
        /// Every deck the player has used, without duplicates
        /// </summary>
        public static Dictionary<string, Deck> decks = new Dictionary<string, Deck>() {{ "Unknown", new Deck() }};

        /// <summary>
        /// Add a new deck to the list of decks. If a deck with the same name already exists, it will not be added.
        /// </summary>
        public static string AddDeck(dynamic d)
        {
            string name;
            try 
            {
                 name = (string)d.name;
            }
            catch (RuntimeBinderException)
            {
                Console.WriteLine("Deck name is missing");
                return null;
            }

            if (decks.ContainsKey(name))
            {
                Console.WriteLine("Deck already exists");
                return name;
            }
            else
            {
                decks.Add(name, new Deck(d));
                return name;
            }
        }
    }
}