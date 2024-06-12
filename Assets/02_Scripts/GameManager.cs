using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // ���ӽ����̽�

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

        // ȿ����
        audioManager.PlaySFX(audioManager.coin);

        // �÷��̾� �ӵ� ����
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this; // ���� ���۽� ����
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

}
