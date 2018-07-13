using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetaliateActionController : MonoBehaviour {
    [Header("Modifier")]
    public int retAmount;
    public int range;

    [Header("Core Asset")]
    public Text retaliateNum;
    public GameObject rangeImg;
    public GameObject rangeNum;
    // Use this for initialization
    void Start()
    {
        retaliateNum.text = retAmount.ToString();
        if (range > 0)
        {
            rangeImg.SetActive(true);
            rangeNum.SetActive(true);
            rangeNum.GetComponent<Text>().text = range.ToString();
        }
        else
        {
            rangeImg.SetActive(false);
            rangeNum.SetActive(false);
        }
    }
}
