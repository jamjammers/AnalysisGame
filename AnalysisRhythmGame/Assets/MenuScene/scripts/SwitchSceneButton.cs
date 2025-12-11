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
        GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene(sceneName, LoadSceneMode.Single));
    }
}
