using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

namespace Scrabble
{
    class Plateau
    {
        private Jeton[,] plateau;
        private char[,] matchar;
        private Sac_Jetons sac;
        private Dictionnaire dico;
        private Joueur joueur;
        public Plateau(Sac_Jetons sac,string file)
        {
            //this.sac = new sac();
            string[] tabstr = new string[15];
            string contenu = File.ReadAllText(file); // CHANGER LE FICHIER POUR LA REVUE DE CODE
            for (int x = 0; x < 15; x++)
            {
                tabstr[x] = contenu.Split('\n')[x];

            }

            char[,] matchar = new char[15, 15];
            int a = 0;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    matchar[i, j] = Convert.ToChar(tabstr[i].Split(';')[j]);
                    //Console.Write(matchar[i, j]);
                    a = j;
                }
            }
            Jeton[,] plateau = new Jeton[15, 15];
            for (int i = 0; i < matchar.GetLength(0); i++)
            {
                for (int j = 0; j < matchar.GetLength(1); j++)   // On parcours la matrice (on pourrait mettre 15 directement)
                {
                    if (matchar[i, j] != '_')
                    {
                        plateau[i, j] = new Jeton(matchar[i, j]);     //On créer un Jeton avec la lettre de la mtrice de char et réduire le sac de jeton
                        if(plateau[i, j] != null)
                        {
                            sac.Retire_JetonPrecis(plateau[i, j]);
                            
                        }
                        
                    }
                }

            }
           
