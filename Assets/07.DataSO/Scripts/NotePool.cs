using UnityEngine;
using System.Collections.Generic;

public class NotePool : MonoBehaviour
{
    public GameObject notePrefab;
    public int poolSize = 20;

    private List<GameObject> notePool;

    void Start()
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
            note.SetActive(false);
            notePool.Add(note);
        }
    }

    // 오브젝트 풀에서 노트를 가져오는 함수
    public GameObject GetNote()
    {
        // 비활성화된 노트 찾기
        for (int i = 0; i < notePool.Count; i++)
        {
            if (!notePool[i].activeInHierarchy)
            {
                return notePool[i];
            }
        }

        // 모든 노트가 활성화된 경우 새로운 노트 생성
        GameObject newNote = Instantiate(notePrefab, transform);
        notePool.Add(newNote);
        return newNote;
    }
}
