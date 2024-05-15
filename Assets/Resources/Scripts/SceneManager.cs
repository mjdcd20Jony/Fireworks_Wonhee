using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject[] particle;
    public GameObject firstPlayButton;
    public GameObject playButton;
    public GameObject pauseButton;

    public GameObject[] bgmTitle;

    public GameObject tipTitle;
    public GameObject[] tips;
    public int tipnum = 0;

    void Awake()
    {
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].SetActive(false);
        }

        firstPlayButton.SetActive(true);
        playButton.SetActive(false);
        pauseButton.SetActive(false);


        bgmTitle[0].SetActive(false);

        tipTitle.SetActive(false);
        tips[0].SetActive(false);

        // 코루틴을 Awake에서 시작합니다.
        StartCoroutine(RepeatedFunction());
    }

    public void FirstPlay()
    {
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].SetActive(true);
        }

        bgmTitle[0].SetActive(true);
        firstPlayButton.SetActive(false);
        pauseButton.SetActive(true);

        tipTitle.SetActive(true);
        tips[0].SetActive(true);
    }

    public void WhenPlayButtonOnClicked()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void WhenPauseButtonOnClicked()
    {
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    IEnumerator RepeatedFunction()
    {
        while (true) // 무한 반복
        {
            yield return new WaitForSeconds(7f); // 7초 대기
            RotationTips(); // 함수 호출
        }
    }

    public void RotationTips()
    {
        tips[tipnum].SetActive(false);
        int r = Random.Range(0, tips.Length);
        tipnum = r;
        tips[tipnum].SetActive(true);
    }
}
