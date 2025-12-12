
using System.Collections.Generic;
using UnityEngine;

public class CollectionScreen : BasicScreen
{
    [SerializeField]
    GameObject GachaCardPrefab;

    public float cardSpacing = 85f;
    public Vector3 startPos = new Vector3(-342.5f, 90, 0);
    public int cols = 9;
    public int rows = 3;


    int index = 0;
    bool debugMode = true;
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
    }
    public void addCard(GachaCard gachaCard)
    {
        GameObject frame = Instantiate(GachaCardPrefab, transform);
        Vector3 position = new Vector3(index % cols, (index / cols), 0) * cardSpacing + startPos;

        frame.GetComponent<GachaDisplay>().setUp(gachaCard.texture, position, gameObject);
        index++;
    }
}