            Dictionnaire dico = new Dictionnaire();
            this.plateau = plateau;
            this.matchar = matchar;
            this.dico = dico;
            this.sac = sac;
        }
        public char[,]Matchar
        {
            get { return matchar; }
        }


        public Jeton[,] MatJetons { get { return plateau; } }

        public string toString() // A FINIR
        {
            string res = null;
            int[,] iDBonus = new int[15, 15]
                             {  { 4,0,0,1,0,0,0,4,0,0,0,1,0,0,4},{ 0,3,0,0,0,2,0,0,0,2,0,0,0,3,0},{ 0,0,3,0,0,0,1,0,1,0,0,0,3,0,0},{ 1,0,0,3,0,0,0,1,0,0,0,3,0,0,1},{ 0,0,0,0,3,0,0,0,0,0,3,0,0,0,0},{ 0,2,0,0,0,2,0,0,0,2,0,0,0,2,0},{ 0,0,1,0,0,0,1,0,1,0,0,0,1,0,0},{ 4,0,0,1,0,0,0,0,0,0,0,1,0,0,4},{ 0,0,1,0,0,0,1,0,1,0,0,0,1,0,0},{ 0,2,0,0,0,2,0,0,0,2,0,0,0,2,0},{ 0,0,0,0,3,0,0,0,0,0,3,0,0,0,0},{ 1,0,0,3,0,0,0,1,0,0,0,3,0,0,1},{ 0,0,3,0,0,0,1,0,1,0,0,0,3,0,0},{ 0,3,0,0,0,2,0,0,0,2,0,0,0,3,0},{ 4,0,0,1,0,0,0,4,0,0,0,1,0,0,4}};
            Console.ResetColor();
            for (int i = 0; i < plateau.GetLength(0); i++)
            {
                for (int j = 0; j < plateau.GetLength(1); j++)
                {
                    switch (iDBonus[i, j])
                    {
                        case 0:
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            break;
                        case 1:
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            break;
                        case 2:
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case 3:
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            break;
                        case 4:
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;


                    }
                    //res = res + " | " + matchar[i, j];
                    if (plateau[i, j] != null)
                    {
                        Console.Write(char.ToUpper(plateau[i, j].Lettre) + " ");
                    }

                    else { Console.Write("  "); }

                }
                Console.Write("\n");
            }
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            return res;
        }


            /*
            string res = null;
            for (int i = 0; i < plateau.GetLength(0); i++)
            {
                for (int j = 0; j < plateau.GetLength(1); j++)
                {
                    res = res + " | " + matchar[i,j];
                }
                res += '\n';
            }
            return res;
            
            
        }

        

        /*public int[,] IDBonus()
        {
            int[,] iDBonus = new int[15,15];
            return IDBonus = {  { 4,0,0,1,0,0,0,4,0,0,0,1,0,0,4},
                                { 0,3,0,0,0,2,0,0,0,2,0,0,0,3,0},
                                { 0,0,3,0,0,0,1,0,1,0,0,0,3,0,0},
                                { 1,0,0,3,0,0,0,1,0,0,0,3,0,0,1},
                                { 0,0,0,0,3,0,0,0,0,0,3,0,0,0,0},
                                { 0,2,0,0,0,2,0,0,0,2,0,0,0,2,0},
                                { 0,0,1,0,0,0,1,0,1,0,0,0,1,0,0},
                                { 4,0,0,1,0,0,0,0,0,0,0,1,0,0,4},
                                { 0,0,1,0,0,0,1,0,1,0,0,0,1,0,0},
                                { 0,2,0,0,0,2,0,0,0,2,0,0,0,2,0},
                                { 0,0,0,0,3,0,0,0,0,0,3,0,0,0,0},
                                { 1,0,0,3,0,0,0,1,0,0,0,3,0,0,1},
                                { 0,0,3,0,0,0,1,0,1,0,0,0,3,0,0},
                                { 0,3,0,0,0,2,0,0,0,2,0,0,0,3,0},
                                { 4,0,0,1,0,0,0,4,0,0,0,1,0,0,4}};
        }*/

        //MODIF
        public bool Tabvide()
        {
            bool res = true;
            for(int i=0;i<plateau.GetLength(0);i++)
            {
                for(int j = 0;j<plateau.GetLength(1);j++)
                {
                    if(matchar[j,i] != '_')
                    {
                        res = false;
                    }
                }
            }
            return res;
        }
        public bool EstLibre(string mot, int ligne, int colonne, char direction)
        {
            bool res = true;

            for (int i = 0; i < mot.Length; i++)
            {
                try
                {
                    if (direction == 'v')
                    {
                        if (plateau[ligne + i, colonne] != null && plateau[ligne + i, colonne].Lettre != char.ToUpper(mot[i]))
                        {
                            //Console.WriteLine(plateau[ligne + i, colonne].Lettre + " =/= " + char.ToUpper(mot[i]));
                            res = false;
                        }
                    }
                    if (direction == 'h')
                    {
                        if (plateau[ligne, colonne + i] != null && plateau[ligne, colonne + i].Lettre != char.ToUpper(mot[i]))
                        {
                            //Console.WriteLine(plateau[ligne, colonne + i].Lettre + " =/= " + char.ToUpper(mot[i]));
                            res = false;
                        }
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    res = false;
                    break;
                }
            }

            //Console.WriteLine("Est Libre" + res);
            return res;
        }

        public static bool MotExiste(string mot, Dictionnaire dico)
        {
            bool res = false;
            //Console.WriteLine("mot dans MotExiste : " + mot);

            if (mot != null)
            {

                if (mot.Length > 1)
                {

                    if (dico.RechDichoRecursif(mot)) { res = true; }
                }
            }
            //Console.WriteLine("On sort de MotExiste avec " + mot + " " + res);
            return res;
        }
        public bool LettreEnMain(string mot, int ligne, int colonne, char direction, Joueur joueur)
        {
            bool res = false;
            
            List<char> charManquant = new List<char>(); // liste de char et pas jeton car la main courante est une liste de char
            for (int i = 0; i < mot.Length; i++)
            {
                if (mot != null && ligne > 0 && colonne > 0 && ligne <= 15 && colonne <= 15)
                {
                    if (direction == 'h')
                    {
                        if (plateau[ligne, colonne + i] != null) // si l'emplacement est null j ajoute la lettre nécessaire a la liste
                        {

                        }
                        else
                        {
                            charManquant.Add(mot[i]);
                        }
                    }
                    if (direction == 'v')
                    {
                        if (plateau[ligne + i, colonne] != null) // si l'emplacement est null j ajoute la lettre nécessaire a la liste
                        {

                        }
                        else
                        {
                            charManquant.Add(mot[i]);

                        }
                    }
                }
            }

            List<char> ListBonResultats = new List<char>();// liste des jetons qui sont a la fois manquant et dans la mains du joueur 
            foreach (char c in charManquant) // la meme que for(int j =0; j<charManquant.Count(); j++)
            {
                if (joueur.Lettre.Contains(char.ToUpper(c)))
                {
                    ListBonResultats.Add(c);
                    joueur.Remove_Main_Courante(new Jeton(char.ToUpper(c)));
                    Console.WriteLine(" Jeton enlevé en main : " + char.ToUpper(c));
                }

            }

            if (charManquant.Count == ListBonResultats.Count) { res = true; }// si TOUS les jetons manquants sont dans la main du joueur c'est qu'il peut écrire le mot

            return res;
        }
        #region jeu
        public List<string> ListeMotAdj(string mot, int ligne, int colonne, char direction, Jeton[,] plateau)
        {
            //Console.WriteLine("On passe dans Liste Mot Adj");
            List<string> listeMotAdj = new List<string>();
            string nouveauMot = null;
            int j = 0; // j est utile pour si on trouve un mot adjacent
            bool motAdjTrouve = false;
            if (direction == 'h')
            {
                for (int i = 0; i < mot.Length; i++) //pour toutes les lettre même les extrémités
                {

                    nouveauMot = null;//réinitialiser la string
                    motAdjTrouve = false; // réinitialiser le bool
                    if (ligne >= 1 && plateau[ligne - 1, colonne + i] != null) // on test pour le cas ou une lettre est au dessus mais rien en dessous
                    {

                        j = 1;

                        while (plateau[ligne - j, colonne + i] != null)// ca teste les cases une par une jusqu'a tomber sur un emplacement vide
                        {
                            if (ligne - j == 0) { break; }//touche un mur aka bord la matrice
                            j++;
                        }


                        while (plateau[ligne - j + 1, colonne + i] != null)
                        {

                            if (plateau[ligne - j, colonne + i] != null) { nouveauMot += plateau[ligne - j, colonne + i].Lettre; } // on ajoute lettre par lettre sauf la dernière
                            if (ligne + j == 15) { break; }
                            j--;
                            if (plateau[ligne - j, colonne + i] != null && plateau[ligne - j + 1, colonne + i] == null) { nouveauMot += plateau[ligne - j, colonne + i].Lettre; } // on ajoute la dernière lettre du mot 
                            if (ligne - j + 1 == ligne && plateau[ligne - j + 1, colonne + i] == null) { nouveauMot += mot[i]; } // Le cas ou le mot completé est au dessus du mot ajouté, il faut ajouter la lettre du mot ajouté Ex : GY que l'on complète par un M
                        }

                        //Console.WriteLine("nouveau mot : " + nouveauMot);
                        if (nouveauMot != null)
                        {
                            listeMotAdj.Add(nouveauMot);// on ajoute le mot a la liste
                            motAdjTrouve = true; // comme ca si on détecte un mot en haut et en bas, on lance pas 2 fois l'algo
                        }

                    }
                    if (ligne < 14 && plateau[ligne + 1, colonne + i] != null && motAdjTrouve == false)
                    {
                        j = 1;
                        nouveauMot += mot[i];
                        while (ligne + j <= 14 && plateau[ligne + j, colonne + i] != null)
                        {
                            nouveauMot += plateau[ligne + j, colonne + i].Lettre;
                            j++;
                        }

                        if (nouveauMot != null)
                        {
                            listeMotAdj.Add(nouveauMot);// on ajoute le mot a la liste
                        }
                    }
                }
            }
            if (direction == 'v')// on refait la meme en vertical 
            {
                for (int i = 0; i < mot.Length; i++) //pour toutes les lettre même les extrémités

                {
                    j = 1;
                    nouveauMot = null;//réinitialiser la string
                    motAdjTrouve = false; // réinitialiser le bool
                    if (colonne >= 1 && plateau[ligne + i, colonne - 1] != null) // on test pour le cas ou une lettre est la gauche 
                    {


                        while (plateau[ligne + i, colonne - j] != null)// ca teste les cases une par une jusqu'a tombé sur un emplacement vide
                        {
                            if (colonne - j == 0) { break; }
                            j++;
                        }

                        while (plateau[ligne + i, colonne - j + 1] != null)
                        {

                            if (plateau[ligne + i, colonne - j] != null) { nouveauMot += plateau[ligne + i, colonne - j].Lettre; } // on ajoute lettre par lettre sauf la dernière
                            if (colonne + j == 15) { break; }
                            j--;
                            if (plateau[ligne + i, colonne - j] != null && plateau[ligne + i, colonne - j + 1] == null) { nouveauMot += plateau[ligne + i, colonne - j].Lettre; } // on ajoute la dernière lettre du mot                                                                                                                                                      
                            if ((colonne - j + 1) == colonne && plateau[ligne + i, colonne - j + 1] == null) { nouveauMot += mot[i]; } // Le cas ou le mot completé est au dessus du mot ajouté, il faut ajouter la lettre du mot ajouté Ex : GY que l'on complète par un M
                        }

                        if (nouveauMot != null)
                        {
                            listeMotAdj.Add(nouveauMot);// on ajoute le mot a la liste
                            motAdjTrouve = true;// comme ca si on détecte un mot en haut et en bas, on lance pas 2 fois l'algo
                        }

                    }
                    if (motAdjTrouve == false && colonne < 14 && plateau[ligne + i, colonne + 1] != null)
                    {
                        j = 1;
                        nouveauMot += mot[i];
                        while (colonne + j <= 14 && plateau[ligne + i, colonne + j] != null)
                        {
                            nouveauMot += plateau[ligne + i, colonne + j].Lettre;
                            j++;
                        }

                        if (nouveauMot != null)
                        {
                            listeMotAdj.Add(nouveauMot);// on ajoute le mot a la liste
                        }
                    }
                }
            }
            //Console.Write("Liste mot adj : ");
            foreach (string a in listeMotAdj) { Console.Write(a + " ;"); }
            //Console.WriteLine(" \n On sort de Liste mot Adj");
            return listeMotAdj;
        }
        #endregion jeu

        /*public static Plateau NouveauPlateau(string mot, int ligne, int colonne, char direction, Jeton[,] plateau)
        {
            Plateau res = null;
            for(int i = 0; i < mot.Length; i++)
            {
                if(plateau[ligne, colonne + i] != null && direction == 'h') { plateau[ligne, colonne + i] = new Jeton(mot[i]); }
                if (plateau[ligne+ i, colonne] != null && direction == 'v') { plateau[ligne + i, colonne ] = new Jeton(mot[i]); }
            }
            res = new Plateau(plateau);
            return res;
        }*/
        public bool Test_Plateau(string mot, int ligne, int colonne, char direction, Dictionnaire dico, Plateau plateau, Joueur joueur)
        {
            bool res = false;
            ligne -= 1; // pour être en accord avec la ligne et colonne qui commence par 1 et non 0
            colonne -= 1;
            //MODIF
            bool vide = true;
            for (int i = 0; i < matchar.GetLength(0); i++)
            {
                for (int j = 0; j < matchar.GetLength(1); j++)
                {
                    if (matchar[j, i] != '_')
                    {
                        res = false;
                    }
                }
            }
            if (vide == true && LettreEnMain(mot, ligne, colonne, direction, joueur))
            {
                return true;
            }
            int CompteurDeMotFaux = 0;
            List<string> motAdjacents = ListeMotAdj(mot, ligne, colonne, direction, plateau.MatJetons);
            if (mot != null && ligne >= 0 && colonne >= 0 && ligne <= 15 && colonne <= 15)
            {
                if (direction == 'v' || direction == 'h')
                {
                    if (MotExiste(mot, dico) && EstLibre(mot, ligne, colonne, direction) && LettreEnMain(mot, ligne, colonne, direction, joueur) && motAdjacents.Count > 0)//RAJOUTER AU MOINS UNE LETTRE POSEE
                    {
                        foreach (string motAdj in motAdjacents)
                        {
                            if (MotExiste(motAdj, dico) == false) { CompteurDeMotFaux += 1; }
                        }
                        if (CompteurDeMotFaux == 0) { res = true; }
                    }
                }

            }
            return res;
        }
        public void Ajoutemot(string mot, int ligne, int colonne, char direction)
        {
            ligne--;
            colonne--;
            if (direction == 'v')
                        {
                            
                            for (int i = 0; i < mot.Length ; i++)
                            {
                                Jeton j1 = new Jeton(Convert.ToChar(mot[i]));
                                //Console.WriteLine("tableau [" + (colonne-1) + " , " + i + "]  = " + plateau[colonne, i]);
                                plateau[ligne+i,colonne] = j1;
                                matchar[ligne+i,colonne] = char.ToUpper(j1.Lettre);
                                //Console.WriteLine("tableau [" + (colonne-1) + " , " + i + "]  = " + plateau[colonne, i]);
                            }
                        }
                        if(direction == 'h')
                        {
                for (int i = 0; i < mot.Length; i++)
                {
                    Jeton j1 = new Jeton(Convert.ToChar(mot[i]));
                                //Console.WriteLine("tableau [" + i + " , " + ligne + "]  = " + plateau[i, ligne]);
                                //Console.WriteLine(char.ToUpper(j1.Lettre));
                                //Console.WriteLine("tableau [" + i + " , " + ligne + "]  = " + plateau[i, ligne]);
                                plateau[ligne, colonne + i] = j1;
                                matchar[ligne, colonne + i] = char.ToUpper(j1.Lettre);

                }
                }
            for(int h = 0;h<mot.Length;h++)
            {
                Random r = new Random();
                Jeton te = sac.Retire_Jeton(r);
                
            }
        }
        public int Ajoutescor(string mot)
        {

            int res = 0;
            for (int i = 0; i < mot.Length; i++)
            {
                char e = Convert.ToChar(mot[i]);
                Jeton test = new Jeton('e');
                res += test.Score;
            }
            return res;
        }
    }
    
}