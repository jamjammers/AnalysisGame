using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeControllerCE : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public static float CTIME = 0f;
    [SerializeField] private GameObject scoreController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { 
        _audioSource.Play();                 
        StartCoroutine(end(_audioSource.clip.length + 5f));

}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NoteSpawnerCE.notes.Count; i++) { 
            if (NoteSpawnerCE.prefabs[i] != null) {
                NoteSpawnerCE.prefabs[i].transform.position 
                        = new Vector3(NoteSpawnerCE.notes[i].prefab.transform.position.x, NoteSpawnerCE.notes[i].prefab.transform.position.y, 40 * (NoteSpawnerCE.notes[i].impactTime-CTIME)+NoteSpawnerCE.notes[i].scale.z/2);
            }
        }
        CTIME = _audioSource.time;
    }

    public IEnumerator end(float delay)
    {
        Debug.Log(delay);
        yield return new WaitForSeconds(delay);
        ScoreController.gamed = true;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        ScoreController.done = true;

        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        // Set Scene2 as the active Scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));

        // Ouput the name of the active Scene
        // See now that the name is updated
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
    }
}
