using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager instance;

    public GameObject notePrefab; // 노트의 프리팹
    public float beatsPerMinute = 136.0f; // 음악의 BPM
    public float beatTolerance = 4f; // 노트 생성을 위한 시간 오프셋
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
        lastBeatTime = Time.time; // lastBeatTime 초기화
        InvokeRepeating("SpawnNote", 1f, beatInterval);
    }

    // 노트를 활성화하여 화면에 나타내는 메서드

    void SpawnNote()
    {
        // 노트를 오브젝트 풀에서 가져오기
        GameObject note = notePool.GetInactiveNote();

        if (note != null)
        {
            // 노트를 필요한 위치에 배치하고 활성화
            note.transform.position = new Vector3(10f, 0.0f, 0.0f);
            note.SetActive(true);
        }
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        // 오디오 데이터를 분석하여 특정 패턴 감지
        bool isPatternDetected = AnalyzeAudioPattern(data, channels);

        // 특정 패턴이 감지되면 노트 생성
        if (isPatternDetected)
        {
            SpawnNote();
        }
    }

    // 오디오 데이터를 분석하여 특정 패턴을 감지하는 메서드
    private bool AnalyzeAudioPattern(float[] data, int channels)
    {
        // 여기에서 오디오 데이터 분석 로직을 구현합니다.
        // 간단한 예시로, 특정 시간 동안의 오디오 에너지를 측정하여 패턴 감지

        // 패턴 감지를 위한 샘플 윈도우 크기 설정
        int sampleWindowSize = 3000;

        // 샘플 윈도우 내의 오디오 에너지 계산
        float energy = 0f;
        for (int i = 0; i < sampleWindowSize; i++)
        {
            // 각 채널에서의 데이터를 합산
            for (int channel = 0; channel < channels; channel++)
            {
                energy += data[i * channels + channel] * data[i * channels + channel];
            }
        }

        // 특정 에너지 임계값 이상이면 패턴 감지
        float energyThreshold = 0.1f;
        bool isPatternDetected = energy > energyThreshold;

        return isPatternDetected;
    }


}
