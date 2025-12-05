
using UnityEngine;

public class CollectionScreen : BasicScreen
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public new void Show()
    {
        base.Show();
        gameObject.SetActive(true);
        foreach(GachaCard gc in Inventory.getCards())
        {
            
        }
    }
}