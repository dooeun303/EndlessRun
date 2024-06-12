using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime; // ����� �ð�
    
    void Update()
    {
        elapsedTime += Time.deltaTime; // ����� �ð� �����ֱ�

        int minutes = Mathf.FloorToInt(elapsedTime / 60); // '��' �����ֱ�
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // '��' �����ֱ�

        //timerText.text = elapsedTime.ToString(); // Ÿ�̸� �ؽ�Ʈ ���� (��� �ð��� String����)
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Ÿ�̸� �ؽ�Ʈ ���� (�а� �ʷ�)
    }
}
