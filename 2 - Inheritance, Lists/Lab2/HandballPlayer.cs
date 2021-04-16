using System;

namespace Inheritance_Lists
{
    public class HandballPlayer : Player
    {
        public HandballPlayer(string firstName, string lastName, DateTime dateOfBirth,
            string position, string club, int scoredGoals = 0)
            :base(firstName, lastName, dateOfBirth, position, club,scoredGoals)  // base for Player, doesn't matter that Player will call his own base class
        {
            // nothing new to implement here
        }
        public override void ScoreGoal()
        {
            base.ScoreGoal();
            Console.WriteLine("Handball player scored goal.");
        }
    }
}
