using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioNumController : MonoBehaviour
{
    public ScalarController scalarController;
    public Text scenarioName;
    public GameController gameController;


    // Use this for initialization
    void OnEnable()
    {
        scalarController.minValue = 0;
        scalarController.maxValue = 95;
        UpdateText();
    }

    // Update is called once per frame
    public void UpdateScenarioName()
    {
        // Gotta take the +1 into consideration given the -1 scenario. 
        gameController.scenarioNum = scalarController.currentValue;
        UpdateText();
    }

    public void UpdatePanel()
    {
        scalarController.currentValue = gameController.scenarioNum;
        UpdateText();
    }

    void UpdateText()
    {
        //Debug.Log(gameController.scenarioNum);
        //Debug.Log(gameController.scenarioDispatcher.scenario.Length);
        //Debug.Log(gameController.scenarioDispatcher.scenario[0].name);
        scenarioName.text = "Total: ";
        scenarioName.text += gameController.scenarioDispatcher.scenario.Length.ToString();
        scenarioName.text = gameController.scenarioDispatcher.scenario[gameController.scenarioNum].name;
    }

}
