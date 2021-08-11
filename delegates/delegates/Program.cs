using System;
using System.Linq;

namespace delegates
{
    class Program
    {
        public delegate string ValidationChaine(string s);

        static void Main(string[] args)
        {


            string nom = DemanderChaineUtilisateur("quel est ton nom :",CheckValidationDuNom);

            //max 10 chiffres
            string numero = DemanderChaineUtilisateur("quel est votre numero :", CheckValidationDuNumero);

            Console.WriteLine();
            Console.WriteLine("Bonjour " + nom + ", vous etes joignable au numero : " + numero);



        }
        static string DemanderChaineUtilisateur(string message, ValidationChaine fonctionValidation = null)
        {

            Console.Write(message);
            string reponse = Console.ReadLine();
            if (fonctionValidation != null)
            {
                string erreur = fonctionValidation(reponse);
                if (erreur != null)
                {
                    Console.WriteLine("ERREUR :" + erreur);
                    return DemanderChaineUtilisateur(message,fonctionValidation);
                }

            }
            return reponse;

        }

        static string CheckValidationDuNom(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {

                return "ne doit pas etre vide";
            }


            if (s.Any(char.IsDigit))
            {

                return "ne peut pas contenir de chiffre";
            }
            return null;
        }
        static string CheckValidationDuNumero(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {

                return "le numero de tel ne doit pas etre vide";
            }
            if (s.Length != 10)
            {
              return "le nmero de tel doit contenir 10 chiffres ";
            }

            if (!s.All(char.IsDigit))
            {

                return "le numero de tel ne doit continir que des chiffre";
            }
            return null;
        }

    }
}
