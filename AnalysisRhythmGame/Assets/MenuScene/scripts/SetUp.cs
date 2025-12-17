using UnityEngine;
using System.Collections.Generic;
using System;

public class SetUp : MonoBehaviour
{
    void Start()
    {
        Inventory.setUp(findInactiveText("PullsHUD"),
                        findInactiveText("LevelsHUD"),
                        findInactiveText("TicketsHUD"));
    }

    static TMPro.TextMeshProUGUI findInactiveText(string name)
    {
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (GameObject go in allObjects)
        {
            if (go.name == name)
            {
                return go.GetComponent<TMPro.TextMeshProUGUI>();
            }
        }
        return null;
    }
}