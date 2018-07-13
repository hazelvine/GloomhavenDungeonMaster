using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour {
    public Text txt;
    public Image img;
    public CreatureList creatureList;

    GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    public void OnClick()
    {
        gameController.ShowMonsterListPanel();
        gameController.monsterListPanel.GetComponent<MonsterListPanelController>().SetMonsterList(creatureList);
    }
}
