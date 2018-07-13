[System.Serializable]
public class Line
{
    public string name;
    /* Types:
     * attack, move, heal, retaliate, push, pull, createElement, convert element
     */
    public bool jump = false;
    // integers
    public int mod = 0;
    public int range = 0;
    // for heal self, you set the range to 0.
    public int shield = 0;
    public int pierce = 0;
    public int target = 0;
    public int push = 0;
    public int pull = 0;
    // Strings
    public string aoe = "aoe-none";
    public string aoe2 = "aoe-none";
    public string label = "";
    // Conditions
    public bool immobilize = false;
    public bool curse = false;
    public bool wound = false;
    public bool disarm = false;
    public bool muddle = false;
    public bool poison = false;
    public bool stun = false;
    public bool bless = false;
    public bool strengthen = false;

    // ELEMENT Conversion
    public string element = "";
    public string toElement = "";
    public string action = "";

}