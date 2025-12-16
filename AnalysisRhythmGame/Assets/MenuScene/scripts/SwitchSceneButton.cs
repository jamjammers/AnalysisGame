using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchSceneButton : MonoBehaviour
{
    public string sceneName = "Nadir Easy";

    void Start()
    {

    }
    void Awake()
    {
        
    }
    public void stageSelect()
    {
        EndController.grantPull = false;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);;
    }
}
