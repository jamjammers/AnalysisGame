using Unity.VisualScripting;
using UnityEngine;

public class Note
{
    public GameObject prefab;
    public Vector3 pos;
    public Vector3 scale;
    public float impactTime;
    public float releaseTime;
    private int speed;

    // slider constructor
    public Note(GameObject prefab, float impactTime, float releaseTime)
    {
        this.prefab = prefab;
        this.impactTime = impactTime;
        this.releaseTime = releaseTime;
        speed = 40;
        scale = new Vector3(2f,0.5f,speed * (releaseTime - impactTime)+3);
        pos = new Vector3(prefab.transform.position.x, prefab.transform.position.y, speed*impactTime+scale.z/2);
    }

    // single/flick constructor
    public Note(GameObject prefab, float impactTime)
    {
        this.prefab = prefab;
        this.impactTime = impactTime;
        this.releaseTime = impactTime;
        speed = 40;
        scale = new Vector3(prefab.transform.localScale.x, prefab.transform.localScale.y, prefab.transform.localScale.z);
        pos = new Vector3(prefab.transform.position.x, prefab.transform.position.y, speed*impactTime+scale.z/2);
    }
}