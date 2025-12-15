using UnityEngine;
using System.Collections.Generic;
using System;
public class Gacha : MonoBehaviour
{
    // public int[] rarities;
    [SerializeField] string[] names;
    [SerializeField] GachaCard.GachaRarity[] rarities;


    public static List<GachaCard> allGachaCards = new List<GachaCard>();

    Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

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
        { GachaCard.GachaRarity.LEGENDARY, new List<GachaCard>() }
    };

    static CollectionScreen collectionScreen;
    static bool debugMode = true;
    public void Start()
    {
        collectionScreen = FindObjectsByType<CollectionScreen>(FindObjectsInactive.Include, FindObjectsSortMode.None)[0];
        loadTextures();
        loadCards();

        if (debugMode)
        {
            Inventory.addPulls(10000);
            Inventory.addTickets(10000);
        }
    }

//loading (only needs to be done once)
    public void loadTextures()
    {
        if (textures.Count != 0 || allGachaCards.Count != 0) return;
        Debug.Log("Loading Textures");
        foreach (Texture2D t in Resources.LoadAll<Texture2D>("GachaCards/"))
        {
            textures[t.name] = t;
            if (debugMode) Debug.Log("Loaded texture: " + t.name);
        }
        Debug.Log("Loaded Textures");
    }

    public void loadCards()
    {
        if (allGachaCards.Count != 0) return;
        Debug.Log("Loading Gacha Cards");

        /* Gacha Cards */

        //Three stars
        new GachaCard("Angry Cat", GachaCard.GachaRarity.THREE_STAR, textures["angry_cat"]);
        new GachaCard("Dizzy Cat", GachaCard.GachaRarity.THREE_STAR, textures["dizzy_cat"]);
        new GachaCard("Grumpy Cat", GachaCard.GachaRarity.THREE_STAR, textures["grumpy_cat"]);
        new GachaCard("Happy Cat", GachaCard.GachaRarity.THREE_STAR, textures["happy_cat"]);
        new GachaCard("Old Cat", GachaCard.GachaRarity.THREE_STAR, textures["old_cat"]);
        new GachaCard("Sad Cat", GachaCard.GachaRarity.THREE_STAR, textures["sad_cat"]);
        new GachaCard("Scard Cat", GachaCard.GachaRarity.THREE_STAR, textures["scared_cat"]);

        //Four stars
        new GachaCard("Bubbles Cat", GachaCard.GachaRarity.FOUR_STAR, textures["bubbles_cat"]);
        new GachaCard("Cook Cat", GachaCard.GachaRarity.FOUR_STAR, textures["cook_cat"]);
        new GachaCard("Flower Cat", GachaCard.GachaRarity.FOUR_STAR, textures["flower_cat"]);
        new GachaCard("Painter Cat", GachaCard.GachaRarity.FOUR_STAR, textures["painter_cat"]);
        new GachaCard("Singer Cat", GachaCard.GachaRarity.FOUR_STAR, textures["singer_cat"]);

        //Five stars
        new GachaCard("Patchwork Cat", GachaCard.GachaRarity.FIVE_STAR, textures["patchwork_cat"]);
        new GachaCard("Fat Cat", GachaCard.GachaRarity.FIVE_STAR, textures["fat_cat"]);
        new GachaCard("Cat Girl", GachaCard.GachaRarity.FIVE_STAR, textures["cat_girl"]);

        /* Food */

        //Coal
        new GachaCard("Coal", GachaCard.GachaRarity.COAL, textures["coal"]);

        //Curse
        new GachaCard("Mud Pie", GachaCard.GachaRarity.CURSE, textures["mud_pie"]);
        new GachaCard("Cockroach Sandwich", GachaCard.GachaRarity.CURSE, textures["cockroach_sandwich"]);

        //Trash
        new GachaCard("Fast Food Wrappers", GachaCard.GachaRarity.TRASH, textures["fast_food_wrappers"]);

        //Common
        new GachaCard("Apple", GachaCard.GachaRarity.COMMON, textures["apple"]);
        new GachaCard("Cat Food", GachaCard.GachaRarity.COMMON, textures["cat_food"]);

        //Uncommon
        new GachaCard("Ketchup", GachaCard.GachaRarity.UNCOMMON, textures["ketchup"]);
        new GachaCard("Salt", GachaCard.GachaRarity.UNCOMMON, textures["salt"]);
        new GachaCard("Soy Sauce", GachaCard.GachaRarity.UNCOMMON, textures["soy_sauce"]);

        //Rare
        new GachaCard("Burger", GachaCard.GachaRarity.RARE, textures["burger"]);
        new GachaCard("Chicken Nuggets", GachaCard.GachaRarity.RARE, textures["chicken_nuggets"]);
        new GachaCard("Fries", GachaCard.GachaRarity.RARE, textures["fries"]);

        //Epic
        new GachaCard("Boba", GachaCard.GachaRarity.EPIC, textures["boba"]);
        new GachaCard("Ramen", GachaCard.GachaRarity.EPIC, textures["ramen"]);
        new GachaCard("Sushi", GachaCard.GachaRarity.EPIC, textures["sushi"]);

        // Legendary
        new GachaCard("Rainbow Food", GachaCard.GachaRarity.LEGENDARY, textures["rainbow_food"]);

        // food ticket!
        new GachaCard("Gacha Ticket", GachaCard.GachaRarity.FOOD_TICKET, textures["food_ticket"]);
    }


    public static GachaCard pull(GachaBanner.BannerType bannerType)
    {
        if (bannerType == GachaBanner.BannerType.FOOD)
        {
            return foodPull();
        }
        return characterPull();

    }

    public static GachaCard foodPull()
    {
        if (Inventory.ticketPull() == false) return null;

        double pullValue = Utilities.Normal();
        GachaCard.GachaRarity rarity = getGachaRarity(true, pullValue);

        int randValue = UnityEngine.Random.Range(0, rarityDict[rarity].Count);
        GachaCard pulledCard = rarityDict[rarity][randValue];
        if(pulledCard.rarity == GachaCard.GachaRarity.COMMON)
        {
            if(debugMode)
                Debug.Log("Pulled common food: " + pulledCard.name);
            Inventory.gainExp(pulledCard.name == "Cat Food"?25:75);
            
        }else{
            Buffs.foodBuffs[pulledCard.name] = Math.Clamp(Buffs.foodBuffs[pulledCard.name] + 6, 0, 9);
            if(debugMode){
                Debug.Log("Buff " + pulledCard.name + " duration increased to " + Buffs.foodBuffs[pulledCard.name]);
                Debug.Log("Food buffs:\n" + Buffs.foodBuffString());
            }
        }
        return pulledCard;
    }
    public static GachaCard characterPull()
    {
        if (Inventory.characterPull() == false) return null;

        double pullValue = UnityEngine.Random.Range(0f, 1f);
        GachaCard.GachaRarity rarity = getGachaRarity(false, pullValue);
        
        int randValue = UnityEngine.Random.Range(0, rarityDict[rarity].Count);
        GachaCard pulledCard = rarityDict[rarity][randValue];

        Inventory.addCard(pulledCard);
        collectionScreen.addCard(pulledCard);
        
        return pulledCard;
    }

    static GachaCard.GachaRarity getGachaRarity(bool food, double pullValue)
    {
        if (!food)
        {
            if (pullValue < 0.01f)
            {
                return GachaCard.GachaRarity.FIVE_STAR;
            }
            else if (pullValue < 0.1f)
            {
                return GachaCard.GachaRarity.FOUR_STAR;
            }
            else if (pullValue < 0.5f)
            {
                return GachaCard.GachaRarity.THREE_STAR;
            } else
            {
                return GachaCard.GachaRarity.FOOD_TICKET;
            }
        }

        if(pullValue < -0.6)
        {
            return GachaCard.GachaRarity.COAL;
        } 
        else if (pullValue < -0.4f)
        {
            return GachaCard.GachaRarity.CURSE;
        }
        else if (pullValue < -0.2f)
        {
            return GachaCard.GachaRarity.TRASH;
        }
        else if (pullValue <= 0f)
        {
            return GachaCard.GachaRarity.COMMON;
        }
        else if (pullValue <= 0.2f)
        {
            return GachaCard.GachaRarity.UNCOMMON;
        }
        else if (pullValue <= 0.4f)
        {
            return GachaCard.GachaRarity.RARE;
        }
        else if (pullValue <= 0.6f)
        {
            return GachaCard.GachaRarity.EPIC;
        }
        else
        {
            return GachaCard.GachaRarity.LEGENDARY;
        }

    }
}
