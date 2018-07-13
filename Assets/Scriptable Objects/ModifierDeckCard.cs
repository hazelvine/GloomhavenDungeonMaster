using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Deck Card", menuName = "Deck Card")]
public class ModifierDeckCard : ScriptableObject {
    public int num;
    public Sprite img;
    public bool shuffle;
    public bool remove;
    
}
