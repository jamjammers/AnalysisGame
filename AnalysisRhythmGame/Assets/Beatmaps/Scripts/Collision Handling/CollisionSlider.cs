using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionSlider : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private TextMeshProUGUI hitCategory;
    [SerializeField] private AudioSource hitEffect;
    [SerializeField] private float bpm;
    private bool hit = false;
    private bool exit = false;
    private bool keyReleased = false;
    private float t1=0f;
    private float scoreTiming=0f;
    private float speed = BuffNumbers.spd;
    private float keyEntryTolerance;

    public void Update()
    {
        if (transform.position.z - transform.localScale.z/2 < speed/2 && Input.GetKey(KeyMapping.keyMap[key])) {t1 += Time.deltaTime; hit = true; }
        if (Input.GetKeyUp(KeyMapping.keyMap[key])) keyReleased = true;
        if (transform.position.z + transform.localScale.z/2 < speed/(-4)) {
            Destroy(gameObject);
            hitCategory.text = "Miss";
            hitCategory.CrossFadeAlpha(1,.01f,false);
            if (BuffNumbers.bubbles && UnityEngine.Random.value < .65f) {
                // hi (do nothing)
            } else {ScoreController.BreakCombo();}
        }

        if (exit && keyReleased)
        {
            // Debug.Log("note length: " + transform.localScale.z/speed + ", key pressed length: " + t1);
            float keyHeldVsNoteLength = Math.Abs(transform.localScale.z/speed-t1);
            // Debug.Log("key entry tolerance: " + keyEntryTolerance + ", keyHeldVsNoteLength: " + keyHeldVsNoteLength);
            if (keyEntryTolerance > 1.5f) { 
                hitCategory.text = "Miss"; 
                hitCategory.CrossFadeAlpha(1,.01f,false);
                ScoreController.BreakCombo();
            } else if (BuffNumbers.perf && keyHeldVsNoteLength < .5) { 
                hitCategory.text = "Perfect"; 
                hitCategory.CrossFadeAlpha(1,.01f,false);
                ScoreController.ScorePerfect();
            } else if (keyEntryTolerance < BuffNumbers.timingTolerance && keyHeldVsNoteLength < 0.15) { 
                hitCategory.text = "Perfect"; 
                hitCategory.CrossFadeAlpha(1,.01f,false);
                ScoreController.ScorePerfect();
            } else if (keyEntryTolerance < BuffNumbers.timingTolerance * 4 && keyHeldVsNoteLength < .25) { 
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
    public void OnTriggerStay(Collider other) { 
        if (other.gameObject.tag == "Input" && hit) {
            // if (hit && !keyReleased) {
                scoreTiming += Time.deltaTime;
                if (scoreTiming > (60.0/(bpm*2)))
                {
                    hitEffect.Play();
                    hitCategory.text = "Perfect"; 
                    hitCategory.CrossFadeAlpha(1,.01f,false);
                    ScoreController.ScorePerfect();
                    scoreTiming = 0;
                }
            // }
        }
    }

    public void OnTriggerExit(Collider other) { if (other.gameObject.tag == "Input") exit = true;}
    public void OnTriggerEnter(Collider other)
    {
        keyEntryTolerance = Math.Abs((transform.position.z - transform.localScale.z/2)/speed-t1);
    }
}
