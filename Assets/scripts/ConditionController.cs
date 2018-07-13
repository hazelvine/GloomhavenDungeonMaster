using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConditionController : MonoBehaviour {
    

    public Creature creature;
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

    public GameController gameController;
        
	public void UpdatePanel(Creature c, CreatureList cList)
    {
        creature = c;
                
        // Make all conditions visible.
        for (int i = 0; i < allConditions.Length; i++)
        {
            allConditions[i].SetActive(true);
        }

        // Hide currently active conditions.
        for (int i = 0; i < creature.conditions.Count; i++)
        {
            switch (creature.conditions[i])
            {
                case Creature.Conditions.Disarm:
                    disarm.SetActive(false);
                    break;
                case Creature.Conditions.Doomed:
                    doomed.SetActive(false);
                    break;
                case Creature.Conditions.Immobilize:
                    immobilize.SetActive(false);
                    break;
                case Creature.Conditions.Invisible:
                    invisible.SetActive(false);
                    break;
                case Creature.Conditions.Muddle:
                    muddle.SetActive(false);
                    break;
                case Creature.Conditions.Poison:
                    poison.SetActive(false);
                    break;
                case Creature.Conditions.Strengthen:
                    strengthen.SetActive(false);
                    break;
                case Creature.Conditions.Stun:
                    stun.SetActive(false);
                    break;
                case Creature.Conditions.Summon:
                    summon.SetActive(false);
                    break;
                case Creature.Conditions.Wound:
                    wound.SetActive(false);
                    break;                
            }
        }

        // For boss, hide conditions that it is immune to. 
        if (cList.stats.isBoss)
        {
            Immunity im = cList.stats.immunity;
            // Then Go through all immunities. 
           
            disarm.SetActive(!im.disarm);
            doomed.SetActive(true);
            immobilize.SetActive(!im.immobilize);
            invisible.SetActive(true);
            muddle.SetActive(!im.muddle);
            poison.SetActive(!im.poison);
            strengthen.SetActive(true);
            stun.SetActive(!im.stun);
            summon.SetActive(false);
            wound.SetActive(!im.wound);
        }
    }

    public void AddCondition(string condition)
    {
        switch (condition)
        {
            case "Disarm":
                creature.conditions.Add(Creature.Conditions.Disarm);
                break;
            case "Doomed":
                creature.conditions.Add(Creature.Conditions.Doomed);
                break;
            case "Immobilize":
                creature.conditions.Add(Creature.Conditions.Immobilize);
                break;
            case "Invisible":
                creature.conditions.Add(Creature.Conditions.Invisible);
                break;
            case "Muddle":
                creature.conditions.Add(Creature.Conditions.Muddle);
                break;
            case "Poison":
                creature.conditions.Add(Creature.Conditions.Poison);
                break;
            case "Strengthen":
                creature.conditions.Add(Creature.Conditions.Strengthen);
                break;
            case "Stun":
                creature.conditions.Add(Creature.Conditions.Stun);
                break;
            case "Summon":
                creature.conditions.Add(Creature.Conditions.Summon);
                break;
            case "Wound":
                creature.conditions.Add(Creature.Conditions.Wound);
                break;
        }
        //update the creature
        creature.healthBar.GetComponent<HealthBarController>().UpdateConditionPanel();
        gameController.CloseConditionPanel();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
