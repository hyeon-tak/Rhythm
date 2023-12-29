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
    private float lastBeatTime;

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
        lastBeatTime = Time.time; // lastBeatTime �ʱ�ȭ
        InvokeRepeating("SpawnNote", 1f, beatInterval);
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

    private void OnAudioFilterRead(float[] data, int channels)
    {
        // ����� �����͸� �м��Ͽ� Ư�� ���� ����
        bool isPatternDetected = AnalyzeAudioPattern(data, channels);

        // Ư�� ������ �����Ǹ� ��Ʈ ����
        if (isPatternDetected)
        {
            SpawnNote();
        }
    }

    // ����� �����͸� �м��Ͽ� Ư�� ������ �����ϴ� �޼���
    private bool AnalyzeAudioPattern(float[] data, int channels)
    {
        // ���⿡�� ����� ������ �м� ������ �����մϴ�.
        // ������ ���÷�, Ư�� �ð� ������ ����� �������� �����Ͽ� ���� ����

        // ���� ������ ���� ���� ������ ũ�� ����
        int sampleWindowSize = 3000;

        // ���� ������ ���� ����� ������ ���
        float energy = 0f;
        for (int i = 0; i < sampleWindowSize; i++)
        {
            // �� ä�ο����� �����͸� �ջ�
            for (int channel = 0; channel < channels; channel++)
            {
                energy += data[i * channels + channel] * data[i * channels + channel];
            }
        }

        // Ư�� ������ �Ӱ谪 �̻��̸� ���� ����
        float energyThreshold = 0.1f;
        bool isPatternDetected = energy > energyThreshold;

        return isPatternDetected;
    }


}
