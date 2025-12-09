public static class Buffs
{
    /* 
    card buffs: btw all of these are cats

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
    
    /* 
    food buffs
        the int is the number of turns left
        honestly within the groups, the actual effects can be swapped around
        
        Coal Tier: really bad debuff
            Coal: Idk i forgot what this debuff does

        Curse Tier: debuffs (with a slight counteracting buff)
            cockroach and jam: idk
            mud pie: requires more precise timing + other things (think hard rock)

        Trash Tier: light vision debuff
            fast food wrappers: high contrast mode or sthn

        Uncommon Tier: drop rate buffs
            ketchup: more player exp (% boost)
            salt: more coin drops (% boost)
            soy sauce: more character exp (% boost)
            
        Rare Tier: minor (non-score related) buffs 
            burger: starting hp ++
            chicken nuggets: I'm rinning out of ideas
            fries: out of ideas
            
        Epic Tier: major buffs ?
            boba: perfects give more score
            ramen: slightly increases something
            sushi: overall score boost
            
        rainbow tier: ultimate buffs
            rainbow food: does all of the drop rate, minor and major buffs (at half rate)
    */
    public static Dictionary<string, int> activeBuffs = new Dictionary<string, int>()
    {
        //Coal tier
        {"coal",0},
        //Curse tier
        {"cockroach",0}, {"mudpie",0},
        //Trash tier
        {"fastFoodWrapper",0},
        //Uncommon tier
        {"ketchup",0}, {"salt",0}, {"soysauce",0},
        //Rare tier
        {"burger",0}, {"chickenNuggets",0},{"fries",0},
        //Epic tier
        {"boba",0}, {"ramen",0}, {"sushi",0},
        //Rainbow tier
        {"rainbow",0}
    };

    public static void DecreaseBuffDurations()
    {
        List<string> keys = new List<string>(activeBuffs.Keys);
        foreach (string key in keys)
        {
            if (activeBuffs[key] > 0)
            {
                activeBuffs[key]--;
            }
        }
    }

}