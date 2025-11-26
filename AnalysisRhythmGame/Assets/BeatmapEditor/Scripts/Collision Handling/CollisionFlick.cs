using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionFlick : MonoBehaviour
{
    [SerializeField] private string key1;
    [SerializeField] private string key2;
    [SerializeField] private TextMeshProUGUI hitCategory;
    [SerializeField] private AudioSource hitEffect;
    private bool hit;
    private float time=0f;
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Hi");
        if (other.gameObject.tag == "Input") {
            if (Input.GetKeyDown(KeyMapping.keyMap[key1])) {
                time += Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyMapping.keyMap[key2]))
            {
                hit = true;
                hitEffect.Play();

                if (time < transform.localScale.z/40*.33) { 
                    hitCategory.text = "Perfect"; 
                } else if (time < transform.localScale.z/40*.67) { 
                    hitCategory.text = "Great"; 
                } else if (time < transform.localScale.z/40) { 
                    hitCategory.text = "Good";
                }
            }
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (!hit) { hitCategory.text = "Miss"; }
        hit = false;
        time = 0f;
        Debug.Log("Bye");
    }
}
