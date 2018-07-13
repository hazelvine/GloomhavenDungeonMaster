using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeckBuilder : MonoBehaviour
{
    // String variable that's going to hold our file. 
    string path;

    // Hold the raw json data
    string jsonString;
    public DeckDB deckDB;
    // Use this for initialization
    void Start()
    {
        // Path to json File and we want the path to a certain file. 
        // path = Application.streamingAssetsPath + "/scenarios.json";

        // Now we want to bring it into Unity. 
        jsonString = LoadResourceTextfile("mainDeck.json");

        // FromJson - We pass it the creature type so the from json it knows what to map it to. 
        // Creature test - so it knows what it's working with (db)
        deckDB = JsonUtility.FromJson<DeckDB>(jsonString);
    }

    public static string LoadResourceTextfile(string path)
    {

        string filePath = path.Replace(".json", "");

        TextAsset targetFile = Resources.Load<TextAsset>(filePath);

        return targetFile.text;
    }
}


