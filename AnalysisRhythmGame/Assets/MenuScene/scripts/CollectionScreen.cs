
using System.Collections.Generic;
using UnityEngine;

public class CollectionScreen : BasicScreen
{
    [SerializeField]
    GameObject GachaCardPrefab;

    public float cardSpacing = 85f;
    public Vector3 startPos = new Vector3(-342.5f, 90, 0);
    public float cols = 9;
    public float rows = 3;
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
        List<GachaCard> cardList = Inventory.getCards();
        for (int i = 0; i < cardList.Count; i++)
        {
            GameObject frame = Instantiate(GachaCardPrefab, new Vector3(i % cols, (int)(i / cols), 0) * cardSpacing + startPos, Quaternion.identity, transform);
            frame.GetComponent<GachaDisplay>().setImage(cardList[i].texture);
        }
    }
}