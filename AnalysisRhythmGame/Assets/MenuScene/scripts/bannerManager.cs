using UnityEngine;

public class banner : MonoBehaviour
{
    public int speed = 10;
    GameObject[] Banners;
    int selected = 0;
    int direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void next()
    {
        Banners[selected].GetComponent<Banner>().move(-speed, false);
        selected = (selected + 1) % Banners.Length;
        Banners[selected].GetComponent<Banner>().move(-speed, true);

    }
    void previous()
    {
        Banners[selected].GetComponent<Banner>().move(speed, false);
        selected = (selected - 1) % Banners.Length;
        Banners[selected].GetComponent<Banner>().move(speed, true);
    }
}
