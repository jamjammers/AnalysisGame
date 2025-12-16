using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionSingle : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private TextMeshProUGUI hitCategory;
    [SerializeField] private AudioSource hitEffect;
    private bool hit = false;
    private bool enter = false;

    private float timeKeyPressed = 0f; //time
    private float timeAfterEnter = 0f; //time since it was enabled to be hit

    private float speed = NoteSpawner.spd;

    public void Update()
    {
        if (transform.position.z < speed / 2 && Input.GetKeyDown(KeyMapping.keyMap[key]))
        {
            hit = true; hitEffect.Play();
        }
        if (hit) { timeKeyPressed += Time.deltaTime; }
        if (enter) { timeAfterEnter += Time.deltaTime; }

        if (transform.position.z < -speed / 4 && !hit)
        {
            Destroy(gameObject);
            hitCategory.text = "Miss";
            ScoreController.ScoreMiss();
        }

        if (hit && enter)
        {
            float dif = Math.Abs(timeAfterEnter - timeKeyPressed);
            if (dif < 0.05)
            {
                hitCategory.text = "Perfect";
                ScoreController.ScorePerfect();
            }
            else if (dif < .2)
            {
                hitCategory.text = "Great";
                ScoreController.ScoreGreat();
            }
            else
            {
                hitCategory.text = "Good";
                ScoreController.ScoreGood();
            }

            Destroy(gameObject);
        }
        /*
                if (timeAfterEnter > .5) { 
                    hitCategory.text = "Miss";
                    ScoreController.ScoreMiss();
                }
        */
    }

    public void OnTriggerEnter(Collider other)
    {
        enter = other.gameObject.tag == "Input" ? true : enter;
    }
}
