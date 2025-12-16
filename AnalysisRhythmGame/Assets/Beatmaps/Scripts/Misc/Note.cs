using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Note
{
    public GameObject prefab;
    public Vector3 startPos;
    public Vector3 scale;
    public float impactTime;
    public float releaseTime;
    public float speed;
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
        releaseTime = impactTime;
        slider = false;
    }

    public void UpdateTransform()
    {
        if (slider)
        {
            scale = new Vector3(2f,0.5f, speed * (releaseTime - impactTime)+3);
            startPos = new Vector3(prefab.transform.position.x, prefab.transform.position.y, speed*impactTime+scale.z/2);
            return;
        }
        scale = new Vector3(prefab.transform.localScale.x, prefab.transform.localScale.y, prefab.transform.localScale.z);
        startPos = new Vector3(prefab.transform.position.x, prefab.transform.position.y, speed*impactTime+scale.z/2);
        
    }

    public void SetSpeed(float spd)
    {
        speed = spd;
    }

    public void update(float CTIME)
    {
        if(prefab == null) return;

        prefab.transform.position = new Vector3(prefab.transform.position.x, 
                                                prefab.transform.position.y, 
                                                speed * (impactTime - CTIME) + scale.z / 2);
           
    }
}