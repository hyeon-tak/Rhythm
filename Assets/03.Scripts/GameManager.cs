using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject notePrefab; // 노트의 프리팹
    public float beatsPerMinute = 120.0f; // 음악의 BPM
    public float beatOffset = 0.2f; // 노트 생성을 위한 시간 오프셋
    public float beatInterval;

    public NotePool notePool;

    void Start()
    {
        InvokeRepeating("SpawnNote", 0.0f, beatInterval);
        beatInterval = 60.0f / beatsPerMinute;
    }

    void SpawnNote()
    {
        // 노트를 오브젝트 풀에서 가져오기
        GameObject note = notePool.GetNote();

        // 노트를 필요한 위치에 배치하고 활성화
        note.transform.position = new Vector3(10f, 0.0f, 0.0f);
        note.SetActive(true);
    }
}
