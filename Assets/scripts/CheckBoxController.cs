using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxController : MonoBehaviour {

    public bool selected;
    public GameObject skull;

    public void Start()
    {
        UpdateBox(selected);
    }

    public void Click()
    {
        selected = !selected;
        UpdateBox(selected);
    }
	
    public void UpdateBox(bool sel)
    {
        selected = sel;
        skull.SetActive(selected);
    }
}
