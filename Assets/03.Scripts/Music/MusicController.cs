using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;  // ���� ����� ���� AudioSource
    public AudioClip musicClip;      // ���� ����
    public bool PauseState = true;

    void Start()
    {
        // AudioSource�� ���� ���� �Ҵ�
        musicSource.clip = musicClip;
        //����
        musicSource.volume = 0.1f;    

        // ���� ��� ����
        musicSource.Play();
    }

    void Update()
    {
        // Ư�� ���ǿ� ���� ���� �Ͻ� ����
        if (PauseState == true)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();  // ������ �����Ǹ� �ٽ� ���
        }
    }

    private void ChangePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

                PauseState = !PauseState;

        }
    }
}

