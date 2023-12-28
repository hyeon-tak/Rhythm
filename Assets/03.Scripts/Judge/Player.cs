using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    private int Point;
    private int Combo;
    private int Score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ComboText;
    public GameObject Note;
    //public AudioSource audioSource;
    //public MusicData musicData;

    bool collisionDetected = false;

    private void Start()
    {
        ComboText.gameObject.SetActive(false);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collisionDetected == false)
            {
                Combo = 0;
                Debug.Log(Combo);
            }

            if (Note.transform.position.x <= -6.84f && Note.transform.position.x >= -7.14f)
            {
                ++Combo;
                Point = 120;
                Debug.Log(Point);
                Destroy(Note);
            }
            if ((Note.transform.position.x <= -7.37f && Note.transform.position.x >= -7.15f) && (Note.transform.position.x >= -6.84f && Note.transform.position.x >= -6.61f) )
            {
                ++Combo;
                Point = 100;
                Debug.Log(Point);
                Destroy(Note);
            }
            if ((Note.transform.position.x <= -6.44f && Note.transform.position.x >= -6.6f) && (Note.transform.position.x >= -7.55f && Note.transform.position.x >= -7.38f))
            {
                ++Combo;
                Point = 80;
                Debug.Log(Point);
                Destroy(Note);
            }
            ScoreCalc();
            UpdateScore();
            UpdateComboText();

        }
        Debug.Log(collisionDetected);
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
        if(Combo != 0 )
        {
            Score = (Combo % 10) * Point; 
        } 

        Debug.Log(Combo);
        Debug.Log(Score);
    }
}
