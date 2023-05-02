using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace oop_beadando_2
{
    public class FileNoNextException : Exception { }
    public class FileNotFoundException : Exception { }
    public class FileLineNullException : Exception { }
    public class WrongFileNameException : Exception { }

    public class Caches
    {
        public string[]? FishName { get; set; }
        public double[]? FishWeight { get; set; }
    }

    internal class horgaszverseny
    {
        public string Name { get; private set; }
        public string Id { get; private set; }

        public Caches FishData;

        public horgaszverseny(Caches FishData)
        {
            this.FishData = FishData;
            FishData.FishName = new string[1] { "Nincs kapás" };
            FishData.FishWeight = new double[1] { 0 };
        }

        public void AddFish(string name, double weight)
        {
            FishData.FishName = FishData.FishName.Concat(new string[] { name }).ToArray();
            FishData.FishWeight = FishData.FishWeight.Concat(new double[] { weight }).ToArray();
        }

        public void Start()
        {

            Name = "";
            Id = "";
            Caches Caches = new Caches { FishName = new string[1] { "Nincs kapás" }, FishWeight = new double[1] { 0 } };
        }

        public void Next()
        {
            if (!HasNext())
            {
                throw new FileNoNextException();
            }

            if (file == null) return;

            string? line = file.ReadLine();

            if (line == null)
            {
                throw new FileLineNullException();
            }

            string[] spls = line.Split(' ');

            Name = spls[0];
            Id = spls[1];

            for (int i = 2; i < spls.Length; i += 2)
            {
                AddFish(spls[i], Convert.ToDouble(spls[i + 1]));
            }
        }

        public bool HasNext()
        {
            if (file == null)
            {
                return false;
            }

            return !file.EndOfStream;
        }

        public void OpenFile(string path)
        {
            if (file != null)
            {
                file.Close();
            }

            try
            {
                file = new StreamReader(path);
            }
            catch (Exception)
            {
                file = null;

                throw new FileNotFoundException();
            }
        }

        public bool IsFileOpen()
        {
            return file != null;
        }

        public horgaszverseny()
        {
            Name = "";
            Id = "";
            FishData = new Caches { FishName = new string[] { "" }, FishWeight = new double[] { 0 } };
            file = null;
        }

        private StreamReader? file;
    }
}

