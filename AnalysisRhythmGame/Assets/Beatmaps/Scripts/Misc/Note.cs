using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Note
{
    public GameObject original;
    public GameObject prefab;
    public Vector3 startPos;
    public Vector3 scale;
    public float impactTime;
    public float releaseTime;
    public float speed = NoteSpawner.spd;
    private bool slider = false;

    // slider constructor
    public Note(GameObject prefab, float impactTime, float releaseTime)
    {
        this.original = prefab;
        this.impactTime = impactTime;
        this.releaseTime = releaseTime;
        slider = true;
    }

    // single/flick constructor
    public Note(GameObject prefab, float impactTime)
    {
        this.original = prefab;
        this.impactTime = impactTime;
        releaseTime = impactTime;
        slider = false;
    }

    public void UpdateTransform()
    {
        if (slider)
        {
            scale = new Vector3(2f,0.5f, speed * (releaseTime - impactTime)+3);
            startPos = new Vector3(original.transform.position.x, original.transform.position.y, speed*impactTime+scale.z/2);
            return;
        }
        scale = new Vector3(original.transform.localScale.x, original.transform.localScale.y, original.transform.localScale.z);
        startPos = new Vector3(original.transform.position.x, original.transform.position.y, speed*impactTime+scale.z/2);
        
    }

    public void update(float CTIME)
    {
        if(original == null || prefab == null) return;
        Debug.Log(speed * (impactTime - CTIME) + scale.z / 2);

        prefab.transform.position = new Vector3(original.transform.position.x, 
                                                original.transform.position.y, 
                                                speed * (impactTime - CTIME) + scale.z / 2);
        Debug.Log(original.transform.position);
           
    }
}