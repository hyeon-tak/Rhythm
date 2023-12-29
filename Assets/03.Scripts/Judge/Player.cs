using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private int Point;
    public int Combo;
    private int Score;
    public GameObject noteOBJ;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ComboText;
    public Note note;
    bool collisionDetected = false;

    private void Start()
    {
        ComboText.gameObject.SetActive(false);

        // Note 클래스의 이벤트에 대한 리스너 등록
        if (note != null)
        {
            note.OnNoteHit.AddListener(HandleNoteHit);
            note.OnNoteMiss.AddListener(HandleNoteMiss);
        }
    }

    private void HandleNoteHit()
    {
        Combo++;
        Point = 120;
        ScoreCalc();
        UpdateScore();
        UpdateComboText();
    }

    private void HandleNoteMiss()
    {
        Combo = 0;
        Point = 0;
        ScoreCalc();
        UpdateScore();
        UpdateComboText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collisionDetected)
            {
                HandleNoteHit();
            }
            else
            {
                HandleNoteMiss();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collisionDetected = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionDetected = false;
    }

    public void UpdateComboText()
    {
        ComboText.gameObject.SetActive(true);
        Invoke("HideComboText", 0.2f);
        ComboText.text = Combo.ToString();
    }

    public void HideComboText()
    {
        ComboText.gameObject.SetActive(false);
    }

    public void UpdateScore()
    {
        ScoreText.text = Score.ToString();
    }

    public void ScoreCalc()
    {
        Score += Point + (Combo / 10);
    }
}
