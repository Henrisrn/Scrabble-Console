using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    class Sac_Jetons
    {

        private int nbjetons;
        private List<Jeton> sac;
        private Jeton j1;
        public Sac_Jetons()
        {
            //char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            string contenu2 = File.ReadAllText("Jetons.txt");
            string[] con = contenu2.Split('\n');
            string r = "";
            foreach (string element in con)
            {
                r += element;
            }
            List<Jeton> sac = new List<Jeton>();
            string[] contenu3 = r.Split(';');
            for (int j = 0; j < contenu3.Length - 4; j += 4)
            {
                j1 = new Jeton(Convert.ToChar(contenu3[j + 1]), Convert.ToInt32(contenu3[j + 2]), Convert.ToInt32(contenu3[j + 3]));
                sac.Add(j1);
                nbjetons += Convert.ToInt32(contenu3[j + 3]);
            }
            this.sac = sac;
        }
        public int Nbjetons
        {
            get { return nbjetons; }
        }
        public Jeton Retire_Jeton(Random r)
        {
            int numjeton = r.Next(1, 27);
            Jeton j2 = sac.ElementAt(numjeton);
            j2.Quantite--;
            nbjetons--;

            return j2; // il faut aussi faire le décompte et tt
        }
        public void Retire_JetonPrecis(Jeton j1)
        {
            j1.Quantite--;
            nbjetons--;
            // il faut aussi faire le décompte et tt
        }
        public bool Sacvide()
        {
            bool res = false;
            if(nbjetons <= 7 || sac.Count <= 7)
            {
                res = true;
            }
            return res;
        }
        public override string ToString()
        {

            string res = "Dans le sac il y a " + nbjetons + " jetons";
            return res;
        }
    }
}
