using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace projet_pizza
{

    class PizzaPersonnalsee : Pizza
    {
        static int numeroPizza;

        public PizzaPersonnalsee() : base("Personnalisée", 5, false, null)
        {


            ingredients = new List<string>();
            numeroPizza++;

            nom = "Personalisée " + numeroPizza;
            while (true)
            {
                Console.Write("Rentrez un ingredient pour la pizza personnalisée " + numeroPizza + " (ENTER pour terminer) : ");
                var reponse = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(reponse))
                {
                    break;
                }
                if (ingredients.Contains(reponse))
                {
                    Console.WriteLine("cette ingredient est deja present dans la liste");

                }
                else
                {
                    ingredients.Add(reponse);
                    //ma version
                    prix += 1.5f;
                    Console.WriteLine(string.Join(", ", ingredients));

                }
                Console.WriteLine();
            }

            //Version de jonathan =>prix = 5 + ingredients.Count * 1.5f;



        }



    }


    class Pizza
    {
        public string nom { get; protected set; }
        public float prix { get; protected set; }
        public bool vegetarienne { get; private set; }
        public List<string> ingredients { get; protected set; }


        public Pizza(String nom, float prix, bool vegetarienne, List<string> ingredients)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
            this.ingredients = ingredients;

        }


        public void Afficher()
        {
            //expression ternaire
            string badgeVegetarienne = vegetarienne ? " (V)" : "";
            string nomAfficher = PremiereLettreMajuscule(nom);
            var ingredientAfficher = ingredients.Select(i => PremiereLettreMajuscule(i)).ToList();

            Console.WriteLine(nomAfficher + badgeVegetarienne + " - " + prix + "$ :");
            Console.WriteLine(string.Join(",  ", ingredientAfficher));
            Console.WriteLine();

        }

        public bool ContientIngredients(string ingredient)
        {

            return ingredients.Where(i => i.ToLower().Contains(ingredient)).ToList().Count > 0;

        }

        private static string PremiereLettreMajuscule(string s)
        {
            string nomMinuscules = s.ToLower();
            string nomMajuscules = s.ToUpper();

            //subtring or [1..] => c pareil
            string resultat = nomMajuscules[0] + nomMinuscules[1..];

            return resultat;
        }

       



    }

    class Program
    {


        static List<Pizza> GetPizzasFromCode()
        {

            var pizzas = new List<Pizza>() {
                  new Pizza("4 fromages", 11.5f, true, new List<string> { "cantal", "mozzarella", "fromage de chèvre", "gruyère" }),
                  new Pizza("indienne", 10.5f, false, new List<string> { "curry", "mozzarella", "poulet", "poivron", "oignon", "coriandre" }),
                  new Pizza("MEXICAINE", 13f, false, new List<string> {"boeuf", "mozzarella", "maïs", "tomates", "oignon", "coriandre"}),
                  new Pizza("margherita", 8f, true, new List<string> { "sauce tomate", "mozzarella", "basilic" }),
                  new Pizza("Calzone", 12f, false, new List<string> { "tomate", "jambon", "persil", "oignons"}),
                  new Pizza("complète", 9.5f, false, new List<string> { "jambon", "oeuf", "fromage" }),
            };
            return pizzas;
        }

        static List<Pizza> GetPizzasFromFile(string filename)
        {
            string json = null;

            try
            {

                json = File.ReadAllText(filename);

            }
            catch
            {
                Console.WriteLine("erreur de lecteur du ficher :" + filename);
                return null;

            }

            List<Pizza> pizzas = null;
            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);

            }
            catch
            {
                Console.WriteLine("erreur les donne ne sont pas valide");
                return null;
            }



            return pizzas;

        }

        static void GenerateJsonFile(string filename, List<Pizza> pizzas)
        {
            string pizzaJson = JsonConvert.SerializeObject(pizzas);

            File.WriteAllText(filename, pizzaJson);

        }

        static List<Pizza> GetPizzasByUrl(string url)
        {
            var webClient = new WebClient();
            string json = null;
            try
            {
                json = webClient.DownloadString(url);

            }
            catch
            {
                Console.WriteLine("erreur ");
                return null;

            }




            List<Pizza> pizzas = null;
            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);

            }
            catch
            {
                Console.WriteLine("erreur les donne ne sont pas valide");
                return null;
            }
            return pizzas;

        }





        static void Main(string[] args)
        {

            /*    var filename = "pizza.json";
               // var pizzas = GetPizzasFromCode();
                var pizzas= GetPizzasFromFile(filename);

               //GenerateJsonFile(filename, pizzas);



                foreach(var pizza in pizzas)
                {
                    pizza.Afficher();
                }
    */

            string url = "https://codeavecjonathan.com/res/pizzas2.json";


            var pizzas = GetPizzasByUrl(url);


            if(pizzas != null)
            {

                foreach (var pizza in pizzas)
                {

                    pizza.Afficher();
                }

            }


        }
    }
}
