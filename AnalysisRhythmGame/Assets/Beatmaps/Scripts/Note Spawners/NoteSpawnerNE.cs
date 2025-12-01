using System;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnerNE : MonoBehaviour
{
    public GameObject[] originals;
    public static List<GameObject> prefabs = new List<GameObject>();
    public static List<Note> notes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notes = new List<Note> {
            new(originals[(int) Indexes.S], 2.43f+8*.2927f, 2.43f+11*.2927f), 
            new(originals[(int) Indexes.D], 2.43f+1*.2927f) 
        };

        foreach (Note note in notes) {  
            GameObject curr = Instantiate(note.prefab, note.pos, note.prefab.transform.rotation); 
            curr.transform.localScale = note.scale;
            prefabs.Add(curr);
        }
    }
}
