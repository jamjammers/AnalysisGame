using TMPro;
using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class button : MonoBehaviour
{
    public float rate = 1;
    public int direction = 0;

    public TextMeshProUGUI tmpGUI;
    void Start()
    {
        tmpGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction != 0)
        {
            tmpGUI.alpha += rate * direction * Time.deltaTime;
        }
        if (tmpGUI.alpha > 1)
        {
            tmpGUI.alpha = 1;
        }
        else if (tmpGUI.alpha < 0)
        {
            tmpGUI.alpha = 0;
        }
    }
    public void show()
    {
        direction = 1;
    }
    public void hide()
    {
        direction = -1;
    }
}
