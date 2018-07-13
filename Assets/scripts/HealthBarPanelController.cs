using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPanelController : MonoBehaviour {

    public GameObject healthBar;
    public Transform container;
    public GameObject Container;

    GameObject clone;

    //GameController gameController;
    CreatureDispatcher creatureDispatcher;

	// Use this for initialization
	void Start () {
        //gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        creatureDispatcher = GameObject.Find("Creature Dispatcher").GetComponent<CreatureDispatcher>();
        //clone = new GameObject(); 

        for (int i = 0; i < creatureDispatcher.creatureList.Length; i++)
        {            
            for (int j = 0; j < creatureDispatcher.creatureList[i].creature.Length; j++)
            {
                clone = (GameObject)Instantiate(healthBar, container);
                clone.GetComponent<HealthBarController>().SetupHealthBar(creatureDispatcher.creatureList[i], creatureDispatcher.creatureList[i].creature[j], j);
                creatureDispatcher.creatureList[i].creature[j].healthBar = clone;
                clone.SetActive(false);
                clone.name = creatureDispatcher.creatureList[i].name + " " + (j + 1).ToString();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
