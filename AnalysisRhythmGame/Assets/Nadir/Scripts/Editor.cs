using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Editor : MonoBehaviour 
{
    public int index;
    private string type;
    private float startTime;
    private float endTime;
    private Indexes key;
    private bool isSlider;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_InputField start;
    [SerializeField] private TMP_InputField end;
    [SerializeField] private GameObject[] prefabs;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // index = NoteSpawner.notes.Count+1;
    }

    public void NoteType()
    {
        type = dropdown.options[dropdown.value].text;
        // this is goofy
        switch (type) {
            case "s":
                key = Indexes.S;
                isSlider = true;
                break;
            case "d":
                key = Indexes.D;
                isSlider = false;
                break;
            case "f":
                key = Indexes.F;
                isSlider = false;
                break;
            case "j":
                key = Indexes.J;
                isSlider = false;
                break;
            case "k":
                key = Indexes.K;
                isSlider = false;
                break;
            case "l":
                key = Indexes.L;
                isSlider = true;
                break;
            case "a;":
                key = Indexes.ASEMI;
                isSlider = false;
                break;
            case ";a":
                key = Indexes.SEMIA;
                isSlider = false;
                break;
            case " a":
                key = Indexes.SPACEA;
                isSlider = false;
                break;
            case "a ":
                key = Indexes.ASPACE;
                isSlider = false;
                break;
            case " ;":
                key = Indexes.SPACESEMI;
                isSlider = false;
                break;
            case "; ":
                key = Indexes.SEMISPACE;
                isSlider = false;
                break;
        }
    }
 
    public void EditStart() { startTime = float.Parse(start.text); }
    public void EditEnd() { endTime = float.Parse(end.text); }

    public void Change()
    {
        // if (isSlider) {
        //     Note note = new Note(prefabs[(int) key], startTime, endTime);
        // } else {
        //     Note note = new Note(prefabs[(int) key], startTime);
        // }

        // NoteSpawner.notes.Insert(index, note);
        // NoteSpawner.notes.RemoveAt(index+1);

        // GameObject curr = Instantiate(note.prefab, note.pos, note.prefab.transform.rotation); 
        // curr.transform.localScale = note.scale;
        // NoteSpawner.prefabs.Insert(index, curr);
        // NoteSpawner.prefabs.RemoveAt(index+1);
    }

    public void Add()
    {
        // if (isSlider) {
        //     Note note = new Note(prefabs[(int) key], startTime, endTime);
        // } else {
        //     Note note = new Note(prefabs[(int) key], startTime);
        // }

        // NoteSpawner.notes.Add(note);

        // GameObject curr = Instantiate(note.prefab, note.pos, note.prefab.transform.rotation); 
        // curr.transform.localScale = note.scale;
        // NoteSpawner.prefabs.Add(curr);

        // index++;
    }
    public void Delete()
    {
        
    }

}
