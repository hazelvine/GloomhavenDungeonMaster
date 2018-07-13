using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateElementController : MonoBehaviour {
    public enum State { Any, Light, Earth, Air, Fire, Frost, Night }
    
    public State element;

    [Header("Core Asset")]
    public Sprite[] sprite;
    public GameObject toElementImg;

    GameController gameController;
    string toElem;



    List<int> activeElements;

    private void Awake()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    // Use this for initialization
    void Start()
    {
        
        switch (element)
        {
            case State.Light:
                toElementImg.GetComponent<Image>().sprite = sprite[0];
                toElem = "Light";
                break;
            case State.Earth:
                toElementImg.GetComponent<Image>().sprite = sprite[1];
                toElem = "Earth";
                break;
            case State.Air:
                toElementImg.GetComponent<Image>().sprite = sprite[2];
                toElem = "Air";
                break;
            case State.Fire:
                toElementImg.GetComponent<Image>().sprite = sprite[3];
                toElem = "Fire";
                break;
            case State.Frost:
                toElementImg.GetComponent<Image>().sprite = sprite[4];
                toElem = "Frost";
                break;
            case State.Night:
                toElementImg.GetComponent<Image>().sprite = sprite[5];
                toElem = "Night";
                break;
            case State.Any:
                toElementImg.GetComponent<Image>().sprite = sprite[6];
                toElem = "Any";
                break;
        }
    }
    

    public void CreateElement()
    {
        gameController.roomInfusion.GetComponent<ElementController>().InfuseRoomWithElement(toElem);
    }
}
