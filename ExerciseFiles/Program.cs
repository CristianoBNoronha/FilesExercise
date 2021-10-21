using System;
using System.IO;
using System.Collections.Generic;
using ExerciseFiles.Entities;
using System.Globalization;

namespace ExerciseFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Products> list = new List<Products>();
            string sourcePath = @"C:\Users\fuzil\source\repos\ExerciseFiles\file1.csv";
            Directory.CreateDirectory(@"C:\Users\fuzil\source\repos\ExerciseFiles\Out");           

            try
            {                
                using (StreamReader sr = File.OpenText(sourcePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        double price = double.Parse(line[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(line[2]);
                        list.Add(new Products(name, price, quantity));
                        using (StreamWriter sw = File.AppendText(@"C:\Users\fuzil\source\repos\ExerciseFiles\Out\summary.csv"))
                        {
                            Products product = new Products(name, price, quantity);
                            sw.WriteLine(product);
                        }
                    }
                    
                }                
            }
            catch (IOException e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Message);
            }
        }
    }
}
