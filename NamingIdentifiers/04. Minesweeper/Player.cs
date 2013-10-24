using System;

// Extract class tochki and rename it as Player
// Rename fields, properties and variables
// Fill the empty constructor

namespace Minesweeper
{
    public class Player
    {
        private string name;
		private int scores;

        public string Name
		{
            get { return this.name; }
            set { this.name = value; }
		}

		public int Scores
		{
			get { return this.scores; }
			set { this.scores = value; }
		}

		public Player()
        {
            this.Name = "Anonymous Player";
            this.Scores = 0;
        }

        public Player(string player, int scores)
		{
            this.Name = player;
            this.Scores = scores;
		}
    }
}
