using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;

    public GameObject notePrefab; // 노트의 프리팹
    public float beatsPerMinute = 136.0f; // 음악의 BPM
    public float beatTolerance = 2f; // 노트 생성을 위한 시간 오프셋
    public float beatInterval;

    public NotePool notePool;

    public void Awake()
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
        beatInterval = 53.0f / beatsPerMinute;
        InvokeRepeating("SpawnNote", 0.45f, beatInterval);
    }

    public void RemoveNote()
    {
        notePrefab.SetActive(false);
    }

    // 노트를 활성화하여 화면에 나타내는 메서드

    void SpawnNote()
    {
        // 노트를 오브젝트 풀에서 가져오기
        GameObject note = notePool.GetInactiveNote();

        if (note != null)
        {
            // 노트를 필요한 위치에 배치하고 활성화
            note.transform.position = new Vector3(18.5f, 0.0f, 0.0f);
            note.SetActive(true);
        }
    }
}
