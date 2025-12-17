using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public static List<GameObject> prefabs = new List<GameObject>();
    public static List<Note> notes;
    public static float spd = 40f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // setting beatmap to local List for usage
        notes = Beatmaps.NOTES;
        ScoreController.totalNotes = notes.Count;
        // instantiating game objects in {notes} and adding to List prefabs
        SpawnNotes(spd);
    }
    
    public void SpawnNotes(float speed)
    {
        foreach (Note note in notes) {  
            note.SetSpeed(speed);
            note.UpdateTransform();
            GameObject curr = Instantiate(note.prefab, note.startPos, note.prefab.transform.rotation); 
            curr.transform.localScale = note.scale;
            prefabs.Add(curr);
        }
    }
}
