using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    [Header("Core")]
    public Text title;
    public Text num;
    public Text healthNum;
    public Text shieldNum;
    public Text retaliateNum;
    public Text rangeNum;
    public Image avatar;

    [Header("Conditions")]
    public GameObject summon;
    public GameObject doomed;
    public GameObject invisible;
    public GameObject muddle;
    public GameObject strengthen;
    public GameObject poison;
    public GameObject stun;
    public GameObject wound;
    public GameObject immobilize;
    public GameObject disarm;
    public GameObject[] allConditions;

    [Header("Creatures")]
    public CreatureList creatureList;
    public Creature creature;

    [Header("Other")]
    public GameObject shield;
    public GameObject retaliate;
    public GameObject range;

    public GameObject normalBanner;
    public GameObject eliteBanner;
    public GameObject bossBanner;

    public int currentHealth;
    public Image fillBar;

    GameController gameController;

    enum Banner { Normal, Elite, Boss }

    public void SetupHealthBar(CreatureList cList, Creature c, int i)
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        creatureList = cList;
        creature = c;
        title.text = creatureList.name;
        num.text = (i + 1).ToString();
        avatar.sprite = creatureList.image;

        // Make all conditions visible.
        for (int x = 0; x < allConditions.Length; x++)
        {
            allConditions[x].SetActive(false);
        }

    }

    public void CreatureStatClick()
    {
        Debug.Log("We clicked on it");
        gameController.ShowStatPanel();
        gameController.statPanel.GetComponent<StatPanelController>().UpdateMonsterStats(creatureList);
    }

    public void DecreaseHealth()
    {
        currentHealth--;
        if(currentHealth < 0)
        {
            creature.healthBar.SetActive(false);
            creature.status = Creature.Status.Dead;
            creature.conditions.Clear();
            gameController.creatureDispatcher.RemoveCreature(creatureList);
            gameController.ShowAttackView();
            return;
        }
        UpdateHealth();
    }

    public void IncreaseHealth()
    {
        currentHealth++;
        if(currentHealth > creature.maxHealth)
        {
            currentHealth = creature.maxHealth;
        }
        UpdateHealth();
    }

    public void SetHealth(int health)
    {
        creature.maxHealth = health;
        currentHealth = health;
        UpdateHealth();
    }

    public void HealthPanelClick()
    {
        gameController.maxHealthPanel.GetComponent<MaxHealthPanelController>().creature = creature;
        gameController.ShowMaxHealthPanel();
    }

    public void ConditionPanelClick()
    {
        gameController.ShowConditionPanel();
        gameController.conditionPanel.GetComponent<ConditionController>().UpdatePanel(creature, creatureList);
    }

    public void RemoveCondition(string condition)
    {
        Creature.Conditions condi = Creature.Conditions.Curse;
        switch (condition)
        {
            case "Disarm":
                condi = Creature.Conditions.Disarm;
                break;
            case "Doomed":
                condi = Creature.Conditions.Doomed;
                break;
            case "Immobilize":
                condi = Creature.Conditions.Immobilize;
                break;
            case "Invisible":
                condi = Creature.Conditions.Invisible;
                break;
            case "Muddle":
                condi = Creature.Conditions.Muddle;
                break;
            case "Poison":
                condi = Creature.Conditions.Poison;
                break;
            case "Strengthen":
                condi = Creature.Conditions.Strengthen;
                break;
            case "Stun":
                condi = Creature.Conditions.Stun;
                break;
            case "Summon":
                condi = Creature.Conditions.Summon;
                break;
            case "Wound":
                condi = Creature.Conditions.Wound;
                break;
        }

        for (int i = 0; i < creature.conditions.Count; i++)
        {
            if (creature.conditions[i] == condi)
            {
                creature.conditions.RemoveAt(i);
                UpdateConditionPanel();
            }
        }
    }

    public void RemoveAllConditions()
    {
        // Make all conditions visible.
        for (int i = 0; i < allConditions.Length; i++)
        {
            allConditions[i].SetActive(false);
        }
    }


    public void UpdateConditionPanel()
    {
        RemoveAllConditions();

        // Hide currently active conditions.
        for (int i = 0; i < creature.conditions.Count; i++)
        {
            switch (creature.conditions[i])
            {
                case Creature.Conditions.Disarm:
                    disarm.SetActive(true);
                    break;
                case Creature.Conditions.Doomed:
                    doomed.SetActive(true);
                    break;
                case Creature.Conditions.Immobilize:
                    immobilize.SetActive(true);
                    break;
                case Creature.Conditions.Invisible:
                    invisible.SetActive(true);
                    break;
                case Creature.Conditions.Muddle:
                    muddle.SetActive(true);
                    break;
                case Creature.Conditions.Poison:
                    poison.SetActive(true);
                    break;
                case Creature.Conditions.Strengthen:
                    strengthen.SetActive(true);
                    break;
                case Creature.Conditions.Stun:
                    stun.SetActive(true);
                    break;
                case Creature.Conditions.Summon:
                    summon.SetActive(true);
                    break;
                case Creature.Conditions.Wound:
                    wound.SetActive(true);
                    break;
            }
        }
    }


    public void UpdateHealthBarWithNormalStats()
    {
        if (creatureList.stats.isBoss)
        {
            SetBanner(Banner.Boss);
        }
        else
        {
            SetBanner(Banner.Normal);
        }
        // THIS NEEDS TO BE FIXED (Jan.21 2018 12:53)
        UpdateStats(creatureList.stats);
    }

    public void UpdateHealthBarWithEliteStats()
    {
        SetBanner(Banner.Elite);
        // THIS NEEDS TO BE FIXED (Jan.21 2018 12:53)
        UpdateEliteStats(creatureList.stats);
    }

    public void AvatarClick()
    {
        gameController.ShowMonsterListPanel();
        gameController.monsterListPanel.GetComponent<MonsterListPanelController>().SetMonsterList(creatureList);
    }

    void SetBanner(Banner banner)
    {
        normalBanner.SetActive(false);
        eliteBanner.SetActive(false);
        bossBanner.SetActive(false);

        switch (banner)
        {
            case Banner.Normal:
                normalBanner.SetActive(true);
                break;
            case Banner.Elite:
                eliteBanner.SetActive(true);
                break;
            case Banner.Boss:
                bossBanner.SetActive(true);
                break;
        }
    }

    void UpdateStats(MonsterStats stats)
    {
        int level = creatureList.creatureLevel;
        StatGroup normal = stats.level[level].statGroup[0];
        if (creatureList.stats.isNPC)
        {
            switch (creatureList.name)
            {
                case "Hail":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 4 + (2 * creatureList.creatureLevel);
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].move = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].attack = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].range = 0;
                    break;
                case "Orchid":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 6 + (3 * creatureList.creatureLevel);
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].move = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].attack = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].range = 0;
                    break;
                case "Redthorn":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 6 + (3 * creatureList.creatureLevel);
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].move = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].attack = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].range = 0;
                    break;
                case "Captive Orchid":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 4 + (2 * creatureList.creatureLevel);
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].move = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].attack = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].range = 0;
                    break;
                case "Orchid Captive":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 4 + (2 * creatureList.creatureLevel);
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].move = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].attack = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].range = 0;
                    break;
                case "Fish":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 6 + (2 * creatureList.creatureLevel);
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].move = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].attack = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].range = 0;
                    break;
                case "Villager":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 3 + creatureList.creatureLevel;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].move = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].attack = 0;
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[1].range = 0;
                    break;
                case "Door":
                    switch (gameController.scenarioNum)
                    {
                        case 33:
                            creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = (4 + gameController.scenarioLevel);
                            break;
                        case 35:
                            creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = (7 + gameController.scenarioLevel) * gameController.numOfCharacters;
                            break;

                    }
                    break;
                case "Rock Column":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = (8 + gameController.scenarioLevel) * gameController.numOfCharacters;
                    break;
                case "Altar":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 4 + (gameController.scenarioLevel * gameController.numOfCharacters);
                    break;
                case "Mysterious Altar":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 6 + (gameController.scenarioLevel * gameController.numOfCharacters);
                    break;
                case "Totem":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 1 + gameController.numOfCharacters + gameController.scenarioLevel;
                    break;
                case "Bone Pile":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = gameController.scenarioLevel + (2 * gameController.numOfCharacters);
                    break;
                case "Tree":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = gameController.numOfCharacters * (3 + gameController.scenarioLevel);
                    break;
                case "Bloated Regent":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = Mathf.CeilToInt((creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health * gameController.numOfCharacters)/2);
                    break;
                case "Crystal":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 4 + gameController.numOfCharacters + (2 * gameController.scenarioLevel);
                    break;
                case "Siege Cannon":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health * 2;
                    break;
                case "Chord":
                    creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = Mathf.FloorToInt(gameController.scenarioLevel * gameController.numOfCharacters / 2);
                    break;
            }

            SetHealth(normal.health);
        }
        else if (creatureList.stats.isBoss)
        {
            if (creatureList.name == "Hungry Soul")
            {
                creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = (stats.level[creatureList.creatureLevel].statGroup[1].health * gameController.numOfCharacters) / 2;
            }
            else if (creatureList.name == "Gate")
            {
                creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = 10 + (2 * gameController.scenarioLevel);
            }
            else if(creatureList.name == "Prime Demon B")
            {
                creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health * gameController.numOfCharacters * 2;               
            }
            else
            {
                creatureList.stats.level[creatureList.creatureLevel].statGroup[0].health = creatureList.stats.level[creatureList.creatureLevel].statGroup[1].health * gameController.numOfCharacters;                
            }

            SetHealth(normal.health);

            // This has to be done after the health is set for infinity purpose. 
            if (creatureList.name == "Zephyr")
            {
                creatureList.stats.level[creatureList.creatureLevel].statGroup[0].attack = gameController.numOfCharacters;
                SetHealth(normal.health);
                SetSpecialHealth("∞");
            }
        }
        else
        {
            SetHealth(normal.health);
        }


        if (normal.shield > 0)
        {
            shield.SetActive(true);
            shieldNum.text = normal.shield.ToString();
        }
        else
        {
            shield.SetActive(false);
        }

        if(normal.retaliate > 0)
        {
            retaliate.SetActive(true);
            retaliateNum.text = normal.retaliate.ToString();
        }
        else
        {
            retaliate.SetActive(false);
        }

        if(normal.retaliateRange > 0)
        {
            range.SetActive(true);
            rangeNum.text = normal.retaliateRange.ToString();
        }
        else
        {
            range.SetActive(false);
        }
    }

    void UpdateEliteStats(MonsterStats stats)
    {
        int level = creatureList.creatureLevel;
        StatGroup elite = stats.level[level].statGroup[1];
        SetHealth(elite.health);
            

            if (elite.shield > 0)
            {
                shield.SetActive(true);
                shieldNum.text = elite.shield.ToString();
            }
            else
            {
                shield.SetActive(false);
            }

            if (elite.retaliate > 0)
            {
                retaliate.SetActive(true);
                retaliateNum.text = elite.retaliate.ToString();
            }
            else
            {
                retaliate.SetActive(false);
            }

            if (elite.retaliateRange > 0)
            {
                range.SetActive(true);
                rangeNum.text = elite.retaliateRange.ToString();
            }
            else
            {
                range.SetActive(false);
            }
    }

    void UpdateHealth()
    {
        if (creatureList.name == "Zephyr")
            return;
        healthNum.text = currentHealth.ToString();
        float hp = currentHealth;
        float maxhp = creature.maxHealth;

        fillBar.fillAmount = hp / maxhp;
    }

    void SetSpecialHealth(string s)
    {
        healthNum.text = s;
    }
}
