using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _comboText;
    [SerializeField] private TextMeshProUGUI hitCategory;
    public static int score = 0;
    private static int combo = 0;
    public static int maxCombo {get; private set;} = 0;
    public static int totalNotes {get; set;} = 0;

    public static int perfect = 0;
    public static int miss = 0;
    public static int good = 0;
    public static int great = 0;
    public static bool done = false;
    private float time = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // setting score+combo text
        _scoreText.text = score.ToString();
        _comboText.text = combo.ToString();
        
        // calling AddScore every .5s
        if (time > .1f)
        {
            AddScore();
            time -= .1f;
        }

        time += Time.deltaTime;

        hitCategory.CrossFadeAlpha(0,.5f,false);
    }

    public static void AddScore() { score += (int) BuffNumbers.scoreBuffs * (5 * combo + 5); }
    public static void AddCombo() { maxCombo = Mathf.Max(combo, maxCombo); combo += 1;}
    public static void ScorePerfect() { score += (int) (BuffNumbers.scoreBuffs * BuffNumbers.perfectBuff * 30); AddCombo(); perfect++; HPController.hp += 75+BuffNumbers.hpBonus;}
    public static void ScoreGreat() { score += (int) BuffNumbers.scoreBuffs * 10; AddCombo(); great++; HPController.hp += 50+BuffNumbers.hpBonus;}
    public static void ScoreGood() { score += (int) BuffNumbers.scoreBuffs * 5; AddCombo(); good++; combo = 0; HPController.hp += 25+BuffNumbers.hpBonus;}

    public static void BreakCombo() { 
        if (BuffNumbers.petals && UnityEngine.Random.value < .65f) {
            // do nothing
        } else {HPController.hp -= BuffNumbers.missValue;}
        maxCombo = Mathf.Max(combo, maxCombo); 
        combo = 0; 
        miss++; 
    }
    public static void ResetScore()
    {
        score = 0;
        combo = 0;
        perfect = 0;
        miss = 0;
        good = 0;
        great = 0;
    }
}
