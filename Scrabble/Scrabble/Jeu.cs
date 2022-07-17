using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    class Jeu
    {
        private Dictionnaire mondico;
        private Plateau monplateau;
        private Sac_Jetons monsac_jetons;
        private Joueur j1;
        public Jeu(Dictionnaire mondico, Plateau monplateau, Sac_Jetons monsac_jetons, Joueur j1)
        {
            this.mondico = mondico;
            this.monplateau = monplateau;
            this.monsac_jetons = monsac_jetons;
            this.j1 = j1;

        }
        public bool Trouveunmot(string mot)
        {
            List<char> maincourante = j1.Lettre;
            bool countains = false;
            bool res = true;
            int j = 0;
            for (int h = 0; h < maincourante.Count; h++)
            {
                Console.WriteLine(" Maincourante[" + h + "] = " + maincourante.ElementAt(h));
            }
            if (mondico.RechDichoRecursif(mot))
            {
                if (maincourante.Count > mot.Length)
                {
                    for (int i = 0; i < mot.Length; i++)
                    {
                        j = 0;
                        while (countains == false)
                        {
                            Console.WriteLine("mot[i] = " + mot[i] + " maincourante.ElementAt(j) = " + maincourante.ElementAt(j));
                            if (mot[i] == maincourante.ElementAt(j))
                            {
                                countains = true;
                                maincourante.Remove(mot[i]);
                            }
                            if (j >= mot.Length)
                            {
                                res = false;
                                break;
                            }
                            else
                            {
                                j++;
                            }
                            Console.WriteLine("countains = " + countains + " j = " + j);
                        }
                        countains = false;

                    }
                }
                else
                {
                    res = false;
                }
            }
            else
            {
                res = false;
            }
            return res;
        }
        public bool Motpossible(string mot)
        {
            bool res = false;
            if (mot != null && mot.Length > 1)
            {
                if (mondico.RechDichoRecursif(mot))
                {
                    Console.Write("Entrez la direction de votre mot :  ");
                    char dir = Convert.ToChar(Console.ReadLine());
                    Console.Write("Entrez la colonne de votre mot :  ");
                    int colo = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Entrez la ligne de votre mot :  ");
                    int ligne = Convert.ToInt32(Console.ReadLine());
                    if (monplateau.Test_Plateau(mot, ligne, colo, dir,mondico, monplateau, j1))
                    {
                        Console.WriteLine("Le mot est possible");
                        res = true;
                        monplateau.Ajoutemot(mot, ligne, colo, dir);
                        monplateau.toString();
                    }

                }
            }
            return res;
        }
        public void ChangerMain()

        {
            Random r = new Random();
            Console.Write("Combien de lettre voulez vous changez :  ");
            int nblettre = int.Parse(Console.ReadLine());
            for (int u = 0; u < nblettre; u++)
            {
                Console.WriteLine("Quel lettre souhaitez vous enlevez ? ");
                char let = char.ToUpper(char.Parse(Console.ReadLine()));
                Jeton j4 = new Jeton(let);
                j1.Remove_Main_Courante(j4);

            }
            for(int i = j1.Lettre.Count;i<7 ;i++)
            {
                Jeton j3 = monsac_jetons.Retire_Jeton(r);
                j1.Add_Main_Courante(j3);
            }
        }
        public void Ajoutelettreapresmot(string mot)
        {
            Random r = new Random();
            while(j1.Lettre.Count<7)
            {
                
                Jeton te = monsac_jetons.Retire_Jeton(r);
                j1.Add_Main_Courante(te);
            }
        }
        public bool Partiefini()
        {
            bool res = false;
            if(monsac_jetons.Sacvide()) //RAJOUTER TIMER EN CONDITION ET ABANDON
            {
                res = true;
            }
            return res;
        }
    
    public string Tostring()
        {
            string res = null;
            res += "Le tour est au joueur " + j1.Nom + " il reste " + monsac_jetons.Nbjetons + " jetons dans le sac";
            return res;
        }
    }
}
