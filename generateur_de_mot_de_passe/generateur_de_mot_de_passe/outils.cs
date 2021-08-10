using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formationcs


{
    class outils
    {
        public static int DemanderNombrePositiveNonNul(string question)
        {
            return DemanderNombreEntre(question, 1, int.MaxValue,"Erreur le nombre doit etre positf et non nul");
        }

        public static int DemanderNombreEntre(string question, int min, int max, string messagePerso=null)
        {
            int reponse = DemanderNombre(question);

            if (reponse >= min && reponse <= max )
            {
                return reponse;
            }

            if (messagePerso == null)
            {
                Console.WriteLine($"Erreur: le nombre doit etre entre {min} et {max} ");

            }
            else
            {
                Console.WriteLine(messagePerso);
            }

            Console.WriteLine();
            
            return DemanderNombreEntre(question, min, max);

        }

        public static int DemanderNombre(string question)
        {
            while (true)
            {
                Console.Write(question);
                string reponse_str = Console.ReadLine();

                try
                {
                    int reponseInt = int.Parse(reponse_str);
                    return reponseInt;
                }
                catch
                {
                    Console.WriteLine("Erruer entrez un nombre numerique");

                    Console.WriteLine();
                }

            }

        }



    }
}
