using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Scrabble
{
    class Dictionnaire
    {

        private string[] diico;
        private List<string> mots2lettre;
        private List<string> mots3lettre;
        private List<string> mots4lettre;
        private List<string> mots5lettre;
        private List<string> mots6lettre;
        private List<string> mots7lettre;
        private List<string> mots8lettre;
        private List<string> mots9lettre;
        private List<string> mots10lettre;
        private List<string> mots11lettre;
        private List<string> mots12lettre;
        private List<string> mots13lettre;
        private List<string> mots14lettre;
        private List<string> mots15lettre;

        public Dictionnaire()
        {
            string contenu2 = File.ReadAllText("Francais.txt");
            string[] con = contenu2.Split('\n');
            string r = "";
            List<string> mots2lettre = new List<string>();
            List<string> mots3lettre = new List<string>();
            List<string> mots4lettre = new List<string>();
            List<string> mots5lettre = new List<string>();
            List<string> mots6lettre = new List<string>();
            List<string> mots7lettre = new List<string>();
            List<string> mots8lettre = new List<string>();
            List<string> mots9lettre = new List<string>();
            List<string> mots10lettre = new List<string>();
            List<string> mots11lettre = new List<string>();
            List<string> mots12lettre = new List<string>();
            List<string> mots13lettre = new List<string>();
            List<string> mots14lettre = new List<string>();
            List<string> mots15lettre = new List<string>();


            foreach (string element in con)
            {
                r += element;
            }
            diico = r.Split(' ');
            for (int i = 0; i < diico.Length; i++)
            {
                switch (diico[i].Length)
                {
                    case 2:
                        mots2lettre.Add(diico[i]);
                        break;
                    case 3:
                        mots3lettre.Add(diico[i]);
                        break;
                    case 4:
                        mots4lettre.Add(diico[i]);
                        break;
                    case 5:
                        mots5lettre.Add(diico[i]);
                        break;
                    case 6:
                        mots6lettre.Add(diico[i]);
                        break;
                    case 7:
                        mots7lettre.Add(diico[i]);
                        break;
                    case 8:
                        mots8lettre.Add(diico[i]);
                        break;
                    case 9:
                        mots9lettre.Add(diico[i]);
                        break;
                    case 10:
                        mots10lettre.Add(diico[i]);
                        break;
                    case 11:
                        mots11lettre.Add(diico[i]);
                        break;
                    case 12:
                        mots12lettre.Add(diico[i]);
                        break;
                    case 13:
                        mots13lettre.Add(diico[i]);
                        break;
                    case 14:
                        mots14lettre.Add(diico[i]);
                        break;
                    case 15:
                        mots15lettre.Add(diico[i]);
                        break;

                }

                this.mots2lettre = mots2lettre;
                this.mots3lettre = mots3lettre;
                this.mots4lettre = mots4lettre;
                this.mots5lettre = mots5lettre;
                this.mots6lettre = mots6lettre;
                this.mots7lettre = mots7lettre;
                this.mots8lettre = mots8lettre;
                this.mots9lettre = mots9lettre;
                this.mots10lettre = mots10lettre;
                this.mots11lettre = mots11lettre;
                this.mots12lettre = mots12lettre;
                this.mots13lettre = mots13lettre;
                this.mots14lettre = mots14lettre;
                this.mots15lettre = mots15lettre;

            }
            /*for(int j = 0;j<mots2lettre.Count;j++)
            {
                Console.Write(mots2lettre.ElementAt(j)+"  ");
            }*/
            /*
                for(int i = 0;i<tab.Length;i++)
                {
                    //if (tab[i] != "2" || tab[i] != "2" || tab[i] != "2" || tab[i] != "2" || tab[i] != "2" || tab[i] != "2" || tab[i] != "2" || tab[i] != "2" || tab[i] != "9" || tab[i] != "10" || tab[i] != "11" || tab[i] != "12" || tab[i] != "13" || tab[i] != "14" || tab[i] != "15")
                    if (tab[i].Equals(typeof(int)))
                    {
                        Console.WriteLine("le type est un entier");
                    }
                    else
                    {
                        dico.Add(tab[i]);
                    }
                }
            */

        }
        public string[] Dico
        {
            get { return diico; }
        }
        public List<string> Listlettres2
        {
            get { return mots2lettre; }
        }
        public List<string> Listlettres3
        {
            get { return mots3lettre; }
        }
        public List<string> Listlettres4
        {
            get { return mots4lettre; }
        }
        public List<string> Listlettres5
        {
            get { return mots5lettre; }
        }
        public List<string> Listlettres7
        {
            get { return mots7lettre; }
        }
        public List<string> Listlettres6
        {
            get { return mots6lettre; }
        }
        public List<string> Listlettres8
        {
            get { return mots8lettre; }
        }
        public List<string> Listlettres9
        {
            get { return mots9lettre; }
        }
        public List<string> Listlettres10
        {
            get { return mots10lettre; }
        }
        public string toString()
        {
            string res = "Le dico possède des mots allant de 2 à 15 lettres par mots, la longueur du dico est de " + diico.Length + " mots.";
           

                res += "\n Pour les mots avec 2 lettres, il y a exactement " + mots2lettre.Count;
            res += "\n Pour les mots avec 3 lettres, il y a exactement " + mots3lettre.Count;
            res += "\n Pour les mots avec 4 lettres, il y a exactement " + mots4lettre.Count;
            res += "\n Pour les mots avec 5 lettres, il y a exactement " + mots5lettre.Count;
            res += "\n Pour les mots avec 6 lettres, il y a exactement " + mots6lettre.Count;
            res += "\n Pour les mots avec 7 lettres, il y a exactement " + mots7lettre.Count;
            res += "\n Pour les mots avec 8 lettres, il y a exactement " + mots8lettre.Count;
            res += "\n Pour les mots avec 9 lettres, il y a exactement " + mots9lettre.Count;
            res += "\n Pour les mots avec 10 lettres, il y a exactement " + mots10lettre.Count;
            res += "\n Pour les mots avec 11 lettres, il y a exactement " + mots11lettre.Count;
            res += "\n Pour les mots avec 12 lettres, il y a exactement " + mots12lettre.Count;
            res += "\n Pour les mots avec 13 lettres, il y a exactement " + mots13lettre.Count;
            res += "\n Pour les mots avec 14 lettres, il y a exactement " + mots14lettre.Count;
            res += "\n Pour les mots avec 15 lettres, il y a exactement " + mots15lettre.Count;


            return res;

        }
        public bool RechDichoRecursif(string mot)
        {
            bool res = false;
            if (mot != null)
            {
                mot = mot.ToUpper();
            }
            for (int i = 0; i < diico.Length; i++)
            {
                if (mot == diico[i])
                {
                    res = true;
                }
            }
            return res;
        }


    }
}