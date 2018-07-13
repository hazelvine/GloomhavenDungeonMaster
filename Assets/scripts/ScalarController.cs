using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalarController : MonoBehaviour {

    public int currentValue;
    public int startValue;
    public int minValue;
    public int maxValue;

    public Text label;   

	// Use this for initialization
	void Start () {
	}

    public void ResetCount()
    {
        currentValue = startValue;
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
    public void GreaterIncreaseCount()
    {
        currentValue += 10;
        if (currentValue > maxValue)
            currentValue = maxValue;
    }

    public void IncreaseCount()
    {
        currentValue++;
        if (currentValue > maxValue)
            currentValue = maxValue;
    }

    public void DecreaseCount()
    {
        currentValue--;
        if (currentValue < minValue)
            currentValue = minValue;
    }

    public void GreaterDecreaseCount()
    {
        currentValue -= 10;
        if (currentValue < minValue)
            currentValue = minValue;
    }
	
	// Update is called once per frame
	void Update () {
        if(currentValue < 10)
        {
            label.text = "0" + currentValue.ToString();
        }
        else
        {
            label.text = currentValue.ToString();
        }                
    }
}
