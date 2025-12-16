using UnityEngine;
using System.Collections.Generic;

public class GachaDisplay : MonoBehaviour
{
    public GameObject Collection;
    void Start()
    {
    }
    public void setUp(Texture2D img, Vector3 position, GameObject collection)
    {
        GetComponent<RectTransform>().anchoredPosition = position;
        transform.GetChild(0).GetComponent<UnityEngine.UI.RawImage>().texture = img;
        Collection = collection;
    }
}