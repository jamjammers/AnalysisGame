using Unity.VisualScripting;
using UnityEngine;

public class Note
{
    public GameObject prefab;
    public Vector3 pos;
    public Vector3 scale;
    public float impactTime;
    public float releaseTime;
    public int speed;
    private bool slider = false;

    // slider constructor
    public Note(GameObject prefab, float impactTime, float releaseTime)
    {
        this.prefab = prefab;
        this.impactTime = impactTime;
        this.releaseTime = releaseTime;
        slider = true;
    }

    // single/flick constructor
    public Note(GameObject prefab, float impactTime)
    {
        this.prefab = prefab;
        this.impactTime = impactTime;
        this.releaseTime = impactTime;
    }

    public void UpdateTransform()
    {
        if (slider)
        {
            scale = new Vector3(2f,0.5f,speed * (releaseTime - impactTime)+3);
            pos = new Vector3(prefab.transform.position.x, prefab.transform.position.y, speed*impactTime+scale.z/2);
        } else
        {
        scale = new Vector3(prefab.transform.localScale.x, prefab.transform.localScale.y, prefab.transform.localScale.z);
        pos = new Vector3(prefab.transform.position.x, prefab.transform.position.y, speed*impactTime+scale.z/2);
        }
    }

    public void SetSpeed(int spd)
    {
        speed = spd;
    }
}