using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionSlider : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private TextMeshProUGUI hitCategory;
    [SerializeField] private AudioSource hitEffect;
    private bool hit = false;
    private bool exit = false;
    private bool keyReleased = false;
    private float t1=0f;
    private float t2=0f;

    public void Update()
    {
        if (transform.position.z - transform.localScale.z/2 < 20 && Input.GetKeyDown(KeyMapping.keyMap[key])) { hit = true; }
        if (hit) {
            t1 += Time.deltaTime; 
            if ((int) (t1*100)%15 == 0)
            {
                hitEffect.Play();
            }
        }
        if (Input.GetKeyUp(KeyMapping.keyMap[key])) {keyReleased = true; hitEffect.Play(); }
        if (exit && keyReleased)
        {
            float dif1 = Math.Abs(transform.localScale.z/40-t1);
            float dif2 = Math.Abs(t2-t1);
            Debug.Log("Dif: " + dif1 + ", dif2: " + dif2 + ", t1: " + t1 + ", t2: " + t2);
            if (!hit || dif1 > 1.5) { 
                hitCategory.text = "Miss"; 
                ScoreController.BreakCombo();
            } else if (dif1 < 0.5 && dif2 < 0.15) { 
                hitCategory.text = "Perfect"; 
                ScoreController.ScorePerfect();
            } else if (dif1 < .3 && dif2 < .3) { 
                hitCategory.text = "Great"; 
                ScoreController.ScoreGreat();
            } else { 
                hitCategory.text = "Good";
                ScoreController.ScoreGood();
            }
            // Destroy(gameObject);
        }
    }
    public void OnTriggerStay(Collider other) { if (other.gameObject.tag == "Input") {t2 += Time.deltaTime;} }

    public void OnTriggerExit(Collider other) { if (other.gameObject.tag == "Input") {exit = true;} }
}
