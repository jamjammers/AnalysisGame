using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RandomStageSelect : MonoBehaviour
{
    [SerializeField]
    private string[] stages;

    const float pullChance = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stageSelect()
    {
        string sceneName = stages[Random.Range(0, stages.Length)];
        if(Random.Range(0f, 1f) <= pullChance)
        {
            EndController.grantPull = true;
            
            float randVal = Random.Range(0f, 1f);
            if(randVal <= 0.5)
            {
                sceneName = stages[0];
            }
            else if(randVal <= 0.8)
            {
                sceneName = stages[1];
            }
            else
            {
                sceneName = stages[2];
            }
        }
        
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);;

    }
}
