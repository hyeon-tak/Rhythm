using UnityEngine;
using System.Collections.Generic;

public class NotePool : MonoBehaviour
{
    public GameObject notePrefab;
    public int poolSize = 20;

    private List<GameObject> notePool;

    void Awake()
    {
        // ������Ʈ Ǯ �ʱ�ȭ
        InitializePool();
    }

    void InitializePool()
    {
        notePool = new List<GameObject>();
        // ������Ʈ Ǯ�� ��Ʈ �̸� ����
        for (int i = 0; i < poolSize; i++)
        {
            GameObject note = Instantiate(notePrefab, transform);
            note.SetActive(false); // �ʱ⿡�� Ȱ��ȭ���� ����
            notePool.Add(note);
        }
    }


    //public void SpawnNote(Vector3 spawnPosition)
    //{
    //    // ��Ȱ��ȭ�� ��Ʈ ã��
    //    GameObject note = GetInactiveNote();

    //    if (note != null)
    //    {
    //        // ��Ʈ ��ġ ����
    //        note.transform.position = spawnPosition;
    //        // ��Ʈ Ȱ��ȭ
    //        note.SetActive(true);
    //    }
    //}


    // ��Ȱ��ȭ�� ��Ʈ ã��
    public GameObject GetInactiveNote()
    {
        for (int i = 0; i < notePool.Count; i++)
        {
            if (!notePool[i].activeInHierarchy)
            {
                return notePool[i];
            }
        }

        // ��� ��Ʈ�� Ȱ��ȭ�Ǿ� ���� ��� ���ο� ��Ʈ ����
        GameObject note = Instantiate(notePrefab);
        note.SetActive(false);
        notePool.Add(note);

        return note;
    }
}
