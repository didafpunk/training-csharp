using System;
using System.Collections.Generic;
using System.Linq;

namespace programme_poo
{
    class Enfant : Etudiant
    {

        string ClasseEcole;
        Dictionary<string, float> notes;
        public Enfant(string nom, int age, string ClasseEcole = null, Dictionary<string, float> note = null) : base(nom, age, null)
        {
            this.ClasseEcole = ClasseEcole;
            this.notes = note;
        }

        public override void Afficher()
        {
            afficherAgeEtNom();
            Console.WriteLine("Enfant en classe de  :" + ClasseEcole);
            if ((notes != null)&&(notes.Count>0))
            {
                Console.WriteLine("Note moyenne :");
                foreach (var note in notes)
                {
                    Console.WriteLine($"    {note.Key} : {note.Value}/10");



                }
            }
            AfficherProfesseurPrincipal();
        }
    }

    class Etudiant : Personne
    {
        public String infosEtudiant;
        public Personne professeurPrincipal { get; init; }

        public Etudiant(string nom, int age, string infoEtudiant) : base(nom, age)
        {
            this.infosEtudiant = infoEtudiant;
        }

         public override  void Afficher()
        {
            afficherAgeEtNom();
            Console.WriteLine("Etudiant en :" + infosEtudiant);
            Console.WriteLine();
            AfficherProfesseurPrincipal();
        }

        protected void AfficherProfesseurPrincipal()
        {
            if (professeurPrincipal != null)
            {
                Console.WriteLine("Professeur Principal :");
                professeurPrincipal.Afficher();
            }

        }

    }

    class Personne : IAffichable
    {

        static int nbPersonnes = 0;
        public String nom { get; init; }
        public int age { get; init; }
        protected String profession;
        protected int numeroPersonne;


        public Personne(string nom, int age, string profession = null)
        {
            nbPersonnes++;
            this.nom = nom;
            this.age = age;
            this.profession = profession;
            this.numeroPersonne = nbPersonnes;
           
        }


        public virtual void Afficher()
        {
            afficherAgeEtNom();
            
            if (this.profession != null)
            {
                Console.WriteLine(" Profession : " + this.profession);
            }
            else
            {
                Console.WriteLine("Profession : emploi non specifer");
            }
            Console.WriteLine();

        }



        protected void afficherAgeEtNom()
        {
            Console.WriteLine("Numero de la personne :" + this.numeroPersonne);
            Console.WriteLine("Nom : " + this.nom);
            Console.WriteLine(" Age : " + this.age);
        }

        public static void AfficherNombreDePersonnes()
        {
            Console.WriteLine();
            Console.WriteLine("Nombre total de personnes :" + nbPersonnes);
        }

    }

    class TableDeMultiplication : IAffichable
    {

        int numero;

        public TableDeMultiplication(int numero)
        {

            this.numero = numero;
        }


        public void Afficher()
        {
            Console.WriteLine("Table de mutliplication de "+ numero);
            

            for(int i=1; i <= 10; i++)
            {
                Console.WriteLine(i +"x"+ numero+"="+ (i*numero));

            }

        }
     
      

    }
    interface IAffichable
    {

        void Afficher();
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            var elements = new List<IAffichable> { 
            new Personne("Paul",30,"Developpeur"),
            new Personne("Jacques",35,"Professeur"),
            new Etudiant("David",20,"philo"),
            new Enfant("Juliette",8,"cp",null),
            new TableDeMultiplication(2)
        };

            //where fait partit du linq
           // personnes = personnes.Where(p => p.nom[0] =='J' && p.age>=30).ToList();

            foreach(var element in elements)
            {

                element.Afficher();
            }

/*
            var table2 = new TableDeMultiplication(2);
            table2.Afficher();
          */

        }


    }
}
