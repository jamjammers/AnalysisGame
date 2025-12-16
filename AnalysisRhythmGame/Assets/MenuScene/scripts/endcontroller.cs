using UnityEngine;
using TMPro;
using System.Linq;

public class endcontroller : MonoBehaviour
{
    public GameObject perfText;
    public GameObject greatText;
    public GameObject goodText;
    public GameObject missText;
    public GameObject scoreText;
    public GameObject expText;
    public GameObject pullText;


    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ScoreController.gamed)
        {
            loadValues(ScoreController.score, ScoreController.perfect, ScoreController.great, ScoreController.good, ScoreController.miss);
        }
        else
        {
            target.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void loadValues(int score, int perfect, int great, int good, int miss)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        perfText.GetComponent<TextMeshProUGUI>().text = "Perfect: " + perfect;
        greatText.GetComponent<TextMeshProUGUI>().text = "Great: " + great;
        goodText.GetComponent<TextMeshProUGUI>().text = "Good: " + good;
        missText.GetComponent<TextMeshProUGUI>().text = "Miss: " + miss;

        float gain = Mathf.Max(Utilities.Normal(score, 10000), 0);
        expText.GetComponent<TextMeshProUGUI>().text = "Exp Gained: \n" + gain.ToString();
        Inventory.gainExp(gain);

        if(Buffs.team[0].name == "Fat Cat")
        {
            Inventory.addTicket();   
        }

        
    }
}