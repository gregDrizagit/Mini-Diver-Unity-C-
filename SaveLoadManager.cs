using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public class SaveLoadManager
{
	[Serializable]
	class SaveData
	{


    public string SavedMessage = "Game Saved";  // for displaying

    private const string SAVE_FILE_NAME = "SaveGame.dat";

    // PROPERTIES
    public string FullFilePathAndName { get { return Application.persistentDataPath + "/" + SAVE_FILE_NAME;  } }
    public bool SaveFileExists { get { return File.Exists(FullFilePathAndName); } }

	CanvasScript canvas;
	int allTimeHighScore;
    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream file = File.Create(FullFilePathAndName);

				canvas = GameObject.FindWithTag ("Canvas").GetComponent<CanvasScript> ();

				allTimeHighScore = canvas.allTimeHighScore;

				binaryFormatter.Serialize(file, allTimeHighScore);

        file.Close();
    }



    public void Load()
    {
        if (!SaveFileExists)
        {
            Debug.LogWarning("No save file to load!");
            return;
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream file = File.Open(FullFilePathAndName, FileMode.Open);

		canvas = GameObject.FindWithTag ("Canvas").GetComponent<CanvasScript> ();

		canvas.allTimeHighScore = allTimeHighScore;

        file.Close();

    }



    public void DeleteSave()
    {
        if (!SaveFileExists)
        {
            Debug.LogWarning("No save file to delete!");
            return;
        }

        File.Delete(FullFilePathAndName);
    }
}
