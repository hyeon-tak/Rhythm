using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager instance;

    public GameObject notePrefab; // ��Ʈ�� ������
    public float beatsPerMinute = 136.0f; // ������ BPM
    public float beatTolerance = 4f; // ��Ʈ ������ ���� �ð� ������
    public float beatInterval;

    public NotePool notePool;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        beatInterval = 60.0f / beatsPerMinute;
        InvokeRepeating("SpawnNote", 0.4f, beatInterval);
    }


    void Update()
    {
        float beatTime = Time.time % beatInterval;

        if (beatTime < beatTolerance)
        {
            OnBeat();
        }
    }


    private void OnBeat()
    {
        SpawnNote();
    }

    // ��Ʈ�� Ȱ��ȭ�Ͽ� ȭ�鿡 ��Ÿ���� �޼���

    void SpawnNote()
    {
        // ��Ʈ�� ������Ʈ Ǯ���� ��������
        GameObject note = notePool.GetInactiveNote();

        if (note != null)
        {
            // ��Ʈ�� �ʿ��� ��ġ�� ��ġ�ϰ� Ȱ��ȭ
            note.transform.position = new Vector3(10f, 0.0f, 0.0f);
            note.SetActive(true);
        }
    }


}
