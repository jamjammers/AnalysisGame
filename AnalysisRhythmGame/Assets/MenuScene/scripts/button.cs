using TMPro;
using Unity.IntegerTime;
using UnityEngine;

public class button : MonoBehaviour
{
    public RectTransform tmpGUI;
    public bool startHidden;

    Vector3 location;
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
