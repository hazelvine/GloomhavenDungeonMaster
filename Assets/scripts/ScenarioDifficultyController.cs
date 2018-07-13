using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioDifficultyController : MonoBehaviour {

    public int currentValue;
    public int minValue;
    public int maxValue;

    public Text label;

    private void Start()
    {
        UpdateText();
    }

    public int GetCurrentValue()
    {
        return currentValue;
    }

    public void SetValue(int i)
    {
        if (i > maxValue)
            i = maxValue;
        if (i < minValue)
            i = minValue;
        currentValue = i;
    }

    public void IncreaseCount()
    {
        currentValue++;
        if (currentValue > maxValue)
            currentValue = maxValue;

        UpdateText();
    }

    public void DecreaseCount()
    {
        currentValue--;
        if (currentValue < minValue)
            currentValue = minValue;

        UpdateText();
    }

    public void UpdateText()
    {
        string tempS = "";

        switch (currentValue)
        {
            case -1:
                tempS = "Easy";
                break;
            case 0:
                tempS = "Normal";
                break;
            case 1:
                tempS = "Hard";
                break;
            case 2:
                tempS = "Very Hard";
                break;
        }

        label.text = tempS;
    }   
}