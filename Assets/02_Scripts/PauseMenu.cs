using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true); // pauseMenu ���� ������Ʈ�� true��
        Time.timeScale = 0; // �����ϸ� �ð��� 0����
    }

    public void Home()
    {
        SceneManager.LoadScene(0); // 0�� �� (���θ޴�)���� �̵�
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false); // pauseMenu ���� ������Ʈ�� false��
        Time.timeScale = 1; // �簳�ϸ� �ٽ� ����
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
