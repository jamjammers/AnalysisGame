using UnityEngine;
using System.Collections.Generic;

public class Gacha : MonoBehaviour
{
    [SerializeField] Texture2D[] textures;
    // public int[] rarities;
    [SerializeField] string[] names;
    [SerializeField] GachaCard.GachaRarity[] rarities;

    [SerializeField] Texture2D ticketTexture;

    public static List<GachaCard> allGachaCards = new List<GachaCard>();
    public static List<GachaCard> fiveStars = new List<GachaCard>();
    public static List<GachaCard> fourStars = new List<GachaCard>();
    public static List<GachaCard> threeStars = new List<GachaCard>();
    public static List<GachaCard> foods = new List<GachaCard>();

    public static Dictionary<GachaCard.GachaRarity, List<GachaCard>> rarityDict = new Dictionary<GachaCard.GachaRarity, List<GachaCard>>()
    {
        { GachaCard.GachaRarity.FIVE_STAR, new List<GachaCard>() },
        { GachaCard.GachaRarity.FOUR_STAR, new List<GachaCard>() },
        { GachaCard.GachaRarity.THREE_STAR, new List<GachaCard>() },
        { GachaCard.GachaRarity.FOOD_TICKET, new List<GachaCard>() },

        { GachaCard.GachaRarity.COAL, new List<GachaCard>() },
        { GachaCard.GachaRarity.CURSE, new List<GachaCard>() },
        { GachaCard.GachaRarity.TRASH, new List<GachaCard>() },
        { GachaCard.GachaRarity.COMMON, new List<GachaCard>() },
        { GachaCard.GachaRarity.UNCOMMON, new List<GachaCard>() },
        { GachaCard.GachaRarity.RARE, new List<GachaCard>() },
        { GachaCard.GachaRarity.EPIC, new List<GachaCard>() },
        { GachaCard.GachaRarity.LEGENDARY, new List<GachaCard>() },
        { GachaCard.GachaRarity.MYTHIC, new List<GachaCard>() }
    };

    public static GachaCard ticket;

    public void Start()
    {
        Debug.Log(Resources.LoadAll<Texture2D>("GachaCards/"));
        if (allGachaCards.Count == 0)
            loadCards();
    }
    public void loadCards()
    {
        for (int i = 0; i < textures.Length; i++)
        {
            new GachaCard(names[i], rarities[i], textures[i]);
        }
        ticket = new GachaCard("Gacha Ticket", GachaCard.GachaRarity.FOOD_TICKET, ticketTexture);
    }

    public static GachaCard foodPull()
    {
        if (Inventory.ticketPull() == false) return null;
        double pullChance = Utilities.Normal();

        GachaCard pulled;
        if (pullChance < 0.5f)
        {
            pulled = foods[Random.Range(0, foods.Count)];
        }
        else if (pullChance < 0.8f)
        {
            pulled = threeStars[Random.Range(0, threeStars.Count)];
        }
        else if (pullChance < 0.95f)
        {
            pulled = fourStars[Random.Range(0, fourStars.Count)];
        }
        else
        {
            pulled = fiveStars[Random.Range(0, fiveStars.Count)];
        }
        return pulled;
    }

    public static GachaCard pull()
    {
        if (Inventory.characterPull() == false) return null;

        double pullChance = Random.Range(0f, 1f);

        if (pullChance >= 0.5f)
        {
            Inventory.addTicket();
            return ticket;
        }

        GachaCard pulled;

        if (pullChance < 0.01f)
        {
            pulled = fiveStars[Random.Range(0, fiveStars.Count)];
        }
        else if (pullChance < 0.2f)
        {
            pulled = fourStars[Random.Range(0, fourStars.Count)];
        }
        else
        {
            pulled = threeStars[Random.Range(0, threeStars.Count)];
        }

        Inventory.addCard(pulled);
        return pulled;
    }
}
