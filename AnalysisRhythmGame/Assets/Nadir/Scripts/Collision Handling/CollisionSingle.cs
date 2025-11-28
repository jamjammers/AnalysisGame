using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionSingle : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private string key;
    [SerializeField] private TextMeshProUGUI hitCategory;
    [SerializeField] private AudioSource hitEffect;
    private bool hit;
    private float time=0f;
    public void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;

        if (other.gameObject.tag == "Input") {
            if (Input.GetKeyDown(KeyMapping.keyMap[key])) {
                hit = true;
                hitEffect.Play();
            }
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (!hit) { 
            hitCategory.text = "Miss"; 
            ScoreController.BreakCombo();
        } else if (time < transform.localScale.z/40*.5) { 
            hitCategory.text = "Perfect"; 
            ScoreController.ScorePerfect();
        } else if (time < transform.localScale.z/40*.75) { 
            hitCategory.text = "Great"; 
            ScoreController.ScoreGreat();
        } else if (time < transform.localScale.z/40) { 
            hitCategory.text = "Good";
            ScoreController.ScoreGood();
        }
        Destroy(gameObject);
    }
}
