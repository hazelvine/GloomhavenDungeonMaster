using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementController : MonoBehaviour {
    public Image lightElement;
    public Image earthElement;
    public Image airElement;
    public Image fireElement;
    public Image frostElement;
    public Image nightElement;

    public Sprite[] lightState;
    public Sprite[] earthState;
    public Sprite[] airState;
    public Sprite[] fireState;
    public Sprite[] frostState;
    public Sprite[] nightState;

    public int[] elementState = new int[6];

    public GameObject frostAnimation;
    public GameObject fireAnimation;
    public GameObject lightAnimation;
    public GameObject nightAnimation;
    public GameObject airAnimation;
    public GameObject earthAnimation;

	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < elementState.Length; i++)
        {
            elementState[i] = 0;
        }
        SetElementInert("All");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        Debug.Log("CLICK!");
    }

    public void InfuseRoomWithElement(string element)
    {
        switch (element)
        {
            case "Light":
                elementState[0] = 2;
                break;
            case "Earth":
                elementState[1] = 2;
                break;
            case "Air":
                elementState[2] = 2;
                break;
            case "Fire":
                elementState[3] = 2;
                break;
            case "Frost":
                elementState[4] = 2;
                break;
            case "Night":
                elementState[5] = 2;
                break;
        }
        UpdateSprites();
    }

    public void SetElementInert(string element)
    {
        switch (element)
        {
            case "Light":
                elementState[0] = 0;
                break;
            case "Earth":
                elementState[1] = 0;
                break;
            case "Air":
                elementState[2] = 0;
                break;
            case "Fire":
                elementState[3] = 0;
                break;
            case "Frost":
                elementState[4] = 0;
                break;
            case "Night":
                elementState[5] = 0;
                break;
            case "All":
                elementState[0] = 0;                
                elementState[1] = 0;                
                elementState[2] = 0;                
                elementState[3] = 0;                
                elementState[4] = 0;                
                elementState[5] = 0;
                break;
        }
        UpdateSprites();
    }

    public void SetElementWeak(string element)
    {
        switch (element)
        {
            case "Light":
                elementState[0] = 1;
                break;
            case "Earth":
                elementState[1] = 1;
                break;
            case "Air":
                elementState[2] = 1;
                break;
            case "Fire":
                elementState[3] = 1;
                break;
            case "Frost":
                elementState[4] = 1;
                break;
            case "Night":
                elementState[5] = 1;
                break;
            case "All":
                elementState[0] = 1;
                elementState[1] = 1;
                elementState[2] = 1;
                elementState[3] = 1;
                elementState[4] = 1;
                elementState[5] = 1;
                break;
        }
        UpdateSprites();
    }

    public void UpdateSprites()
    {
        lightElement.sprite = lightState[elementState[0]];
        earthElement.sprite = earthState[elementState[1]];
        airElement.sprite = airState[elementState[2]];
        fireElement.sprite = fireState[elementState[3]];
        frostElement.sprite = frostState[elementState[4]];
        nightElement.sprite = nightState[elementState[5]];
    }

    public void ReduceAllElements()
    {
        for (int i = 0; i < elementState.Length; i++)
        {
            if (elementState[i] > 0)
            {
                elementState[i]--;
            }            
        }
        UpdateSprites();
    }

    public void FrostClick()
    {
        if(elementState[4] > 0)
        {
            frostAnimation.SetActive(true);
            frostAnimation.GetComponent<Animator>().Play(0);
            SetElementInert("Frost");
        }
    }

    public void FireClick()
    {
        if (elementState[3] > 0)
        {
            fireAnimation.SetActive(true);
            fireAnimation.GetComponent<Animator>().Play(0);
            SetElementInert("Fire");
        }
    }

    public void LightClick()
    {
        if (elementState[0] > 0)
        {
            lightAnimation.SetActive(true);
            lightAnimation.GetComponent<Animator>().Play(0);
            SetElementInert("Light");
        }
    }

    public void NightClick()
    {
        if (elementState[5] > 0)
        {
            nightAnimation.SetActive(true);
            nightAnimation.GetComponent<Animator>().Play(0);
            SetElementInert("Night");
        }
    }

    public void EarthClick()
    {
        if (elementState[1] > 0)
        {
            earthAnimation.SetActive(true);
            earthAnimation.GetComponent<Animator>().Play(0);
            SetElementInert("Earth");
        }
    }

    public void AirClick()
    {
        if (elementState[2] > 0)
        {
            airAnimation.SetActive(true);
            airAnimation.GetComponent<Animator>().Play(0);
            SetElementInert("Air");
        }
    }
}
