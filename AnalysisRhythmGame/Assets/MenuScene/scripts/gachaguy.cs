using UnityEngine.UI;
using UnityEngine;

public class gachaguy : MonoBehaviour
{

    public RawImage thing;
    public GameObject gf;
    public Gachafather father;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        father = gf.GetComponent<Gachafather>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thing.color.a > 0)
        {
            Color temp = thing.color;
            temp.a -= 0.01f;
            thing.color = temp;
        }
    }
    public void gacha()
    {
        if(Gachafather.pulls <= 0) return;
        Gachafather.pulls -= 1;
        int index = Random.Range(0, gachas.gachalist.Count);
        Debug.Log(index);
        thing.texture = gachas.gachalist[index].texture;
        father.gachaslist.Add(gachas.gachalist[index]);
        Color temp = thing.color;
        temp.a = 5f;
        thing.color = temp;
    }
}
