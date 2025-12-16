using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SocialPlatforms.Impl;

public class EndController : MonoBehaviour
{
    public GameObject perfText;
    public GameObject greatText;
    public GameObject goodText;
    public GameObject missText;
    public GameObject scoreText;
    public GameObject expText;
    public GameObject pullText;


    public GameObject target;

    public static bool gameJustCompleted = false;
    public static bool grantPull = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameJustCompleted)
        {
            gameJustCompleted = false;
            loadValues(ScoreController.score, ScoreController.perfect, ScoreController.great, ScoreController.good, ScoreController.miss);
            distributeRewards(ScoreController.score, ScoreController.perfect, ScoreController.great, ScoreController.good, ScoreController.miss);
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

        
    }
    void distributeRewards(int score, int perfect, int great, int good, int miss)
    {
        float expGain = Mathf.Max(Utilities.Normal(score, 10000), 0);
        expText.GetComponent<TextMeshProUGUI>().text = "Exp Gained: \n" + expGain.ToString();
        Inventory.gainExp(expGain);

        // if full combo -> eligible for guarentee
        if(ScoreController.maxCombo == ScoreController.totalNotes && Random.Range(0f, 1f)<=0.25f)
        {
            Inventory.setSecretGuarentee(true);
        }

        if (grantPull)
        {
            grantPull = false;
            Inventory.addPulls(1);
            pullText.GetComponent<TextMeshProUGUI>().text = "Pull Gained!";
        }


        if(Buffs.team[0].name == "Fat Cat")
        {
            Inventory.addTicket();   
        }

    }
}
