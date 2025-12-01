using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TimeControllerCE : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public static float CTIME = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { _audioSource.Play(); }

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
}
