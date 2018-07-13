using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPanel : MonoBehaviour {

    public ScalarController scalarController;
    GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    public void PushRoundLevel(int i)
    {
        scalarController.currentValue = i;
    }

    public void ResetRound()
    {
        scalarController.currentValue = 0;
    }
    // Update is called once per frame
    void Update()
    {
        gameController.round = scalarController.GetCurrentValue();
    }
}
