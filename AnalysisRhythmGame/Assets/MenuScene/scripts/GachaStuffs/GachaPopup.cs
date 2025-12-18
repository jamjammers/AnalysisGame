using UnityEngine.UI;
using UnityEngine;
using UnityEditor.Rendering;
using System.IO;
using System.Linq;
using NUnit.Framework.Constraints;
using System;
using System.Runtime.CompilerServices;

public class GachaPopup : MonoBehaviour
{

    public RawImage thing;

    public GachaManager gachaManager;

    public ParticleSystem particles;
    public GameObject underPanel;

    void Start()
    {
        particles = FindObjectsByType<ParticleSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(p => p.transform.parent != null && p.transform.parent.name == "Gacha");
        Debug.Log(particles);
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

            temp = underPanel.GetComponent<Image>().color;
            temp.a = Math.Clamp(thing.color.a, 0, 0.8f);
            underPanel.GetComponent<Image>().color = temp;
        }
    }
    public void pull(bool risky = false)
    {
        if(thing.color.a > 2f) return;
        Debug.Log("Pulling from "+ gachaManager.getBannerType().name());
        (GachaCard gachaCard, bool special) = Gacha.pull(gachaManager.getBannerType(), risky);


        if (gachaCard == null) return;
        thing.texture = gachaCard.texture;

        var colorOverLifetime = particles.colorOverLifetime;
        colorOverLifetime.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys( 
            new GradientColorKey[] { 
                new GradientColorKey(Color.white, 0.0f), 
                new GradientColorKey(special? 
                    new Color(1.0f, 0.807843137254902f, 0.0f, 1.0f): 
                    new Color(0.0f, 0.8392156862745098f, 1.0f, 1.0f), 
                    0.8f) 
                }, 
            new GradientAlphaKey[] { 
                new GradientAlphaKey(0.8f, 0.0f), 
                new GradientAlphaKey(1.0f, 1.0f) 
                }
            );
        colorOverLifetime.color = new ParticleSystem.MinMaxGradient(grad);
        
        particles.Clear();
        particles.Play();

        // set alpha to 3 so that it like fades out
        Color temp = thing.color;
        temp.a = 3f;
        thing.color = temp;


        temp = underPanel.GetComponent<Image>().color;
        temp.a = 3f;
        underPanel.GetComponent<Image>().color = temp;

        // Debug.Log("Pulled: " + gachaCard.name + " of rarity " + gachaCard.rarity);
    }
    public void hide()
    {
        Color temp = thing.color;
        temp.a = 0;
        thing.color = temp;

        temp = underPanel.GetComponent<Image>().color;
        temp.a = 0;
        underPanel.GetComponent<Image>().color = temp;


    }
}
