using UnityEngine;
using System.Collections.Generic;

public class GachaDisplay : MonoBehaviour
{
    public GameObject Collection;
    void Start()
    {
        Collection = transform.parent.gameObject;
    }
    public void setImage(Texture2D img)
    {
        GetComponent<UnityEngine.UI.RawImage>().texture = img;
    }
}