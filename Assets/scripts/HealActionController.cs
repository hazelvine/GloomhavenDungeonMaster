using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealActionController : MonoBehaviour {
    [Header("Modifier")]
    public int healAmount;
    public int range;

    [Header("Core Asset")]
    public Text healNum;
    public GameObject rangeImg;
    public GameObject rangeNum;
    public GameObject self;
	// Use this for initialization
	void Start () {
        healNum.text = healAmount.ToString();
		if(range > 0)
        {
            rangeImg.SetActive(true);
            rangeNum.SetActive(true);
            self.SetActive(false);
            rangeNum.GetComponent<Text>().text = range.ToString();
        }
        else if(range < 0)
        {
            rangeImg.SetActive(false);
            rangeNum.SetActive(false);
            self.SetActive(false);
        }
        else
        {
            rangeImg.SetActive(false);
            rangeNum.SetActive(false);
            self.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
