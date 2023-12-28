using UnityEngine;
using System.Collections.Generic;

public class NotePool : MonoBehaviour
{
    public GameObject notePrefab;
    public int poolSize = 20;

    private List<GameObject> notePool;

    void Start()
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
            note.SetActive(false);
            notePool.Add(note);
        }
    }

    // ������Ʈ Ǯ���� ��Ʈ�� �������� �Լ�
    public GameObject GetNote()
    {
        // ��Ȱ��ȭ�� ��Ʈ ã��
        for (int i = 0; i < notePool.Count; i++)
        {
            if (!notePool[i].activeInHierarchy)
            {
                return notePool[i];
            }
        }

        // ��� ��Ʈ�� Ȱ��ȭ�� ��� ���ο� ��Ʈ ����
        GameObject newNote = Instantiate(notePrefab, transform);
        notePool.Add(newNote);
        return newNote;
    }
}
