using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatPanelController : MonoBehaviour
{
    [Header("Access all data from...")]
    public CreatureList creatureList;
    public GameController gameController;

    [Header("Main GameObjects")]
    public GameObject[] monsterAssets;
    public GameObject[] bossAssets;
    public GameObject[] npcAssets;
    public GameObject monsterStat;

    [Header("Containers")]
    public Transform normalContainer;
    public Transform eliteContainer;
    public Transform bossContainer;

    [Header("Clones")]
    public GameObject attackClone;
    public GameObject conditionClone;
    public GameObject createElementClone;
    public GameObject convertElementToActionClone;
    public GameObject healClone;
    public GameObject strengthenClone;
    public GameObject moveClone;
    public GameObject retaliateClone;
    public GameObject shieldClone;
    public GameObject lootClone;
    public GameObject poisonClone;
    public GameObject disarmClone;
    public GameObject muddleClone;
    public GameObject immobilizeClone;
    public GameObject invisibleClone;
    public GameObject woundClone;
    public GameObject curseClone;
    public GameObject blessClone;
    public GameObject stunClone;
    public GameObject pushClone;
    public GameObject pullClone;
    public GameObject textAction;
    public GameObject AoE1;
    public GameObject AoE2;
    public Sprite[] aoe;
    

    [Header("UI Assets")]
    public Text creatureName;
    public Text mainBannerName;
    public Text mainBannerNameShadow;
    public GameObject redBanner;
    public GameObject image;
    public Image img;

    [Header("Boss Items")]
    public ImmunityContainer immunityContainer;

    GameObject clone;

    public List<GameObject> myList;

    void Start()
    {
        myList = new List<GameObject>();
    }

    public void MonsterStatClick()
    {
        gameController.ShowStatPanel();
        gameController.statPanel.GetComponent<StatPanelController>().UpdateMonsterStats(creatureList);
    }

    private void OnEnable()
    {
        roundCheck(gameController.round); 
    }

    public void roundCheck(int round)
    {
        if (round == 0)
        {
            monsterStat.SetActive(false);
            redBanner.SetActive(false);
            image.SetActive(false);
        }
        else
        {
            monsterStat.SetActive(true);
            redBanner.SetActive(true);
            image.SetActive(true);
        }
    }

    public void SetMonster(CreatureList cList)
    {
        creatureList = cList;

        if (eliteContainer.childCount > 0)
        {
            foreach (Transform child in eliteContainer)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        if (normalContainer.childCount > 0)
        {
            foreach (Transform child in normalContainer)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        roundCheck(gameController.round);
        
        // Fill stats
        creatureName.text = creatureList.name;
        img.sprite = creatureList.image;

        AoE1.SetActive(false);
        AoE2.SetActive(false);

        // Set everything to false...
        foreach (GameObject item in monsterAssets)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in npcAssets)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in bossAssets)
        {
            item.SetActive(false);
        }

        if (creatureList.stats.isBoss)
        {
            mainBannerName.text = "Actions";
            mainBannerNameShadow.text = "Actions";
            // Setup Boss Items
            foreach (GameObject item in bossAssets)
            {
                item.SetActive(true);
            }
            immunityContainer.poison.SetActive(creatureList.stats.immunity.poison);
            immunityContainer.wound.SetActive(creatureList.stats.immunity.wound);
            immunityContainer.stun.SetActive(creatureList.stats.immunity.stun);
            immunityContainer.muddle.SetActive(creatureList.stats.immunity.muddle);
            immunityContainer.immobilize.SetActive(creatureList.stats.immunity.immobilize);
            immunityContainer.disarm.SetActive(creatureList.stats.immunity.disarm);
            immunityContainer.push.SetActive(creatureList.stats.immunity.push);
            immunityContainer.pull.SetActive(creatureList.stats.immunity.pull);
            immunityContainer.curse.SetActive(creatureList.stats.immunity.curse);

            for (int i = 0; i < creatureList.creatureDeck[0].line.Length; i++)
            {
                SetupLine(creatureList.creatureDeck[0].line[i], "boss");
            }
        }
        else if (creatureList.stats.isNPC)
        {
            mainBannerName.text = "Actions";
            mainBannerNameShadow.text = "Actions";
            foreach (GameObject item in npcAssets)
            {
                item.SetActive(true);
            }

            for (int i = 0; i < creatureList.creatureDeck[0].line.Length; i++)
            {
                SetupLine(creatureList.creatureDeck[0].line[i], "boss");
            }
        }
        else
        {
            foreach (GameObject item in monsterAssets)
            {
                item.SetActive(true);
            }

            mainBannerName.text = "Elite Actions";
            mainBannerNameShadow.text = "Elite Actions";
            for (int i = 0; i < creatureList.creatureDeck[0].line.Length; i++)
            {
                SetupLine(creatureList.creatureDeck[0].line[i], "normal");
                SetupLine(creatureList.creatureDeck[0].line[i], "elite");
            }
        }
       
    }

    private void SetupLine(Line line, string creatureState)
    {
        StatGroup stat = creatureList.stats.level[creatureList.creatureLevel].statGroup[0];

        if (creatureState == "elite")
            stat = creatureList.stats.level[creatureList.creatureLevel].statGroup[1];

        Transform container; // Dictates which box the lines will be written in. 
        if (creatureState == "normal")
        {
            container = normalContainer;
        }
        else if (creatureState == "boss")
        {
            container = eliteContainer;
        }
        else
        {
            container = eliteContainer;
        }

        switch (line.name)
        {
            case "attack":
                clone = (GameObject)Instantiate(attackClone, container);
                                
                clone.GetComponent<AttackActionController>().modifier = stat.attack + line.mod;
                if(creatureList.name == "Inox Bodyguard")
                {
                    clone.GetComponent<AttackActionController>().modifier = creatureList.stats.level[creatureList.creatureLevel].statGroup[1].attack  + gameController.numOfCharacters + line.mod;
                }
                clone.GetComponent<AttackActionController>().rangeModifier = stat.range + line.range;
                clone.GetComponent<AttackActionController>().targetModifier = stat.target + line.target;

                if(line.pierce > 0)
                {
                    clone.GetComponent<AttackActionController>().pierce = line.pierce;
                }
                else
                {
                    clone.GetComponent<AttackActionController>().pierce = stat.pierce;
                }

                clone.GetComponent<AttackActionController>().push = line.push;
                clone.GetComponent<AttackActionController>().pull = line.pull;

                if (stat.disarm || line.disarm)
                    clone.GetComponent<AttackActionController>().disarm = true;

                if (stat.immobilize || line.immobilize)
                    clone.GetComponent<AttackActionController>().immobilize = true;

                if (stat.muddle || line.muddle)
                    clone.GetComponent<AttackActionController>().muddle = true;

                if (stat.poison || line.poison)
                    clone.GetComponent<AttackActionController>().poison = true;

                if (stat.stun || line.stun)
                    clone.GetComponent<AttackActionController>().stun = true;

                if (stat.wound || line.wound)
                    clone.GetComponent<AttackActionController>().wound = true;

                if (stat.curse || line.curse)
                    clone.GetComponent<AttackActionController>().curse = true;

                foreach (Sprite sp in aoe)
                {
                    if(sp.name == line.aoe)
                    {
                        AoE1.GetComponent<Image>().sprite = sp;
                        if (sp.name == "aoe-none")
                        {
                            AoE1.SetActive(false);
                        }
                        else
                        {
                            AoE1.SetActive(true);
                        }
                    }

                    if (sp.name == line.aoe2)
                    {
                        AoE2.GetComponent<Image>().sprite = sp;
                        if(sp.name == "aoe-none")
                        {
                            AoE2.SetActive(false);
                        }
                        else
                        {
                            AoE2.SetActive(true);
                        }
                    }
                }                 
                
                clone.GetComponent<AttackActionController>().SetupCard();

                if (creatureList.name == "Dark Rider")
                {
                    RectTransform rectTransf = clone.GetComponent<AttackActionController>().attackNumGO.GetComponent<RectTransform>();
                    rectTransf.sizeDelta = new Vector2(64f, rectTransf.rect.height);
                    clone.GetComponent<AttackActionController>().attackNum.text += "+X";                    
                }

                if (creatureList.name == "Merciless Overseer")
                {
                    clone.GetComponent<AttackActionController>().attackNum.text = "X";
                }

                if(line.range == -5)
                {
                    clone.GetComponent<AttackActionController>().rangeNum.SetActive(false);
                    clone.GetComponent<AttackActionController>().range.SetActive(false);
                }

                break;            
            case "heal":
                clone = (GameObject)Instantiate(healClone, container);
                clone.GetComponent<HealActionController>().healAmount = line.mod + stat.heal;
                clone.GetComponent<HealActionController>().range = line.range;
                break;
            case "strengthen":
                clone = (GameObject)Instantiate(strengthenClone, container);
                clone.GetComponent<HealActionController>().healAmount = line.mod;
                clone.GetComponent<HealActionController>().range = line.range;
                break;
            case "loot":
                clone = (GameObject)Instantiate(lootClone, container);
                clone.GetComponent<BasicActionController>().num.text = line.range.ToString();
                break;

            case "bless":
                clone = (GameObject)Instantiate(blessClone, container);
                clone.GetComponent<HealActionController>().healAmount = line.mod;
                clone.GetComponent<HealActionController>().range = line.range;

                break;
            case "shield":
                clone = (GameObject)Instantiate(shieldClone, container);
                clone.GetComponent<BasicActionController>().modifier = line.mod;
                clone.GetComponent<BasicActionController>().SetupCard();

                break;
            case "retaliate":
                clone = (GameObject)Instantiate(retaliateClone, container);
                if(line.mod == -1 && creatureList.name == "Inox Bodyguard")
                {
                    switch (creatureList.creatureLevel)
                    {
                        case 0:
                            clone.GetComponent<RetaliateActionController>().retAmount = 3;
                            break;
                        case 1:
                            clone.GetComponent<RetaliateActionController>().retAmount = 3;
                            break;
                        case 2:
                            clone.GetComponent<RetaliateActionController>().retAmount = 3;
                            break;
                        case 3:
                            clone.GetComponent<RetaliateActionController>().retAmount = 4;
                            break;
                        case 4:
                            clone.GetComponent<RetaliateActionController>().retAmount = 4;
                            break;
                        case 5:
                            clone.GetComponent<RetaliateActionController>().retAmount = 5;
                            break;
                        case 6:
                            clone.GetComponent<RetaliateActionController>().retAmount = 5;
                            break;
                        case 7:
                            clone.GetComponent<RetaliateActionController>().retAmount = 5;
                            break;
                    }
                }
                else
                {
                    clone.GetComponent<RetaliateActionController>().retAmount = line.mod;
                    clone.GetComponent<RetaliateActionController>().range = line.range;
                }
                break;
            case "push":
                clone = (GameObject)Instantiate(pushClone, container);
                clone.GetComponent<ConditionAction>().modifier = line.mod;
                clone.GetComponent<ConditionAction>().poison = line.poison;
                clone.GetComponent<ConditionAction>().SetupCard();

                break;
            case "pull":
                clone = (GameObject)Instantiate(pullClone, container);
                clone.GetComponent<ConditionAction>().modifier = line.mod;
                clone.GetComponent<ConditionAction>().SetupCard();

                break;
            case "move":
                clone = (GameObject)Instantiate(moveClone, container);

                    if (creatureList.stats.canFly)
                {
                    clone.GetComponent<MoveActionController>().moveState = MoveActionController.Move.Fly;
                }
                else if (line.jump)
                {
                    clone.GetComponent<MoveActionController>().moveState = MoveActionController.Move.Jump;
                }
                else
                {
                    clone.GetComponent<MoveActionController>().moveState = MoveActionController.Move.Walk;
                }
                clone.GetComponent<MoveActionController>().modifier = stat.move + line.mod;
                clone.GetComponent<MoveActionController>().SetupCard();
                break;
            case "text":
                clone = (GameObject)Instantiate(textAction, container);
                string lineString = line.label;
                if (creatureList.name == "Gate" && line.label == "Special1a")
                {                    
                   lineString = "Prime Demon suffers " + ((2*gameController.numOfCharacters) + gameController.scenarioLevel - 2).ToString() + " dmg.";                    
                }

                if (creatureList.name == "Siege Cannon" && line.label == "Special1")
                {
                    Debug.Log("Scenario Level: " + gameController.scenarioLevel);
                    Debug.Log("Attack: " + creatureList.stats.level[gameController.scenarioLevel].statGroup[1].attack);
                    lineString = "When fired, it deals " + creatureList.stats.level[gameController.scenarioLevel].statGroup[1].attack.ToString() + " attack damage on all characters and character summons in hexes (b) and the columns above those hexes (including all of the G tile).";
                }

                if (creatureList.name == "Bone Pile" && line.label == "Special1")
                {
                    line.label = "For each bone pile present on the map, the harvester gains 1 Shield and Heals " + (gameController.numOfCharacters - 1).ToString() + " hit points at the end of each round.";
                }

                if (creatureList.name == "Tree" && line.label == "Special1")
                {
                    if(gameController.numOfCharacters == 2)
                    {
                        lineString = "A tree summons one Normal Ooze in the order of a, b, c, and back to a.";
                    }
                    if (gameController.numOfCharacters == 3)
                    {
                        lineString = "A tree summons one Normal Ooze (for odd rounds) or one Elite Ooze (for even rounds) in the order of a, b, c, and back to a.";
                    }
                    if (gameController.numOfCharacters >= 4)
                    {
                        lineString = "A tree summons one Elite Ooze in the order of a, b, c, and back to a.";
                    }
                }

                if (creatureList.name == "Gate" && line.label == "Special1")
                {
                    if (gameController.numOfCharacters == 2)
                    {
                        lineString = "Summon one normal Demon";

                    }
                    else if (gameController.numOfCharacters == 3)
                    {
                        lineString = "Summon a Demon (Earth & Wind demons are normal, Flame and Frost are elite)";
                    }
                    else
                    {
                        lineString = "Summon one elite Demon";
                    }
                }

                if (creatureList.name == "Dark Rider" && line.label == "Special2")
                {
                    if (gameController.numOfCharacters == 2)
                    {
                        lineString = "Summon one normal Forest Imp";

                    }
                    else 
                    {
                        lineString = "Summon two normal Forest Imp";
                    }
                }

                if (creatureList.name == "Rock Column" && line.label == "Special1")
                {
                    if (gameController.numOfCharacters <= 3)
                    {
                        lineString = "Starting from the current round, at the end of every odd round, one normal Night Demon will spawn in hex b.";

                    }
                    else
                    {
                        lineString = "Starting from the current round, at the end of every odd round, one elite Night Demon will spawn in hex b.";
                    }
                }

                if (creatureList.name == "Rock Column" && line.label == "Special2")
                {
                    if (gameController.numOfCharacters == 2)
                    {
                        lineString = "At the end of every even round, one normal Night Demon will spawn in hex c.";

                    }
                    else
                    {
                        lineString = "At the end of every even round, one elite Night Demon will spawn in hex c.";
                    }
                }


                if (creatureList.name == "Merciless Overseer" && line.label == "Special2")
                {
                    if (gameController.numOfCharacters == 2)
                    {
                        lineString = "Summon two normal Vermling Scout";

                    }
                    else if (gameController.numOfCharacters == 3)
                    {
                        lineString = "Summon one normal and one elite Vermling Scout";
                    }
                    else
                    {
                        lineString = "Summon two elite Vermling Scout";
                    }
                }

                if (creatureList.name == "Jekserah" && line.label == "Special1")
                {
                    if (gameController.numOfCharacters == 2)
                    {
                        lineString = "Summon two normal Living Bones";

                    }
                    else if (gameController.numOfCharacters == 3)
                    {
                        lineString = "Summon one normal and one elite Living Bones";
                    }
                    else
                    {
                        lineString = "Summon two elite Living Bones";
                    }
                }

                if (creatureList.name == "Jekserah" && line.label == "Special2")
                {
                    if (gameController.numOfCharacters == 2)
                    {
                        lineString = "Summon two normal Living Corpse";

                    }
                    else if (gameController.numOfCharacters == 3)
                    {
                        lineString = "Summon one normal and one elite Living Corpse";
                    }
                    else
                    {
                        lineString = "Summon two elite Living Corpse";
                    }
                }

                if (creatureList.name == "Prime Demon" && line.label == "Special1")
                {
                    if (gameController.numOfCharacters <= 2)
                    {
                        lineString = "Summon one normal Demon";

                    }
                    else 
                    {
                        lineString = "Summon one elite Demon";
                    }
                }

                if (creatureList.name == "Prime Demon" && line.label == "Special2")
                {
                    if (gameController.numOfCharacters <= 3)
                    {
                        lineString = "Summon one normal Demon";

                    }
                    else
                    {
                        lineString = "Summon one elite Demon";
                    }
                }

                if (creatureList.name == "The Betrayer" && line.label=="Special1")
                {
                    if(gameController.numOfCharacters == 2)
                    {
                        lineString = "Summon one elite Giant Viper";

                    }
                    else if(gameController.numOfCharacters == 3)
                    {
                        lineString = "Summon one normal and one elite Giant Viper";
                    }
                    else
                    {
                        lineString = "Summon two elite Giant Vipers";
                    }
                }

                if (creatureList.name == "The Sightless Eye" && line.label == "Special1")
                {
                    if (gameController.numOfCharacters == 2)
                    {
                        lineString = "Summon one normal Deep Terror";

                    }
                    else
                    {
                        lineString = "Summon one elite Deep Terror";
                    }
                }

                if (creatureList.name == "The Sightless Eye" && line.label == "Special2")
                {
                    if (gameController.numOfCharacters <= 3)
                    {
                        lineString = "Summon one normal Deep Terror";
                    }
                    else
                    {
                        lineString = "Summon one elite Deep Terror";
                    }
                }

                if (creatureList.name == "Winged Horror" && line.label == "egg")
                {
                    lineString = "Summon " + gameController.numOfCharacters.ToString() + " eggs with " + Mathf.CeilToInt(2f+(gameController.scenarioLevel/2f)).ToString() + " hit points each.";
                }



                clone.GetComponent<Text>().text = lineString;

                int numLines = Mathf.CeilToInt(lineString.Length / 28f);
                RectTransform rectTrans = clone.GetComponent<RectTransform>();
                rectTrans.sizeDelta = new Vector2(rectTrans.rect.width, 33f * numLines);

                clone.GetComponent<RectTransform>().sizeDelta = rectTrans.sizeDelta;
                //rectTrans.sizeDelta = new Vector2(rectTrans.rect.width, 39f * numLines);
                break;
            case "immobilize":
                clone = (GameObject)Instantiate(immobilizeClone, container);
                break;
            case "disarm":
                clone = (GameObject)Instantiate(disarmClone, container);
                break;
            case "invisible":
                clone = (GameObject)Instantiate(invisibleClone, container);
                break;
            case "poison":
                clone = (GameObject)Instantiate(poisonClone, container);
                break;
            case "wound":
                clone = (GameObject)Instantiate(woundClone, container);
                break;
            case "muddle":
                clone = (GameObject)Instantiate(muddleClone, container);
                break;
            case "curse":
                clone = (GameObject)Instantiate(curseClone, container);
                if(line.range == -1)
                {
                    clone.GetComponent<CurseAction>().rangeIcon.SetActive(true);
                    clone.GetComponent<CurseAction>().rangeNum.text = stat.range.ToString();
                    clone.GetComponent<CurseAction>().rangeText.SetActive(true);
                }
                else
                {
                    clone.GetComponent<CurseAction>().rangeIcon.SetActive(false);
                    clone.GetComponent<CurseAction>().rangeText.SetActive(false);
                }                
                break;
            case "createElement":
                clone = (GameObject)Instantiate(createElementClone, container);               
                clone.GetComponent<CreateElementAction>().CreateElement(line.element);
                break;         
            case "convertElementToAction":
                clone = (GameObject)Instantiate(convertElementToActionClone, container);
                clone.GetComponent<ConvertElementAction>().InsertAction(line);
                break;
            case "aoe1":
                foreach (Sprite sp in aoe)
                {
                    if (sp.name == line.aoe)
                    {
                        AoE1.GetComponent<Image>().sprite = sp;
                        if (sp.name == "aoe-none")
                        {
                            AoE1.SetActive(false);
                        }
                        else
                        {
                            AoE1.SetActive(true);
                        }
                    }
                }
                break;
            case "aoe2":
                foreach (Sprite sp in aoe)
                {
                    if (sp.name == line.aoe)
                    {
                        AoE2.GetComponent<Image>().sprite = sp;
                        if (sp.name == "aoe-none")
                        {
                            AoE2.SetActive(false);
                        }
                        else
                        {
                            AoE2.SetActive(true);
                        }
                    }
                }
                break;
        }
        clone.tag = "CardClone";
    }
}