using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionSlider : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private string key;
    [SerializeField] private TextMeshProUGUI hitCategory;
    [SerializeField] private AudioSource hitEffect;
    private bool hit;
    private float time=0f;
    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Input") {
            if (Input.GetKey(KeyMapping.keyMap[key])) {
                time += Time.deltaTime;
                hitEffect.Play();
                hit = true;
            }
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (!hit) { 
            hitCategory.text = "Miss"; 
            ScoreController.BreakCombo();
        } else if (time > transform.localScale.z/40*.9) { 
            hitCategory.text = "Perfect"; 
            ScoreController.ScorePerfect();
        } else if (time > transform.localScale.z/40*.8) { 
            hitCategory.text = "Great"; 
            ScoreController.ScoreGreat();
        } else if (time > transform.localScale.z/40*.7) { 
            hitCategory.text = "Good";
            ScoreController.ScoreGood();
        }else {
            hitCategory.text = "Miss";
            ScoreController.BreakCombo();
        }
        Destroy(gameObject);
    }
}
