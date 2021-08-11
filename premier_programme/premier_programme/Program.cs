using System;

namespace premier_programme
{
    class Programme
    {

        static int AskAge(String nom)
        {
            int age = 0;

            while (age <= 0)
            {
                Console.Write(nom + " Quel est ton age ?");
                string age_str = Console.ReadLine();
                try
                {
                    age = int.Parse(age_str);
                    if (age < 0)
                    {
                        Console.WriteLine("l'age ne doit pas etre negatif");
                    }
                    if (age == 0)
                    {

                        Console.WriteLine("L'age ne peut etre egal a zero");
                    }

                }
                catch
                {
                    Console.WriteLine("erreur: vous devez rentrer un code valide");
                }
            }
            return age;

        }

        static String AskName(int numeroPersonne)
        {
            String nom = "";

            while (nom == "")
            {
                Console.Write("Personne numrero " + numeroPersonne + ", quel votre nom?");

                nom = Console.ReadLine();
                nom = nom.Trim();
                if (nom == "")
                {
                    Console.WriteLine("Veuillez entrez un nom :");
                }
            }
            return nom;
        }

        static void Afficher(String nom, int age)
        {
            if (age <= 10)
            {
                Console.WriteLine("Vous etes un enafnt");
            }
            else if (age < 18 && age > 10)
            {
                Console.WriteLine("vous etes mineur");
            }

            else if (age == 18)
            {
                Console.WriteLine("Vous tou juste majeur!");
            }
            else if (age == 17)
            {
                Console.WriteLine("Vous serez bientot majeur");
            }


            else if (age >= 60)
            {
                Console.WriteLine("vous etes senior");
            }
            else
            {
                Console.WriteLine("vous etes majeur!");
            }

            Console.WriteLine("Bonjour " + nom + " , Vous avez " + age + " ans");
            Console.WriteLine("l'an prochaine vous aurez " + (age + 1) + " ans");

        }

        static void Main(String[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            //ask name
            String nom1 = AskName(1);
            String nom2 = AskName(2);

            //ask age
            int age1 = AskAge(nom1);
            int age2 = AskAge(nom2);


            //affiche information
            Afficher(nom1, age1);
            Afficher(nom2, age2);



        }


    }
}





