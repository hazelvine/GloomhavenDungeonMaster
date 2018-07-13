using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreatureDispatcher : MonoBehaviour
{


    public CreatureList[] creatureList;
    public GameObject[] cardList;
    public List<MonsterStats> creatures;
    public List<CreatureList> activeCreatures;

    public DeckDB deckDB;
    string path;
    string jsonString;

    public GameController gameController;

    private void Start()
    {
        // Path to json File and we want the path to a certain file. 
        //  path = Application.streamingAssetsPath + "/Deck.json";
        // Now we want to bring it into Unity. 
        jsonString = LoadResourceTextfile("deck.json");

        // FromJson - We pass it the creature type so the from json it knows what to map it to. 
        // Creature test - so it knows what it's working with (db)
        deckDB = JsonUtility.FromJson<DeckDB>(jsonString);

        // THEN REPEAT
        for (int i = 0; i < creatureList.Length; i++)
        {
            // Path to json File and we want the path to a certain file. 
            //path = Application.streamingAssetsPath + creatureList[i].dbStatPath;
            // Now we want to bring it into Unity. 
            // jsonString = File.ReadAllText(path);
            jsonString = LoadResourceTextfile(creatureList[i].dbStatPath);

            // FromJson - We pass it the creature type so the from json it knows what to map it to. 
            // Creature test - so it knows what it's working with (db)
            MonsterStats mStat = JsonUtility.FromJson<MonsterStats>(jsonString);
            creatureList[i].creatureLevel = -1;
            creatureList[i].stats = mStat;
            //Debug.Log("creature decktype : " + creatureList[i].DeckType);
            foreach (Deck deck in deckDB.deck)
            {
                if (deck.name == creatureList[i].DeckType)
                {
                    //Debug.Log("Creature name: " + deck.name + ", creature decktype : " + creatureList[i].DeckType);
                    creatureList[i].deck = deck;
                }
            }
        }
        activeCreatures = new List<CreatureList>();

        ResetAllMonsters();
    }

    public static string LoadResourceTextfile(string path)
    {

        string filePath = Application.streamingAssetsPath + "/" + path;

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }

            return reader.text;
        }
        else
        {
            return System.IO.File.ReadAllText(filePath); ;
        }
    }

    public void OverrideMonsterLevels(int level)
    {
        if (gameController.isFivePlayers)
        {
            level += 2;
            if (level > 7)
                level = 7;
        }
        else if (gameController.isSolo)
        {
            level++;
        }

        for (int i = 0; i < creatureList.Length; i++)
        {
            creatureList[i].creatureLevel = level;
        }
    }

    public void ResetAllMonsters()
    {
        for (int i = 0; i < creatureList.Length; i++)
        {
            foreach (Creature creature in creatureList[i].creature)
            {
                creature.status = Creature.Status.Dead;
            }
            creatureList[i].shuffleDeck();
        }
    }

    public void DispatchToInitiativeBar()
    {
        gameController.initiativeBar.GetComponent<InitiativeBarController>().UpdateInitiativeBar(activeCreatures);
    }

    public void DispatchMonsterToLeftPage(int index)
    {
        if (gameController.round != 0)
            gameController.monsterStatPanel.GetComponent<MonsterStatPanelController>().SetMonster(activeCreatures[index]);
    }

    public void AddCreature(CreatureList cList)
    {
        // Check if monster is already in the list.
        foreach (CreatureList creature in activeCreatures)
        {
            if (creature.name == cList.name)
                return;
        }

        // Monster doesn't exist, so add it to the stack.  
        activeCreatures.Add(cList);
        SortCreatures();
    }

    public void RemoveCreature(CreatureList cList)
    {
        // Pull the list of creatures in creature list, and check if they all have status dead. 
        foreach (Creature c in cList.creature)
        {
            if (c.status != Creature.Status.Dead)
                return;

        }

        // if they are, then remove them from the initiative pile.
        for (int i = 0; i < activeCreatures.Count; i++)
        {
            if (activeCreatures[i].name == cList.name)
            {
                activeCreatures.RemoveAt(i);
                SortCreatures();
                return;
            }
        }
    }

    public void SortCreatures()
    {
        if (activeCreatures.Count < 1)
        {
            return;
        }
            

        activeCreatures.Sort(delegate (CreatureList a, CreatureList b)
        {
            return (a.initiative).CompareTo(b.initiative);
        });
        // Update the initative bar.
        DispatchToInitiativeBar();
    }

    public void NewRound()
    {
        //foreach (CreatureList creature in activeCreatures)
        foreach (CreatureList creature in creatureList)
        {
            creature.DiscardCard();
        }

        if (activeCreatures.Count == 0)
            return;

        SortCreatures();

        gameController.initiativeBar.GetComponent<InitiativeBarController>().InitClicked(0);
    }
}
