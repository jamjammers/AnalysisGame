using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;

public static class Inventory
{
    static int pulls = 1;
    static int tickets = 1;

    // static int coins = 0;
    static float level = 1;
    static float exp = 0;
    static List<GachaCard> cards = new List<GachaCard>();
    static bool secretGuarentee = true;
    public static CollectionScreen collectionScreen;

    static TextMeshProUGUI pullsText;
    static TextMeshProUGUI levelText;
    static TextMeshProUGUI ticketsText;
    public static void setUp(TextMeshProUGUI p, TextMeshProUGUI l, TextMeshProUGUI t)
    {
        pullsText = p;
        levelText = l;
        ticketsText = t;

        if(pullsText != null)
            pullsText.text = pulls.ToString();
        if(levelText != null)
            levelText.text = level.ToString();
        if(ticketsText != null)
            ticketsText.text = tickets.ToString();
    }

    public static bool characterPull()
    {
        if (pulls <= 0) return false;
        pulls--;

        if(pullsText != null)
            pullsText.text = pulls.ToString();

        return true;
    }
    public static bool ticketPull()
    {
        if (tickets <= 0) return false;
        tickets--;

        if(ticketsText != null)
            ticketsText.text = tickets.ToString();

        return true;
    }
    public static void addCard(GachaCard gachaCard)
    {
        if (cards.Contains(gachaCard)) return;
        cards.Add(gachaCard);
        collectionScreen.addCard(gachaCard);

    }
    public static void addCards(List<GachaCard> gachaCards)
    {
        foreach (GachaCard gachaCard in gachaCards)
        {
            addCard(gachaCard);
        }
    }
    public static List<GachaCard> getCards() { return cards; }

    public static void addPulls(int amount)
    {
        pulls += amount;
        
        if(pullsText != null)
            pullsText.text = pulls.ToString();
    }
    public static void addTicket()
    {
        addTickets(1);
    }
    public static void addTickets(int amount)
    {
        tickets += amount;
        if(ticketsText != null)
            ticketsText.text = tickets.ToString();
    }
    public static void gainExp(float amount)
    {
        exp += amount;
        while (exp >= level * 100)
        {
            exp -= level * 100;
            level++;
        }
        if(levelText != null)
            levelText.text = level.ToString();
    }
    public static void setSecretGuarentee(bool val)
    {
        secretGuarentee = val;
    }
    public static bool triggerGuarentee()
    {
        bool temp = secretGuarentee;
        secretGuarentee = false;
        return temp;
    }
}
