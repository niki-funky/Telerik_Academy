using System;

class ShipDamage
{
    static void Main()
    {
        //variables
        int sx1 = int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        int cx1 = int.Parse(Console.ReadLine());
        int cy1 = int.Parse(Console.ReadLine());
        int cx2 = int.Parse(Console.ReadLine());
        int cy2 = int.Parse(Console.ReadLine());
        int cx3 = int.Parse(Console.ReadLine());
        int cy3 = int.Parse(Console.ReadLine());
        bool sy = true;
        bool sx = true;
        int damage = 0;

        //expressions
        cy1 = 2 * h - cy1;
        cy2 = 2 * h - cy2;
        cy3 = 2 * h - cy3;

        if (sy1 < sy2)
        {
            sy = false;
        }
        if (sx1 < sx2)
        {
            sx = false;
        }
        //calculate damage
        #region Sx1>Sx2
        if (sx)
        {
            if (sx1 != sx2 && sy1 != sy2)
            {
                if (sy)
                {
                    #region Sy1>Sy2
                    if ((cx1 != cx2 || cy1 != cy2) && (cx2 != cx3 || cy2 != cy3) && (cx1 != cx3 || cy1 != cy3))
                    {
                        //damage 25%
                        if ((cy1 == sy1 || cy1 == sy2) && (cx1 == sx1 || cx1 == sx2))
                        {
                            damage += 25;
                        }
                        if ((cy2 == sy1 || cy2 == sy2) && (cx2 == sx1 || cx2 == sx2))
                        {
                            damage += 25;
                        }
                        if ((cy3 == sy1 || cy3 == sy2) && (cx3 == sx1 || cx3 == sx2))
                        {
                            damage += 25;
                        }
                        //damage 50%
                        if ((cy1 < sy1 && cy1 > sy2 && (cx1 == sx1 || cx1 == sx2))
                            || (cx1 < sx1 && cx1 > sx2 && (cy1 == sy1 || cy1 == sy2)))
                        {
                            damage += 50;
                        }
                        if ((cy2 < sy1 && cy2 > sy2 && (cx2 == sx1 || cx2 == sx2))
                            || (cx2 < sx1 && cx2 > sx2 && (cy2 == sy1 || cy2 == sy2)))
                        {
                            damage += 50;
                        }
                        if ((cy3 < sy1 && cy3 > sy2 && (cx3 == sx1 || cx3 == sx2))
                            || (cx3 < sx1 && cx3 > sx2 && (cy3 == sy1 || cy3 == sy2)))
                        {
                            damage += 50;
                        }
                        //damage 100%
                        if (cy1 < sy1 && cy1 > sy2
                            && cx1 < sx1 && cx1 > sx2)
                        {
                            damage += 100;
                        }
                        if (cy2 < sy1 && cy2 > sy2
                            && cx2 < sx1 && cx2 > sx2)
                        {
                            damage += 100;
                        }
                        if (cy3 < sy1 && cy3 > sy2
                            && cx3 < sx1 && cx3 > sx2)
                        {
                            damage += 100;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Sy1<Sy2
                    if ((cx1 != cx2 || cy1 != cy2) && (cx2 != cx3 || cy2 != cy3) && (cx1 != cx3 || cy1 != cy3))
                    {
                        //damage 25%
                        if ((cy1 == sy1 || cy1 == sy2) && (cx1 == sx1 || cx1 == sx2))
                        {
                            damage += 25;
                        }
                        if ((cy2 == sy1 || cy2 == sy2) && (cx2 == sx1 || cx2 == sx2))
                        {
                            damage += 25;
                        }
                        if ((cy3 == sy1 || cy3 == sy2) && (cx3 == sx1 || cx3 == sx2))
                        {
                            damage += 25;
                        }
                        //damage 50%
                        if ((cy1 > sy1 && cy1 < sy2 && (cx1 == sx1 || cx1 == sx2))
                            || (cx1 < sx1 && cx1 > sx2 && (cy1 == sy1 || cy1 == sy2)))
                        {
                            damage += 50;
                        }
                        if ((cy2 > sy1 && cy2 < sy2 && (cx2 == sx1 || cx2 == sx2))
                            || (cx2 < sx1 && cx2 > sx2 && (cy2 == sy1 || cy2 == sy2)))
                        {
                            damage += 50;
                        }
                        if ((cy3 > sy1 && cy3 < sy2 && (cx3 == sx1 || cx3 == sx2))
                            || (cx3 < sx1 && cx3 > sx2 && (cy3 == sy1 || cy3 == sy2)))
                        {
                            damage += 50;
                        }
                        //damage 100%
                        if (cy1 > sy1 && cy1 < sy2
                            && cx1 < sx1 && cx1 > sx2)
                        {
                            damage += 100;
                        }
                        if (cy2 > sy1 && cy2 < sy2
                            && cx2 < sx1 && cx2 > sx2)
                        {
                            damage += 100;
                        }
                        if (cy3 > sy1 && cy3 < sy2
                            && cx3 < sx1 && cx3 > sx2)
                        {
                            damage += 100;
                        }
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Sx1<Sx2
        else
        {
            if (sx1 != sx2 && sy1 != sy2)
            {
                if (sy)
                {
                    #region Sy1>Sy2
                    if ((cx1 != cx2 || cy1 != cy2) && (cx2 != cx3 || cy2 != cy3) && (cx1 != cx3 || cy1 != cy3))
                    {
                        //damage 25%
                        if ((cy1 == sy1 || cy1 == sy2) && (cx1 == sx1 || cx1 == sx2))
                        {
                            damage += 25;
                        }
                        if ((cy2 == sy1 || cy2 == sy2) && (cx2 == sx1 || cx2 == sx2))
                        {
                            damage += 25;
                        }
                        if ((cy3 == sy1 || cy3 == sy2) && (cx3 == sx1 || cx3 == sx2))
                        {
                            damage += 25;
                        }
                        //damage 50%
                        if ((cy1 < sy1 && cy1 > sy2 && (cx1 == sx1 || cx1 == sx2))
                            || (cx1 > sx1 && cx1 < sx2 && (cy1 == sy1 || cy1 == sy2)))
                        {
                            damage += 50;
                        }
                        if ((cy2 < sy1 && cy2 > sy2 && (cx2 == sx1 || cx2 == sx2))
                            || (cx2 > sx1 && cx2 < sx2 && (cy2 == sy1 || cy2 == sy2)))
                        {
                            damage += 50;
                        }
                        if ((cy3 < sy1 && cy3 > sy2 && (cx3 == sx1 || cx3 == sx2))
                            || (cx3 > sx1 && cx3 < sx2 && (cy3 == sy1 || cy3 == sy2)))
                        {
                            damage += 50;
                        }
                        //damage 100%
                        if (cy1 < sy1 && cy1 > sy2
                            && cx1 > sx1 && cx1 < sx2)
                        {
                            damage += 100;
                        }
                        if (cy2 < sy1 && cy2 > sy2
                            && cx2 > sx1 && cx2 < sx2)
                        {
                            damage += 100;
                        }
                        if (cy3 < sy1 && cy3 > sy2
                            && cx3 > sx1 && cx3 < sx2)
                        {
                            damage += 100;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Sy1<Sy2
                    if ((cx1 != cx2 || cy1 != cy2) && (cx2 != cx3 || cy2 != cy3) && (cx1 != cx3 || cy1 != cy3))
                    {
                        //damage 25%
                        if ((cy1 == sy1 || cy1 == sy2) && (cx1 == sx1 || cx1 == sx2))
                        {
                            damage += 25;
                        }
                        if ((cy2 == sy1 || cy2 == sy2) && (cx2 == sx1 || cx2 == sx2))
                        {
                            damage += 25;
                        }
                        if ((cy3 == sy1 || cy3 == sy2) && (cx3 == sx1 || cx3 == sx2))
                        {
                            damage += 25;
                        }
                        //damage 50%
                        if ((cy1 > sy1 && cy1 < sy2 && (cx1 == sx1 || cx1 == sx2))
                            || (cx1 > sx1 && cx1 < sx2 && (cy1 == sy1 || cy1 == sy2)))
                        {
                            damage += 50;
                        }
                        if ((cy2 > sy1 && cy2 < sy2 && (cx2 == sx1 || cx2 == sx2))
                            || (cx2 > sx1 && cx2 < sx2 && (cy2 == sy1 || cy2 == sy2)))
                        {
                            damage += 50;
                        }
                        if ((cy3 > sy1 && cy3 < sy2 && (cx3 == sx1 || cx3 == sx2))
                            || (cx3 > sx1 && cx3 < sx2 && (cy3 == sy1 || cy3 == sy2)))
                        {
                            damage += 50;
                        }
                        //damage 100%
                        if (cy1 > sy1 && cy1 < sy2
                            && cx1 > sx1 && cx1 < sx2)
                        {
                            damage += 100;
                        }
                        if (cy2 > sy1 && cy2 < sy2
                            && cx2 > sx1 && cx2 < sx2)
                        {
                            damage += 100;
                        }
                        if (cy3 > sy1 && cy3 < sy2
                            && cx3 > sx1 && cx3 < sx2)
                        {
                            damage += 100;
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
