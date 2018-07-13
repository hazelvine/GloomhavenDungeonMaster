using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AreYouSurePanel : MonoBehaviour {

    public GameObject panel;
	// Use this for initialization
	void Start () {
		
	}
	
    public void QuitClick()
    {
        Application.Quit();
    }

    public void CancelClick()
    {
        panel.SetActive(false);
    }
}
