using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject notePrefab; // ��Ʈ�� ������
    public float beatsPerMinute = 120.0f; // ������ BPM
    public float beatOffset = 0.2f; // ��Ʈ ������ ���� �ð� ������
    public float beatInterval;

    public NotePool notePool;

    void Start()
    {
        InvokeRepeating("SpawnNote", 0.0f, beatInterval);
        beatInterval = 60.0f / beatsPerMinute;
    }

    void SpawnNote()
    {
        // ��Ʈ�� ������Ʈ Ǯ���� ��������
        GameObject note = notePool.GetNote();

        // ��Ʈ�� �ʿ��� ��ġ�� ��ġ�ϰ� Ȱ��ȭ
        note.transform.position = new Vector3(10f, 0.0f, 0.0f);
        note.SetActive(true);
    }
}
