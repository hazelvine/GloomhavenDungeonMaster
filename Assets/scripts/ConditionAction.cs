using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionAction : MonoBehaviour {

    [Header("Modifier")]
    public int modifier;
    public bool poison = false;


    [Header("Core Assets")]
    public Text title;
    public GameObject numTxt;
    public GameObject poisonIcon;

    public void SetupCard()
    {
        poisonIcon.SetActive(poison);
        if (modifier > 0)
        {
            numTxt.GetComponent<Text>().text = modifier.ToString();
            numTxt.SetActive(true);
        }
        else
        {
            numTxt.SetActive(false);
        }
    }
}
