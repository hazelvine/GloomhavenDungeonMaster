using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiativeBarController : MonoBehaviour
{
    public int currentInitiative;
    public int currentIndex;

    public Transform container;
    public GameObject initiative;

    public List<GameObject> initiativeList;
    
    GameObject clone;
    GameController gameController;
    // Use this for initialization
    void Start()
    {
        currentInitiative = 0;

        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        initiativeList = new List<GameObject>();
    }

    public void NextRound()
    {
        InitClicked(0);
    }

    public void InitClicked(int index)
    {
        currentIndex = index;
        currentInitiative = initiativeList[index].GetComponent<InitiativeController>().initiative;

        for (int i = 0; i < initiativeList.Count; i++)
        {
            initiativeList[i].GetComponent<InitiativeController>().img.SetActive(false);
            if (i == index)
            {
                initiativeList[i].GetComponent<InitiativeController>().img.SetActive(true);
                // Send a message to the dispatcher to dispatch to the left page
                gameController.creatureDispatcher.DispatchMonsterToLeftPage(index);
            }
        }
    }
    
    public void UpdateInitiativeBar(List<CreatureList> activeCreatures)
    {
        // Delete any active clones.
        //var clones = GameObject.FindGameObjectsWithTag("InitiativeClone");
        foreach (GameObject clone in initiativeList)
        {
            DestroyImmediate(clone);
        }

        initiativeList.Clear();

        if (activeCreatures.Count == 0)
            return;

        // Rebuild the panel.
        for (int i = 0; i < activeCreatures.Count; i++)
        {
            clone = (GameObject)Instantiate(initiative, container);
            clone.GetComponent<InitiativeController>().creatureList = activeCreatures[i];
            // THIS IS WHERE I LEFT OFF. 
            if (gameController.round == 0)
            {
                clone.GetComponent<InitiativeController>().initiativeTxt.text = "?";
            }
            else
            {
                clone.GetComponent<InitiativeController>().initiativeTxt.text = activeCreatures[i].initiative.ToString();
            }
            clone.GetComponent<InitiativeController>().initiative = activeCreatures[i].initiative;
            clone.GetComponent<InitiativeController>().index = i;
            initiativeList.Add(clone);
            //clone.tag = "InitiativeClone";
            clone.name = i.ToString();
        }

        if(currentIndex >= activeCreatures.Count)
        {
            currentIndex = activeCreatures.Count - 1;
        }
        
        if(activeCreatures[currentIndex].initiative > currentInitiative)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = 0;
        }

        InitClicked(currentIndex);
    }
}
