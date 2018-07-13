using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject startPage;
    public GameObject noMonsterPanel;
    public GameObject grimoirePanel;
    public GameObject roundPanel;
    public GameObject scenarioPanel;
    public GameObject charPanel;
    public GameObject monsterStatPanel;
    public GameObject monsterListPanel;
    public GameObject healthBarPanel;
    public GameObject initiativeBar;
    public GameObject conditionPanel;
    public GameObject roomInfusion;
    public GameObject statPanel;
    public GameObject AnimationPanel;
    public GameObject maxHealthPanel;
    public GameObject areYouSurePanel;

    [Header("Deck Modifier")]
    public GameObject AttackModifier;

    [Header("Data")]
    public int scenarioNum;
    public int scenarioLevel;
    public int numOfCharacters;
    public int p1Level;
    public int p2Level;
    public int p3Level;
    public int p4Level;
    public int p5Level;
    public int difficultyLevel;
    public int round;

    // SPECIAL SECTION
    public bool isSolo;
    public bool isFivePlayers;

    public Text goldCoin;
    public Text trapDamage;
    public Text xpPoints;

    public CreatureDispatcher creatureDispatcher;
    public ScenarioDispatcher scenarioDispatcher;

    private void Start()
    {
        startPage.SetActive(true);
        scenarioNum = 0;
        scenarioLevel = 0;
        numOfCharacters = 2;
        round = 0;
        isSolo = false;
        noMonsterPanel.SetActive(true);
        AnimationPanel.SetActive(true);
    }


    public void UpdateScenarioLevel()
    {
        goldCoin.text = GetCoinValue(scenarioLevel).ToString();
        trapDamage.text = GetTrapValue(scenarioLevel).ToString();
        xpPoints.text = GetXPValue(scenarioLevel).ToString();

        creatureDispatcher.OverrideMonsterLevels(scenarioLevel);
    }

    public int GetCoinValue(int sLevel)
    {
        switch (sLevel)
        {
            case 0:
                return 2;
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return 3;
            case 4:
                return 4;
            case 5:
                return 4;
            case 6:
                return 5;
            case 7:
                return 6;
        }
        return sLevel;
    }

    public int GetTrapValue(int sLevel)
    {
        if (isFivePlayers)
        {
            sLevel += 2;
            if (sLevel > 7)
            {
                sLevel = 7;
            }
            Debug.Log("5 players");
        }
        else if (isSolo)
        {
            sLevel++;
            Debug.Log("AND solo");
        }

        
         
        switch (sLevel)
        {
            case 0:
                return 2;
            case 1:
                return 3;
            case 2:
                return 4;
            case 3:
                return 5;
            case 4:
                return 6;
            case 5:
                return 7;
            case 6:
                return 8;
            case 7:
                return 9;
        }
        return sLevel;
    }

    public int GetXPValue(int sLevel)
    {
        switch (sLevel)
        {
            case 0:
                return 4;
            case 1:
                return 6;
            case 2:
                return 8;
            case 3:
                return 10;
            case 4:
                return 12;
            case 5:
                return 14;
            case 6:
                return 16;
            case 7:
                return 18;
        }
        return sLevel;
    }

    public string GetRound()
    {
        if (round < 10)
            return "0" + round.ToString();

        return round.ToString();
    }

    public string GetScenarioLevel()
    {
        return scenarioLevel.ToString();
    }

    public string GetNumberOfCharacters()
    {
        return numOfCharacters.ToString();
    }

    public void ShowPanel(string panel)
    {
        switch (panel)
        {
            case "Start Page":
                break;

            case "NoMonsterPanel":
                noMonsterPanel.SetActive(true);
                break;
            case "RoundPanel":
                roundPanel.GetComponent<RoundPanel>().PushRoundLevel(round);
                roundPanel.SetActive(true);
                break;
            case "CharPanel":
                charPanel.GetComponent<CharPanel>().PushRoundLevel(numOfCharacters);
                charPanel.SetActive(true);
                break;
            case "ScenarioPanel":
                scenarioPanel.GetComponent<StartPageController>().UpdatePanel();
                scenarioPanel.SetActive(true);
                break;
            case "GrimoirePanel":
                HidePanel();
                grimoirePanel.SetActive(true);
                break;
            case "MonsterStatPanel":
                HidePanel();
                monsterStatPanel.SetActive(true);
                break;
            case "MonsterListPanel":
                break;
        }
    }

    public void ShowMonsterListPanel()
    {
        HidePanel();
        monsterListPanel.SetActive(true);
    }


    public void HidePanel()
    {
        startPage.SetActive(false);
        noMonsterPanel.SetActive(false);
        monsterStatPanel.SetActive(false);
        grimoirePanel.SetActive(false);
        healthBarPanel.SetActive(false);

        if (monsterListPanel.activeSelf)
        {
            monsterListPanel.GetComponent<MonsterListPanelController>().destroyClones();
            monsterListPanel.SetActive(false);
        }
    }

    public void TogglePanel(GameObject panel, bool visible)
    {
        panel.SetActive(visible);
    }

    public void ShowAttackView()
    {
        HidePanel();
        if(creatureDispatcher.activeCreatures.Count > 0)
        {
            ShowHealthBarPanel();

            //creatureDispatcher.DispatchToInitiativeBar();
            monsterStatPanel.SetActive(true);
        }
        else
        {
            noMonsterPanel.SetActive(true);
        }
    }

    public void ShowConditionPanel()
    {
        conditionPanel.SetActive(true);
    }

    public void ShowMonsterStatPanel()
    {
        monsterStatPanel.SetActive(true);
    }

    public void ShowHealthBarPanel()
    {
        healthBarPanel.SetActive(true);
    }

    public void ShowStatPanel()
    {
        statPanel.SetActive(true);
    }

    public void ShowMaxHealthPanel()
    {
        maxHealthPanel.SetActive(true);
    }

    public void CloseMaxHealthPanel()
    {
        maxHealthPanel.SetActive(false);
    }

    public void CloseStatPanel()
    {
        statPanel.SetActive(false);
    }

    public void CloseHealthBarPanel()
    {
        healthBarPanel.SetActive(false);
    }

    public void CloseConditionPanel()
    {
        conditionPanel.SetActive(false);
    }
    public void CloseScenarioPanel()
    {
        scenarioPanel.SetActive(false);
    }

    public void CloseRoundPanel()
    {
        roundPanel.SetActive(false);
        monsterStatPanel.GetComponent<MonsterStatPanelController>().roundCheck(round);
    }

    public void CloseCharPanel()
    {
        charPanel.SetActive(false);
    }

    public void QuitApplication()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
        else
        {
            areYouSurePanel.SetActive(true);
        }
    }
}
