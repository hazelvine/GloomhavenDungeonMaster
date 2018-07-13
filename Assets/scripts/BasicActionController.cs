using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicActionController : MonoBehaviour {

    [Header("Modifier")]
    public int modifier;


    [Header("Core Asset")]
    public Text num;


    // Use this for initialization
    public void SetupCard()
    {
        num.text = modifier.ToString();
	}
	
}
