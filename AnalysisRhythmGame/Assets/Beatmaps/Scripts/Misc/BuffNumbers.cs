using UnityEngine;

public class BuffNumbers : MonoBehaviour
{
    // food effects
    public static bool randomSpeed = false; // coal
    public static int missValue = 40; // cockroach sandwich and ramen
    public static float timingTolerance = .05f;  // mud pie and painter cat
    public static float spd = 40; // fast food wrappers
    public static float expBoost = 1; // ketchup
    public static float coinBoost = 1; // salt
    public static float charExpBoost = 1; // soy sauce
    public static int hpBoost = 0; // burger
    public static int hpLoss = 5; // chicken nuggets
    public static float perfectBuff = 1; // boba
    public static float scoreBuffs = 1; // sushi and fries

    // character effects
    public static float baseProb = 0.5f; // bubble cat and flower cat
    public static bool bubbles = false; // Bubble cat
    public static int hpBonus = 0; // Cook cat
    public static bool petals = false; // Flower cat
    public static bool buffAll = false; // Patchwork cat
    public static bool ticket = false; // Gourmand cat
    public static bool perf = false; // Perfectionist cat

    void Start() {
        // food buffs
        if (Buffs.foodBuffs["Rainbow Food"] >= 1) {
            Buffs.foodBuffs["Rainbow Food"] -= 1;
            missValue = 20;
            expBoost = 1.3f;
            coinBoost = 1.3f;
            charExpBoost = 1.3f;
            hpBoost = 1000;
            hpLoss = 3;
            scoreBuffs = 1.75f;
            perfectBuff = 1.5f;
        } else {
            if (Buffs.foodBuffs["Coal"] >= 1) {
                Buffs.foodBuffs["Coal"] -= 1;
                randomSpeed = true;
            }
            if (Buffs.foodBuffs["Ramen"] >= 1) {
                Buffs.foodBuffs["Ramen"] -= 1;
                missValue = 5;
            } else if (Buffs.foodBuffs["Cockroach Sandwich"] >= 1) {
                Buffs.foodBuffs["Cockroach Sandwich"] -= 1;
                missValue = 80;
            }
            if (Buffs.foodBuffs["Mud Pie"] >= 1) {
                Buffs.foodBuffs["Mud Pie"] -= 1;
                timingTolerance = .03f;
            }
            if (Buffs.foodBuffs["Fast Food Wrappers"] >= 1) {
                Buffs.foodBuffs["Fast Food Wrappers"] -= 1;
                spd = 3;
            }
            if (Buffs.foodBuffs["Ketchup"] >= 1) {
                Buffs.foodBuffs["Ketchup"] -= 1;
                expBoost = 1.3f;
            }
            if (Buffs.foodBuffs["Salt"] >= 1) {
                Buffs.foodBuffs["Salt"] -= 1;
                coinBoost = 1.3f;
            }
            if (Buffs.foodBuffs["Soy Sauce"] >= 1) {
                Buffs.foodBuffs["Soy Sauce"] -= 1;
                charExpBoost = 1.3f;
            }
            if (Buffs.foodBuffs["Burger"] >= 1) {
                Buffs.foodBuffs["Burger"] -= 1;
                hpBoost = 1000;
            }
            if (Buffs.foodBuffs["Chicken Nuggets"] >= 1) {
                Buffs.foodBuffs["Chicken Nuggets"] -= 1;
                hpLoss = 3;
            }
            if (Buffs.foodBuffs["Sushi"] >= 1) {
                Buffs.foodBuffs["Sushi"] -= 1;
                scoreBuffs = 1.75f;
            } else if (Buffs.foodBuffs["Fries"] >= 1) {
                Buffs.foodBuffs["Fries"] -= 1;
                scoreBuffs = 1.25f;
            }
            if (Buffs.foodBuffs["Boba"] >= 1) {
                Buffs.foodBuffs["Boba"] -= 1;
                perfectBuff = 1.5f;
            }
        }

        // character buffs
        // preliminary check for patchwork cat
        foreach (GachaCard gc in Buffs.team) {
            if (gc == null) continue;
            if (gc.name == "Patchwork Cat") buffAll = true;
        }

        foreach (GachaCard gc in Buffs.team) {
            if (gc == null) continue;

            if (gc.rarity == GachaCard.GachaRarity.THREE_STAR) {
                scoreBuffs += buffAll ? 0.25f : 0.5f;
            } else if (gc.name == "Bubbles Cat") {
                bubbles = true;
            } else if (gc.name == "Cook Cat") {
                hpBonus = buffAll ? 20 : 40;
            } else if (gc.name == "Flower Cat") {
                petals = true;
            } else if (gc.name == "Painter Cat") {
                timingTolerance = buffAll ? 0.07f : 0.09f;
            } else if (gc.name == "Singer Cat") {
                perfectBuff += buffAll ? 0.5f : 1;
            // } else if (gc.name == "Fat Cat") { // it seems like this is already implemented
            //     Inventory.addTicket();
            } else if (gc.name == "Cat Girl") {
                perf = true;
            }
        }

        if (buffAll) {
            baseProb = 0.65f;
        }
    }
}