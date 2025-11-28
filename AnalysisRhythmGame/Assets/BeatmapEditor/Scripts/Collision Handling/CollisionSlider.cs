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
        } else if (time > transform.localScale.z/40*.9) { 
            hitCategory.text = "Perfect"; 
        } else if (time > transform.localScale.z/40*.8) { 
            hitCategory.text = "Great"; 
        } else if (time > transform.localScale.z/40*.7) { 
            hitCategory.text = "Good";
        }else {
            hitCategory.text = "Miss";
        }
        hit = false;
        time = 0f;
        Destroy(gameObject);
    }
}
