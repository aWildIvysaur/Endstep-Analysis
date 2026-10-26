using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;

namespace Endstep_Analysis
{
    internal class Match
    {
        long startedAt; // time 
        int mySeat; // 0 or 1 
        Game[] games; // game info
        int[] score; // [2,1] etc
        string myDeckName;
        // needs to be sent to game probably - mains; // mainboard at start of match
        bool isWon; // W or L

        public long StartedAt { get => startedAt;}
        public int MySeat { get => mySeat; }
        public Game[] Games { get => games; }
        public int[] Score { get => score; }
        public string MyDeckName { get => myDeckName; }
        public bool IsWon { get => isWon; }

        public Match(dynamic m)
        {
            startedAt = m.startedAt;
            mySeat = m.mySeat;
            score = m.score.ToObject<int[]>();
            games = new Game[m.games.Count];
            for (int i = 0; i < m.games.Count; i++)
            {
                games[i] = new Game(m.games[i]);
            }

            var name = Deck.AddDeck(m.myDeck);
            if (!string.IsNullOrEmpty(name))
            {
                myDeckName = name;

            }
            else
            {
                myDeckName = "Unknown";
            }
            if (m.result == "L")
            {
                isWon = false;
            }
            else
            {
                isWon = true;
            }
        }
    }
}