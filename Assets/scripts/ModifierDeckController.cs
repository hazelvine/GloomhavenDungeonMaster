using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModifierDeckController : MonoBehaviour {
    [Header("To decide whether or not it needs to be reshuffled")]
    public bool shuffleAppeared;

    public Button BlessingBtn;
    public Button CurseBtn;

    public Image mainRoll;
    public Image badRoll;

    public Text curseCount;
    public Text blessingCount;
    public Text cardsLeft;
    [Header("In-game Generated Deck")]
    public List<ModifierDeckCard> deck = new List<ModifierDeckCard>();

    [Header("Core Deck")]
    public ModifierDeckCard[] baseDeck;
    [Header("Extra Deck Pieces")]
    public ModifierDeckCard curseCard;
    public ModifierDeckCard blessingCard;
    public ModifierDeckCard drawDeckCard;
    public ModifierDeckCard blankCard;

    private int blessings;
    private int curses;

    private int MaxBlessings = 10;
    private int MaxCurses = 10;

    public void DrawCard()
    {
        if (deck.Count == 0)
        {
            ResetDeck();
        }

        badRoll.sprite = mainRoll.sprite;
        mainRoll.sprite = deck[0].img;

        if (deck[0].remove)
        {
            if (deck[0].num == 3)
            {
                // tis a blessing.
                blessings--;
                if (blessings < 0)
                    blessings = 0;
            }
            else if(deck[0].num == -3)
            {
                // tis a curse!
                curses--;
                if (curses < 0)
                    curses = 0;
            }
        }

        // Check if deck needs to be shuffled. 
        if (deck[0].shuffle)
        {
            shuffleAppeared = true;
        }

        deck.RemoveAt(0);
        
        
        
    }

    public void AddCurse()
    {
        // Add a curse
        curses++;
        deck.Add(curseCard);
        // shuffle the current deck.
        Shuffle(deck);
    }

    public void AddBlessing()
    {
        // Add a blessing
        blessings++;
        deck.Add(blessingCard);
        // shuffle the current deck.
        Shuffle(deck);
    }

    public void ResetDeck()
    {
        mainRoll.sprite = drawDeckCard.img;
        badRoll.sprite = blankCard.img;
        deck.Clear();
        shuffleAppeared = false;

        foreach (ModifierDeckCard card in baseDeck)
        {
            deck.Add(card);
        }

        // Add Curses
        for (int i = 0; i < curses; i++)
        {
            deck.Add(curseCard);
        }

        // Add Blessings
        for (int j = 0; j < blessings; j++)
        {
            deck.Add(blessingCard);
        }

        Shuffle(deck);
    }

    public void FullReset()
    {
        curses = 0;
        blessings = 0;
        mainRoll.sprite = drawDeckCard.img;
        badRoll.sprite = blankCard.img;
        ResetDeck();
    }
    
    private static List<ModifierDeckCard> Shuffle(List<ModifierDeckCard> aList)
    {
        System.Random _random = new System.Random();

        ModifierDeckCard myGO;

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

    // Use this for initialization
    void Start () {
        curses = 0;
        blessings = 0;
        ResetDeck();		
	}
	
	// Update is called once per frame
	void Update () {
        curseCount.text = (MaxCurses-curses).ToString();
        blessingCount.text = (MaxBlessings-blessings).ToString();
        cardsLeft.text = deck.Count.ToString();
        if(curses >= MaxCurses)
        {
            // disable the button
            CurseBtn.enabled = false;
        }
        else
        {
            // enable the button
            CurseBtn.enabled = true;
        }

        if (blessings >= MaxBlessings)
        {
            // disable the button
            BlessingBtn.enabled = false;
        }
        else
        {
            // enable the button
            BlessingBtn.enabled = true;
        }
	}
}
