using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

    public CreatureList creatureList;

	// Use this for initialization
	void Start () {
        creatureList = GameObject.Find("Game Controller").GetComponent<GameController>().monsterStatPanel.GetComponent<MonsterStatPanelController>().creatureList;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
