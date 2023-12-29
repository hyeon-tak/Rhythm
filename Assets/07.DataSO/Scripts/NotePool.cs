using UnityEngine;
using System.Collections.Generic;

public class NotePool : MonoBehaviour
{
    public GameObject notePrefab;
    public int poolSize = 20;

    private List<GameObject> notePool;

    void Awake()
    {
        // 오브젝트 풀 초기화
        InitializePool();
    }

    void InitializePool()
    {
        notePool = new List<GameObject>();
        // 오브젝트 풀에 노트 미리 생성
        for (int i = 0; i < poolSize; i++)
        {
            GameObject note = Instantiate(notePrefab, transform);
            note.SetActive(false); // 초기에는 활성화하지 않음
            notePool.Add(note);
        }
    }


    //public void SpawnNote(Vector3 spawnPosition)
    //{
    //    // 비활성화된 노트 찾기
    //    GameObject note = GetInactiveNote();

    //    if (note != null)
    //    {
    //        // 노트 위치 설정
    //        note.transform.position = spawnPosition;
    //        // 노트 활성화
    //        note.SetActive(true);
    //    }
    //}


    // 비활성화된 노트 찾기
    public GameObject GetInactiveNote()
    {
        for (int i = 0; i < notePool.Count; i++)
        {
            if (!notePool[i].activeInHierarchy)
            {
                return notePool[i];
            }
        }

        // 모든 노트가 활성화되어 있을 경우 새로운 노트 생성
        GameObject note = Instantiate(notePrefab);
        note.SetActive(false);
        notePool.Add(note);

        return note;
    }
}
