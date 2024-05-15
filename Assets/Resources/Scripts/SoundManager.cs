using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("# BGM")]
    public AudioSource bgm;
    [SerializeField] private AudioClip[] clip;

    public GameObject[] bgmtitles;

    int n = 0;

    void Start()
    {
        // AudioSource를 스크립트에서 생성하여 할당합니다.
        bgm = gameObject.AddComponent<AudioSource>();

        for (int i = 1; i < bgmtitles.Length; i++)
        {
            bgmtitles[i].SetActive(false);
        }
    }

    public void Play()
    {
        bgm.clip = clip[n];
        bgm.Play();
    }

    public void PreviousMusic()
    {
        bgmtitles[n].SetActive(false);
        n--;
        if (n < 0)
        {
            n = clip.Length - 1;
        }
        bgm.Stop();
        bgmtitles[n].SetActive(true);
        Play();
    }

    public void NextMusic()
    {
        bgmtitles[n].SetActive(false);
        n++;
        if (n >= clip.Length)
        {
            n = 0; 
        }
        bgm.Stop();
        bgmtitles[n].SetActive(true);
        Play();
    }

    public void Stop()
    {
        bgm.Stop();
    }
}
