using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    bool m_SceneLoaded;
    public string sceneName = "Nadir Easy";

void Start()
    {

    }
    void Awake()
    {
        // Outputs the current active Scene to the console

            // Call the LoadScene2Button() function when this Button is clicked
        this.GetComponent<Button>().onClick.AddListener(LoadSceneButton);
        
    }

    // Load the Scene when this Button is pressed
    void LoadSceneButton()
    {
        // Check that the second Scene hasn't been added yet
        if (m_SceneLoaded == false){
            // Loads the second Scene
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

            // Outputs the name of the current active Scene.
            // Notice it still outputs the name of the first Scene

            // The Scene has been loaded, exit this method
            m_SceneLoaded = true;
            // Set Scene2 as the active Scene
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

            // Ouput the name of the active Scene
            // See now that the name is updated
        }
    }

}
