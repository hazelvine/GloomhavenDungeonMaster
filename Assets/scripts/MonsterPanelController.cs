using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPanelController : MonoBehaviour {

    public GameObject monster;
    public Transform container;
    public CreatureDispatcher creatureDispatcher;
    public ScenarioDispatcher scenarioDispatcher;
    public GameController gameController;
    public List<GameObject> monsterList;
    // Use this for initialization
    void Start () {
        monsterList = new List<GameObject>();
        for (int i = 0; i < creatureDispatcher.creatureList.Length; i++)
        {            
            monster = (GameObject)Instantiate(monster, container);
            monster.GetComponent<MonsterController>().img.sprite = creatureDispatcher.creatureList[i].thumbnail;
            monster.GetComponent<MonsterController>().txt.text = creatureDispatcher.creatureList[i].name;
            monster.GetComponent<MonsterController>().creatureList = creatureDispatcher.creatureList[i];
            monster.name = creatureDispatcher.creatureList[i].name;
            monsterList.Add(monster);
        }
        ShowMonsters();
    }
	
    public void ShowMonsters()
    {
        foreach (GameObject monster in monsterList)
        {
            monster.SetActive(false);
            
            foreach (string name in scenarioDispatcher.scenario[gameController.scenarioNum].monsterList)
            {
                if (monster.name == name)
                    monster.SetActive(true);

                if (name == "All" && !monster.GetComponent<MonsterController>().creatureList.stats.isNPC)
                    monster.SetActive(true);                    
            }            
        }
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
