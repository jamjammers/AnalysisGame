using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

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
        if(ScoreController.gamed){
            e(ScoreController.score, ScoreController.perfect, ScoreController.great, ScoreController.good, ScoreController.miss);   
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


    public void e(int score, int perfect, int great, int good, int miss)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        perfText.GetComponent<TextMeshProUGUI>().text = "Perfect: " + perfect;
        greatText.GetComponent<TextMeshProUGUI>().text = "Great: " + great;
        goodText.GetComponent<TextMeshProUGUI>().text = "Good: " + good;
        missText.GetComponent<TextMeshProUGUI>().text = "Miss: " + miss;

        float gain = Mathf.Max(NextGaussian(score, 10000),0);
        expText.GetComponent<TextMeshProUGUI>().text = "Exp Gained: \n" + gain.ToString();
        Gachafather.exp += gain;

        int count = (int)Mathf.Floor(10 * perfect / (perfect + great + good + miss + 1));
        int pull = 0;
        for(int i = 0; i < count; i++)
        {
            if(random.NextDouble() < 0.1)
            {
                pull++;
            }
        }
        pullText.GetComponent<TextMeshProUGUI>().text = "Pulls recieved: \n" + (pull.ToString());
        Gachafather.pulls += pull;
    
    
        
    }
    private System.Random random = new System.Random();
    
    public float NextGaussian(double mean = 0, double stdDev = 1)
    {
        double u1 = 1.0 - random.NextDouble();
        double u2 = 1.0 - random.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * 
                               Math.Sin(2.0 * Math.PI * u2);
        return (float) (mean + stdDev * randStdNormal);
    }
}