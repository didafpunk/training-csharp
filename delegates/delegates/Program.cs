using System;

namespace delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //demander le nom de l'utilisateur;
            //demander le numero de telephone de l'utilisateur

            string nom = Demander("quel est ton nom :");
            string numero = Demander("quel est votre numero :");

            Console.WriteLine();
            Console.WriteLine("Bonjour "+ nom+ ", vous etes joignable au numero : "+numero);

        }
        static string Demander(string message)
        {

            Console.Write(message);
            string reponse = Console.ReadLine();
            return reponse;
        }
        

    }
}
