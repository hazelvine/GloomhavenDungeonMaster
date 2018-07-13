using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarController : MonoBehaviour {

   // public Text scenarioLabel;
    public Text charLabel;
    public Text scenarioLevel;
    public Text round;

    GameController gameController;
    

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        charLabel.text = gameController.GetNumberOfCharacters();
        scenarioLevel.text = gameController.GetScenarioLevel();
        round.text = gameController.GetRound();
	}

    public void NextRound()
    {
        gameController.round++;
        gameController.roomInfusion.GetComponent<ElementController>().ReduceAllElements();
        if(gameController.AttackModifier.GetComponent<ModifierDeckController>().shuffleAppeared)
        {
            gameController.AttackModifier.GetComponent<ModifierDeckController>().ResetDeck();
        }
        gameController.creatureDispatcher.NewRound();
    }

    public void ResetRound()
    {
        gameController.round = 0;
    }
}
