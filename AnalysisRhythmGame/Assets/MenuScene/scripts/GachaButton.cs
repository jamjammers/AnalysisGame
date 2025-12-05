using UnityEngine.UI;
using UnityEngine;

public class GachaPopup : MonoBehaviour
{

    public RawImage thing;
    public GameObject manager;
    void Start()
    {
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
        if(Inventory.pulls <= 0) return;
        
        GachaCard gachaCard = GachaManager.pull();
        if (gachaCard == null) return;
        thing.texture = gachaCard.texture;

        // set alpha to 5 so that it like fades out
        Color temp = thing.color;
        temp.a = 5f;
        thing.color = temp;
    }
}
