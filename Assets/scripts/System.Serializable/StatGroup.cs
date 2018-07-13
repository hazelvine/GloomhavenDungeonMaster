using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class StatGroup
{
    public string type;
    public int health;
    public int move;
    public int attack;
    public int range;
    public int heal = 0;

    [Header("Conditions")]
    public bool poison = false;
    public bool muddle = false;
    public bool curse = false;
    public bool immobilize = false;
    public bool disarm = false;
    public bool wound = false;
    public bool stun = false;
    public bool advantage = false;
    public bool disadvantage = false;

    [Header("Pierce Settings")]
    public int pierce = 0;

    [Header("Shield Settings")]
    public int shield = 0;

    [Header("Multiple Targets Settings")]
    public int target = 0;

    [Header("Retaliate Settings")]
    public int retaliate = 0;
    public int retaliateRange = 0;
}
