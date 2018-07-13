using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterListPanelController : MonoBehaviour {

    [Header("Cloned Object")]
    public GameObject checkMark;
    public Transform container1;
    public Transform container2;

    [Header("UI Items")]
    public Text titleL;
    public Text titleR;
    public ScalarController creatureLevel;
    

    public GameObject img;
    public GameObject leftPage;
    public GameObject rightPage;
    public GameObject eliteText;
    public GameObject rightEliteText;

    GameObject clone;
    CreatureList creatureList;
    private void Start()
    {

    }

    public void SetMonsterList(CreatureList cList)
    {
        creatureList = cList;

        titleL.text = creatureList.name;
        titleR.text = creatureList.name;
        img.GetComponent<Image>().sprite = creatureList.image;
        
        creatureLevel.currentValue = creatureList.creatureLevel;

        if (creatureList.creature.Length > 6)
        {
            rightPage.SetActive(true);
            img.SetActive(false);
            SetupRightPage(creatureList);
        }
        else
        {
            rightPage.SetActive(false);
            img.SetActive(true);
            SetupLeftPage(creatureList.creature.Length, creatureList);
        }        
    }

    public void IncreaseCreatureLevel()
    {
        creatureList.creatureLevel++;
        if (creatureList.creatureLevel > 7)
            creatureList.creatureLevel = 7;
        creatureLevel.currentValue = creatureList.creatureLevel;

    }

    public void DecreaseCreatureLevel()
    {
        creatureList.creatureLevel--;
        if (creatureList.creatureLevel < 0)
            creatureList.creatureLevel = 0;
        creatureLevel.currentValue = creatureList.creatureLevel;
    }

    void SetupLeftPage(int x, CreatureList creatureList)
    {
        for (int i = 0; i < x; i++)
        {
            clone = (GameObject)Instantiate(checkMark, container1);
            clone.GetComponent<CheckMarkGroupController>().num.text = (i + 1).ToString();
            clone.GetComponent<CheckMarkGroupController>().linkedCreature = creatureList.creature[i];
            clone.GetComponent<CheckMarkGroupController>().creatureList = creatureList;
            clone.GetComponent<CheckMarkGroupController>().UpdateStatus(creatureList.creature[i].status);
            
            if (creatureList.stats.isNPC || creatureList.stats.isBoss)
            {
                eliteText.SetActive(false);
                clone.GetComponent<CheckMarkGroupController>().ShowElite(false);
            }
            else
            {
                eliteText.SetActive(true);
                clone.GetComponent<CheckMarkGroupController>().ShowElite(true);
            }
            clone.tag = "Clone";
            clone.name = "Creature" + (i + 1).ToString();
        }
    }

    void SetupRightPage(CreatureList creatureList)
    {
        for (int i = 0; i < 5; i++)
        {
            clone = (GameObject)Instantiate(checkMark, container1);
            clone.GetComponent<CheckMarkGroupController>().num.text = (i + 1).ToString();
            clone.GetComponent<CheckMarkGroupController>().linkedCreature = creatureList.creature[i];
            clone.GetComponent<CheckMarkGroupController>().creatureList = creatureList;
            clone.GetComponent<CheckMarkGroupController>().UpdateStatus(creatureList.creature[i].status);
            if (creatureList.stats.isNPC || creatureList.stats.isBoss)
            {
                eliteText.SetActive(false);
                clone.GetComponent<CheckMarkGroupController>().ShowElite(false);
            }
            else
            {
                eliteText.SetActive(true);
                clone.GetComponent<CheckMarkGroupController>().ShowElite(true);
            }
            clone.tag = "Clone";
            clone.name = "Creature" + (i + 1).ToString();
        }

        for (int j = 5; j < creatureList.creature.Length; j++)
        {
            clone = (GameObject)Instantiate(checkMark, container2);
            clone.GetComponent<CheckMarkGroupController>().num.text = (j + 1).ToString();
            clone.GetComponent<CheckMarkGroupController>().linkedCreature = creatureList.creature[j];
            clone.GetComponent<CheckMarkGroupController>().creatureList = creatureList;
            clone.GetComponent<CheckMarkGroupController>().UpdateStatus(creatureList.creature[j].status);
            if (creatureList.stats.isNPC || creatureList.stats.isBoss)
            {
                rightEliteText.SetActive(false);
                clone.GetComponent<CheckMarkGroupController>().ShowElite(false);
            }
            else
            {
                rightEliteText.SetActive(true);
                clone.GetComponent<CheckMarkGroupController>().ShowElite(true);
            }
            clone.tag = "Clone";
            clone.name = "Creature" + (j + 1).ToString();
        }
    }

    public void destroyClones()
    {
        var clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }
}
