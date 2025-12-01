using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _comboText;
    private static int score = 0;
    private static int combo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddScore();
    }

    // Update is called once per frame
    void Update()
    {
        AddScore();

        _scoreText.text = score.ToString();
        _comboText.text = combo.ToString();
    }

    public static void AddScore() { score += 10 * combo + 10; }
    public static void BreakCombo() { combo = 0; }
    public static void AddCombo() { combo += 1; }
    public static void ScorePerfect() { score += 300; AddCombo(); }
    public static void ScoreGreat() { score += 100; AddCombo(); }
    public static void ScoreGood() { score += 50; AddCombo(); }
}
