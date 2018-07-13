using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMarkGroupController : MonoBehaviour {
    
    public Creature.Status status;
    public CheckMarkController[] group;
    public CreatureList creatureList;
    public Creature linkedCreature;
    public Text num;
    public GameObject eliteCheck;

    GameController gameController;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
	}

    public void UpdateStatus(Creature.Status status)
    {
        int x = 0;

        switch (status)
        {
            case Creature.Status.Dead:
                x = 0;
                break;
            case Creature.Status.Normal:
                x = 1;
                break;
            case Creature.Status.Elite:
                x = 2;
                break;
        }

        for (int i = 0; i < group.Length; i++)
        {
            if (i == x)
            {
                group[i].isChecked = true;
            }
            else
            {
                group[i].isChecked = false;
            }
            group[i].UpdateCheckBox();
        }
    }

    public void ShowElite(bool b)
    {
        eliteCheck.SetActive(b);
    }

    public void checkBoxClicked(int x)
    {
        switch (x)
        {
            case 0:
                status = Creature.Status.Dead;
                linkedCreature.status = status;
                linkedCreature.healthBar.SetActive(false);
                // Check to see if all of that type are dead (get the initiative bar to do the check)
                gameController.creatureDispatcher.RemoveCreature(creatureList);
                linkedCreature.conditions.Clear();
                break;
            case 1:
                status = Creature.Status.Normal;
                linkedCreature.status = status;
                linkedCreature.healthBar.SetActive(true);
                linkedCreature.healthBar.GetComponent<HealthBarController>().UpdateHealthBarWithNormalStats();
                gameController.creatureDispatcher.AddCreature(creatureList);
                linkedCreature.conditions.Clear();
                linkedCreature.healthBar.GetComponent<HealthBarController>().UpdateConditionPanel();
                break;
            case 2:
                status = Creature.Status.Elite;
                linkedCreature.status = status;
                linkedCreature.healthBar.SetActive(true);
                linkedCreature.healthBar.GetComponent<HealthBarController>().UpdateHealthBarWithEliteStats();
                gameController.creatureDispatcher.AddCreature(creatureList);
                linkedCreature.conditions.Clear();
                linkedCreature.healthBar.GetComponent<HealthBarController>().UpdateConditionPanel();
                break;
        }
        
        for (int i = 0; i < group.Length; i++)
        {            
            if(i == x)
            {
                group[i].isChecked = true;
            }
            else
            {
                group[i].isChecked = false;
            }
            group[i].UpdateCheckBox();
        }
    }
}
