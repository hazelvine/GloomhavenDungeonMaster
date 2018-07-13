using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// We have to tell unity that this IS serializable.
[System.Serializable]
public class MonsterStats
{
    public string name;
    public bool isBoss = false;
    public bool isNPC = false;
    public bool canFly = false;
    public Immunity immunity;
    public Level[] level; // cause it has to match the json file. that's why it's cap. 
}