using System;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {

        #region Fields
        static string SaveFilePath = @"D:\Howest\Brian\jsonTest";
        static string SaveFileName = "MyJSONSave";
        #endregion

        #region Properties

        public static string SaveFile { get => string.Format(@"{0}\{1}.json", SaveFilePath, SaveFileName); }

        #endregion

        #region Methods
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Saving to json");
            Save("testName");

            Console.ReadKey();

            Console.WriteLine("Loading from json");
            Console.WriteLine(Load());

            Console.ReadKey();

        }
        public static void Save(string _input)
        {
            // Convert to JSON
            string _json = JsonConvert.SerializeObject(_input);

            // Check if savefile exists, if so, make a backup
            if (File.Exists(SaveFile))
            {
                string _fileName = Path.GetFileNameWithoutExtension(SaveFile);
                File.Copy(SaveFile, SaveFile.Replace(_fileName, string.Format("{0}_backup", _fileName)), true);
            }

            // write to file
            File.WriteAllText(SaveFile, _json);
        }
        public static string Load()
        {
            // Check if savefile exists
            if (!File.Exists(SaveFile))
            {
                Console.WriteLine("Error, savefile doesn't exist!");
                return "";
            };

            // Convert JSON to string and return it
            return JsonConvert.DeserializeObject<string>(File.ReadAllText(SaveFile));
        }
        #endregion
    }
}