using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace programme_fichiers
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = "out";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //  c:\User\...
            //  /User/
            string filename = "monFichier.txt";
            string filename2 = "monFichier2.txt";

            string pathAndFile = Path.Combine(path, filename);
            string pathAndFile2 = Path.Combine(path, filename2);

            if (File.Exists(pathAndFile))
            {
                Console.WriteLine("Le fichier existe déjà, on va écraser son contenu");
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas, on va le créer");
            }


            Console.WriteLine("FICHIER : " + pathAndFile);

            /*var noms = new List<string>()
            {
                "Jean",
                "Paul",
                "Martin"
            };*/

            StringBuilder texte = new StringBuilder();
            int nbLignes = 100000;

            // immutable
            //texte = "toto";
            //texte += "o"; // totoo

            // mutable
            // StringBuilder

            //------------------------------------------
            /*DateTime t1 = DateTime.Now;

            Console.Write("Préparation des données...");
            for (int i = 1; i <= nbLignes; i++)
            {
                texte.Append("Ligne " + i + "\n");
            }
            Console.WriteLine("OK");

            Console.Write("Ecriture des données...");
            File.WriteAllText(pathAndFile, texte.ToString());
            Console.WriteLine("OK");

            DateTime t2 = DateTime.Now;
            var diff = (int)((t2 - t1).TotalMilliseconds);  //1s = 1000ms
            Console.WriteLine("Durée (ms) : " + diff);*/
            //------------------------------------------
            // Stream : flux 

            DateTime t1 = DateTime.Now;

            Console.Write("Ecriture des données...");
            using (var writeStream = File.CreateText(pathAndFile))
            {
                for (int i = 1; i <= nbLignes; i++)
                {
                    writeStream.Write("Ligne " + i + "\n");
                }
            }
            Console.WriteLine("OK");

            DateTime t2 = DateTime.Now;
            var diff = (int)((t2 - t1).TotalMilliseconds);  //1s = 1000ms
            Console.WriteLine("Durée (ms) : " + diff);

/*
            // Lecture avec un stream
            using (var readStream = File.OpenText(pathAndFile))
            {
                while (true)
                {
                    var line = readStream.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    Console.WriteLine(line);
                }

            }

*/            //File.AppendAllText(filename, "je rajoute ce texte.");
            //File.WriteAllLines(pathAndFile, noms);

            /*try
            {
                ///string resultat = File.ReadAllText(filename);
                var lignes = File.ReadAllLines(pathAndFile);

                foreach(var ligne in lignes)
                {
                    Console.WriteLine(ligne);
                }
                
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("ERREUR : Ce fichier n'existe pas (" + ex.Message + ")");
            }
            catch
            {
                Console.WriteLine("Une erreur inconnue est arrivée");
            }*/

            //File.Copy(pathAndFile, pathAndFile2);
            //File.Delete(pathAndFile2);
            //File.Move(pathAndFile, pathAndFile2);
        }
    }
}
