using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Continents.Data;
using Continents.Models;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContinentDB countryEntities = new ContinentDB();

            //for (int i = 0; i < 10; i++)
            //{
            //    var conti = new Continent()
            //    {
            //        Name = "new continent" + i,

            //    };
            //    countryEntities.Continents.Add(conti);

            //    for (int m = 0; m < 20; m++)
            //    {
            //        var newCountry = new Country()
            //        {
            //            Name = "new country" + i + m,
            //            Language = "lang" + i + m,
            //            Population = 10 * (i + 1) + m,
            //            Flag = ReadImage("../../ninja.png"),
            //            Continent = conti
            //        };
            //        countryEntities.Countries.Add(newCountry);

            //        for (int n = 0; n < 30; n++)
            //        {
            //            var newTown = new Town()
            //            {
            //                Name = "new town" + i + m + n,
            //                Population = 10 * n + n,
            //                Country = newCountry
            //            };
            //            countryEntities.Towns.Add(newTown);
            //        }
            //    }
            //}
            //countryEntities.SaveChanges();
        }

        private static byte[] ReadImage(string p_postedImageFileName)
        {
            bool isValidFileType = false;
            try
            {
                FileInfo file = new FileInfo(p_postedImageFileName);

                FileStream fs = new FileStream(p_postedImageFileName, FileMode.Open, FileAccess.Read);

                BinaryReader br = new BinaryReader(fs);

                byte[] image = br.ReadBytes((int)fs.Length);

                br.Close();

                fs.Close();

                return image;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
