using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Creature List", menuName = "Creature List")]
public class CreatureList : ScriptableObject {
    public enum Immunity { Summon, Doomed, Poison, Disarm, Stun, Wound, Immobilize, Muddle, Strengthen, Invisible, Push, Pull, Curse, Bless };

    [Header("Global Stats")]
    public int initiative;
    public int creatureLevel;

    [Header("Images")]
    public Sprite image;
    public Sprite thumbnail;
    public string dbStatPath;

    [Header("Creature AI Deck")]
    public string DeckType;
    public Deck deck;
    //public DeckType deck;
    public List<Cards> creatureDeck = new List<Cards>();

    [Header("Creature Count")]
    public Creature[] creature;
    
    public MonsterStats stats;

    public void linkStats()
    {
       foreach (MonsterStats creature in GameObject.Find("Creature Dispatcher").GetComponent<CreatureDispatcher>().creatures)
        {
            if(creature.name == this.name)
            {
                stats = creature;
            }
        }        
    }

    public void shuffleDeck()
    {
        creatureDeck.Clear();
        for (int i = 0; i < deck.cards.Length; i++)
        {
            creatureDeck.Add(deck.cards[i]);
        }
        Shuffle(creatureDeck);
        UpdateInitiative(creatureDeck[0].initiative);
    }

    public void DiscardCard()
    {
        if (creatureDeck[0].shuffle)
        {
            shuffleDeck();
        }
        else
        {
            creatureDeck.RemoveAt(0);
        }
        UpdateInitiative(creatureDeck[0].initiative);
    }

    void UpdateInitiative(int x)
    {
        initiative = x;
    }

    private static List<Cards> Shuffle(List<Cards> aList)
    {
        System.Random _random = new System.Random();

        Cards myGO;

        int n = aList.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }

        return aList;
    }
}
