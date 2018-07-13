using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Creature 1", menuName = "Creature")]
public class Creature : ScriptableObject
{
    public enum Status { Dead, Normal, Elite };
    public enum Conditions { Summon, Doomed, Poison, Disarm, Stun, Wound, Immobilize, Muddle, Strengthen, Invisible, Push, Pull, Curse, Bless };    

    [Header("In-Game Stats")]
    public Status status; // 0 Dead, 1 Normal / Boss, 2 Elite
    public GameObject healthBar;
    public int maxHealth = 0;

    [Header("Conditions")]
    public List<Conditions> conditions;

    public void ClearConditions()
    {
        conditions.Clear();
    }
}
