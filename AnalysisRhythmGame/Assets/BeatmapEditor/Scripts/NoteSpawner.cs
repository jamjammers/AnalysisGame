using System;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject[] originals;
    public static List<GameObject> prefabs = new List<GameObject>();
    public static List<Note> notes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notes = new List<Note> {
            // new Note(prefabs[(int) Indexes.D], false, 2.8235f, 2.8235f, 0)
            // new(prefabs[(int) Indexes.K], false, 3.176f, 3.176f, 1), 
            // new(prefabs[(int) Indexes.F], false, 3.529f, 3.529f, 2), 
            // new(prefabs[(int) Indexes.J], false, 3.882f, 3.882f, 3), 
            // new(prefabs[(int) Indexes.J], false, 4.235f, 4.235f, 4), 
            // new(prefabs[(int) Indexes.F], false, 4.588f, 4.588f, 5), 
            // new(prefabs[(int) Indexes.D], false, 4.941f, 4.941f, 6), 
            // new(prefabs[(int) Indexes.D], false, 5.294f, 5.294f, 7), 
            // new(prefabs[(int) Indexes.K], false, 5.294f, 5.294f, 8), 

            // new(prefabs[(int) Indexes.L], true, 5.647f, 8.117f, 9), 
            // new(prefabs[(int) Indexes.K], false, 5.647f, 5.647f, 10), 
            // new(prefabs[(int) Indexes.K], false, 6f, 6f, 11), 
            // new(prefabs[(int) Indexes.J], false, 6.352f, 6.352f, 12), 
            // new(prefabs[(int) Indexes.D], false, 6.7058f, 6.7058f, 13), 
            // new(prefabs[(int) Indexes.S], true, 7.0588f, 8.117f, 14), 
            // new(prefabs[(int) Indexes.D], false, 7.4117f, 7.4117f, 15), 
            // new(prefabs[(int) Indexes.F], false, 7.588f, 7.588f, 16), 
            // new(prefabs[(int) Indexes.J], false, 7.7647f, 7.7647f, 17), 
            // new(prefabs[(int) Indexes.K], false, 7.941f, 7.941f, 18), 
            // new(prefabs[(int) Indexes.ASEMI], false, 8.1176f, 8.1176f, 19) 
        };

        foreach (Note note in notes) { 
            GameObject curr = Instantiate(note.prefab, note.pos, note.prefab.transform.rotation); 
            curr.transform.localScale = note.scale;
            prefabs.Add(curr);
        }
    }

    // Update is called once per frame
    void Update() {
        foreach (Note note in notes) { Debug.Log("Impact Time: " + note.impactTime + "; Release Time: " + note.releaseTime + "; Is slider? " + note.isSlider); }
        Debug.Log("");
    }
}
