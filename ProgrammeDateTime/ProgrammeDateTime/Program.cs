using System;
using System.Globalization;

namespace ProgrammeDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            //Console.WriteLine(date);
            //Console.WriteLine(date.ToString("dd/MM/yyyy HH:mm:ss"));

            CultureInfo cultureFrancais = CultureInfo.GetCultureInfo("fr-FR");
           // CultureInfo cultureAnglais = CultureInfo.GetCultureInfo("en-US");

            Console.WriteLine(date.ToString("dddd dd MMMM yyyy HH:mm:ss",cultureFrancais));

            DateTime dateDemain = date.AddDays(1);
            Console.WriteLine(dateDemain.ToString("dddd dd MMMM yyyy HH:mm:ss", cultureFrancais));


            var diff = dateDemain - date;
            Console.WriteLine("difference heure :"+diff.TotalSeconds);
        }
    }
}
