using UnityEngine;
using System.Collections.Generic;

public class gachas
{
    public static List<gachas> gachalist = new List<gachas>();
    public string name;
    public int rarity;
    public Texture2D texture;
    public gachas(string n, int r, Texture2D t)
    {
        name = n;
        rarity = r;
        texture = t;
        gachalist.Add(this);
    }
}