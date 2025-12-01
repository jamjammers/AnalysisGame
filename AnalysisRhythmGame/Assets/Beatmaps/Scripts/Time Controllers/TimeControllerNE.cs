using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TimeControllerNE : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public static float CTIME = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { _audioSource.Play();         
    // scoreController.end(_audioSource.clip.length + 5f);
}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NoteSpawnerNE.notes.Count; i++) { 
            if (NoteSpawnerNE.prefabs[i] != null) {
                NoteSpawnerNE.prefabs[i].transform.position 
                        = new Vector3(NoteSpawnerNE.notes[i].prefab.transform.position.x, NoteSpawnerNE.notes[i].prefab.transform.position.y, 40 * (NoteSpawnerNE.notes[i].impactTime-CTIME)+NoteSpawnerNE.notes[i].scale.z/2);
            }
        }
        CTIME = _audioSource.time;
    }
}
