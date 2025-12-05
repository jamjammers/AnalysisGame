using UnityEngine;
using System.Collections.Generic;

public class GachaManager : MonoBehaviour
{
    [SerializeField] Texture2D[] textures;
    // public int[] rarities;
    [SerializeField] string[] names;
    [SerializeField] int[] rarities;

    public static List<GachaCard> allGachaCards = new List<GachaCard>();    
    public static List<GachaCard> fiveStars = new List<GachaCard>();
    public static List<GachaCard> fourStars = new List<GachaCard>();
    public static List<GachaCard> threeStars = new List<GachaCard>();


    public void Start()
    {
        if(allGachaCards.Count == 0)
            loadCards();
    }
    public void loadCards()
    {
        for (int i = 0; i < textures.Length; i++)
        {
            GachaCard gachaCard = new GachaCard(names[i], rarities[i], textures[i]);
        }
    }
    public static GachaCard pull()
    {        
        if(Inventory.pull() == false) return null;

        double pullChance = Random.Range(0f, 1f);
        if(pullChance < 0.01f)
        {
            
        }
        else if(pullChance < 0.2f)
        {
            
        }
        else if(pullChance < 0.5f)
        {

        }
        else
        {
            
        }
        int index = Random.Range(0, allGachaCards.Count);
        Debug.Log(index);
        Inventory.addCard(allGachaCards[index]);
        return allGachaCards[index];
    }
}
