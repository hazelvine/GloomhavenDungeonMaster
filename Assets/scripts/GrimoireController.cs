using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimoireController : MonoBehaviour {

    public ScenarioNumController scenarioController;
    public MonsterPanelController monsterPanelController;

    private void OnEnable()
    {
        scenarioController.UpdatePanel();
        monsterPanelController.ShowMonsters();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
