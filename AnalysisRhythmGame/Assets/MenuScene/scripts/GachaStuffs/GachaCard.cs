using UnityEngine;
using System.Collections.Generic;

public class GachaCard
{
    public string name;
    public GachaRarity rarity;
    public Texture2D texture;
    public GachaCard(string n, GachaRarity r, Texture2D t)
    {
        name = n;
        rarity = r;
        texture = t;
        Gacha.allGachaCards.Add(this);
        Gacha.rarityDict[r].Add(this);
    }
    public enum GachaRarity
    {
// things you get in regular gacha
        FIVE_STAR,
        FOUR_STAR,
        THREE_STAR,
        FOOD_TICKET,

//things you can get in food
        COAL, 
        CURSE,
        TRASH,
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        LEGENDARY,
        MYTHIC

    }
}