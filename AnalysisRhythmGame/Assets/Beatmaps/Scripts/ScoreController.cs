using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _comboText;
    public static int score = 0;
    private static int combo = 0;

    public static int perfect = 0;
    public static int miss = 0;
    public static int good = 0;
    public static int great = 0;
    public static bool gamed = false;
    public static bool done = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddScore();
        gamed = true;
    }

    // Update is called once per frame
    void Update()
    {
        AddScore();

        _scoreText.text = score.ToString();
        _comboText.text = combo.ToString();
    }

    public static void AddScore() { score += 10 * combo + 10; }
    public static void BreakCombo() { combo = 0; miss++;}
    public static void AddCombo() { combo += 1; miss++;}
    public static void ScorePerfect() { score += 300; AddCombo(); perfect++;}
    public static void ScoreGreat() { score += 100; AddCombo(); great++;}
    public static void ScoreGood() { score += 50; AddCombo(); good++;}

    public static void ResetScore()
    {
        score = 0;
        combo = 0;
        perfect = 0;
        miss = 0;
        good = 0;
        great = 0;
    }
    public IEnumerator end(float delay)
    {
        Debug.Log(delay);
        yield return new WaitForSeconds(delay);


        // Loads the second Scene
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

        // Outputs the name of the current active Scene.
        // Notice it still outputs the name of the first Scene
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);

        // Set Scene2 as the active Scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));

        // Ouput the name of the active Scene
        // See now that the name is updated
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
    }
}
