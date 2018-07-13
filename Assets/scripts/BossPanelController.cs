using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossPanelController : MonoBehaviour {

    public GameObject boss;
    public Transform container;
    public CreatureDispatcher creatureDispatcher;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < creatureDispatcher.creatureList.Length; i++)
        {
            if (creatureDispatcher.creatureList[i].stats.isBoss)
            {
                boss = (GameObject)Instantiate(boss, container);
                boss.GetComponent<BossController>().txt.text = creatureDispatcher.creatureList[i].name;
                boss.GetComponent<BossController>().creatureList = creatureDispatcher.creatureList[i];
                boss.name = creatureDispatcher.creatureList[i].name;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
