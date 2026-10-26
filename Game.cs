using System;

namespace Endstep_Analysis
{
    internal class Game
    {

        int gameNumber; // game number
        dynamic mulligans; // {0: mulligans, 1: mulligans}
        dynamic otherSeen; // cards seen from other player
        Action[] log; // every action taken in the game
        int firstSeat; // who went first
        dynamic cardsDrawn;
        int turnsTaken;
        dynamic openingHand;
        int winnerSeat; // 0 or 1
        string endReason; // "concede", "time", "win"

        public Game(dynamic g)
        {
            gameNumber = g.n;
            mulligans = g.mulligans;
            otherSeen = g.seen;
            log = new Action[g.log.Count];
            for (int i = 0; i < g.log.Count; i++)
            {
                log[i] = new Action(g.log[i]);
            }
            firstSeat = g.firstSeat;
            cardsDrawn = g.drawn;
            turnsTaken = g.turns;
            openingHand = g.openingHand;
            winnerSeat = g.winnerSeat;
            endReason = g.endReason;
        }

    }
}