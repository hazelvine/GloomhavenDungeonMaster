using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiativeController : MonoBehaviour {
    
    [Header("Variables")]
    public CreatureList creatureList;
    public int index;
    public int initiative;

    [Header("UI")]
    public GameObject img;
    public Text initiativeTxt;

    GameController gameController;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();               
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        // gameController.in
        gameController.initiativeBar.GetComponent<InitiativeBarController>().InitClicked(index);
    }
}
