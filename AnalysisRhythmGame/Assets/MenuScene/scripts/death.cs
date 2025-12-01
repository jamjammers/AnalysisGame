using UnityEngine;

public class death : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void die()
    {
        gameObject.SetActive(false);
    }
    public void hi()
    {
        gameObject.SetActive(true);
    }
}
