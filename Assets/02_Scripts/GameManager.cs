using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 네임스페이스

public class GameManager : MonoBehaviour
{
    AudioManager audioManager;
    int score;
    public static GameManager inst;

    public TextMeshProUGUI scoreText;
    public PlayerMovement playerMovement;

    public void IncrementScore()
    {

        score++;
        scoreText.text = "SCORE: " + score;

        // 효과음
        audioManager.PlaySFX(audioManager.coin);

        // 플레이어 속도 증가
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this; // 게임 시작시 생성
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

}
