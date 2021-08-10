using System;
using System.Collections.Generic;
using System.IO;
using AsciiArt;


namespace jeu_du_pendu
{
    class Program
    {
        static void AfficherMot(string mot, List<char> lettre)
        {
            for (int i = 0; i < mot.Length; i++)
            {
                char let = mot[i];

                if (lettre.Contains(let))
                {
                    Console.Write(let + " ");
                }
                else
                {
                    Console.Write("_ ");

                }

            }
            Console.WriteLine();
        }

        static char DemanderUneLettre(String message="Rentrez une lettre :")
        {
            while (true)
            {
                Console.Write(message);
                string reponse = Console.ReadLine();

                if (reponse.Length == 1)
                {
                    reponse = reponse.ToUpper();
                    return reponse[0];

                }
                Console.WriteLine("Veuille entrez une seul lettre ");

            }
        }

        static void DevinerMot(string mot)
        {
            const int NB_VIES = 6;
            int vie = NB_VIES;
            var motAdeviner = new List<Char>();
            var lettreEntrer = new List<char>();
            while (vie > 0)
            {
                Console.WriteLine(Ascii.PENDU[NB_VIES - vie]);
                Console.WriteLine();
                AfficherMot(mot, motAdeviner);
                Console.WriteLine();
                var lettre = DemanderUneLettre();
                Console.Clear();

                if (mot.Contains(lettre))
                {
                    Console.WriteLine($"la lettre est dans le mot ");
                    motAdeviner.Add(lettre);

                    if (ToutLesLettreTrouve(mot, motAdeviner))
                    {

                        break;
                    }
                }
                else
                {

                    if (!lettreEntrer.Contains(lettre))
                    {
                        vie--;
                        lettreEntrer.Add(lettre);
                    }


                    Console.WriteLine("vie restante " + vie);
                }
                if (lettreEntrer.Count > 0)
                {
                    Console.WriteLine("Le mot ne contient pas la lettre :" + string.Join(" , ", lettreEntrer));
                }
                Console.WriteLine();
            }
            if (vie == 0)
            {
                Console.WriteLine(Ascii.PENDU[6]);
                Console.WriteLine();
                Console.WriteLine($"Vous avez perdu ! Le mot qu'il fallait deviner était : {mot}");
            }
            else
            {
                AfficherMot(mot, motAdeviner);
                Console.WriteLine();
                Console.WriteLine("Bravo , avez deviner le mot");
            }

        }

        static bool ToutLesLettreTrouve(string mot, List<char> lettres)
        {
            foreach (var lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }
            if (mot.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string[] ChargerMotDuFicher(string nomDuFichier)
        {
            try
            {
                return File.ReadAllLines(nomDuFichier);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur de lecture du fichier " + nomDuFichier + "(" + ex.Message);
            }
            return null;
        }

        static bool DemanderDeRejouer()
        {
            
            char reponse = DemanderUneLettre("Voulez vous rejour ? o/n :");
            if ((reponse == 'o') || (reponse == 'O'))
            {
                return true;
            }
            else if ((reponse == 'n') || (reponse == 'N'))
            {
                return false;
            }

            else
            {
                Console.WriteLine("erreru : Vous devez repondre avec o ou n");
                return DemanderDeRejouer();
            }
        }

        static void Main(string[] args)
        {
            Random r = new Random();

            var mots = ChargerMotDuFicher("mots.txt");

            if (mots == null || mots.Length == 0)
            {
                Console.WriteLine("La liste de mots est vide");

            }
            else
            {
                while (true)
                {
                    int pos = r.Next(mots.Length);
                    string mot = mots[pos].Trim().ToUpper();
                    DevinerMot(mot);
                    if (!DemanderDeRejouer())
                    {
                        break;
                    }
                    Console.Clear();
                }
                Console.WriteLine("Merci et à Bientot");

            }
        }
    }
}
