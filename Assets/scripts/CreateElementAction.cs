using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateElementAction : MonoBehaviour {


    [Header("Core Asset")]
    public Sprite[] sprite;
    public Image img;
    public string toElem;

    GameController gameController;

    private void Awake()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }
        
    public void CreateElement(string element)
    {
        switch (element)
        {
            case "light":
                img.sprite = sprite[0];
                toElem = "Light";
                break;
            case "earth":
                img.sprite = sprite[1];
                toElem = "Earth";
                break;
            case "air":
                img.sprite = sprite[2];
                toElem = "Air";
                break;
            case "fire":
                img.sprite = sprite[3];
                toElem = "Fire";
                break;
            case "frost":
                img.sprite = sprite[4];
                toElem = "Frost";
                break;
            case "night":
                img.sprite = sprite[5];
                toElem = "Night";
                break;           
        }
    }
    
    public void InfuseRoom()
    {
        gameController.roomInfusion.GetComponent<ElementController>().InfuseRoomWithElement(toElem);
    }
}
