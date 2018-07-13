using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMarkController : MonoBehaviour {
    public bool isChecked;
    public GameObject skull;

    public void UpdateCheckBox()
    {
        skull.SetActive(isChecked);
    }
}
