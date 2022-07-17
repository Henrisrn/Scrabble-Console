using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Scrabble
{
    class Joueur
    {
        private string nom;
        private int score;
        private List<string> mots;
        private List<char> lettres;
        public Joueur(string file)
        {
            string contenu = File.ReadAllText(file);
            string[] contenu1 = contenu.Split(';');
            nom = contenu1[0];
            score = Convert.ToInt32(contenu1[1]);
            List<string> mots = new List<string>();
            List<char> lettres = new List<char>();
            for (int i = 2; i < contenu1.Length; i++)
            {
                if (contenu1[i].Length == 1)
                {
                    contenu1[i].ToLower();
                    lettres.Add(Convert.ToChar(contenu1[i]));
                }
                else
                {
                    mots.Add(contenu1[i]);
                }

            }
            this.mots = mots;
            this.lettres = lettres;



        }
         // Faire un autre constructeur avec le fichier txt mais la aussi pas utile pour l'instant pour le CC
        public Joueur(string nom, int score, List<string> mots, List<char> lettres)
        {
            for(int i = 0;i<lettres.Count;i++)
            {
                char.ToUpper(lettres.ElementAt(i));
                
            }
            if(score < 0)
            {
                this.score = 0;
            }
            else
            {
                this.score = score;
            }
            this.mots = mots;
            this.lettres = lettres;

            if (nom != null)
            {

                nom = nom.ToLower();
                this.nom = nom;
            }
            else
            {
                Console.WriteLine("Veuillez saisir un nom");
            }
        }
        public string Nom
        {
            get { return nom; }
        }
        public List<char> Lettre
        {
            get { return lettres; }
        }
        public List<string> Mots
        {
            get { return mots; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        
        public void Add_Mot(string mot)
        {
            this.mots.Add(mot);
        }
        public string toString()
        {
            string res;
            res = "Le joueur " + nom + " a comme mots ";
            for (int i = 0; i < mots.Count; i++)
            {
                res += mots.ElementAt(i) + " et ";
            }
            if (mots.Count > 0)
            {
                res += " ce qui fait exactement " + (mots.Count - 1) + " mots mais aussi il a comme lettre ";
            }
            else
            {
                res += " ce qui fait exactement " + mots.Count + " mots mais aussi il a comme lettre ";
            }
            for (int j = 0; j < lettres.Count; j++)
            {
                res += lettres.ElementAt(j) + " et ";
            }
            res += " ce qui fait exactement " + lettres.Count + " lettres tout cela lui fait un score de " + score + " ce qui est pas mal";
            return res;
        }
        public void Add_Score(int val)
        {
            score += val;
        }
        public void Add_Main_Courante(Jeton monjeton)
        {
            //int sco = monjeton.Score;
            char a = monjeton.Lettre;
            //Add_Score(sco);
            lettres.Add(a);
        }
        public void Remove_Main_Courante(Jeton monjeton)
        {
            int sco = monjeton.Score;
            char a = monjeton.Lettre;
            if (lettres.Contains(char.ToUpper(a)))
            {
                score -= sco;
                lettres.Remove(a);
            }
            else
            {
                Console.WriteLine("La lettre n'est pas dans la mains du joueur   :   " +monjeton.Lettre);
            }
        }

    }
}
