using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TimeControllerCH : MonoBehaviour
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
        for (int i = 0; i < NoteSpawnerCH.notes.Count; i++) { 
            if (NoteSpawnerCH.prefabs[i] != null) {
                NoteSpawnerCH.prefabs[i].transform.position 
                        = new Vector3(NoteSpawnerCH.notes[i].prefab.transform.position.x, NoteSpawnerCH.notes[i].prefab.transform.position.y, 40 * (NoteSpawnerCH.notes[i].impactTime-CTIME)+NoteSpawnerCH.notes[i].scale.z/2);
            }
        }
        CTIME = _audioSource.time;
    }
}
