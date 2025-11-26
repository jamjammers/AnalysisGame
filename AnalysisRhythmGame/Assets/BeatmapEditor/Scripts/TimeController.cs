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

    public static float CTIME;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _slider.onValueChanged.AddListener((v) =>
        {
            CTIME = v * SONGLENGTH;
            _audioSource.Stop();
            if ((int)CTIME%60 < 10) {_currentTime.text = ((int)(CTIME / 60)).ToString() + ":0" + ((int)(100*CTIME%6000)).ToString();}
            else{_currentTime.text = ((int)(CTIME/ 60)).ToString() + ":" + ((int)(CTIME*100%60000)).ToString();}
            state = "pause";

        });
        _totalTime.text = "/ " + ((int)(SONGLENGTH/60)).ToString() + ":" + ((int)SONGLENGTH%60).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && !oldK) {
            switch (state) {
                case "pause":
                    state = "play";
                    PlayAudio(CTIME);
                    break;
                case "play":
                    state = "pause";
                    break;
            }
        }

        oldK = Input.GetKeyDown(KeyCode.K);
        
        switch (state) {
            case "pause":
                _audioSource.Stop();
                break;
            case "play":
                break;
        }

        t += Time.deltaTime;
        if ((int)t%60 < 10) {_globalTime.text = ((int)(t/60)).ToString() + ":0" + ((int)t%60).ToString();}
        else{_globalTime.text = ((int)(t/ 60)).ToString() + ":" + ((int)t%60).ToString();}

        if(_audioSource.isPlaying) {
            CTIME += Time.deltaTime;
            if ((int)CTIME%60 < 10) {_currentTime.text = ((int)(CTIME / 60)).ToString() + ":0" + ((int)(CTIME*100%60000)).ToString();}
            else{_currentTime.text = ((int)(CTIME/ 60)).ToString() + ":" + ((int)(CTIME*100%60000)).ToString();}            
        }

        foreach (Note note in NoteSpawner.notes) { 
            NoteSpawner.prefabs[note.index].transform.position 
                    = new Vector3(note.prefab.transform.position.x, note.prefab.transform.position.y, 40 * (note.impactTime-CTIME)+note.scale.z/2);
        }
    }
    void PlayAudio(float time)
    {        
        _audioSource.time = time;
        _audioSource.Play();
    }
}
