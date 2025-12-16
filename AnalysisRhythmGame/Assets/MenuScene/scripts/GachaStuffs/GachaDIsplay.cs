using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class GachaDisplay : MonoBehaviour
{
    public GameObject Collection;
    public GachaCard card;
    public int selected = -1;
    public GameObject selectedPanel;

    [SerializeField] Texture2D[] selectedTextures;
    void Start()
    {
        Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        
    }
    public void setUp(GachaCard gachaCard, Vector3 position, GameObject collection)
    {
        GetComponent<RectTransform>().anchoredPosition = position;
        transform.GetChild(0).GetComponent<UnityEngine.UI.RawImage>().texture = gachaCard.texture;
        Collection = collection;
        card = gachaCard;
    }
    public void OnClick()
    {
        if(selected != -1)
        {
            Buffs.team[selected] = null;
            selectedPanel.SetActive(false);
            selected = -1;
            return;
        }

        if(card.rarity == GachaCard.GachaRarity.FIVE_STAR && Buffs.team[0] != null)
        {
            return;
        }

        for(int i = 0; i< Buffs.team.Length; i++)
        {
            if(Buffs.team[i] == null)
            {
                Buffs.team[i] = card;
                selected = i;
                selectedPanel.SetActive(true);
                selectedPanel.GetComponent<RawImage>().texture = selectedTextures[i];
                return;
            }
        }
    }
}