using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;  // ���� ����� ���� AudioSource
    public AudioClip musicClip;      // ���� ����

    void Start()
    {
        // AudioSource�� ���� ���� �Ҵ�
        musicSource.clip = musicClip;

        // �߰����� ����
        musicSource.volume = 0.1f;    // ���� ���� (0.0 ~ 1.0)
        musicSource.loop = false;      // ���� ���� ����

        // ���� ��� ����
        musicSource.Play();
    }
}

