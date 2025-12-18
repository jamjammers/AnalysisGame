using System.Collections.Generic;

public static class Buffs
{
    /* 
    card buffs:
        all of these are cats
        the name below can be gotten using team[n].name and will return it in full lowercase
        see the gacha card class in assets/menuscene/scripts/gachastuffs/gachacard.cs for more
        there may be null values if no card is equipped in that slot
        teams of 3 

        3*: basic buffs
            angry: +score %
            confused: +score %
            grumpy: +score %
            happy: +score %
            old: +score %
            sad: +score %
            scared: +score %

        4*: good buffs
            bubbles: grants "bubbles" that grants combo on misses, etc (n) times
            cook: grants extra hp for each perfect note
            flower: grants "petals" that prevents hp loss (n) times
            painter: multiplies the size of the judgement bar by (n%)
            singer: grants a score boost for perfect notes

        5*: game altering effects (must be the party leader)
            patchwork: has a boosted effect of every party member 
            gourmand: guarrentees a food ticket every game
            perfectionist: guarrentees all perfects (for tapped notes)
    */
    public static GachaCard[] team = new GachaCard[3];

    /* 
    food buffs
        the int is the number of turns left
        honestly within the groups, the actual effects can be swapped around
        
        Coal Tier: really bad debuff
            Coal: random note speed

        Curse Tier: debuffs (with a slight counteracting buff?)
            cockroach sandwich: increases HP loss on misses
            mud pie: requires more precise timing + other things (think hard rock)

        Trash Tier: light vision debuff
            fast food wrappers: high contrast mode or sthn

        Uncommon Tier: drop rate buffs
            ketchup: more player exp (% boost)
            salt: more coin drops (% boost)
            soy sauce: more character exp (% boost)
            
        Rare Tier: minor (non-score related) buffs 
            burger: starting hp ++
            chicken nuggets: don't decerase hp after misses 5 times
            fries: don't decrease combo after misses or goods 5 times
            
        Epic Tier: major buffs ?
            boba: perfects give more score
            ramen: slightly increases perfect window
            sushi: overall score boost
            
        legendary tier: ultimate buffs
            rainbow food: does all of the drop rate, minor and major buffs (at half rate)
    */
    public static Dictionary<string, int> foodBuffs = new Dictionary<string, int>()
    {
        //Coal tier
        {"Coal",0},
        //Curse tier
        {"Cockroach Sandwich",0}, {"Mud Pie",0},
        //Trash tier
        {"Fast Food Wrappers",0},
        //Uncommon tier
        {"Ketchup",0}, {"Salt",0}, {"Soy Sauce",0},
        //Rare tier
        {"Burger",0}, {"Chicken Nuggets",0},{"Fries",0},
        //Epic tier
        {"Boba",0}, {"Ramen",0}, {"Sushi",0},
        //Rainbow tier
        {"Rainbow Food",0}
    };

    public static string foodBuffString()
    {
        string result = "";
        foreach ( var kvp in foodBuffs )
        {
            result += kvp.Key + ": " + kvp.Value + " turns left\n";
        }
        return result;
    }

    public static void DecreaseBuffDurations()
    {
        List<string> keys = new List<string>(foodBuffs.Keys);
        foreach (string key in keys)
        {
            if (foodBuffs[key] > 0)
            {
                foodBuffs[key]--;
            }
        }
    }

}