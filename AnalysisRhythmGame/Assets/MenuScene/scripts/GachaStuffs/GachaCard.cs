using UnityEngine;
using System.Collections.Generic;

public class GachaCard
{
    public string name;
    public int rarity;
    public Texture2D texture;
    public GachaCard(string n, int r, Texture2D t)
    {
        name = n;
        rarity = r;
        texture = t;
        Gacha.allGachaCards.Add(this);
        if (r == 5)
        {
            Gacha.fiveStars.Add(this);
        }
        else if (r == 4)
        {
            Gacha.fourStars.Add(this);
        }
        else if (r == 3)
        {
            Gacha.threeStars.Add(this);
        }
        else if (r == 0)
        {
            Gacha.foods.Add(this);
        }
    }
}