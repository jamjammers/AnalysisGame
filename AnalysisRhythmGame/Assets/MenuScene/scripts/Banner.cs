using UnityEngine;

public class Banner : MonoBehaviour
{
    public int direction = 0;
    public bool isMain = false;
    RectTransform rt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == 0) return;
        if (isMain)
        {
            if(rt.position.x * direction < 0)
            {
                rt.position = new Vector3(0,0,0);
                direction = 0;
            }
            rt.position += Vector3.right * Time.deltaTime * direction;
        }
        else
        {
            rt.position += Vector3.right * Time.deltaTime * direction;
            if(Mathf.Abs(rt.position.x) > 1100)
                direction = 0;
        }
    }
    public void move(int dir, bool main)
    {
        direction = dir;
        isMain = main;
    }
}
