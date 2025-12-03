using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public static List<GameObject> prefabs = new List<GameObject>();
    public static List<Note> notes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // setting beatmap to local List for usage
        notes = Beatmaps.NOTES;

        // instantiating game objects in {notes} and adding to List prefabs
        foreach (Note note in notes) {  
            GameObject curr = Instantiate(note.prefab, note.pos, note.prefab.transform.rotation); 
            curr.transform.localScale = note.scale;
            prefabs.Add(curr);
        }
    }
}
