using UnityEngine;
using UnityEngine.UI;

public class GachaBanner : MonoBehaviour
{
    public int direction = 0;
    public bool isMain;

    [SerializeField]
    
    public BannerType bannerType = BannerType.CHARACTER;
    RectTransform rt;


    public RawImage rawImage;
    public Texture2D[] bannerImages;

    public int index = 0;
    public float switchTimer = 0;
    public float switchInterval = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rt = GetComponent<RectTransform>();
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMain)
        {
            switchTimer += Time.deltaTime;

            if (switchTimer >= switchInterval) {
            switchTimer = 0;
            index = (index + 1) % bannerImages.Length;
            rawImage.texture = bannerImages[index];
            }
        }
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
        direction = dir;
        isMain = main;
    }
public enum BannerType
{
    CHARACTER,
    FOOD
}
}

public static class BannerTypeExtensions
{
    public static string name(this GachaBanner.BannerType t)
    {
        switch (t)
        {
            case GachaBanner.BannerType.CHARACTER: return "Character Banner";
            case GachaBanner.BannerType.FOOD:    return "Food Banner";
            default:                 return t.ToString();
        }
    }
}