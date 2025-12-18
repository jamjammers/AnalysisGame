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
    private float speed = BuffNumbers.spd;

    public void Update()
    {
        if (transform.position.z < speed/2 && Input.GetKeyDown(KeyMapping.keyMap[key1])) k1 = true;
        if (k1 && Input.GetKeyDown(KeyMapping.keyMap[key2])) {hit = true; hitEffect.Play(); t1 = 0; }
        if (hit) t1 += Time.deltaTime;
        if (enter) t2 += Time.deltaTime;
        if (transform.position.z < speed/(-4) && !hit) {
            Destroy(gameObject);
            hitCategory.text = "Miss";
            hitCategory.CrossFadeAlpha(1,.01f,false);
            if (BuffNumbers.bubbles && UnityEngine.Random.value < .65f) {
                // hi (do nothing)
            } else {ScoreController.BreakCombo();}
        }
        
        if (hit && enter)
        {
            float dif = Math.Abs(t2-t1);
            if (BuffNumbers.perf && dif < BuffNumbers.timingTolerance * 8) {
                hitCategory.text = "Perfect"; 
                hitCategory.CrossFadeAlpha(1,.01f,false);
                ScoreController.ScorePerfect();
            } else if (dif < BuffNumbers.timingTolerance) { 
                hitCategory.text = "Perfect"; 
                hitCategory.CrossFadeAlpha(1,.01f,false);
                ScoreController.ScorePerfect();
            } else if (dif < BuffNumbers.timingTolerance * 4) { 
                hitCategory.text = "Great"; 
                hitCategory.CrossFadeAlpha(1,.01f,false);
                ScoreController.ScoreGreat();
            } else { 
                hitCategory.text = "Good";
                hitCategory.CrossFadeAlpha(1,.01f,false);
                ScoreController.ScoreGood();
            }

            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other) { if (other.gameObject.tag == "Input") enter = true;}
    public void OnTriggerExit(Collider other) { if (other.gameObject.tag == "Input") {} }
}
