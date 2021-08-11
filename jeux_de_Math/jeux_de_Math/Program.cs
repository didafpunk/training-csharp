using System;

namespace jeux_de_Math
{

    class Program
    {


        enum e_operateur
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            SOUSTRACTION = 3

        }


        static bool PoserQuestion(int min, int max)
        {
            Random rand = new Random();

            int nombre_int = 0;
            e_operateur o = (e_operateur)rand.Next(1, 4);
            int reponseAttendu;

            while (true)
            {

                int a = rand.Next(min, max + 1);
                int b = rand.Next(min, max + 1);



                switch (o)
                {

                    case e_operateur.MULTIPLICATION:

                        Console.Write($"{a} x {b} =");
                        reponseAttendu = a * b;
                        break;
                    case e_operateur.ADDITION:
                        Console.Write($"{a} + {b} =");
                        reponseAttendu = a + b;
                        break;

                    case e_operateur.SOUSTRACTION:

                        Console.Write($"{a} - {b} =");
                        reponseAttendu = a - b;
                        break;

                    default:
                        Console.WriteLine("Operateur inconnue");
                        return false;

                }

               
                String nombre_str = Console.ReadLine();

                try
                {
                    nombre_int = int.Parse(nombre_str);
                    if (nombre_int == reponseAttendu)
                    {
                        return true;
                    }
                    return false;
                }

                catch
                {
                    Console.WriteLine("erreur , entre un nombre");

                }
            }


        }

        static void Main(string[] args)
        {
            const int NB_MIN = 1;
            const int NB_MAX = 10;
            const int NB_QUESTION = 3;
            int score = 0;
            int moyenne = NB_QUESTION / 2;

            for (int i = 0; i < NB_QUESTION; i++)
            {

                Console.WriteLine($"Question numéro {(i + 1)}:");
                bool reponse = PoserQuestion(NB_MIN, NB_MAX);

                if (reponse)
                {
                    score++;
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Votre score est de {score} sur {NB_QUESTION} ");
            if (score == NB_QUESTION)
            {
                Console.WriteLine("excellent!");
            }
            else if (score == 0)
            {
                Console.WriteLine("Revisez vos maths");
            }
            else if (score > moyenne)
            {
                Console.WriteLine("pas mal");

            }
            else
            {
                Console.WriteLine("peut mieux faire");

            }
        }
    }
}
