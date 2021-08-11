using System;
using System.Collections.Generic;
using System.Linq;

namespace programme_collections
{
    class Program
    {
        static void afficher(int[] tableau)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                Console.WriteLine($"- [{i}] {tableau[i]}\n");
            }


        }

        static void valeurMaximalDuTableau(int[] tableau)
        {

            int max = tableau[0];


            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] > max)
                {
                    max = tableau[i];
                }


            }
            Console.WriteLine($"La valeur maximal est le { max}");
        }

        static void valeurMinimalDuTableau(int[] tableau)
        {
            int min = tableau[0];


            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] < min)
                {
                    min = tableau[i];
                }


            }
            Console.WriteLine($"La valeur minimal est le { min}");

        }

        static void Tableaux()
        {
            const int TAILLE_DU_TABLEAU = 20;
            Random rand = new Random();
            //int[] tableau = { 200, 40, 15, 8, 12 };
            int[] t = new int[TAILLE_DU_TABLEAU];
            for (int i = 0; i < TAILLE_DU_TABLEAU; i++)
            {
                t[i] += rand.Next(1, 101);

            }




            afficher(t);
            valeurMaximalDuTableau(t);
            Console.WriteLine();
            valeurMinimalDuTableau(t);


        }

        static void afficherListe(List<String> liste, bool Desc = false)
        {
            if (!Desc)
            {
                for (int i = 0; i < liste.Count; i++)
                {
                    Console.WriteLine(liste[i]);
                }

            }
            else
            {
                for (int i = liste.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(liste[i]);
                }

            }

            var nomPlusLong = "";

            for (int i = 0; i < liste.Count; i++)
            {

                while (liste[i].Length > nomPlusLong.Length)
                {
                    nomPlusLong = liste[i];
                }
            }
            Console.WriteLine($"le nom le plus long de la liste est {nomPlusLong}");

        }

        static void afficherElementCommun(List<string> list1, List<string> list2)
        {


            //version 1
            /* for (int i=0; i< list1.Count; i++){

                 string nom1 = list1[i];

                 for(int y=0;y < list2.Count; y++)
                 {
                     string nom2 = list2[y];

                     if(nom1 == nom2)
                     {
                         Console.WriteLine(nom2);
                     }

                 }
             }*/

            //version 2
            for (int i = 0; i < list1.Count; i++)
            {
                string nom = list1[i];
                if (list2.Contains(nom))
                {

                    Console.WriteLine(nom);
                }
            }



        }

        static void Listes()
        {
            /* var noms = new List<string>();
             while (true)
             {

                 Console.Write("Veuillez entre un nom : ");
                 String nom = Console.ReadLine();
                 if (nom == "")
                 {
                     break;
                 }

                 if (noms.Contains(nom))
                 {

                     Console.WriteLine("erreur , ce nom existe deja");

                 }
                 else
                 {
                     noms.Add(nom);
                 }
             }
             // filtre les noms se terminant par "e" et les supprime
             for (int i = noms.Count - 1; i >= 0; i--)
             {
                 string nom = noms[i];

                 if (nom[nom.Length - 1]=='e')
                 {
                     noms.RemoveAt(i);
                 }
             }

             afficherListe(noms, true);*/

            var list1 = new List<string> { "toto", "tata", "Celine", "nordinne" };
            var list2 = new List<string> { "toto", "tata", "Celine" };



            afficherElementCommun(list1, list2);



        }

        static void ListesDeListes()
        {
            var pays = new List<List<string>>();

            var list1 = new List<string>() { "Belgique", " bruxelles", "anvers", "saint-josse" };
            var list2 = new List<string>() { "France", " paris", "monaco", "marseille", "lille" };
            var list3 = new List<string>() { "Allemagne", " berlin", "munich", "dortmund", "wolsburg" };

            pays.Add(list1);
            pays.Add(list2);
            pays.Add(list3);

            for (int i = 0; i < pays.Count; i++)
            {
                var p = pays[i];
                Console.WriteLine(p[0] + ": " + (p.Count - 1) + "villes");
                for (int k = 1; k < p.Count; k++)
                {

                    Console.WriteLine("  -" + p[k]);

                }
            }



        }


        static void Dictionnaire()
        {
            string personneAChercher = "nordinne";

            /*  var d = new Dictionary<string, string>();

              d.Add("nordinne", "04985262");
              d.Add("ali", "03985262");
              d.Add("adam", "058557896");
              d.Add("nouriya", "02985262");
              d.Add("celine", "0485262");
              d.Add("didaf", "0985262");
              d.Add("rayan", "985262");

              if (d.ContainsKey(personneAChercher)){

                  Console.WriteLine(d[personneAChercher]);
              }
              else
              {
                  Console.WriteLine("cette perosnne n'est pas dans le dico");
              }*/

            var l = new List<string[]>();
            l.Add(new string[] { "nordinne", "04985262" });
            l.Add(new string[] { "adam", "058557896" });
            l.Add(new string[] { "nouriya", "02985262" });
            l.Add(new string[] { "rayan", "985262" });

            for (int i = 0; i < l.Count; i++)
            {
                if (l[i][0] == personneAChercher)
                {
                    Console.WriteLine(l[i][1]);
                    break;
                }
                else
                {
                    Console.WriteLine("cette personne n'est pas presente dans le dico");
                }
            }
        }

        static void BoucleForEach()
        {
            /*
                        var noms = new string[] { "nordinne", "rayan", "adam" };


                        foreach(var nom in noms)
                        {
                            Console.WriteLine(nom);
                        }
            */
            var d = new Dictionary<string, string>();

            d.Add("nordinne", "04985262");
            d.Add("ali", "03985262");
            d.Add("adam", "058557896");
            d.Add("nouriya", "02985262");
            d.Add("celine", "0485262");
            d.Add("didaf", "0985262");
            d.Add("rayan", "985262");

            foreach (var e in d)
            {
                Console.WriteLine(e.Key + "->" + e.Value);
            }



        }

        static void TriEtLinq()
        {
            /*var nom = new List<string>() { "emilie", "sofie", "jean", "toto", "nordinne", "adam", "rayan", "nouriya" };

            //  nom.Sort();
            //var nomTrier= nom.OrderBy(nom => nom[nom.Length-1]);
            // nom =  nom.OrderBy(nom => nom).ToList();
            // nom = nom.Where(nom => nom.Length > 4).ToList();
            nom = nom.Where(nom => nom[nom.Length-1]!='e').ToList();
            foreach (string e in nom)
            {

                Console.WriteLine(e);
            }*/

            var notes = new List<int> {4,8,1,9,2 };
            notes =notes.OrderBy(n => n).ToList();
            notes = notes.Where(n => n >= 5).ToList();

            foreach(int e in notes)
            {
                Console.WriteLine(e);
            }
        }


        static void Mafonction(out int p)
        {

            p = 10;
        }
        
        static void Mafonction2(List<int> p)
        {
            p[0] = 10;
            
        }

        static void PassageParReference()
        {

            int a = 5;
            Mafonction( out a);
            int num = 0;
            if(int.TryParse("gggggg",out num))
            {
                Console.WriteLine("conversion ok") ;
                num++;
                Console.WriteLine(num);
            }
            else{

                Console.WriteLine("erreur , pas de conversion");
            }
            //var l = new List<int> { 5 };
            //Mafonction2(l);

            //Console.WriteLine(l[0]);
           // Console.WriteLine(a);
        }




        static void Main(string[] args)
        {
            //Tableaux();
            //Listes();
            //ListesDeListes();
            //Dictionnaire();
            //BoucleForEach();
            //TriEtLinq();
            PassageParReference();
        }
    }
}
