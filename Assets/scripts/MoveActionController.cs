using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveActionController : MonoBehaviour {
    
    public enum Move { Walk, Jump, Fly}

    [Header("Modifier")]
    public Move moveState = Move.Walk;
    public int modifier = 0;    

    [Header("Core Content")]
    public Text num;
    public GameObject flyImg;
    public GameObject walkImg;
    public GameObject jumpImg;

    public void SetupCard()
    {
        switch (moveState)
        {
            case Move.Walk:                
                walkImg.SetActive(true);
                jumpImg.SetActive(false);
                flyImg.SetActive(false);
                break;
            case Move.Jump:
                walkImg.SetActive(true);
                jumpImg.SetActive(true);
                flyImg.SetActive(false);
                break;
            case Move.Fly:
                walkImg.SetActive(false);
                jumpImg.SetActive(false);
                flyImg.SetActive(true);
                break;
        }
            
        num.text = modifier.ToString();
    }
}
