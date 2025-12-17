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

    private float speed = NoteSpawner.spd;
    private float keyEntryTolerance;

    public void Update()
    {
        if (transform.position.z - transform.localScale.z/2 < speed/2 && Input.GetKeyDown(KeyMapping.keyMap[key])) {t1 += Time.deltaTime; hit = true; }
        if (Input.GetKeyUp(KeyMapping.keyMap[key])) keyReleased = true;
        if (transform.position.z + transform.localScale.z/2 < speed/(-4)) {
            Destroy(gameObject);
            hitCategory.text = "Miss";
            ScoreController.BreakCombo();
        }

        if (exit && keyReleased)
        {
            float keyHeldVsNoteLength = Math.Abs(transform.localScale.z/speed-t1);
            Debug.Log("key entry tolerance: " + keyEntryTolerance + ", keyHeldVsNoteLength: " + keyHeldVsNoteLength);
            if (keyEntryTolerance > 1.5) { 
                hitCategory.text = "Miss"; 
                ScoreController.BreakCombo();
            } else if (keyEntryTolerance < 0.05 && keyHeldVsNoteLength < 0.15) { 
                hitCategory.text = "Perfect"; 
                ScoreController.ScorePerfect();
            } else if (keyEntryTolerance < .3 && keyHeldVsNoteLength < .3) { 
                hitCategory.text = "Great"; 
                ScoreController.ScoreGreat();
            } else { 
                hitCategory.text = "Good";
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
