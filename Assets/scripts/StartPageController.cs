using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPageController : MonoBehaviour {
    public bool isStartPage;
    public Text numOfChar;
    public Text scenarioLevel;
    public GameObject[] characters;
    public GameObject difficutlyLevelGO;

    public ScalarController numOfCharacters;
    public ScalarController p1;
    public ScalarController p2;
    public ScalarController p3;
    public ScalarController p4;
    public ScalarController p5;

    public ScenarioDifficultyController difficultyLevel;
    public CheckBoxController soloBox;

    private int scenarioLevelNum;

    public GameController gameController;
    public ScenarioNumController scenarioNumController;

    public void UserGuideClick()
    {
        Application.OpenURL("https://goo.gl/iJqerx");
    }

    public void FacebookClick()
    {
        Application.OpenURL("https://www.facebook.com/groups/405379303226514/");
    }

	// Use this for initialization
	void Start () {
        UpdateCharacterCount();
        UpdateScenarioLevel();
        if(isStartPage)
            scenarioNumController.UpdatePanel();
    }
	
	// Update is called once per frame
	void Update () {
        // This has to be caluclated

        // More 
    }
    public void UpdatePlayer()
    {
        gameController.p1Level = p1.currentValue;
        gameController.p2Level = p2.currentValue;
        gameController.p3Level = p3.currentValue;
        gameController.p4Level = p4.currentValue;
        gameController.p5Level = p5.currentValue;
    }

    public void UpdatePanel()
    {
        scenarioLevelNum = gameController.scenarioLevel;
        numOfCharacters.currentValue = gameController.numOfCharacters;
        difficultyLevel.currentValue = gameController.difficultyLevel;
        p1.currentValue = gameController.p1Level;
        p2.currentValue = gameController.p2Level;
        p3.currentValue = gameController.p3Level;
        p4.currentValue = gameController.p4Level;
        p5.currentValue = gameController.p5Level;

        soloBox.selected = gameController.isSolo;

        UpdateCharacterCount();
        UpdateScenarioLevel();
    }

    public void ClickStart()
    {
        gameController.HidePanel();
        gameController.ShowAttackView();
    }

    public void UpdateCharacterCount()
    {
        foreach (GameObject chars in characters)
        {
            chars.SetActive(false);
        }

        for (int i = 0; i < numOfCharacters.currentValue; i++)
        {
            characters[i].SetActive(true);
        }

        if(numOfCharacters.currentValue == 5)
        {
            difficutlyLevelGO.SetActive(false);
            gameController.isFivePlayers = true;
            //difficultyLevel.currentValue = 2;
            difficultyLevel.UpdateText();
        }
        else
        {
            gameController.isFivePlayers = false;
            difficutlyLevelGO.SetActive(true);
        }

        gameController.numOfCharacters = numOfCharacters.currentValue;
    }



    public void UpdateScenarioLevel()
    {
        UpdatePlayer();

        float num = 0f;
        for (int i = 0; i < numOfCharacters.currentValue; i++)
        {
            num += characters[i].GetComponentInChildren<ScalarController>().currentValue;
        }

        int avg = Mathf.RoundToInt(Mathf.Ceil(num / numOfCharacters.currentValue / 2));
        scenarioLevelNum = avg + difficultyLevel.currentValue;
        

        scenarioLevel.text = scenarioLevelNum.ToString();

        gameController.scenarioLevel = scenarioLevelNum;
        gameController.difficultyLevel = difficultyLevel.currentValue;
        gameController.isSolo = soloBox.selected;
        gameController.UpdateScenarioLevel();
    }
}
