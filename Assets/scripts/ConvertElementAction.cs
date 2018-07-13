using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertElementAction : MonoBehaviour {
    public enum State { Any, Light, Earth, Air, Fire, Frost, Night, None }

    public State fromElement;
    public State toElement;

    [Header("Core Asset")]
    public Sprite[] sprite;
    public GameObject fromElementImg;
    public GameObject toElementImg;
    public GameObject healAction;
    public GameObject attackAction;
    public GameObject textAction;
    public GameObject buffAttack;
    public GameObject muddle;
    public GameObject muddleSelf;
    public GameObject target2;
    public GameObject target3;
    public GameObject invisibleSelf;
    public GameObject stun;
    public GameObject curseSelf;
    public GameObject woundAll;
    public GameObject disarmAll;
    public GameObject minusRange;
    public GameObject retaliate;
    public GameObject push1;
    public GameObject push2;
    public GameObject push4;
    public GameObject immobilize;
    public GameObject strenghten;

    GameController gameController;
    string fromElem;
    string toElem;



    List<int> activeElements;

    private void Awake()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        activeElements = new List<int>();
    }

    // Use this for initialization
    void Start () {
    }

    public void InsertAction(Line line)
    {
        switch (line.element)
        {
            case "light":
                fromElementImg.GetComponent<Image>().sprite = sprite[0];
                fromElem = "Light";
                break;
            case "earth":
                fromElementImg.GetComponent<Image>().sprite = sprite[1];
                fromElem = "Earth";
                break;
            case "air":
                fromElementImg.GetComponent<Image>().sprite = sprite[2];
                fromElem = "Air";
                break;
            case "fire":
                fromElementImg.GetComponent<Image>().sprite = sprite[3];
                fromElem = "Fire";
                break;
            case "frost":
                fromElementImg.GetComponent<Image>().sprite = sprite[4];
                fromElem = "Frost";
                break;
            case "night":
                fromElementImg.GetComponent<Image>().sprite = sprite[5];
                fromElem = "Night";
                break;
            case "any":
                fromElementImg.GetComponent<Image>().sprite = sprite[6];
                fromElem = "Any";
                break;
        }
        
        switch (line.action)
        {
            case "heal":
                healAction.SetActive(true);
                healAction.GetComponent<HealActionController>().healAmount = line.mod;
                healAction.GetComponent<HealActionController>().range = line.range;
                break;
            case "attack":
                attackAction.SetActive(true);
                attackAction.GetComponent<AttackActionController>().modifier = line.mod;
                attackAction.GetComponent<AttackActionController>().rangeModifier = line.range;
                attackAction.GetComponent<AttackActionController>().pierce = line.pierce;
                // Conditions
                attackAction.GetComponent<AttackActionController>().poison = line.poison;
                attackAction.GetComponent<AttackActionController>().muddle = line.muddle;
                attackAction.GetComponent<AttackActionController>().disarm = line.disarm;
                attackAction.GetComponent<AttackActionController>().stun = line.stun;
                attackAction.GetComponent<AttackActionController>().push = line.push;
                attackAction.GetComponent<AttackActionController>().pull = line.pull;
                attackAction.GetComponent<AttackActionController>().wound = line.wound;
                attackAction.GetComponent<AttackActionController>().targetModifier = line.target;
                attackAction.GetComponent<AttackActionController>().immobilize = line.immobilize;
                attackAction.GetComponent<AttackActionController>().SetupCard();
                break;
            case "attackBuff":
                buffAttack.SetActive(true);
                buffAttack.GetComponent<BuffAttackActionController>().modifier = line.mod;
                buffAttack.GetComponent<BuffAttackActionController>().rangeModifier = line.range;
                buffAttack.GetComponent<BuffAttackActionController>().pierce = line.pierce;
                // Conditions
                buffAttack.GetComponent<BuffAttackActionController>().poison = line.poison;
                buffAttack.GetComponent<BuffAttackActionController>().muddle = line.muddle;
                buffAttack.GetComponent<BuffAttackActionController>().disarm = line.disarm;
                buffAttack.GetComponent<BuffAttackActionController>().stun = line.stun;
                buffAttack.GetComponent<BuffAttackActionController>().push = line.push;
                buffAttack.GetComponent<BuffAttackActionController>().pull = line.pull;
                buffAttack.GetComponent<BuffAttackActionController>().wound = line.wound;
                buffAttack.GetComponent<BuffAttackActionController>().targetModifier = line.target;
                buffAttack.GetComponent<BuffAttackActionController>().immobilize = line.immobilize;
                buffAttack.GetComponent<BuffAttackActionController>().SetupCard();
                break;
            case "muddle":
                // show muddle.
                muddle.SetActive(true);
                break;
            case "muddleSelf":
                muddleSelf.SetActive(true);
                break;
            case "target2":
                target2.SetActive(true);
                break;
            case "target3":
                target3.SetActive(true);
                break;
            case "invisibleSelf":
                invisibleSelf.SetActive(true);
                break;
            case "stun":
                stun.SetActive(true);
                break;
            case "strengthen":
                strenghten.SetActive(true);
                break;
            case "curseSelf":
                curseSelf.SetActive(true);
                break;
            case "woundAll":
                woundAll.SetActive(true);
                break;
            case "disarmAll":
                disarmAll.SetActive(true);
                break;
            case "minusRange":
                minusRange.SetActive(true);
                break;
            case "retaliate":
                retaliate.SetActive(true);
                break;
            case "push1":
                push1.SetActive(true);
                break;
            case "push2":
                push2.SetActive(true);
                break;
            case "push4":push4.SetActive(true);
                break;
            case "immobilize":
                immobilize.SetActive(true);
                break;
           
            case "text":
                textAction.SetActive(true);
                textAction.GetComponent<Text>().text = line.label;
                break;
            case "element":
                toElementImg.SetActive(true);
                switch (line.toElement)
                {
                    case "light":
                        toElementImg.GetComponent<Image>().sprite = sprite[0];
                        toElem = "Light";
                        break;
                    case "earth":
                        toElementImg.GetComponent<Image>().sprite = sprite[1];
                        toElem = "Earth";
                        break;
                    case "air":
                        toElementImg.GetComponent<Image>().sprite = sprite[2];
                        toElem = "Air";
                        break;
                    case "fire":
                        toElementImg.GetComponent<Image>().sprite = sprite[3];
                        toElem = "Fire";
                        break;
                    case "frost":
                        toElementImg.GetComponent<Image>().sprite = sprite[4];
                        toElem = "Frost";
                        break;
                    case "night":
                        toElementImg.GetComponent<Image>().sprite = sprite[5];
                        toElem = "Night";
                        break;
                    case "any":
                        toElementImg.GetComponent<Image>().sprite = sprite[6];
                        toElem = "Any";
                        break;
                }
                break;
        }
    }

    public void DestroyElement()
    {
        switch (fromElem)
        {
            case "Light":
                gameController.roomInfusion.GetComponent<ElementController>().LightClick();
                break;
            case "Earth":
                gameController.roomInfusion.GetComponent<ElementController>().EarthClick();
                break;
            case "Air":
                gameController.roomInfusion.GetComponent<ElementController>().AirClick();
                break;
            case "Fire":
                gameController.roomInfusion.GetComponent<ElementController>().FireClick();
                break;
            case "Frost":
                gameController.roomInfusion.GetComponent<ElementController>().FrostClick();
                break;
            case "Night":
                gameController.roomInfusion.GetComponent<ElementController>().NightClick();
                break;
            case "Any":
                // Grab any of the active elements.          

                activeElements.Clear();

                for (int i = 0; i < gameController.roomInfusion.GetComponent<ElementController>().elementState.Length; i++)
                {
                    if(gameController.roomInfusion.GetComponent<ElementController>().elementState[i] > 0)
                        activeElements.Add(i);
                }

                Debug.Log("Total elements: " +activeElements.Count);
                for (int i = 0; i < activeElements.Count; i++)
                {
                    Debug.Log("Element " + i + " :" + activeElements[i]);
                }
                if (activeElements.Count == 0)
                    return;

                string s = ReturnElement(activeElements[Random.Range(0, activeElements.Count)]);
                Debug.Log(s);
                switch (s)
                    {
                    case "Light":
                        gameController.roomInfusion.GetComponent<ElementController>().LightClick();
                        break;
                    case "Earth":
                        gameController.roomInfusion.GetComponent<ElementController>().EarthClick();
                        break;
                    case "Air":
                        gameController.roomInfusion.GetComponent<ElementController>().AirClick();
                        break;
                    case "Fire":
                        gameController.roomInfusion.GetComponent<ElementController>().FireClick();
                        break;
                    case "Frost":
                        gameController.roomInfusion.GetComponent<ElementController>().FrostClick();
                        break;
                    case "Night":
                        gameController.roomInfusion.GetComponent<ElementController>().NightClick();
                        break;
                }
                
                break;
        }
    }

    private string ReturnElement(int x)
    {
        switch (x)
        {
            case 0:
                return "Light";
            case 1:
                return "Earth";
            case 2:
                return "Air";
            case 3:
                return "Fire";
            case 4:
                return "Frost";
            case 5:
                return "Night";
        }
        return "null";
    }

    public void InfuseRoom()
    {
        gameController.roomInfusion.GetComponent<ElementController>().InfuseRoomWithElement(toElem);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
