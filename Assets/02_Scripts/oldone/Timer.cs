using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime; // 경과한 시간
    
    void Update()
    {
        elapsedTime += Time.deltaTime; // 경과한 시간 더해주기

        int minutes = Mathf.FloorToInt(elapsedTime / 60); // '분' 나눠주기
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // '초' 나눠주기

        //timerText.text = elapsedTime.ToString(); // 타이머 텍스트 설정 (경과 시간을 String으로)
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // 타이머 텍스트 설정 (분과 초로)
    }
}
