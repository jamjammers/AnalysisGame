using UnityEngine;

public class Banner : MonoBehaviour
{
    public int direction = 0;
    public bool isMain = false;

    [SerializeField]
    public BannerType bannerType {get;} = BannerType.REGULAR;
    RectTransform rt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rt = GetComponent<RectTransform>();
        Debug.Log(rt.anchoredPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == 0) return;
        if (isMain)
        {
            if(rt.anchoredPosition.x * ( direction/Mathf.Abs(direction)) > 0)
            {
                rt.position = new Vector3(0,0,0);
                direction = 0;
            }
            rt.position += Vector3.right * Time.deltaTime * direction;
        }
        else
        {
            rt.position += Vector3.right * Time.deltaTime * direction;
            if(rt.anchoredPosition.x * (direction/Mathf.Abs(direction)) > 800){
                direction = 0;
            }
        }
    }
    public void move(int dir, bool main, float offset = 0)
    {
        if (main)
        {
            rt.anchoredPosition = new Vector3(800 * -dir / Mathf.Abs(dir) + offset, 0, 0);
        }
        else
        {
            // rt.anchoredPosition = new Vector3(-dir / Mathf.Abs(dir) * 800,0,0);
        }
        direction = dir;
        isMain = main;
    }
    public enum BannerType
    {
        REGULAR,
        FOOD
    }
}
