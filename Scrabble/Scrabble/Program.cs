using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Timers;


namespace Scrabble
{
    class Program
    {
        /* TRUCS QUI RESTE A FAIRE
         * - Organiser le Main + FAIT
         * - Faire test Unitaire +
         * Finir Couleur+ FAIT
         * Finir Bonus plateau +
         * Arranger le dico MOITIE FAIT
         * Finir class Jeu +
         * Arranger Le Timer + FAIT
         * Faire un systeme pour plusierus FAIT (on va dire que ça va)
         * 
         * 
         * 
         * File.WriteAllBytes Similaire a File.ReadAllBytes (plus haut) mais en écriture – ex: fichier
multimédia.
File.WriteAllLines Stocke un tableau de chaine dans un fichier spécifié, en réécrivant par
dessus le fichier si celui-ci existait préalablement
File.WriteAllText Similaire à ReadAlltext mais, écriture d'une chaine de caractères dans
un fichier .
         */



        static List<Jeton> Readfi()
        {
            StreamReader lecteur = new StreamReader("Jetons.txt");
            List<Jeton> res = new List<Jeton>();
            while (lecteur.EndOfStream)
            {
                string ligne = lecteur.ReadLine();
                string[] tab = ligne.Split(';');
                Jeton j1 = new Jeton(Convert.ToChar(tab[0]), Convert.ToInt32(tab[1]), Convert.ToInt32(tab[2]));
                res.Add(j1);
            }
            lecteur.Close();
            return res;
        }

        static void SetTimer()
        {

            aTimer = new System.Timers.Timer(1000 * 60*6);

            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            PartieFinieTimer();
            aTimer.Stop();
            aTimer.Dispose();
        }
        static void PartieFinieTimer()
        {
            Console.WriteLine("6 minutes écoulées : Partie Finie ");
            
                while (true)
                {

                }
        }

        static System.Timers.Timer aTimer;
        
        static void Testfile(List<Jeton> sac)
        {
            if (sac != null && sac.Count != 0)
            {
                for (int i = 0; i < sac.Count; i++)
                {
                    Console.WriteLine(sac.ElementAt(i).ToString());
                }
            }
        }
       
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le Jeu SCRABBLE  !!! (trop de temps passer sur cette merde)");
            Console.WriteLine("Pour rappel le jeu dure 6min, il y a 102 jetons au total,");
            
            
            //INITIALISATION
            Dictionnaire dico = new Dictionnaire();
            Sac_Jetons sac = new Sac_Jetons();
            Console.WriteLine(sac.ToString());
            List<Joueur> ttlesjoueurs = new List<Joueur>();
            Plateau p1 = new Plateau(sac, "InstancePlateauTestVide.txt");
            Console.WriteLine(p1.toString());
            List<Jeu> ttlesjeu = new List<Jeu>();
            Random r = new Random();
            SetTimer();
            // FIN INITIALISATION


            //Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now); //Il faut mettre un timer pour à chaque fois une personne trouve un mot)
            //Initialise les variable

            //string[] createText = { "Hello", "And", "Welcome" }; // texte à enregistrer
            //File.WriteAllLines("Jetons.txt", createText);
            // EXPLICATION : 1 Case du tableau = 1 ligne sur le fichier texte



