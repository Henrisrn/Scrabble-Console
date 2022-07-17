using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    class Jeton
    {
        private char lettre;
        private int score;
        private int nombreJ;
        private int quantite;
        //private char[] alphabet;
        public Jeton(char lettre)
        {
            this.lettre = lettre;
            int score2 = 0;
            switch (lettre)
            {
                case char k when (k == 'a' || k == 'e' || k == 'i' || k == 't' || k == 'l' || k == 'n' || k == 'o' || k == 'r' || k == 's' || k == 'u'):
                    score2 += 1;
                    break;
                case char k when (k == 'd' || k == 'g' || k == 'm'):
                    score2 += 2;
                    break;
                case char k when (k == 'b' || k == 'c' || k == 'p'):
                    score2 += 3;
                    break;
                case char k when (k == 'f' || k == 'h' || k == 'v'):
                    score2 += 4;
                    break;
                case char k when (k == 'q' || k == 'j'):
                    score2 += 8;
                    break;
                case char k when (k == 'k' || k == 'w' || k == 'x' || k == 'y' || k == 'z'):
                    score2 += 10;
                    break;
                case char k when (k == ' '):
                    score2 += 0;
                    break;
            }
            this.score = score2;
            //alphabet = new char[]{ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        }
        public Jeton(char lettre, int score, int quantite)
        {
            this.lettre = lettre;
            this.score = score;
            this.quantite = quantite;
            nombreJ += quantite;
        }
        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
        public int Score
        {
            get { return score; }
        }
        public char Lettre
        {
            get { return lettre; }
        }
        public override string ToString()
        {
            string res;
            res = "Le jeton " + lettre + " a comme score " + score + " et il reste " + nombreJ + " jetons dans le sac";
            return res;
        }

    }
}
