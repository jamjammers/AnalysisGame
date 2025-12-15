using UnityEngine.UI;
using UnityEngine;
using UnityEditor.Rendering;
using System.IO;
using System.Linq;
using NUnit.Framework.Constraints;

public class GachaPopup : MonoBehaviour
{

    public RawImage thing;

    public GachaManager gachaManager;

    public ParticleSystem particles;
    void Start()
    {
        particles = FindObjectsByType<ParticleSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(p => p.transform.parent != null && p.transform.parent.name == "Gacha");
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

        particles.Play();
        Gradient grad = new Gradient();
        grad.SetKeys( 
            new GradientColorKey[] { 
                new GradientColorKey(Color.white, 0.0f), 
                new GradientColorKey(false? new Color(00,0xD6,0xFF): new Color(0xFF, 0xE1, 0), 1.0f) 
                }, 
            new GradientAlphaKey[] { 
                new GradientAlphaKey(0.8f, 0.0f), 
                new GradientAlphaKey(1.0f, 1.0f) 
                }
            );

        var colorOverLifetime = particles.colorOverLifetime;
        colorOverLifetime.color = grad;


        // set alpha to 3 so that it like fades out
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