            Console.Write("Combien de joueur voulez vous mettre :  ");
            Joueur n1 = null;
            int nbjoueur = int.Parse(Console.ReadLine());
            Jeu jeuref = null;
            for(int f = 0;f<nbjoueur;f++)
            {
                Console.Write("Voulez vous importé un joueur via un fichier ou le faire vous même (1 ou 2):  ");
                int a = int.Parse(Console.ReadLine());

                if (a == 1)
                {
                    Console.Write("Entrez le nom du fichier que vous voulez utiliser (NE PAS METTRE .txt) Si vous voulez utilisez la valeur de base mettez 0  :  ");
                    string fich = Console.ReadLine();
                    if (fich == "0")
                    {
                        Console.WriteLine("Nous allons utiliser le fichier nom  : Joueur.txt");
                        n1 = new Joueur("Joueur.txt");
                    }
                    else
                    {
                        Console.WriteLine("Nous allons utiliser le fichier nom  : "+fich+".txt");
                        n1 = new Joueur(fich+".txt");
                    }
                    ttlesjoueurs.Add(n1);
                    Jeu jeu3 = new Jeu(dico,p1,sac,n1);
                    ttlesjeu.Add(jeu3);
                    jeuref = jeu3;
                }
                else
                {
                    Console.Write("Nom du Joueur : ");
                    string nom = Console.ReadLine();
                    List<char> main = new List<char>();
                    for (int i = 0; i < 7; i++)
                    {
                        main.Add(char.ToUpper(sac.Retire_Jeton(r).Lettre));
                    }
                    
                    List<string> mots = new List<string>();
                    n1 = new Joueur(nom, 0, mots, main);
                    
                    ttlesjoueurs.Add(n1);
                    Jeu jeu3 = new Jeu(dico, p1, sac, n1);
                    ttlesjeu.Add(jeu3);
                    jeuref = jeu3;
                }

            }


            //SAUVEGARDE JOUEUR
            List<string> createText = new List<string>();
            for (int b = 0; b < ttlesjoueurs.Count; b++)
            {
                Joueur sauv = ttlesjoueurs.ElementAt(b);
                string mots = null;
                string lettre = null;
                for(int k = 0;k<sauv.Mots.Count;k++)
                {
                    mots += ";" + sauv.Mots.ElementAt(k);
                }
                for (int k = 0; k < sauv.Mots.Count; k++)
                {
                    lettre += ";" + sauv.Lettre.ElementAt(k);
                }
                createText.Add(sauv.Nom + ";" + sauv.Score + ";");
                createText.Add(mots);
                createText.Add(lettre);// texte à enregistrer


            }
            string[] res = new string[createText.Count];
            for(int m = 0;m<createText.Count;m++)
            {
                res[m] = createText.ElementAt(m);
            }
            File.WriteAllLines("SauvegardeJoueur.txt", res);

