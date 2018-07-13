using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideToggle : MonoBehaviour {
    public bool visible;
    public Image img;
    public Sprite on;
    public Sprite off;

    public GameObject toggleObject;

	public void Onclick()
    {
        visible = !visible;
        Toggle();
    }

    public void Toggle()
    {
        if (visible)
        {
            img.sprite = on;
            toggleObject.SetActive(true);
        }
        else
        {
            img.sprite = off;
            toggleObject.SetActive(false);
        }
    }
}
