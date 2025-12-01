using UnityEngine;
using System.Collections.Generic;
public class Gachafather : MonoBehaviour
{
    public Texture2D[] textures;
    // public int[] rarities;
    public string[] names;
    public List<gachas> gachaslist = new List<gachas>();

    public static int pulls = 1;

    public static float exp = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < Mathf.Min(textures.Length, names.Length); i++)
        {
            new gachas(names[i], 3, textures[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
