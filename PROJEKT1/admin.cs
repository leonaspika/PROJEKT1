using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    

namespace PROJEKT1
{
    public class Admin
    {

        public static void UnosUdatoteku(string zapis)
        {
            // ensure file exists and append line
            using (StreamWriter sw = new StreamWriter("zivotinje.txt", true))
            {
                sw.WriteLine(zapis);
            }
        }

        public static List<string> Svi()
        {
            var lista = new List<string>();
            if (!File.Exists("zivotinje.txt"))
                return lista;

            using (StreamReader sr = new StreamReader("zivotinje.txt"))
            {
                string linija = sr.ReadLine();
                while (linija != null)
                {
                    // keep raw line with '|' separators so Form3 can parse fields (including saved image filename)
                    lista.Add(linija);
                    linija = sr.ReadLine();
                }
            }
            return lista;
        }
    }
}
