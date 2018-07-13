using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Immunity
{
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
    public bool push = false;
    public bool pull = false;
}