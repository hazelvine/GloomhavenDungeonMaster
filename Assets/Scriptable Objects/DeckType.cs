using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AI Deck", menuName = "AI: Deck")]
public class DeckType : ScriptableObject {    
    public CreatureAICard[] cards;
}
