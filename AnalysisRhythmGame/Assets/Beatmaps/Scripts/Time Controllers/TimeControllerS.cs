using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TimeControllerS : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public static float CTIME = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { 
        _audioSource.Play(); 
        // ScoreController.end(_audioSource.clip.length + 5f);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NoteSpawnerS.notes.Count; i++) { 
            if (NoteSpawnerS.prefabs[i] != null) {
                NoteSpawnerS.prefabs[i].transform.position 
                        = new Vector3(NoteSpawnerS.notes[i].prefab.transform.position.x, NoteSpawnerS.notes[i].prefab.transform.position.y, 40 * (NoteSpawnerS.notes[i].impactTime-CTIME)+NoteSpawnerS.notes[i].scale.z/2);
            }
        }
        CTIME = _audioSource.time;
    }
}
