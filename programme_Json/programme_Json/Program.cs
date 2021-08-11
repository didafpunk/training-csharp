using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace programme_json
{
    class Personne
    {
        public string nom { get; private set; }
        public int age { get; private set; }
        public bool majeur { get; private set; }


        public Personne(string nom, int age, bool majeur)
        {
            this.nom = nom;
            this.age = age;
            this.majeur = majeur;

        }

        public void Afficher()
        {
            Console.WriteLine("Nom: " + nom + " - age: " + age + " ans");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*var personne1 = new Personne();
            personne1.nom = "Toto";
            personne1.age = 20;
            personne1.majeur = true;
            personne1.Afficher();

            string json = JsonConvert.SerializeObject(personne1);
            Console.WriteLine(json);

            string jsonTiti = "{\"nom\":\"Titi\",\"age\":15,\"majeur\":false}";
            Personne titi = JsonConvert.DeserializeObject<Personne>(jsonTiti);
            titi.Afficher();*/
            // creer une list de personne 3 ou 4

            //serialseer
            // ecrire dans le json dans une focheir text.

            /*var personnes = new List<Personne>()
             {
                 new Personne("nordinne",39,true),
                 new Personne("celine",38,true),
                 new Personne("nouriya",10,false),
                 new Personne("rayan",9,false)
             };



                         string jsonPersonnes = JsonConvert.SerializeObject(personnes);
                         //Console.WriteLine(jsonPersonnes);
 
            File.WriteAllText(fileName, jsonPersonnes);*/

            string fileName = "monJson.txt";


            string json = File.ReadAllText(fileName);
           
            var personnes = JsonConvert.DeserializeObject<List<Personne>>(json);

            foreach(var personne in personnes)
            {
                personne.Afficher();
            }



        }
    }
}
