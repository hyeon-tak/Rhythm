using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;  // 음악 재생을 위한 AudioSource
    public AudioClip musicClip;      // 음악 파일
    public bool PauseState = true;

    void Start()
    {
        // AudioSource에 음악 파일 할당
        musicSource.clip = musicClip;
        //볼륨
        musicSource.volume = 0.1f;    

        // 음악 재생 시작
        musicSource.Play();
    }

    void Update()
    {
        // 특정 조건에 따라 음악 일시 정지
        if (PauseState == true)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();  // 조건이 해제되면 다시 재생
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

