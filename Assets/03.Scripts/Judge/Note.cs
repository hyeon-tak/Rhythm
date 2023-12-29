using System.Collections;

using UnityEngine;
using UnityEngine.Events;

public class Note : MonoBehaviour
{
    public UnityEvent OnNoteHit;
    public UnityEvent OnNoteMiss;

    public int Difficulty;
    private float noteSpeed;

    void Start()
    {
        SetNoteSpeedByDifficulty();
    }

    private void SetNoteSpeedByDifficulty()
    {
        switch (Difficulty)
        {
            case 0:
                noteSpeed = 0f;
                break;
            case 1:
                noteSpeed = -0.03f;
                break;
            case 2:
                noteSpeed = -0.05f;
                break;
            case 3:
                noteSpeed = -0.08f;
                break;
        }
    }

    void Update()
    {
        MoveNote();
        if (IsNoteOffScreen())
        {
            RemoveNote();
        }
    }

    private void CheckNoteInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnNoteHit.Invoke();
        }
    }

    private void MoveNote()
    {
        transform.Translate(new Vector3(noteSpeed, 0, 0), Space.World);
    }

    private bool IsNoteOffScreen()
    {
        return transform.position.x <= -10f;
    }

    public void RemoveNote()
    {
        gameObject.SetActive(false);
    }
}
