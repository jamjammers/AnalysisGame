using UnityEngine.UI;
using UnityEngine;
using UnityEditor.Rendering;

public class GachaPopup : MonoBehaviour
{

    public RawImage thing;

    public GachaManager gachaManager;
    void Start()
    {
        gachaManager = transform.parent.GetComponent<GachaManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (thing.color.a > 0)
        {
            Color temp = thing.color;
            temp.a -= Time.deltaTime;
            thing.color = temp;
        }
    }
    public void pull()
    {   
        if(thing.color.a > 2f) return;
        Debug.Log("Pulling from "+ gachaManager.getBannerType().name());
        GachaCard gachaCard = Gacha.pull(gachaManager.getBannerType());
        if (gachaCard == null) return;
        thing.texture = gachaCard.texture;

        // set alpha to 5 so that it like fades out
        Color temp = thing.color;
        temp.a = 3f;
        thing.color = temp;
        Debug.Log("Pulled: " + gachaCard.name + " of rarity " + gachaCard.rarity);
    }
    public void hide()
    {
        Color temp = thing.color;
        temp.a = 0;
        thing.color = temp;
        
    }
}
