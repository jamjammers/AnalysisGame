using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    private static float  SONGLENGTH = 138.423f;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _currentTime;
    [SerializeField] private TextMeshProUGUI _totalTime;
    [SerializeField] private TextMeshProUGUI _globalTime;
    [SerializeField] private AudioSource _audioSource;
    private float t;
    private bool oldK;
    private string state = "pause";

    public static float CTIME = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource.Play();
        // _slider.onValueChanged.AddListener((v) =>
        // {
        //     CTIME = v * SONGLENGTH;
        //     _audioSource.Stop();
        //     // if ((int)CTIME%60 < 10) {_currentTime.text = ((int)(CTIME / 60)).ToString() + ":0" + ((int)(100*CTIME%6000)).ToString();}
        //     // else{_currentTime.text = ((int)(CTIME/ 60)).ToString() + ":" + ((int)(CTIME*100%6000)).ToString();}
        //     state = "pause";

        //     for (int i = 0; i < NoteSpawner.notes.Count; i++) { 
        //         NoteSpawner.prefabs[i].transform.position 
        //                 = new Vector3(NoteSpawner.notes[i].prefab.transform.position.x, NoteSpawner.notes[i].prefab.transform.position.y, 40 * (NoteSpawner.notes[i].impactTime-CTIME)+NoteSpawner.notes[i].scale.z/2);
        //     }
        // });
        // _totalTime.text = "/ " + ((int)(SONGLENGTH/60)).ToString() + ":" + ((int)SONGLENGTH%60).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.K) && !oldK) {
        //     switch (state) {
        //         case "pause":
        //             state = "play";
        //             PlayAudio(CTIME);
        //             break;
        //         case "play":
        //             for (int i = 0; i < NoteSpawner.notes.Count; i++) { 
        //                 NoteSpawner.prefabs[i].transform.position 
        //                         = new Vector3(NoteSpawner.notes[i].prefab.transform.position.x, NoteSpawner.notes[i].prefab.transform.position.y, 40 * (NoteSpawner.notes[i].impactTime-CTIME)+NoteSpawner.notes[i].scale.z/2);
        //             }
        //             state = "pause";
        //             break;
        //     }
        // }

        // oldK = Input.GetKeyDown(KeyCode.K);
        
        // switch (state) {
        //     case "pause":
        //         _audioSource.Stop();
        //         break;
        //     case "play":
                    for (int i = 0; i < NoteSpawner.notes.Count; i++) { 
                        if (NoteSpawner.prefabs[i] != null) {
                            NoteSpawner.prefabs[i].transform.position 
                                    = new Vector3(NoteSpawner.notes[i].prefab.transform.position.x, NoteSpawner.notes[i].prefab.transform.position.y, 40 * (NoteSpawner.notes[i].impactTime-CTIME)+NoteSpawner.notes[i].scale.z/2);
                        }
                    }
        //         break;
        // }

        // t += Time.deltaTime;
        // if ((int)t%60 < 10) {_globalTime.text = ((int)(t/60)).ToString() + ":0" + ((int)t%60).ToString();}
        // else{_globalTime.text = ((int)(t/ 60)).ToString() + ":" + ((int)t%60).ToString();}

        if(_audioSource.isPlaying) {
            CTIME = _audioSource.time;
            // if ((int)CTIME%60 < 10) {_currentTime.text = ((int)(CTIME / 60)).ToString() + ":0" + ((int)(CTIME*100%6000)).ToString();}
            // else{_currentTime.text = ((int)(CTIME/ 60)).ToString() + ":" + ((int)(CTIME*100%6000)).ToString();}            
        }

    }
    // void PlayAudio(float time)
    // {        
    //     _audioSource.time = time;
    //     _audioSource.Play();
    // }
}
