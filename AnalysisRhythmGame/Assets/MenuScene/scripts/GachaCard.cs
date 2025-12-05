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
        GachaManager.allGachaCards.Add(this);
        if (r == 5)
        {
            GachaManager.fiveStars.Add(this);
        }
        else if (r == 4)
        {
            GachaManager.fourStars.Add(this);
        }
        else if (r == 3)
        {
            GachaManager.threeStars.Add(this);
        }
    }
}