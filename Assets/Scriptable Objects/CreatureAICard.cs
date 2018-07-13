using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "card", menuName = "AI: Card")]
public class CreatureAICard : ScriptableObject {
    public int initiative;
    public bool shuffle;
    public GameObject card;
}
