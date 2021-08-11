using System;


namespace nombre_Magic
{
    class Program
    {


        static int DemanderNombre(int Min, int Max)
        {
            int nombre = Min - 1;

            while (nombre < Min || nombre > Max)
            {

                Console.Write($"entre un nombre entre {Min} et {Max} : ");
                try
                {
                    nombre = int.Parse(Console.ReadLine());
                    if (nombre < Min || nombre > Max)
                    {
                        Console.WriteLine($"erreur: entre un nombre entre {Min} et {Max}");
                    }


                }
                catch
                {
                    Console.WriteLine("Erreur : entrez un nombre valide");

                }

            }

            return nombre;

        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            const int NB_MIN = 1;
            const int NB_MAX = 10;
            int NB_MAGIC = rand.Next(NB_MIN, NB_MAX + 1);
            int nombre = NB_MAGIC + 1;

            int vie = 4;

           // while (vie>0 && nombre != NB_MAGIC)
            for (; vie>0;--vie)
            {

                Console.WriteLine($"il vous reste {vie}");
                 nombre = DemanderNombre(NB_MIN, NB_MAX);

                if (nombre > NB_MAGIC)
                {
                    Console.WriteLine("Le nombre magique est plus petit");
                  
                }
                else if (nombre < NB_MAGIC)
                {
                    Console.WriteLine("le nombre magique est plus grand");
                }
                else
                {
                    Console.WriteLine("Bravo!, vous avez trouvez");

                }
                //vie--;




            }
            if (vie == 0)
            {
                Console.WriteLine($"Vous avez perdu! Le nombre magique etait {NB_MAGIC}");

            }



















        }
    }
}
