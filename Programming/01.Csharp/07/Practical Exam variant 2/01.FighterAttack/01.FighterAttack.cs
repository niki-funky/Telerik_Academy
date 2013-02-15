using System;

class FighterAttack
{
    //You are given the location of the plant P, the location of the fighter F 
    //and the distance D. Write a program that calculates the damage over 
    //the plant after the attack. Not that the missile could hits the plant 
    //partially of fully or can hit some area outside of the plant and cause no damage.

    static void Main()
    {
        //variables
        int px1 = int.Parse(Console.ReadLine());
        int py1 = int.Parse(Console.ReadLine());
        int px2 = int.Parse(Console.ReadLine());
        int py2 = int.Parse(Console.ReadLine());
        int fx = int.Parse(Console.ReadLine());
        int fy = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());
        bool py = true;
        bool px = true;
        int damage = 0;

        //expressions
        if (py1 < py2)
        {
            py = false;
        }
        if (px1 < px2)
        {
            px = false;
        }
        //calculate damage
        #region py1>py2
        if (py)
        {
            if (fy <= py1 + 1 && fy >= py2 - 1)
            {
                if (px)
                {
                    #region px1>px2
                    if (fx + D >= px2 - 1 && fx + D <= px1)
                    {
                        if ((fx + D == px2 - 1) && fy <= py1 && fy >= py2)
                        {
                            damage += 75;
                        }
                        if (fx + D >= px2 && fy == py1 + 1)
                        {
                            damage += 50;
                        }
                        if (fx + D >= px2 && fy == py2 - 1)
                        {
                            damage += 50;
                        }
                        if ((fx + D >= px2) && fy == py1 && fx + D < px1)
                        {
                            damage += 225;
                        }
                        if ((fx + D == px1) && fy == py1 && px1!=px2)
                        {
                            damage += 150;
                        }
                        if ((fx + D >= px2) && fy == py2 && fx + D < px1)
                        {
                            damage += 225;
                        }
                        if ((fx + D == px1) && fy == py2 && px1 != px2)
                        {
                            damage += 150;
                        }
                        if ((fx + D >= px2) && fy > py2 && fy < py1 && fx + D < px1)
                        {
                            damage += 275;
                        }
                        if ((fx + D == px1) && fy > py2 && fy < py1)
                        {
                            damage += 200;
                        }
                        if ((fx + D == px1) && (fy == py1 || fy == py2) && px1 == px2)
                        {
                            damage += 150;
                            if (fy == py1 && fy == py2)
                            {
                                damage -= 50;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region px1<px2
                    if (fx + D >= px1 - 1 && fx + D <= px2)
                    {
                        if ((fx + D == px1 - 1) && fy <= py1 && fy >= py2)
                        {
                            damage += 75;
                        }
                        if (fx + D >= px1 && fy == py1 + 1)
                        {
                            damage += 50;
                        }
                        if (fx + D >= px1 && fy == py2 - 1)
                        {
                            damage += 50;
                        }
                        if ((fx + D >= px1) && fy == py1 && fx + D < px2)
                        {
                            damage += 225;
                        }
                        if ((fx + D == px2) && fy == py1 && px1 != px2)
                        {
                            damage += 150;
                        }
                        if ((fx + D >= px1) && fy == py2 && fx + D < px2)
                        {
                            damage += 225;
                        }
                        if ((fx + D == px2) && fy == py2 && px1 != px2)
                        {
                            damage += 150;
                        }
                        if ((fx + D >= px1) && fy > py2 && fy < py1 && fx + D < px2)
                        {
                            damage += 275;
                        }
                        if ((fx + D == px2) && fy > py2 && fy < py1)
                        {
                            damage += 200;
                        }
                        if ((fx + D == px2) && (fy == py1 || fy == py2) && px1 == px2)
                        {
                            damage += 150;
                            if (fy == py1 && fy == py2)
                            {
                                damage -= 50;
                            }
                        }
                    }
                    #endregion
                }
            }
        }
        #endregion
        #region py1<py2
        else
        {
            if (fy <= py2 + 1 && fy >= py1 - 1)
            {
                if (px)
                {
                    #region px1>px2
                    if (fx + D >= px2 - 1 && fx + D <= px1)
                    {
                        if ((fx + D == px2 - 1) && fy <= py2 && fy >= py1)
                        {
                            damage += 75;
                        }
                        if (fx + D >= px2 && fy == py2 + 1)
                        {
                            damage += 50;
                        }
                        if (fx + D >= px2 && fy == py1 - 1)
                        {
                            damage += 50;
                        }
                        if ((fx + D >= px2) && fy == py2 && fx + D < px1)
                        {
                            damage += 225;
                        }
                        if ((fx + D == px1) && fy == py2 && px1 != px2)
                        {
                            damage += 150;
                        }
                        if ((fx + D >= px2) && fy == py1 && fx + D < px1)
                        {
                            damage += 225;
                        }
                        if ((fx + D == px1) && fy == py1 && px1 != px2)
                        {
                            damage += 150;
                        }
                        if ((fx + D >= px2) && fy > py1 && fy < py2 && fx + D < px1)
                        {
                            damage += 275;
                        }
                        if ((fx + D == px1) && fy > py1 && fy < py2)
                        {
                            damage += 200;
                        }
                        if ((fx + D == px1) && (fy == py1 || fy == py2) && px1 == px2)
                        {
                            damage += 150;
                            if (fy == py1 && fy == py2)
                            {
                                damage -= 50;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region px1<px2
                    if (fx + D >= px1 - 1 && fx + D <= px2)
                    {
                        if ((fx + D == px1 - 1) && fy <= py2 && fy >= py1)
                        {
                            damage += 75;
                        }
                        if (fx + D >= px1 && fy == py2 + 1)
                        {
                            damage += 50;
                        }
                        if (fx + D >= px1 && fy == py1 - 1)
                        {
                            damage += 50;
                        }
                        if ((fx + D >= px1) && fy == py2 && fx + D < px2)
                        {
                            damage += 225;
                        }
                        if ((fx + D == px2) && fy == py2 && px1 != px2)
                        {
                            damage += 150;
                        }
                        if ((fx + D >= px1) && fy == py1 && fx + D < px2)
                        {
                            damage += 225;
                        }
                        if ((fx + D == px2) && fy == py1 && px1 != px2)
                        {
                            damage += 150;
                        }
                        if ((fx + D >= px1) && fy > py1 && fy < py2 && fx + D < px2)
                        {
                            damage += 275;
                        }
                        if ((fx + D == px2) && fy > py1 && fy < py2)
                        {
                            damage += 200;
                        }
                        if ((fx + D == px2) && (fy == py1 || fy == py2) && px1 == px2)
                        {
                            damage += 150;
                            if (fy == py1 && fy == py2)
                            {
                                damage -= 50;
                            }
                        }
                    }
                    #endregion
                }
            }
        }
        #endregion

        Console.WriteLine(damage + "%");
    }
}

