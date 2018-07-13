using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour {
    public enum Type { Attack, Range, Heal, Condition, ConvertElement, ConvertElementToAction, Shield, Loot, StaticText}

    public Type type;
    public int modifier;
    public string special;
}
