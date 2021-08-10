using formationcs;
using System;


namespace generateur_de_mot_de_passe
{
    class Program
    {

        static void Main(string[] args)
        {

            const int NB_MOT_DE_PASSSE = 10;

            int longueurMotDePasse = outils.DemanderNombrePositiveNonNul("Longueur du mot de passe : ");
            Console.WriteLine();

            Random rand = new Random();
            String minuscule = "abcdefghijklmnopqrstuvwxyz";
            String majuscule = minuscule.ToUpper();
            String chiffre = "0123456789";
            String caractereSpeciaux = "#+-!@$";
            String alphabet ;
            String motDePasse = "";
            int choixAlphabet = outils.DemanderNombreEntre("Veuillez choisir un mot de passe :\n" +
                 "1- uniqueement minuscule \n" +
                 "2- minusculae et majascule \n" +
                 "3- characte et chiffre \n" +
                 "4- la totale \n" +
                "Faites Votre choix : ", 1, 4);
            Console.WriteLine();

            if (choixAlphabet == 1)
                alphabet = minuscule;
           
            else if (choixAlphabet == 2)
                alphabet = minuscule + majuscule;
            else if (choixAlphabet == 3)
                alphabet = minuscule + majuscule + chiffre;
            else
                alphabet = minuscule + majuscule + chiffre + caractereSpeciaux;

            int l = alphabet.Length;
            int index = rand.Next(0, l);
            for (int y = 0; y < NB_MOT_DE_PASSSE; y++)
            {
                motDePasse = "";
                for (int i = 0; i < longueurMotDePasse; i++)
                {

                    index = rand.Next(0, l);
                    motDePasse += alphabet[index];
                

                }
            Console.WriteLine($"Mot de passe :  {motDePasse}");

            }


        }

    }
}