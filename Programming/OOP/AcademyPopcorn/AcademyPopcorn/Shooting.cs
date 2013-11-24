using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Shooting : Engine
    {
        //constructor
        public Shooting(IRenderer renderer, IUserInterface userInterface, int sleeping)
            : base(renderer, userInterface, sleeping)
        {
        }

        //method
        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
