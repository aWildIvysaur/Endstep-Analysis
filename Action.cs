using System.Linq;

namespace Endstep_Analysis
{
    internal class Action
    {
        int turn; // what turn of the game
        int seat; // who did this action, 3 for none
        string type; // what was this: "spell_cast", "card_zone_change", etc
        string target; // what was the target of this action (often the card being played)
        string description; // what did the log say

        public Action(dynamic a)
        {
            turn = a[0];
            if (a[1] is int)
            { 
                seat = a[1];
            }
            else
            {
                seat = 3;
            }
            
            type = a[2];
            target = a[3];
            description = a[4];
        }
    }
}