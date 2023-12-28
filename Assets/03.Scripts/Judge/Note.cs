using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

using UnityEngine;

public class Note : MonoBehaviour
{
    public NotePool notePool;
    private float NoteSpeed;
    public int Difficulty;
    private float x;

    private void Start()
    {
        if (Difficulty == 0)
            NoteSpeed = 0;

        if (Difficulty == 1)
            NoteSpeed = -0.01f;

        if (Difficulty == 2)
            NoteSpeed = -0.03f;

        if (Difficulty == 3)
            NoteSpeed = -0.07f;
    }
    void Update()
    {
        GameObject note = notePool.GetNote();
        x = note.transform.position.x;
        note.transform.Translate(new Vector3(NoteSpeed, 0, 0), Space.Self);
        if(x <= -10f)
        {
            RemoveNote();
        }
    }

    private void RemoveNote()
{
        GameObject note = notePool.GetNote();
        x = 10f;
        note.gameObject.SetActive(false);
    }

}
