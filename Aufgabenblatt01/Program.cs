using System;
using System.Collections.Generic;
using System.IO;

namespace Aufgabenblatt01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            FileStream stream = new FileStream($@"..\..\Dateien\Personen.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(':',';');
                list.Add(new Person(line[0], line[1]));
            }
            reader.Close();
            double avg = 0;
            
           
            FileStream newStream = new FileStream($@"..\..\Dateien\PersonenNeu.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(newStream);

            foreach (Person person in list)
            {
                avg += person.GetAge();
                Console.WriteLine($"{person.ToString()} alter: {person.GetAge()}");
                writer.WriteLine(person.ToString());
            }
            writer.Close();
            avg /= list.Count;
            Console.WriteLine($"Durchschnittsalter: {avg}");
            Console.ReadKey();
        }

        static void Aufgabe1()
        {
            FileStream stream = new FileStream($@"..\..\Dateien\Aufgabe1und2.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("Hallo ich bin aus Dettmold und fliege ins All.");
            writer.Close();
        }

        static void Aufgabe2()
        {
            FileStream stream = new FileStream($@"..\..\Dateien\Aufgabe1und2.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
        }

        static void Aufgabe3()
        {
            FileStream stream = new FileStream($@"..\..\Dateien\Aufgabe3.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 2; i < 1000; i++)
            {
                bool primzahl = true;
                for (int j = 1; j < i / 2; j++)
                {
                    if (i % j == 0 && i != j && j != 1)
                        primzahl = false;

                }
                if (primzahl)
                    writer.Write($"{i} ");
            }

            writer.Close();
            FileStream stream1 = new FileStream($@"..\..\Dateien\Aufgabe3.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream1);
            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
        }

        static void Aufgabe4()
        {
            Console.Write("Bitte gebe Sie hier den Text ein: ");

            string s = Console.ReadLine();
            string code = "";
            Random random = new Random();

            FileStream stream = new FileStream($@"..\..\Dateien\Aufgabe4.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(stream);


            for (int i = 0; i < s.Length; i++)
            {
                code += s[i];
                for (int j = 0; j < 2; j++)
                {
                    code += (char)random.Next(33, 127);
                }
            }

            writer.WriteLine(code);
            writer.Close();
            FileStream stream1 = new FileStream($@"..\..\Dateien\Aufgabe4.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream1);
            string codedText = reader.ReadToEnd();
            string encodedText = "";

            for (int i = 0; i < codedText.Length; i = i + 3)
            {
                encodedText += codedText[i];
            }
            Console.WriteLine(codedText);
            Console.WriteLine(encodedText);
            reader.Close();
        }

        static void Aufgabe5()
        {
            FileStream stream1 = new FileStream($@"..\..\Dateien\Aufgabe5.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream1);
            string text = reader.ReadToEnd().ToLower();

            int[] häufigkeiten = new int[26];

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < häufigkeiten.Length; j++)
                {
                    if ((int)text[i] == 97 + j)
                    {
                        häufigkeiten[j]++;
                    }
                }
            }

            for (int i = 0; i < häufigkeiten.Length; i++)
            {
                if (häufigkeiten[i] != 0)
                    Console.WriteLine($"Buchstabe: {(char)(i + 97)} Häufigkeit: {häufigkeiten[i]}");
            }
            reader.Close();
        }
    }
}
