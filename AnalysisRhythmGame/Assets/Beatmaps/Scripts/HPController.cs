using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField] private Slider HPSlider;
    public static int hp;
    private static float tickTime = 0;
    private int MAXHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MAXHP = 1000 + BuffNumbers.hpBoost;
        hp = MAXHP;
    }

    // Update is called once per frame
    void Update()
    {
        tickTime += Time.deltaTime;

        if (tickTime > TimeController.waitTime) 
        {
            hp -= BuffNumbers.hpLoss;
            tickTime -= .1f;
        }

        if (hp > MAXHP) hp = MAXHP;

        if (hp < 0) {
            // TODO: exit song
            StartCoroutine(TimeController.end(0));
            return;
        }
        HPSlider.value = hp;
    }
}
