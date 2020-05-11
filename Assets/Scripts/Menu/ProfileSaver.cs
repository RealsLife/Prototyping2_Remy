using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

   public class PlayerProfile
    {
    public bool _profileCreated = false;
    public string _name = "";
    public int _gender = 0;
    }
    static class ProfileSaver
    {

    #region Fields
    //static string SaveFilePath = Application.dataPath + @"/GamerProfile";
    //    static string SaveFilePath = @"C:\Users\Brian Wouters\";
    static string SaveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    static string SaveFileName = "GamerProfile";
        public static PlayerProfile _playerProfile;
        #endregion

        #region Properties

        public static string SaveFile { get => string.Format(@"{0}\{1}.json", SaveFilePath, SaveFileName); }

        #endregion

        #region Methods

        public static void Save()
        {
            // Convert to JSON
            //string _json = JsonConvert.SerializeObject(_input);

            // Check if savefile exists, if so, make a backup
            if (File.Exists(SaveFile))
            {
                string _fileName = Path.GetFileNameWithoutExtension(SaveFile);
                File.Copy(SaveFile, SaveFile.Replace(_fileName, string.Format("{0}_backup", _fileName)), true);
            }

            //write file
            string _json = JsonUtility.ToJson(_playerProfile);
            File.WriteAllText(SaveFile, _json);
    }
    public static void Load()
        {
        //Check if savefile exists
        if (!File.Exists(SaveFile))
        {
            Console.WriteLine("Error, savefile doesn't exist!");
            return;
        };

        // Convert JSON to string and return it
        //string json = JsonConvert.DeserializeObject<string>(File.ReadAllText(SaveFile));

        //getfile 
      
        _playerProfile = JsonUtility.FromJson<PlayerProfile>(File.ReadAllText(SaveFile));
    }
        #endregion
    }
