using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;  // 음악 재생을 위한 AudioSource
    public AudioClip musicClip;      // 음악 파일

    void Start()
    {
        // AudioSource에 음악 파일 할당
        musicSource.clip = musicClip;

        // 추가적인 설정
        musicSource.volume = 0.1f;    // 볼륨 설정 (0.0 ~ 1.0)
        musicSource.loop = false;      // 루핑 여부 설정

        // 음악 재생 시작
        musicSource.Play();
    }
}

