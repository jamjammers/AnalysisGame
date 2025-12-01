using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class TimeControllerNH : MonoBehaviour
{
    // private static float  SONGLENGTH = 138.423f;
    // [SerializeField] private Slider _slider;
    // [SerializeField] private TextMeshProUGUI _currentTime;
    // [SerializeField] private TextMeshProUGUI _totalTime;
    // [SerializeField] private TextMeshProUGUI _globalTime;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private GameObject scoreController;
    // private float t;
    // private bool oldK;
    // private string state = "pause";

    public static float CTIME = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _audioSource.Play();
        StartCoroutine(end(_audioSource.clip.length + 5f));

        // Debug.Log(_audioSource.clip.length);

        // _slider.onValueChanged.AddListener((v) =>
        // {
        //     CTIME = v * SONGLENGTH;
        //     _audioSource.Stop();
        //     if ((int)CTIME%60 < 10) {_currentTime.text = ((int)(CTIME / 60)).ToString() + ":0" + ((int)(100*CTIME%6000)).ToString();}
        //     else{_currentTime.text = ((int)(CTIME/ 60)).ToString() + ":" + ((int)(CTIME*100%6000)).ToString();}
        //     state = "pause";

        //     for (int i = 0; i < NoteSpawnerNH.notes.Count; i++) { 
        //         NoteSpawnerNH.prefabs[i].transform.position 
        //                 = new Vector3(NoteSpawnerNH.notes[i].prefab.transform.position.x, NoteSpawnerNH.notes[i].prefab.transform.position.y, 40 * (NoteSpawnerNH.notes[i].impactTime-CTIME)+NoteSpawnerNH.notes[i].scale.z/2);
        //     }
        // });
        // _totalTime.text = "/ " + ((int)(SONGLENGTH/60)).ToString() + ":" + ((int)SONGLENGTH%60).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space) && !oldK) {
        //     switch (state) {
        //         case "pause":
        //             state = "play";
        //             PlayAudio(CTIME);
        //             break;
        //         case "play":
        //             for (int i = 0; i < NoteSpawnerNH.notes.Count; i++) { 
        //                 NoteSpawnerNH.prefabs[i].transform.position 
        //                         = new Vector3(NoteSpawnerNH.notes[i].prefab.transform.position.x, NoteSpawnerNH.notes[i].prefab.transform.position.y, 40 * (NoteSpawnerNH.notes[i].impactTime-CTIME)+NoteSpawnerNH.notes[i].scale.z/2);
        //             }
        //             state = "pause";
        //             break;
        //     }
        // }

        // oldK = Input.GetKeyDown(KeyCode.Space);
        
        // switch (state) {
        //     case "pause":
        //         _audioSource.Stop();
        //         break;
        //     case "play":
                    for (int i = 0; i < NoteSpawnerNH.notes.Count; i++) { 
                        if (NoteSpawnerNH.prefabs[i] != null) {
                            NoteSpawnerNH.prefabs[i].transform.position 
                                    = new Vector3(NoteSpawnerNH.notes[i].prefab.transform.position.x, NoteSpawnerNH.notes[i].prefab.transform.position.y, 40 * (NoteSpawnerNH.notes[i].impactTime-CTIME)+NoteSpawnerNH.notes[i].scale.z/2);
                        }
                    }
        //         break;
        // }

        // t += Time.deltaTime;
        // if ((int)t%60 < 10) {_globalTime.text = ((int)(t/60)).ToString() + ":0" + ((int)t%60).ToString();}
        // else{_globalTime.text = ((int)(t/ 60)).ToString() + ":" + ((int)t%60).ToString();}

        // if(_audioSource.isPlaying) {
            CTIME = _audioSource.time;
        //     if ((int)CTIME%60 < 10) {_currentTime.text = ((int)(CTIME / 60)).ToString() + ":0" + ((int)(CTIME*100%6000)).ToString();}
        //     else{_currentTime.text = ((int)(CTIME/ 60)).ToString() + ":" + ((int)(CTIME*100%6000)).ToString();}            
        // }

    }
    void PlayAudio(float time)
    {        
        _audioSource.time = time;
        _audioSource.Play();
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
