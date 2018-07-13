using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPanelController : MonoBehaviour {

    public CreatureList creatureList;
    public GameController gameController;

    [Header("UI Assets")]
    public Text creatureName;

    public Image img;

    public Text normalHpTxt;
    public Text eliteHpTxt;
    public Text normalMpTxt;
    public Text eliteMpTxt;
    public Text normalAtkTxt;
    public Text eliteAtkTxt;
    public Text normalRngTxt;
    public Text eliteRngTxt;
    public GameObject walkingIcon;
    public GameObject flyingIcon;

    public GameObject monsterPanel;
    public GameObject bossPanel;

    public GameObject nShield;
    public Text nShieldTxt;
    public GameObject nRetaliate;
    public Text nRetaliateTxt;
    public GameObject nRetaliateRange;
    public Text nRetaliateRangeTxt;
    public GameObject nPierce;
    public Text nPierceTxt;
    public GameObject nPoison;
    public GameObject nWound;
    public GameObject nMuddle;
    public GameObject nDisarm;
    public GameObject nTarget;
    public Text nTargetTxt;
    public GameObject nAdvantage;
    public GameObject nDisadvantage;

    public GameObject eShield;
    public Text eShieldTxt;
    public GameObject eRetaliate;
    public Text eRetaliateTxt;
    public GameObject eRetaliateRange;
    public Text eRetaliateRangeTxt;
    public GameObject ePierce;
    public Text ePierceTxt;
    public GameObject ePoison;
    public GameObject eWound;
    public GameObject eMuddle;
    public GameObject eDisarm;
    public GameObject eTarget;
    public Text eTargetTxt;
    public GameObject eAdvantage;
    public GameObject eDisadvantage;


    public GameObject bossWalk;
    public GameObject bossFly;
    public Text bossHpTxt;
    public Text bossMpTxt;
    public Text bossAtkTxt;
    public Text bossRngTxt;
    public Image bossSpecial;
    public GameObject bossPoison;
    public GameObject bossWound;
    public GameObject bossMuddle;
    public GameObject bossDisarm;
    public GameObject bossPush;
    public GameObject bossPull;
    public GameObject bossCurse;
    public GameObject bossStun;
    public GameObject bossImmobilize;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {

    }

    public void UpdateMonsterStats(CreatureList cList)
    {
        creatureList = cList;

        // CreatureStat normalStats = creatureList.normalStats[gameController.scenarioLevel];

        StatGroup normalStats = creatureList.stats.level[creatureList.creatureLevel].statGroup[0];

        Debug.Log(creatureList.stats.isBoss);

        // Fill stats
        creatureName.text = creatureList.name;
        img.sprite = creatureList.image;

        
        // BOSS
        if (creatureList.stats.isBoss || creatureList.stats.isNPC)
        {
            bossPanel.SetActive(true);
            monsterPanel.SetActive(false);
            /*
            bossWalk.SetActive(!creatureList.stats.canFly);
            bossFly.SetActive(creatureList.stats.canFly);

            bossHpTxt.text = (normalStats.health * gameController.numOfCharacters).ToString();
            bossMpTxt.text = normalStats.move.ToString();
            // To take into consideration the stupid inox bodyguards...
            if (normalStats.attack == -1)
            {
                int atk = 0;
                switch (creatureList.creatureLevel)
                {
                    case 0:
                        atk = gameController.numOfCharacters;
                        break;
                    case 1:
                        atk = gameController.numOfCharacters + 1;
                        break;
                    case 2:
                        atk = gameController.numOfCharacters + 1;
                        break;
                    case 3:
                        atk = gameController.numOfCharacters + 2;
                        break;
                    case 4:
                        atk = gameController.numOfCharacters + 2;
                        break;
                    case 5:
                        atk = gameController.numOfCharacters + 3;
                        break;
                    case 6:
                        atk = gameController.numOfCharacters + 3;
                        break;
                    case 7:
                        atk = gameController.numOfCharacters + 4;
                        break;
                }
                bossAtkTxt.text = atk.ToString();
            }
            else
            {
                bossAtkTxt.text = normalStats.attack.ToString();
            }
            bossRngTxt.text = normalStats.range.ToString();
            
            Immunity im = creatureList.stats.immunity;
            // Section for imunity
            bossCurse.SetActive(im.curse);
            bossDisarm.SetActive(im.disarm);
            bossImmobilize.SetActive(im.immobilize);
            bossPoison.SetActive(im.poison);
            bossPull.SetActive(im.pull);
            bossPush.SetActive(im.push);
            bossStun.SetActive(im.stun);
            bossWound.SetActive(im.wound);

            // Section for special card. 
            //bossSpecial.sprite = normalStats.specialAbilities;

        */
            return;
        }

        // NORMAL
        bossPanel.SetActive(false);
        monsterPanel.SetActive(true);
      
        walkingIcon.SetActive(!creatureList.stats.canFly);
        flyingIcon.SetActive(creatureList.stats.canFly);

        normalHpTxt.text = normalStats.health.ToString();
        normalMpTxt.text = normalStats.move.ToString();
        normalAtkTxt.text = normalStats.attack.ToString();
        normalRngTxt.text = normalStats.range.ToString();

        if (normalStats.shield > 0)
        {
            nShield.SetActive(true);
            nShieldTxt.text = normalStats.shield.ToString();
        }
        else
        {
            nShield.SetActive(false);
        }

        if (normalStats.retaliate > 0)
        {
            nRetaliate.SetActive(true);
            nRetaliateTxt.text = normalStats.retaliate.ToString();
            if (normalStats.retaliateRange > 0)
            {
                nRetaliateRange.SetActive(true);
                nRetaliateRangeTxt.text = normalStats.retaliateRange.ToString();
            }
            else
            {
                nRetaliateRange.SetActive(false);
            }
        }
        else
        {
            nRetaliate.SetActive(false);
        }

        if (normalStats.pierce > 0)
        {
            nPierce.SetActive(true);
            nPierceTxt.text = normalStats.pierce.ToString();
        }
        else
        {
            nPierce.SetActive(false);
        }

        nPoison.SetActive(normalStats.poison);
        nWound.SetActive(normalStats.wound);
        nMuddle.SetActive(normalStats.muddle);
        nDisarm.SetActive(normalStats.disarm);

        if (normalStats.target > 0)
        {
            nTarget.SetActive(true);
            nTargetTxt.text = normalStats.target.ToString();
        }
        else
        {
            nTarget.SetActive(false);
        }
        nAdvantage.SetActive(normalStats.advantage);
        nDisadvantage.SetActive(normalStats.disadvantage);


    
        StatGroup eliteStats = creatureList.stats.level[creatureList.creatureLevel].statGroup[1];

        eliteHpTxt.text = eliteStats.health.ToString();
        eliteMpTxt.text = eliteStats.move.ToString();
        eliteAtkTxt.text = eliteStats.attack.ToString();
        eliteRngTxt.text = eliteStats.range.ToString();

        if (eliteStats.shield > 0)
        {
            eShield.SetActive(true);
            eShieldTxt.text = eliteStats.shield.ToString();
        }
        else
        {
            eShield.SetActive(false);
        }

        if (eliteStats.retaliate > 0)
        {
            eRetaliate.SetActive(true);
            eRetaliateTxt.text = eliteStats.retaliate.ToString();
            if (eliteStats.retaliateRange > 0)
            {
                eRetaliateRange.SetActive(true);
                eRetaliateRangeTxt.text = eliteStats.retaliateRange.ToString();
            }
            else
            {
                eRetaliateRange.SetActive(false);
            }
        }
        else
        {
            eRetaliate.SetActive(false);
        }

        if (eliteStats.pierce > 0)
        {
            ePierce.SetActive(true);
            ePierceTxt.text = eliteStats.pierce.ToString();
        }
        else
        {
            ePierce.SetActive(false);
        }

        ePoison.SetActive(eliteStats.poison);
        eWound.SetActive(eliteStats.wound);
        eMuddle.SetActive(eliteStats.muddle);
        eDisarm.SetActive(eliteStats.disarm);

        if (eliteStats.target > 0)
        {
            eTarget.SetActive(true);
            eTargetTxt.text = eliteStats.target.ToString();
        }
        else
        {
            eTarget.SetActive(false);
        }
        eAdvantage.SetActive(eliteStats.advantage);
        eDisadvantage.SetActive(eliteStats.disadvantage);

    }
}