            //CODE PARTIE
            //CHANGEMENT N°1
            
            
            while (jeuref.Partiefini() == false)
            {
                for (int p = 0; p < ttlesjoueurs.Count; p++)
                {
                    
                    Joueur n3 = ttlesjoueurs.ElementAt(p);
                    Jeu jeu1 = ttlesjeu.ElementAt(p);
                    string nom = n3.Nom.ToUpper();
                    Console.WriteLine("----------------AU TOUR DE " + nom + "-----------------");
                    Console.WriteLine(n3.toString());
                    Console.WriteLine(sac.ToString());
                    Console.Write("Voulez vous poser un mot ou changer vos lettres (TRUE ou FALSE) :   ");
                    bool choix = bool.Parse(Console.ReadLine());
                    if (choix == true)
                    {
                        Console.Write("Entrez un mot :   ");
                        string mo = Console.ReadLine();
                        //string mo = "manger";
                        int ligne = 0;
                        int colo = 0;
                        char dir = 'u';
                        if (dico.RechDichoRecursif(mo) )
                        {
                            if (p1.Tabvide() == false)
                            {
                                Console.Write("Entrez la direction de votre mot :  ");
                                //char dir = 'h';
                                dir = Convert.ToChar(Console.ReadLine());
                                Console.Write("Entrez la colonne de votre mot :  ");
                                //int colo = 7;
                                colo = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Entrez la ligne de votre mot :  ");
                                //int ligne = 7;
                                ligne = Convert.ToInt32(Console.ReadLine());
                            }
                            else
                            {
                                Console.Write("Entrez la direction de votre mot :  ");
                                //char dir = 'h';
                                dir = Convert.ToChar(Console.ReadLine());
                                colo = 8;
                                ligne = 8;
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            if (p1.Test_Plateau(mo, ligne, colo, dir, dico, p1, n3))
                            {
                                Console.WriteLine("Le mot est possible");


                                p1.Ajoutemot(mo, ligne, colo, dir);
                                
                                jeu1.Ajoutelettreapresmot(mo);
                                n3.Add_Score(p1.Ajoutescor(mo));
                                n3.Add_Mot(mo.ToUpper());
                            }
                            else
                            {
                                Console.WriteLine("Le mot ne peut pas être placé sur le plateau");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Le mot n'est pas français");
                        }
                        Console.WriteLine();
                        Console.WriteLine(p1.toString());
                        Console.WriteLine();
                        Console.WriteLine(n3.toString());

                    }
                    else
                    {

                        jeu1.ChangerMain();
                        Console.WriteLine(n1.toString());
                    }
                    Console.WriteLine("---------------------------Joueur suivant------------------------------");
                    char[,] match = p1.Matchar;
                    string[] res2 = new string[15];
                    string q = null;
                    for (int m = 0; m < match.GetLength(0); m++)
                    {
                        for (int t = 0; match.GetLength(1) < 15; t++)
                        {
                            q += match[t, m]+";";
                        }
                        res2[m] = q;
                    }

                    File.WriteAllLines("SauvegardePlateau.txt", res2);
                }
                /*
                Console.WriteLine(n2.toString());
                Console.WriteLine(sac.ToString());
                Console.Write("Voulez vous poser un mot ou changer vos lettres (true ou false) :   ");
                choix = bool.Parse(Console.ReadLine());
                if (choix == true)
                {
                    Console.Write("Entrez un mot :   ");
                    string mo = Console.ReadLine();
                    //string mo = "manger";
                    Console.Write("Entrez la direction de votre mot :  ");
                    //char dir = 'h';
                    char dir = Convert.ToChar(Console.ReadLine());
                    Console.Write("Entrez la colonne de votre mot :  ");
                    //int colo = 7;
                    int colo = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Entrez la ligne de votre mot :  ");
                    //int ligne = 7;
                    int ligne = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine();
                    if (p1.Test_Plateau(mo, ligne, colo, dir, dico, p1, n2))
                    {
                        Console.WriteLine("Le mot est possible");


                        p1.Ajoutemot(mo, ligne, colo, dir);
                        jeu1.Ajoutelettreapresmot(mo);
                        n2.Add_Score(p1.Ajoutescor(mo));
                        n2.Add_Mot(mo.ToUpper());
                    }
                    Console.WriteLine(p1.toString());
                    Console.WriteLine(n2.toString());
                    Console.WriteLine(sac.ToString());
                }
                else
                {
                    
                    jeu1.ChangerMain();
                    Console.WriteLine(n2.toString());
                }
                Console.WriteLine("---------------------------Joueur suivant------------------------------");
            }
                
                Console.WriteLine("Début de l'initialisation");
                bool findepartie = false; //Faire une fonction qui dit quand la partie se fini
                while (findepartie == false)
                {
                    SetTimer();
                    Console.WriteLine("Début du timmer");
                    while (aTimer.Enabled == true)
                    {
                        Console.WriteLine(jeu1.Tostring());
                        Console.WriteLine("Voulez vous trouver un mot ou changer de lettre ?");
                        bool choix = bool.Parse(Console.ReadLine());

                        if (choix)
                        {
                            bool continu = false;
                            while (continu == false)
                            {
                                Console.Write("Entrez un mot :   ");
                                string mo = Console.ReadLine();
                                continu = jeu1.Motpossible(mo);

                            }
                        }
                        else
                        {
                            jeu1.ChangerMain();
                        }
                        p1.toString();
                    }

                    Console.WriteLine("Prochain Joueur");
                }*/
                //}
            }
            /*
            char[,] match = p1.Matchar;
            string[] res2 = new string[createText.Count];
            string q = null;
            for (int m = 0; m < 15; m++)
            {
                for (int t = 0; t < 15; t++)
                {
                    q += match[t, m];
                }
                res[m] = q;
            }
            
            File.WriteAllLines("SauvegardePlateau.txt", res2);*/
            Console.WriteLine("La partie est fini");
            //A NE PAS TOUCHER CAR CECI MARQUE LA FIN DU TIMER
            Console.ReadLine();

        }
    }
}


