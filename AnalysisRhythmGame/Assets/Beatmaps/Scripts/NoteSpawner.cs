using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public static List<GameObject> prefabs = new List<GameObject>();
    public static List<Note> notes;
    public int spd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // setting beatmap to local List for usage
        notes = Beatmaps.NOTES;

        // instantiating game objects in {notes} and adding to List prefabs
        SpawnNotes(spd);
    }
    
    public void SpawnNotes(int speed)
    {
        foreach (Note note in notes) {  
            note.SetSpeed(speed);
            note.UpdateTransform();
            GameObject curr = Instantiate(note.prefab, note.pos, note.prefab.transform.rotation); 
            curr.transform.localScale = note.scale;
            prefabs.Add(curr);
        }
    }
}
