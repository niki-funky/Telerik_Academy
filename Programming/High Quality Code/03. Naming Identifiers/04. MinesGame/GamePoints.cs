namespace MinesGame
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class that holds player's name and points
    /// </summary>
    public class GamePoints
    {
        private string nickname;
        private int points;

        public GamePoints() 
        { 
        }

        public GamePoints(string playerName, int playerPoints)
        {
            this.NickName = playerName;
            this.Points = playerPoints;
        }

        public string NickName
        {
            get { return this.nickname; }
            set { this.nickname = value; }
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }
    }
}
