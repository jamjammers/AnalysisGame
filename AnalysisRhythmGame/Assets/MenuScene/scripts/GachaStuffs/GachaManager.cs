using UnityEngine;

public class GachaManager : MonoBehaviour
{
    public int speed = 10;
    public GameObject[] Banners;
    public GameObject nextButton;
    public GameObject previousButton;
    int selected = 0;
    public void next()
    {
        if(selected >= Banners.Length - 1) return;
        GameObject prevBanner = Banners[selected];
        Banners[selected].GetComponent<GachaBanner>().move(-speed, false);
        selected = selected + 1;
        Banners[selected].GetComponent<GachaBanner>().move(-speed, true, prevBanner.GetComponent<RectTransform>().anchoredPosition.x);
        if(selected == Banners.Length - 1)
        {
            nextButton.SetActive(false);
        }
        if(selected == 1)
        {
            previousButton.SetActive(true);
        }
    }
    public void previous()
    {
        if(selected <= 0) return;
        GameObject prevBanner = Banners[selected];
        Banners[selected].GetComponent<GachaBanner>().move(speed, false);
        selected = selected-1;
        Banners[selected].GetComponent<GachaBanner>().move(speed, true, prevBanner.GetComponent<RectTransform>().anchoredPosition.x);
        if(selected == 0)
        {
            previousButton.SetActive(false);
        }
        if(selected == Banners.Length - 2)
        {
            nextButton.SetActive(true);
        }
    }
    public GachaBanner.BannerType getBannerType()
    {
        return Banners[selected].GetComponent<GachaBanner>().bannerType;
    }
}
