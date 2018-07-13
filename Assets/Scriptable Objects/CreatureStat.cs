using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureStats", menuName = "Creature Stats")]
public class CreatureStat : ScriptableObject {
    public enum Conditions { Summon, Doomed, Poison, Disarm, Stun, Wound, Immobilize, Muddle, Strenghten, Invisible, Push, Pull, Curse, Bless };

    [Header("Basic Settings")]
    public int health = 0;
    public int movement = 0;
   
    [Header("Attack Specials")]
    public int attack = 0;
    public int range = 0;
    public bool poison = false;
    public bool muddle = false;
    public bool curse = false;
    public bool immobolize = false;
    public bool disarm = false;
    public bool wound = false;
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
    
    [Header("Boss Settings")]
    public Sprite specialAbilities;
}
