using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScenarioDispatcher : MonoBehaviour
{
    public Scenario[] scenario;
    public GameController gameController;

    string path;
    // Hold the raw json data
    string jsonString;

    // Use this for initialization
    public void Start()
    {
        // Path to json File and we want the path to a certain file. 
        // path = Application.streamingAssetsPath + "/scenarios.json";

        // Now we want to bring it into Unity. 
        jsonString = LoadResourceTextfile("scenarios.json");

        // FromJson - We pass it the creature type so the from json it knows what to map it to. 
        // Creature test - so it knows what it's working with (db)
        ScenarioList scenarioList = JsonUtility.FromJson<ScenarioList>(jsonString);
        scenario = scenarioList.scenario;
        gameController.startPage.SetActive(true);
    }

    public static string LoadResourceTextfile(string path)
    {

        string filePath = Application.streamingAssetsPath + "/" + path;

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }

            return reader.text;
        }
        else
        {
            return System.IO.File.ReadAllText(filePath); ;
        }
    }
}

[System.Serializable]
public class ScenarioList
{
    public Scenario[] scenario;
}

[System.Serializable]
public class Scenario
{
    public int num = 0;
    public string name = "missing";
    public string[] monsterList;
}
