using TMPro;
using Unity.IntegerTime;
using UnityEngine;

public class BasicButton : MonoBehaviour
{
    public RectTransform tmpGUI;
    public bool startHidden;

    Vector3 location;

    //I don't actually know this is probably temp LOL
    void Start()
    {
        tmpGUI = GetComponent<RectTransform>();
        if(tmpGUI == null)
        {
            Destroy(this);
        }
        location = tmpGUI.position;
        if (startHidden)
        {
            hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void show()
    {
        tmpGUI.position = location;
    }

    public void hide()
    {
        Debug.Log("a");
        tmpGUI.position = new Vector3(-100,-100,-100);
    }
}
