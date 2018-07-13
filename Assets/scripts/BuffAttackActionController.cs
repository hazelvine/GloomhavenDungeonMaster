using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffAttackActionController : MonoBehaviour {

    [Header("Modifier")]
    public int modifier = 0;
    public bool staticModifier = false;
    public bool rangedAttack = false;
    public int rangeModifier = 0;
    public bool staticRange = false;
    public int targetModifier = 0;
    [Header("Conditions")]
    public bool poison = false;
    public int pierce = 0;
    public bool immobilize = false;
    public bool muddle = false;
    public int push = 0;
    public int pull = 0;
    public bool disarm = false;
    public bool stun = false;
    public bool wound = false;

    [Header("Core Assets")]
    public Text attackNum;
    public GameObject range;
    public GameObject rangeNum;
    public GameObject multipleTarget;
    public GameObject multipleTargetNum;
    public GameObject poisonGO;
    public GameObject pierceGO;
    public GameObject pierceNumGO;
    public GameObject immobilizeGO;
    public GameObject muddleGO;
    public GameObject pushGO;
    public GameObject pullGO;
    public GameObject disarmGO;
    public GameObject stunGO;
    public GameObject woundGO;
    public GameObject pushTxtGO;
    public GameObject pullTxtGO;

    public void SetupCard()
    {
        if(modifier > 0)
        {
            attackNum.text = "+" + modifier.ToString();
        }else if(modifier < 0)
        {
            attackNum.text = "-" + modifier.ToString();
        }
        
        // Range
        if (rangeModifier > 0)
        {
            range.SetActive(true);
            rangeNum.SetActive(true);
            rangeNum.GetComponent<Text>().text = "+" + rangeModifier.ToString();
        }
        else if(rangeModifier < 0)
        {
            range.SetActive(true);
            rangeNum.SetActive(true);
            rangeNum.GetComponent<Text>().text = "-" + rangeModifier.ToString();
        }
        else if (rangeModifier == 0 )
        {
            range.SetActive(false);
            rangeNum.SetActive(false);
        }

        // Target
        if (targetModifier > 0)
        {
            multipleTarget.SetActive(true);
            multipleTargetNum.SetActive(true);
            multipleTargetNum.GetComponent<Text>().text = targetModifier.ToString();
        }
        else
        {
            multipleTarget.SetActive(false);
            multipleTargetNum.SetActive(false);
        }

        // Conditions
        poisonGO.SetActive(poison);

        // Pierce
        if (pierce > 0)
        {
            pierceGO.SetActive(true);
            pierceNumGO.SetActive(true);
            pierceNumGO.GetComponent<Text>().text = pierce.ToString() + " ";
        }
        else
        {
            pierceGO.SetActive(false);
            pierceNumGO.SetActive(false);
        }

        immobilizeGO.SetActive(immobilize);
        muddleGO.SetActive(muddle);

        if (push > 0)
        {
            pushGO.SetActive(true);
            pushTxtGO.SetActive(true);
            pushTxtGO.GetComponent<Text>().text = push.ToString() + " ";
        }
        else
        {
            pushGO.SetActive(false);
            pushTxtGO.SetActive(false);
        }
        if (pull > 0)
        {
            pullGO.SetActive(true);
            pullTxtGO.SetActive(true);
            pullTxtGO.GetComponent<Text>().text = pull.ToString() + " ";
        }
        else
        {
            pullGO.SetActive(false);
            pullTxtGO.SetActive(false);
        }

        disarmGO.SetActive(disarm);
        stunGO.SetActive(stun);
        woundGO.SetActive(wound);
    }
}
