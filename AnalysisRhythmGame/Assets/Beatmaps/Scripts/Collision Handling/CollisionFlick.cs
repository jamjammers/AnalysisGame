using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionFlick : MonoBehaviour
{
    [SerializeField] private string key1;
    [SerializeField] private string key2;
    [SerializeField] private TextMeshProUGUI hitCategory;
    [SerializeField] private AudioSource hitEffect;
    private bool hit = false;
    private bool k1 = false;
    private bool enter = false;
    private float t1=0f;
    private float t2=0f;

    public void Update()
    {
        if (transform.position.z < 20 && Input.GetKeyDown(KeyMapping.keyMap[key1])) k1 = true;
        if (k1 && Input.GetKeyDown(KeyMapping.keyMap[key2])) {hit = true; hitEffect.Play();}
        if (hit) t1 += Time.deltaTime;
        if (enter) t2 += Time.deltaTime;
        if (transform.position.z < -10 && !hit) {
            Destroy(gameObject);
            hitCategory.text = "Miss";
            ScoreController.BreakCombo();
        }
        
        if (hit && enter)
        {
            float dif = Math.Abs(t2-t1);
            if (dif < 0.05) { 
                hitCategory.text = "Perfect"; 
                ScoreController.ScorePerfect();
            } else if (dif < .2) { 
                hitCategory.text = "Great"; 
                ScoreController.ScoreGreat();
            } else { 
                hitCategory.text = "Good";
                ScoreController.ScoreGood();
                ScoreController.BreakCombo();
            }

            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other) { if (other.gameObject.tag == "Input") enter = true;}
}
