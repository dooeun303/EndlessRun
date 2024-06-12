using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // ���ӽ����̽�

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;

    public TextMeshProUGUI scoreText;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
    }

    private void Awake()
    {
        inst = this; // ���� ���۽� ����
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
