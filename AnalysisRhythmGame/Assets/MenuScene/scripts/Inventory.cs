using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    static int pulls = 1;
    static int tickets = 1;

    static int coins = 0;
    static float level = 1;
    static float exp = 0;
    static List<GachaCard> cards = new List<GachaCard>();
    static bool loaded = false;

    public void Start()
    {
        if(loaded) return;
        loaded = true;

    }

    public static bool pull()
    {
        if(pulls <= 0) return false;
        pulls--;
        return true;
    }
    public static void addCard(GachaCard gachaCard)
    {
        cards.Add(gachaCard);
    }
    public static void gainExp(float amount)
    {
        exp += amount;
        while(exp >= level * 100)
        {
            exp -= level * 100;
            level++;
        }
    }
}
