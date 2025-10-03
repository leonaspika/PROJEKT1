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
            StreamWriter sw=new StreamWriter("zivotinje.txt");
            sw.WriteLine(zapis);
            sw.Close();
            
        }
        public static List<string> Svi()
        {
            List<string> lista = new List<string>();
            StreamReader sr = new StreamReader("zivotinje.txt");
            string linija=sr.ReadLine();
           while(linija != null)
            {
                linija=linija.Replace("|", " ");
                lista.Add(linija);
                linija=sr.ReadLine();
            }
            sr.Close();
            return lista;
        }
    }
}
